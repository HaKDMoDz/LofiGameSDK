using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using LofiEditor.Controls;
using LofiEditor.Forms;
using LofiEngine.Games;
using LofiEngine.Items;
using LofiEngine.Scenes;
using LofiEditor.SupportForms;
using LofiEngine.Helpers;
using LofiEngine.Graphics;
using LofiEngine.Screens;
using LofiEngine.Dramas;
using LofiEngine.Players;
using LofiEngine;
using LofiEngine.Groups;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LofiEngine.Inputs;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using LofiEditor.Editors;

namespace LofiEditor.Forms
{
    public partial class EditorForm : Form
    {
        #region Variables
        EditorManager EditorMgr;
		#endregion
		
		#region Properties
		// No GameManager here
		// Because we do not need whole game level execution
		// and want to access lower level of the engine
		
		// TODO A slim GameManager is a better choice? put it here or in the engine?
		
        public Item Item
        {
            get { return (Item)prg_itemProperty.SelectedObject; }
        }
        public String CurrentGroup = "";
        #endregion

        #region Constructor
        public EditorForm()
        {
            InitializeComponent();

            Microsoft.Xna.Framework.Input.Mouse.WindowHandle = editMainControl1.Handle;
            editMainControl1.OnSelectItem += EditMainControl_SelectItem;
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            EditorMgr = new EditorManager();
            ModuleSharer.GraphicsMgr = editMainControl1.GraphicsManager;
            ModuleSharer.GameMgr = (IGameManager)EditorMgr;
            ModuleSharer.SceneMgr = editMainControl1.SceneManager;
            initGameKeys();

            loadScenes();
        }

        private void initGameKeys()
        {   
            ModuleSharer.KeyMap = new KeyMap();
            ModuleSharer.KeyMap.AddGameKey(new GameKey("Up", Keys.Up));
            ModuleSharer.KeyMap.AddGameKey(new GameKey("Left", Keys.Left));
            ModuleSharer.KeyMap.AddGameKey(new GameKey("Right", Keys.Right));
            ModuleSharer.KeyMap.AddGameKey(new GameKey("Action", Keys.Space));
        }
        #endregion

        #region Common
        public void EditMainControl_SelectItem(object sender, List<Item> items)
        {
            if(items.Count != 0)
            {
                prg_itemProperty.SelectedObject = items[0];
            }
        }

        // Free all reference in editor
        public void FreeItem()
        {
            prg_itemProperty.SelectedObject = null;
            editMainControl1.SetSelectedItem(null);
        }
        #endregion

        #region Handle Menu
        #region File
        private void tmi_newProject_Click(object sender, EventArgs e)
        {
            // 
        }

        private void tmi_newScene_Click(object sender, EventArgs e)
        {
            CreateSceneForm csf = new CreateSceneForm();
            DialogResult dr = csf.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                loadScenes();
            }
        }

        private void tmi_saveScene_Click(object sender, EventArgs e)
        {
            ModuleSharer.SceneMgr.SaveScene();
        }
        #endregion

        #region View
        private void tmi_showAABB_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                editMainControl1.ShowAABB = true;
            }
            else
            {
                editMainControl1.ShowAABB = false;
            }
        }

        private void tmi_physicsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                EditorMgr.PhysicsEnabled = true;
            }
            else
            {
                EditorMgr.PhysicsEnabled = false;
            }
        }
        #endregion

        #region Tool
        private void tmi_animEditor_Click(object sender, EventArgs e)
        {
            if (Item == null)
            {
                MessageBox.Show("尚未选择任何物体");
            }
            else
            {
                AnimEditeForm aef = new AnimEditeForm();
                // aef.SetAnimTexture(Item.AnimTexture);
            }
        }

        private void ims_itemEditor_Click(object sender, EventArgs e)
        {
            ItemEditForm ief = new ItemEditForm();
            bool isNew = true;
            if (editMainControl1.SelectedItem != null)
            {
                isNew = false;
                ief.Item = editMainControl1.SelectedItem;
            }
            DialogResult dr = ief.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (isNew)
                {
                    ModuleSharer.SceneMgr.AddItem(null, ief.Item);
                }
            }
        }

        private void tsi_makeDecorate_Click(object sender, EventArgs e)
        {
            if (Item != null)
            {
                Item.PhysicsBody.Body.Active = false;
                Item.PhysicsBody.Body.IsStatic = true;
            }
        }

        private void tsi_makeStatic_Click(object sender, EventArgs e)
        {
            if (Item != null)
            {
                Item.PhysicsBody.Body.Active = true;
                Item.PhysicsBody.Body.IsStatic = true;
            }
        }

        private void tsi_makeActive_Click(object sender, EventArgs e)
        {
            if (Item != null)
            {
                Item.PhysicsBody.Body.Active = true;
                Item.PhysicsBody.Body.IsStatic = false;
            }
        }

        #endregion
        #endregion

        #region Handle Toolbar
        private void btn_deleteItem_Click(object sender, EventArgs e)
        {
            editMainControl1.SetAction(EditMainControl.EAction.Delete);
            foreach (Item item in editMainControl1.SelectedItems)
            {
                ModuleSharer.SceneMgr.DeleteItem(item);
            }
            FreeItem();
        }

        private void btn_selectItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            editMainControl1.SetAction(EditMainControl.EAction.Select);
        }

        private void btn_createItem_Click_1(object sender, EventArgs e)
        {
            editMainControl1.SetAction(EditMainControl.EAction.Create);


            Cursor.Current = Cursors.Cross;
        }

        private void btn_transformItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.SizeAll;
            editMainControl1.SetAction(EditMainControl.EAction.Transform);
        }

        private void btn_getTexture_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
            editMainControl1.SetAction(EditMainControl.EAction.GetTexture);
        }

        private void btn_copyItem_Click_1(object sender, EventArgs e)
        {
            editMainControl1.SetAction(EditMainControl.EAction.Copy);
            if (Item != null)
                editMainControl1.SceneManager.AddItem(Item.Group, Item.Clone());
        }

        private void btn_freeCamera_Click(object sender, EventArgs e)
        {
            editMainControl1.SetAction(EditMainControl.EAction.FreeCamera);
        }

        private void btn_editAnim_Click(object sender, EventArgs e)
        {
            AnimEditeForm aef = new AnimEditeForm();
            aef.ShowDialog();

        }

        private void btn_layerBottom_Click(object sender, EventArgs e)
        {
            editMainControl1.LayerBottom();
        }

        private void btn_layerDown_Click(object sender, EventArgs e)
        {
            editMainControl1.LayerDown();
        }

        private void btn_layerUp_Click(object sender, EventArgs e)
        {
            editMainControl1.LayerUp();
        }

        private void btn_layerTop_Click(object sender, EventArgs e)
        {
            editMainControl1.LayerTop();
        }

        private void ptb_curTexture_Click(object sender, EventArgs e)
        {
            PickTextureForm ptf = new PickTextureForm();
            DialogResult dr = ptf.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ((TextureBox)sender).TexturePath = ptf.TexturePath;
                editMainControl1.SetPenTexture(ptf.TexturePath);
            }
        }
        #endregion

        #region Handle EditMainControl
        private void editMainControl1_Click(object sender, MouseEventArgs e)
        {
            if (editMainControl1.Action == EditMainControl.EAction.GetTexture)
            {
                editMainControl1.GetTextureOnPoint(e.Location);
            }
        }

        private void trb_zoom_ValueChanged(object sender, EventArgs e)
        {
            // Map 0 to 1/8; 50 to 1; 100 to 3
            ModuleSharer.SceneMgr.Camera.Zoom = trb_zoom.Value / 1000f;
        }
        #endregion

        #region Handle Panel
        #region Project
        private void btn_deleteScene_Click(object sender, EventArgs e)
        {
            ModuleSharer.SceneMgr.DeleteScene();
        }

        private void btn_editScene_Click(object sender, EventArgs e)
        {
            if (trv_scenes.SelectedNode != null)
            {
                editMainControl1.SelectItem(null);
                editMainControl1.SelectedGroup = "";
                String path = trv_scenes.SelectedNode.FullPath;
                ModuleSharer.SceneMgr.LoadScene(path);
                tb_sceneName.Text = ModuleSharer.SceneMgr.SceneName;
            }
        }

        private void loadScenes()
        {
            trv_scenes.Nodes.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement fElement = xmlDoc.CreateElement("Path");
            fElement.SetAttribute("Info", Path.Combine(Directory.GetCurrentDirectory(), LoadHelper.ScenePath));
            xmlDoc.AppendChild(fElement);
            XmlElement docElement = (XmlElement)xmlDoc.FirstChild;
            FileHelper.FileTree2Xml(xmlDoc, ref docElement);

            TreeNode treeNode = xml2TNodes(docElement);
            trv_scenes.BeginUpdate();
            foreach (TreeNode node in treeNode.Nodes)
            {
                trv_scenes.Nodes.Add(node);
            }
            trv_scenes.EndUpdate();
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
        #endregion

        #region Item Group
        #region Node Type Check
        private bool isGroupNode(TreeNode node)
        {
            if (node.Parent == null)
                return true;
            else
                return false;
        }

        private bool isItemNode(TreeNode node)
        {
            return !isGroupNode(node);
        }
        #endregion

        private TreeNode selectedItemNode;
        private void trv_itemCollection_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedItemNode = e.Node;
            if (isGroupNode(selectedItemNode))
            {
                CurrentGroup = selectedItemNode.Text;
            }
            else
            {
                editMainControl1.SetAction(EditMainControl.EAction.Transform);
                editMainControl1.SelectItem(ModuleSharer.SceneMgr.GetItemByName(e.Node.Text));
            }
        }

        private void btn_deleteGroup_Click(object sender, EventArgs e)
        {
            // Check selection
            if (selectedItemNode == null)
            {
                MessageBox.Show("Please select a group node");
                return;
            }

            // Check current Item in this group
            ItemGroup itemMgr = ModuleSharer.SceneMgr.GetGroupByName(selectedItemNode.Text);
            if (itemMgr.Items.IndexOf(Item) >= 0)
            {
                FreeItem();
            }

            ModuleSharer.SceneMgr.DeleteGroup(selectedItemNode.Text);
            selectedItemNode.Remove();
        }

        private void btn_loadItems_Click(object sender, EventArgs e)
        {
            updateItemCollection();
        }

        private void updateItemCollection()
        {
            trv_itemCollection.BeginUpdate();
            trv_itemCollection.Nodes.Clear();
            for (int i = 0; i < ModuleSharer.SceneMgr.ItemGroups.Count; i++)
            {
                TreeNode tn = new TreeNode(ModuleSharer.SceneMgr.ItemGroups[i].Name);
                foreach (Item item in ModuleSharer.SceneMgr.ItemGroups[i].Items)
                {
                    tn.Nodes.Add(item.Name);
                }
                trv_itemCollection.Nodes.Add(tn);
            }
            trv_itemCollection.EndUpdate();
        }

        private void btn_addGroup_Click(object sender, EventArgs e)
        {
            bool occupied = true;
            NameHelper.RestartNameInc(0);
            String groupName = "";
            while (occupied)
            {
                groupName = NameHelper.GetNextName("Group");
                if (!ModuleSharer.SceneMgr.GroupNameTaken(groupName))
                    occupied = false;
            }

            ItemGroup itemGrp = new ItemGroup();
            itemGrp.Name = groupName;
            ModuleSharer.SceneMgr.ItemGroups.Add(itemGrp);
            updateItemCollection();
        }

        bool itemCollDragging = false;
        TreeNode itemCollDragNode = null;

        private void trv_itemCollection_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode n = (TreeNode)e.Item;
            //if (n.Parent != null)
            {
                itemCollDragging = true;
                DoDragDrop(n, DragDropEffects.Move);
                itemCollDragNode = n;
            }
        }

        private void trv_itemCollection_DragEnter(object sender, DragEventArgs e)
        {
            if (!itemCollDragging) return;
            //if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode n = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
                if (n.Parent == null)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void trv_itemCollection_DragDrop(object sender, DragEventArgs e)
        {
            if (!itemCollDragging) return;
            itemCollDragging = false;
            System.Drawing.Point p = new System.Drawing.Point(e.X, e.Y);
            p = trv_itemCollection.PointToClient(p);
            TreeNode dropNode = trv_itemCollection.GetNodeAt(p);
            //if (dropNode.Parent == null)
            {
                TreeNode n = itemCollDragNode;
                itemCollDragNode.Remove();
                dropNode.Nodes.Add(n);
            }
        }

        private void trv_itemCollection_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Is an Item node
            if (e.Node.Parent != null)
            {
                Item i = ModuleSharer.SceneMgr.GetItemByName(e.Node.Text);
                editMainControl1.SelectItem(i);
            }
        }

        private void btn_groupUp_Click(object sender, EventArgs e)
        {
            int selId = selectedItemNode.Index;
            ModuleSharer.SceneMgr.MoveGroup(selId, -1);
        }

        private void btn_groupDown_Click(object sender, EventArgs e)
        {
            int selId = selectedItemNode.Index;
            ModuleSharer.SceneMgr.MoveGroup(selId, 1);
        }
        #endregion

        #region Test
        private void btn_respawnRole_Click(object sender, EventArgs e)
        {
            ItemGroup roleGrp = ModuleSharer.SceneMgr.GetGroupByName("RoleGroup");
            if(roleGrp == null)
            {
                roleGrp = new ItemGroup();
                roleGrp.Name = "RoleGroup";
                ModuleSharer.SceneMgr.ItemGroups.Add(roleGrp);
            }
            roleGrp.Items.Clear();

            Role role = new Role();
            role.Name = "Role";
            AnimTexture animTex = new AnimTexture("Roles/MarioRole");
            animTex.SourceRect = new Rectangle(0, 0, 28, 48);
            animTex.AnimSeqList.Add(new AnimSequence("Run", 0, 8, 10, false, true));
            animTex.PlaySeq("Run");
            role.AnimTexture = animTex;
            role.PhysicsBody = new PhysicsBody(role.AnimTexture.TextureSize);
            role.Active = true;
            role.IsStatic = false;
            role.Position = ModuleSharer.SceneMgr.Camera.Focus;
            roleGrp.Add(role);
            // SceneMgr.Instance.RespawnRole(new Vector2(GameMgr.GameWidth / 2, GameMgr.GameHeight / 2));
        }

        private void btn_respawnAskia_Click(object sender, EventArgs e)
        {
            // SceneMgr.Instance.RespawnAskia(new Vector2(GameMgr.GameWidth / 2, GameMgr.GameHeight / 2));
        }
        #endregion

        private void cbb_zoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            float zoom = float.Parse(cbb_zoom.SelectedItem.ToString());
            ModuleSharer.SceneMgr.Camera.Zoom = zoom;
        }


        #endregion

        private void tsi_cornerCoordinate_CheckedChanged(object sender, EventArgs e)
        {
            editMainControl1.ShowCornerCoordinate = tsi_cornerCoordinate.Checked;
        }

        private void tsi_focusItem_Click(object sender, EventArgs e)
        {
            if (Item != null)
            {
                ModuleSharer.SceneMgr.Camera.Focus = Item.Position;
            }
        }

        private void tsi_focusZero_Click(object sender, EventArgs e)
        {
            ModuleSharer.SceneMgr.Camera.Focus = Vector2.Zero;
        }

        private void btn_clearScene_Click(object sender, EventArgs e)
        {
            FreeItem();
            ModuleSharer.SceneMgr.ResetScene();
        }

        private void tsi_controlConfig_Click(object sender, EventArgs e)
        {
            ConfigControlForm ccForm = new ConfigControlForm(ModuleSharer.KeyMap);
            ccForm.ShowDialog();
        }

    }
}
