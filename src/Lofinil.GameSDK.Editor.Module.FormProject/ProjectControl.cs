using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Lofinil.GameSDK.Editor;
using Lofinil.GameSDK.Editor.Interception;
using Lofinil.GameSDK.Editor.Interception.ModuleInterface;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor.Module.FormProject;

namespace Lofinil.GameSDK.Editor.Module.Project
{
    public partial class ProjectControl : UserControl, IProjectView
    {
        public ProjectControl()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            EditorService.Instance.QueryModule<ProjectModule>().ProjectLoaded += onProjectLoaded;

            if (EditorService.Instance.QueryModule<ProjectModule>().CurProject == null)
            {
                pnlTreeHolder.Controls.Clear();
                Label label = new Label();
                label.Text = "需要打开项目";
                label.Left = 5;
                label.Top = 8;
                pnlTreeHolder.Controls.Add(label);
            }

            trv_items.ExpandAll();
        }

        private void btn_newScene_Click(object sender, EventArgs e)
        {
            // String fileName = id + EditorStatics.StageExt;

            EditorService.Instance.QueryModule<ProjectModule>(null).NewStage("");
        }

        private void btn_deleteScene_Click(object sender, EventArgs e)
        {
            GameService.Instance.QueryModule<StageModule>().DeleteScene();
        }

        private void btn_editScene_Click(object sender, EventArgs e)
        {
            if (trv_items.SelectedNode != null)
            {
                EditorService.Instance.QueryModule<IStageModule>().SelectItem(SelectMode.Clear, null);
                String path = trv_items.SelectedNode.FullPath;
                GameService.Instance.QueryModule<StageModule>().ReadStage(path);
            }
        }

        public void OnItemChanged()
        {
            loadStages();
        }

        private void onProjectLoaded()
        {
            ProjectModule projMod = EditorService.Instance.QueryModule<ProjectModule>();
            if (projMod.CurProject != null)
            {
                pnlTreeHolder.Controls.Clear();
                pnlTreeHolder.Controls.Add(trv_items);
                BuildTree(projMod.CurProject);
                trv_items.ExpandAll();
            }
        }

        public void BuildTree(ProjectData data)
        {
            trv_items.Nodes.Clear();
            TreeNode projNode = new TreeNode(data.GameName);
            projNode.ImageKey = "Project";
            projNode.SelectedImageKey = "Project";
            FormProjectItemProject tag = new FormProjectItemProject();
            tag.Data = data;
            projNode.Tag = tag;
            trv_items.Nodes.Add(projNode);

            foreach (ProjectItem item in data.ItemList)
            {
                buildProjectNode(projNode, item);
            }
            // HACK
            trv_items.ExpandAll();
        }

        private void buildProjectNode(TreeNode parent, ProjectItem data)
        {
            if (data is ProjectItemFolder)
            {
                TreeNode folderNode = new TreeNode(data.FileName);
                folderNode.ImageKey = "Folder";
                folderNode.SelectedImageKey = "Folder";
                FormProjectItemFolder tag = new FormProjectItemFolder();
                tag.Data = data;
                folderNode.Tag = tag;
                parent.Nodes.Add(folderNode);
            }
            else
            {
                String path = data.FileName;
                FileInfo fInfo = new FileInfo(path);
                String ext = fInfo.Extension;
                if (ext == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".tga" || ext == ".dds")
                {
                    TreeNode imageNode = new TreeNode(fInfo.Name);
                    imageNode.ImageKey = "Image";
                    imageNode.SelectedImageKey = "Image";
                    FormProjectItem tag = new FormProjectItem();
                    tag.Data = data;
                    imageNode.Tag = tag;
                    parent.Nodes.Add(imageNode);
                }
                else if (ext == EditorStatics.StageExt)
                {
                    TreeNode stageNode = new TreeNode(fInfo.Name);
                    stageNode.ImageKey = "Stage";
                    stageNode.SelectedImageKey = "Stage";
                    FormProjectItem tag = new FormProjectItem();
                    tag.Data = data;
                    stageNode.Tag = tag;
                    parent.Nodes.Add(stageNode);
                }
            }
        }

        private void loadStages()
        {                                                                              
            trv_items.Nodes.Clear();

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement fElement = xmlDoc.CreateElement("Path");
            fElement.SetAttribute("Path", Path.Combine(EditorService.Instance.QueryModule<ProjectModule>(null).CurProjDir));
            xmlDoc.AppendChild(fElement);
            XmlElement docElement = (XmlElement)xmlDoc.FirstChild;
            projTreeToXml(xmlDoc, ref docElement);

            TreeNode treeNode = xml2TNodes(docElement);
            trv_items.BeginUpdate();
            foreach (TreeNode node in treeNode.Nodes)
            {
                trv_items.Nodes.Add(node);
            }
            trv_items.EndUpdate();
        }

        private void projTreeToXml(XmlDocument xmlDoc, ref XmlElement xmlEle)
        {
            String[] subDirs = Directory.GetDirectories(xmlEle.GetAttribute("Path"));
            foreach (String sd in subDirs)
            {
                XmlElement newElement = xmlDoc.CreateElement("Node");
                newElement.SetAttribute("Type", "Folder");
                newElement.SetAttribute("Path", sd);
                projTreeToXml(xmlDoc, ref newElement);
                xmlEle.AppendChild(newElement);
            }

            String[] files = Directory.GetFiles(xmlEle.GetAttribute("Path"));
            foreach (String file in files)
            {
                XmlElement fileElement = xmlDoc.CreateElement("Node");
                FileInfo fInfo = new FileInfo(file);
                if (fInfo.Extension == ".lfstage")
                    fileElement.SetAttribute("Type", "Stage");
                else if (fInfo.Extension == ".lfrs")
                    fileElement.SetAttribute("Type", "ResourceSet");
                else if (fInfo.Extension == ".lfts")
                    fileElement.SetAttribute("Type", "TriggerSet");
                
                fileElement.SetAttribute("Path", file);
                xmlEle.AppendChild(fileElement);
            }
        }

        private TreeNode xml2TNodes(XmlElement xmlElement)
        {
            String type = xmlElement.GetAttribute("Type");
            String path = xmlElement.GetAttribute("Path");
            int typeId = -1;
            if (type == "Folder")
                typeId = 0;
            else if (type == "Stage")
                typeId = 2;
            else if (type == "TriggerSet")
                typeId = 3;
            else if (type == "ResourceSet")
                typeId = 4;

            TreeNode node = new TreeNode(Path.GetFileNameWithoutExtension(path), typeId, typeId);
            node.Tag = path;
            TreeNode result = node;
            foreach (XmlElement element in xmlElement.ChildNodes)
            {
                if (element.HasChildNodes)
                    result.Nodes.Add(xml2TNodes(element));
                else
                {
                    String childPath = element.GetAttribute("Path");
                    String childType = element.GetAttribute("Type");
                    int childTypeId = -1;
                    if (childType == "Folder")
                        childTypeId = 0;
                    else if (childType == "Stage")
                        childTypeId = 2;
                    else if (childType == "TriggerSet")
                        childTypeId = 3;
                    else if (childType == "ResourceSet")
                        childTypeId = 4;

                    TreeNode childNode = new TreeNode(Path.GetFileNameWithoutExtension(childPath), childTypeId, childTypeId);
                    childNode.Tag = childPath;

                    result.Nodes.Add(childNode);
                }
            }
            return result;
        }

        private void trv_items_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String path = e.Node.Tag.ToString();
            FileInfo info = new FileInfo(path);
            if (info.Extension == ".lfstage")
                // Open Stage
                EditorService.Instance.QueryModule<IStageModule>().ReadStage(path);
            else if (info.Extension == ".lfrs")
            {
                int id = EditorService.Instance.QueryModule<IResourceSetModule>().Read(path);
                EditorService.Instance.QueryModule<IResourceSetModule>().Active(id);
            }
        }

        private void trv_items_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TreeNode node = trv_items.HitTest(e.Location).Node;
                if (node != null)
                {
                    FormProjectItem item = node.Tag as FormProjectItem;
                    if (item != null)
                    {
                        item.BuildUpContextMenu();
                    }
                }
            }
        }

        private void trv_items_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                TreeNode node = trv_items.HitTest(e.Location).Node;
                if (node != null)
                {
                    FormProjectItem item = node.Tag as FormProjectItem;
                    if (item != null)
                    {
                        item.OnDoubleClicked();
                    }
                }
            }
        }
    }
}
