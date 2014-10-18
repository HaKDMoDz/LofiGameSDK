using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.Module.Menu;
using Lofinil.GameSDK.Editor.Module.Project;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Lofinil.GameSDK.Editor.Module.View;
using Lofinil.GameSDK.Editor.Module.FormView;
using Lofinil.GameSDK.Editor.Module.PropertyEditor;
using MenuItem = Lofinil.GameSDK.Editor.Module.Menu.MenuItem;
using Lofinil.GameSDK.Engine;

namespace Lofinil.GameSDK.Editor.Module.FormProject
{
    public class FormProjectItemProject : FormProjectItem
    {
        public override void BuildUpContextMenu()
        {
            base.BuildUpContextMenu();

            FormProjectModule formProjMod =
                EditorService.Instance.QueryModule<FormProjectModule>();

            List<Menu.MenuItem> menuItems = new List<Menu.MenuItem>();
            Menu.MenuItem ci = new Menu.MenuItem();
            ci.Name = "生成";
            ci.Command = build;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "重新生成";
            ci.Command = null;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "清理";
            ci.Command = null;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "添加现有项";
            ci.Command = addExistedItem;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "添加新场景";
            ci.Command = addNewStage;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "运行";
            ci.Command = null;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "在资源管理器中打开";
            ci.Command = openInShell;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "属性";
            ci.Command = viewProperty;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "新建文件夹";
            ci.Index = 0;
            ci.Command = createFolder;
            menuItems.Add(ci);

            formProjMod.MenuBuilder.SetMenu(menuItems.ToArray());
        }

        public override void OnDoubleClicked()
        {
            EditorService.Instance.QueryModule<FormProjectModule>().menuCommand_ProjConf();
        }

        private void build()
        {
            // HACK 只处理与项目同级资源
            
        }

        private void addNewStage()
        {
            String basePath = EditorService.Instance.QueryModule<ProjectModule>().CurProjDir;
            String newName = "Stage";
            int id = 0;
            while (true)
            {
                String testPath = Path.Combine(basePath, newName + id + EditorStatics.StageExt);
                if (File.Exists(testPath))
                {
                    id++;
                }
                else
                {
                    Engine.Stage newStage = new Engine.Stage();
                    newStage.Name = newName + id;
                    StageModule.WriteStage(testPath, newStage);
                    ProjectItem item = new ProjectItem();
                    item.FileName = PathHelper.MakeRelative(testPath, basePath);
                    EditorService.Instance.QueryModule<ProjectModule>().CurProject.ItemList.Add(item);
                    EditorService.Instance.QueryModule<FormProjectModule>().RefreshProjectTree();
                    break;
                }
            }
            FormProjectModule formProjMod = EditorService.Instance.QueryModule<FormProjectModule>();
            formProjMod.RefreshProjectTree();
        }

        private void addExistedItem()
        {
            FileDialog dlg = new OpenFileDialog();
            dlg.Title = "添加现有项";
            DialogResult dr = dlg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // 项目已添加 忽略
                String fileName = dlg.FileName;
                String projPath = EditorService.Instance.QueryModule<ProjectModule>().CurProjDir;
                if (fileName.StartsWith(projPath))
                {
                    String relaPath = PathHelper.MakeRelative(fileName, projPath);
                    bool existed = EditorService.Instance.QueryModule<ProjectModule>().IsItemIncluded(relaPath);
                    if (existed)
                        return;
                }
                String targetPath = projPath;
                String targetFile = PathHelper.Copy(fileName, targetPath);
                ProjectItem newItem = null;
                FileInfo fInfo = new FileInfo(targetFile);
                if(fInfo.Extension == ".bmp" || fInfo.Extension == ".jpg" 
                    || fInfo.Extension == ".png" || fInfo.Extension == ".tga" ||fInfo.Extension == ".dds")
                {
                    newItem = new ProjectItem();
                }
                String itemPath = PathHelper.MakeRelative(targetFile, projPath);
                newItem.FileName = itemPath;
                EditorService.Instance.QueryModule<ProjectModule>().CurProject.ItemList.Add(newItem);
                EditorService.Instance.QueryModule<FormProjectModule>().RefreshProjectTree();
            }
        }

        private void createFolder()
        {
            String basePath = EditorService.Instance.QueryModule<ProjectModule>().CurProjDir;
            String newName = "新文件夹";
            int id = 0;
            while (true)
            {
                String testPath = Path.Combine(basePath, newName + id);
                if (Directory.Exists(testPath))
                {
                    id++;
                }
                else
                {
                    Directory.CreateDirectory(testPath);
                    ProjectData data = EditorService.Instance.QueryModule<ProjectModule>().CurProject;
                    ProjectItemFolder newFolderItem = new ProjectItemFolder();
                    newFolderItem.FileName = newName+id;
                    data.ItemList.Add(newFolderItem);
                    break;
                }
            }
            FormProjectModule formProjMod = EditorService.Instance.QueryModule<FormProjectModule>();
            formProjMod.RefreshProjectTree();
        }

        private void openInShell()
        {
            String projPath = EditorService.Instance.QueryModule<ProjectModule>().CurProjDir;
            Process.Start("explorer", projPath);
        }

        private void viewProperty()
        {
            EditorService.Instance.QueryModule<FormViewModule>().ShowRegion("PropertyTab");
            EditorService.Instance.QueryModule<PropertyEditorModule>().SetTarget(Data);
        }
    }
}
