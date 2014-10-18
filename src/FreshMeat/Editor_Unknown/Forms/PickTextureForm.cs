using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using LofiEngine.Helpers;

namespace LofiEditor.SupportForms
{
    public partial class PickTextureForm : Form
    {
        #region Variables
        public String TexturePath;
        #endregion

        #region Constructor
        public PickTextureForm()
        {
            InitializeComponent();

            // Load Texture Files
            loadTextureTree(Path.Combine(Application.StartupPath, "Content/Textures"));
        }
        #endregion

        private void loadTextureTree(String path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement fElement = xmlDoc.CreateElement("Path");
            fElement.SetAttribute("Info", path);
            xmlDoc.AppendChild(fElement);
            XmlElement docElement = (XmlElement)xmlDoc.FirstChild;
            FileHelper.FileTree2Xml(xmlDoc, ref docElement);

            TreeNode treeNode = xml2TNodes(docElement);
            trv_textures.BeginUpdate();
            foreach(TreeNode node in treeNode.Nodes)
            {
                trv_textures.Nodes.Add(node);
            }
            trv_textures.EndUpdate();
        }

        private TreeNode xml2TNodes(XmlElement xmlElement)
        {

            TreeNode result = new TreeNode(Path.GetFileNameWithoutExtension(xmlElement.GetAttribute("Info")));
            foreach (XmlElement element in xmlElement.ChildNodes)
            {
                if (element.HasChildNodes)
                    result.Nodes.Add(xml2TNodes(element));
                else
                    result.Nodes.Add(new TreeNode(Path.GetFileNameWithoutExtension(element.GetAttribute("Info"))));
            }
            return result;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void PickTextureForm_Load(object sender, EventArgs e)
        {

        }

        private void trv_textures_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Leaf Node
            if(e.Node.Nodes.Count == 0)
            {
                TreeNode n = e.Node;
                String path = n.FullPath;
                // Check File Again
                if (File.Exists(Path.Combine(Application.StartupPath, "Content/Textures", path + ".xnb")))
                {
                    ttb_textureShow.TexturePath = path;
                    TexturePath = path;
                    lbl_width.Text = ttb_textureShow.Texture.Width.ToString();
                    lbl_height.Text = ttb_textureShow.Texture.Height.ToString();
                }
            }
        }

        private void rdb_normal_CheckedChanged(object sender, EventArgs e)
        {
            ttb_textureShow.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void rdb_zoom_Click(object sender, EventArgs e)
        {
            ttb_textureShow.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void rdb_stretch_Click(object sender, EventArgs e)
        {
            ttb_textureShow.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
