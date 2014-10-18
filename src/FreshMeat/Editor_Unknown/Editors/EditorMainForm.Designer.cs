using LofiEngine;
using LofiEditor.Controls;
namespace LofiEditor.Forms
{
    partial class EditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbp_project = new System.Windows.Forms.TabPage();
            this.btn_clearScene = new System.Windows.Forms.Button();
            this.btn_saveScene = new System.Windows.Forms.Button();
            this.btn_editScene = new System.Windows.Forms.Button();
            this.btn_deleteScene = new System.Windows.Forms.Button();
            this.btn_newScene = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trv_scenes = new System.Windows.Forms.TreeView();
            this.tb_sceneName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbp_item = new System.Windows.Forms.TabPage();
            this.btn_loadItems = new System.Windows.Forms.Button();
            this.btn_removeFx = new System.Windows.Forms.Button();
            this.btn_addFx = new System.Windows.Forms.Button();
            this.btn_deleteGroup = new System.Windows.Forms.Button();
            this.btn_groupDown = new System.Windows.Forms.Button();
            this.btn_groupUp = new System.Windows.Forms.Button();
            this.btn_addGroup = new System.Windows.Forms.Button();
            this.trv_itemCollection = new System.Windows.Forms.TreeView();
            this.tbp_library = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tbp_property = new System.Windows.Forms.TabPage();
            this.prg_itemProperty = new System.Windows.Forms.PropertyGrid();
            this.tbp_test = new System.Windows.Forms.TabPage();
            this.btn_respawnAskia = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_respawnRole = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbb_itemType = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_new = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_newProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_newScene = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_newDrama = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_newTemplete = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_open = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_close = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_saveScene = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_quit = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenePropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_showAABB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_physicsEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_filterAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_filterBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_filterTerrain = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_filterObstacle = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_filterProch = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_filterGravity = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_filterTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_filterCase = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_filterSupply = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_filterForeground = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsi_cornerCoordinate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tsi_focusItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsi_focusZero = new System.Windows.Forms.ToolStripMenuItem();
            this.项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_config = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_release = new System.Windows.Forms.ToolStripMenuItem();
            this.独立运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_animEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.ims_itemEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.renderMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsi_makeDecorate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsi_makeStatic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsi_makeActive = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tsi_configControl = new System.Windows.Forms.ToolStripMenuItem();
            this.资源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_texture = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_audio = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_help = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_tutorial = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_feedback = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_about = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_deleteItem = new System.Windows.Forms.Button();
            this.btn_transformItem = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_createItem = new System.Windows.Forms.Button();
            this.btn_selectItem = new System.Windows.Forms.Button();
            this.btn_getTexture = new System.Windows.Forms.Button();
            this.btn_copyItem = new System.Windows.Forms.Button();
            this.btn_alignVerticalMiddle = new System.Windows.Forms.Button();
            this.btn_alignHorizonalMiddle = new System.Windows.Forms.Button();
            this.btn_alignHorizonalBottom = new System.Windows.Forms.Button();
            this.btn_alignHorizonalTop = new System.Windows.Forms.Button();
            this.btn_alignVerticalRight = new System.Windows.Forms.Button();
            this.btn_alignVerticalLeft = new System.Windows.Forms.Button();
            this.btn_layerUp = new System.Windows.Forms.Button();
            this.btn_layerTop = new System.Windows.Forms.Button();
            this.btn_layerBottom = new System.Windows.Forms.Button();
            this.btn_layerDown = new System.Windows.Forms.Button();
            this.trb_zoom = new System.Windows.Forms.TrackBar();
            this.btn_freeCamera = new System.Windows.Forms.Button();
            this.btn_editAnim = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.cbb_zoom = new System.Windows.Forms.ComboBox();
            this.ttb_texturePicker = new LofiEditor.Controls.TextureBox();
            this.editMainControl1 = new LofiEditor.Controls.EditMainControl();
            this.tbp_dramas = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbp_project.SuspendLayout();
            this.tbp_item.SuspendLayout();
            this.tbp_library.SuspendLayout();
            this.tbp_property.SuspendLayout();
            this.tbp_test.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_zoom)).BeginInit();
            this.tbp_dramas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbp_project);
            this.tabControl1.Controls.Add(this.tbp_item);
            this.tabControl1.Controls.Add(this.tbp_dramas);
            this.tabControl1.Controls.Add(this.tbp_library);
            this.tabControl1.Controls.Add(this.tbp_property);
            this.tabControl1.Controls.Add(this.tbp_test);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tbp_project
            // 
            this.tbp_project.Controls.Add(this.btn_clearScene);
            this.tbp_project.Controls.Add(this.btn_saveScene);
            this.tbp_project.Controls.Add(this.btn_editScene);
            this.tbp_project.Controls.Add(this.btn_deleteScene);
            this.tbp_project.Controls.Add(this.btn_newScene);
            this.tbp_project.Controls.Add(this.label2);
            this.tbp_project.Controls.Add(this.trv_scenes);
            this.tbp_project.Controls.Add(this.tb_sceneName);
            this.tbp_project.Controls.Add(this.label10);
            resources.ApplyResources(this.tbp_project, "tbp_project");
            this.tbp_project.Name = "tbp_project";
            this.tbp_project.UseVisualStyleBackColor = true;
            // 
            // btn_clearScene
            // 
            resources.ApplyResources(this.btn_clearScene, "btn_clearScene");
            this.btn_clearScene.Name = "btn_clearScene";
            this.btn_clearScene.UseVisualStyleBackColor = true;
            this.btn_clearScene.Click += new System.EventHandler(this.btn_clearScene_Click);
            // 
            // btn_saveScene
            // 
            resources.ApplyResources(this.btn_saveScene, "btn_saveScene");
            this.btn_saveScene.Name = "btn_saveScene";
            this.btn_saveScene.UseVisualStyleBackColor = true;
            this.btn_saveScene.Click += new System.EventHandler(this.tmi_saveScene_Click);
            // 
            // btn_editScene
            // 
            resources.ApplyResources(this.btn_editScene, "btn_editScene");
            this.btn_editScene.Name = "btn_editScene";
            this.btn_editScene.UseVisualStyleBackColor = true;
            this.btn_editScene.Click += new System.EventHandler(this.btn_editScene_Click);
            // 
            // btn_deleteScene
            // 
            resources.ApplyResources(this.btn_deleteScene, "btn_deleteScene");
            this.btn_deleteScene.Name = "btn_deleteScene";
            this.btn_deleteScene.UseVisualStyleBackColor = true;
            this.btn_deleteScene.Click += new System.EventHandler(this.btn_deleteScene_Click);
            // 
            // btn_newScene
            // 
            resources.ApplyResources(this.btn_newScene, "btn_newScene");
            this.btn_newScene.Name = "btn_newScene";
            this.btn_newScene.UseVisualStyleBackColor = true;
            this.btn_newScene.Click += new System.EventHandler(this.tmi_newScene_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // trv_scenes
            // 
            resources.ApplyResources(this.trv_scenes, "trv_scenes");
            this.trv_scenes.Name = "trv_scenes";
            // 
            // tb_sceneName
            // 
            resources.ApplyResources(this.tb_sceneName, "tb_sceneName");
            this.tb_sceneName.Name = "tb_sceneName";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // tbp_item
            // 
            this.tbp_item.Controls.Add(this.btn_loadItems);
            this.tbp_item.Controls.Add(this.btn_removeFx);
            this.tbp_item.Controls.Add(this.btn_addFx);
            this.tbp_item.Controls.Add(this.btn_deleteGroup);
            this.tbp_item.Controls.Add(this.btn_groupDown);
            this.tbp_item.Controls.Add(this.btn_groupUp);
            this.tbp_item.Controls.Add(this.btn_addGroup);
            this.tbp_item.Controls.Add(this.trv_itemCollection);
            resources.ApplyResources(this.tbp_item, "tbp_item");
            this.tbp_item.Name = "tbp_item";
            this.tbp_item.UseVisualStyleBackColor = true;
            // 
            // btn_loadItems
            // 
            resources.ApplyResources(this.btn_loadItems, "btn_loadItems");
            this.btn_loadItems.Name = "btn_loadItems";
            this.btn_loadItems.UseVisualStyleBackColor = true;
            this.btn_loadItems.Click += new System.EventHandler(this.btn_loadItems_Click);
            // 
            // btn_removeFx
            // 
            resources.ApplyResources(this.btn_removeFx, "btn_removeFx");
            this.btn_removeFx.Name = "btn_removeFx";
            this.btn_removeFx.UseVisualStyleBackColor = true;
            // 
            // btn_addFx
            // 
            resources.ApplyResources(this.btn_addFx, "btn_addFx");
            this.btn_addFx.Name = "btn_addFx";
            this.btn_addFx.UseVisualStyleBackColor = true;
            // 
            // btn_deleteGroup
            // 
            resources.ApplyResources(this.btn_deleteGroup, "btn_deleteGroup");
            this.btn_deleteGroup.Name = "btn_deleteGroup";
            this.btn_deleteGroup.UseVisualStyleBackColor = true;
            this.btn_deleteGroup.Click += new System.EventHandler(this.btn_deleteGroup_Click);
            // 
            // btn_groupDown
            // 
            resources.ApplyResources(this.btn_groupDown, "btn_groupDown");
            this.btn_groupDown.Name = "btn_groupDown";
            this.btn_groupDown.UseVisualStyleBackColor = true;
            this.btn_groupDown.Click += new System.EventHandler(this.btn_groupDown_Click);
            // 
            // btn_groupUp
            // 
            resources.ApplyResources(this.btn_groupUp, "btn_groupUp");
            this.btn_groupUp.Name = "btn_groupUp";
            this.btn_groupUp.UseVisualStyleBackColor = true;
            this.btn_groupUp.Click += new System.EventHandler(this.btn_groupUp_Click);
            // 
            // btn_addGroup
            // 
            resources.ApplyResources(this.btn_addGroup, "btn_addGroup");
            this.btn_addGroup.Name = "btn_addGroup";
            this.btn_addGroup.UseVisualStyleBackColor = true;
            this.btn_addGroup.Click += new System.EventHandler(this.btn_addGroup_Click);
            // 
            // trv_itemCollection
            // 
            this.trv_itemCollection.AllowDrop = true;
            this.trv_itemCollection.CheckBoxes = true;
            resources.ApplyResources(this.trv_itemCollection, "trv_itemCollection");
            this.trv_itemCollection.Name = "trv_itemCollection";
            this.trv_itemCollection.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trv_itemCollection_ItemDrag);
            this.trv_itemCollection.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv_itemCollection_AfterSelect);
            this.trv_itemCollection.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trv_itemCollection_NodeMouseClick);
            this.trv_itemCollection.DragDrop += new System.Windows.Forms.DragEventHandler(this.trv_itemCollection_DragDrop);
            this.trv_itemCollection.DragEnter += new System.Windows.Forms.DragEventHandler(this.trv_itemCollection_DragEnter);
            // 
            // tbp_library
            // 
            this.tbp_library.Controls.Add(this.button2);
            this.tbp_library.Controls.Add(this.label1);
            this.tbp_library.Controls.Add(this.comboBox1);
            resources.ApplyResources(this.tbp_library, "tbp_library");
            this.tbp_library.Name = "tbp_library";
            this.tbp_library.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            // 
            // tbp_property
            // 
            this.tbp_property.Controls.Add(this.prg_itemProperty);
            resources.ApplyResources(this.tbp_property, "tbp_property");
            this.tbp_property.Name = "tbp_property";
            this.tbp_property.UseVisualStyleBackColor = true;
            // 
            // prg_itemProperty
            // 
            resources.ApplyResources(this.prg_itemProperty, "prg_itemProperty");
            this.prg_itemProperty.Name = "prg_itemProperty";
            // 
            // tbp_test
            // 
            this.tbp_test.Controls.Add(this.btn_respawnAskia);
            this.tbp_test.Controls.Add(this.label12);
            this.tbp_test.Controls.Add(this.btn_respawnRole);
            this.tbp_test.Controls.Add(this.label11);
            resources.ApplyResources(this.tbp_test, "tbp_test");
            this.tbp_test.Name = "tbp_test";
            this.tbp_test.UseVisualStyleBackColor = true;
            // 
            // btn_respawnAskia
            // 
            resources.ApplyResources(this.btn_respawnAskia, "btn_respawnAskia");
            this.btn_respawnAskia.Name = "btn_respawnAskia";
            this.btn_respawnAskia.UseVisualStyleBackColor = true;
            this.btn_respawnAskia.Click += new System.EventHandler(this.btn_respawnAskia_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // btn_respawnRole
            // 
            resources.ApplyResources(this.btn_respawnRole, "btn_respawnRole");
            this.btn_respawnRole.Name = "btn_respawnRole";
            this.btn_respawnRole.UseVisualStyleBackColor = true;
            this.btn_respawnRole.Click += new System.EventHandler(this.btn_respawnRole_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // cbb_itemType
            // 
            this.cbb_itemType.FormattingEnabled = true;
            this.cbb_itemType.Items.AddRange(new object[] {
            resources.GetString("cbb_itemType.Items"),
            resources.GetString("cbb_itemType.Items1"),
            resources.GetString("cbb_itemType.Items2"),
            resources.GetString("cbb_itemType.Items3"),
            resources.GetString("cbb_itemType.Items4"),
            resources.GetString("cbb_itemType.Items5"),
            resources.GetString("cbb_itemType.Items6"),
            resources.GetString("cbb_itemType.Items7")});
            resources.ApplyResources(this.cbb_itemType, "cbb_itemType");
            this.cbb_itemType.Name = "cbb_itemType";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.项目ToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.资源ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_new,
            this.tmi_open,
            this.tmi_close,
            this.toolStripSeparator1,
            this.tmi_add,
            this.toolStripSeparator8,
            this.tmi_saveScene,
            this.保存ToolStripMenuItem,
            this.toolStripSeparator2,
            this.tmi_quit});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            resources.ApplyResources(this.文件ToolStripMenuItem, "文件ToolStripMenuItem");
            // 
            // tmi_new
            // 
            this.tmi_new.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_newProject,
            this.toolStripSeparator7,
            this.tmi_newScene,
            this.tmi_newDrama,
            this.tmi_newTemplete});
            this.tmi_new.Name = "tmi_new";
            resources.ApplyResources(this.tmi_new, "tmi_new");
            // 
            // tmi_newProject
            // 
            this.tmi_newProject.Name = "tmi_newProject";
            resources.ApplyResources(this.tmi_newProject, "tmi_newProject");
            this.tmi_newProject.Click += new System.EventHandler(this.tmi_newProject_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // tmi_newScene
            // 
            this.tmi_newScene.Name = "tmi_newScene";
            resources.ApplyResources(this.tmi_newScene, "tmi_newScene");
            this.tmi_newScene.Click += new System.EventHandler(this.tmi_newScene_Click);
            // 
            // tmi_newDrama
            // 
            this.tmi_newDrama.Name = "tmi_newDrama";
            resources.ApplyResources(this.tmi_newDrama, "tmi_newDrama");
            // 
            // tmi_newTemplete
            // 
            this.tmi_newTemplete.Name = "tmi_newTemplete";
            resources.ApplyResources(this.tmi_newTemplete, "tmi_newTemplete");
            // 
            // tmi_open
            // 
            this.tmi_open.Name = "tmi_open";
            resources.ApplyResources(this.tmi_open, "tmi_open");
            // 
            // tmi_close
            // 
            this.tmi_close.Name = "tmi_close";
            resources.ApplyResources(this.tmi_close, "tmi_close");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tmi_add
            // 
            this.tmi_add.Name = "tmi_add";
            resources.ApplyResources(this.tmi_add, "tmi_add");
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // tmi_saveScene
            // 
            this.tmi_saveScene.Name = "tmi_saveScene";
            resources.ApplyResources(this.tmi_saveScene, "tmi_saveScene");
            this.tmi_saveScene.Click += new System.EventHandler(this.tmi_saveScene_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            resources.ApplyResources(this.保存ToolStripMenuItem, "保存ToolStripMenuItem");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tmi_quit
            // 
            this.tmi_quit.Name = "tmi_quit";
            resources.ApplyResources(this.tmi_quit, "tmi_quit");
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scenePropertyToolStripMenuItem,
            this.toolStripSeparator9,
            this.tmi_showAABB,
            this.toolStripSeparator6,
            this.tmi_physicsEnabled,
            this.toolStripSeparator5,
            this.tmi_filterAll,
            this.tmi_filterBackground,
            this.tmi_filterTerrain,
            this.tmi_filterObstacle,
            this.tmi_filterProch,
            this.tmi_filterGravity,
            this.tmi_filterTrigger,
            this.tmi_filterCase,
            this.tmi_filterSupply,
            this.tmi_filterForeground,
            this.toolStripSeparator11,
            this.tsi_cornerCoordinate,
            this.toolStripSeparator12,
            this.tsi_focusItem,
            this.tsi_focusZero});
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            resources.ApplyResources(this.视图ToolStripMenuItem, "视图ToolStripMenuItem");
            // 
            // scenePropertyToolStripMenuItem
            // 
            this.scenePropertyToolStripMenuItem.Name = "scenePropertyToolStripMenuItem";
            resources.ApplyResources(this.scenePropertyToolStripMenuItem, "scenePropertyToolStripMenuItem");
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // tmi_showAABB
            // 
            this.tmi_showAABB.CheckOnClick = true;
            this.tmi_showAABB.Name = "tmi_showAABB";
            resources.ApplyResources(this.tmi_showAABB, "tmi_showAABB");
            this.tmi_showAABB.Click += new System.EventHandler(this.tmi_showAABB_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // tmi_physicsEnabled
            // 
            this.tmi_physicsEnabled.Name = "tmi_physicsEnabled";
            resources.ApplyResources(this.tmi_physicsEnabled, "tmi_physicsEnabled");
            this.tmi_physicsEnabled.CheckedChanged += new System.EventHandler(this.tmi_physicsEnabled_CheckedChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // tmi_filterAll
            // 
            this.tmi_filterAll.CheckOnClick = true;
            this.tmi_filterAll.Name = "tmi_filterAll";
            resources.ApplyResources(this.tmi_filterAll, "tmi_filterAll");
            // 
            // tmi_filterBackground
            // 
            this.tmi_filterBackground.CheckOnClick = true;
            this.tmi_filterBackground.Name = "tmi_filterBackground";
            resources.ApplyResources(this.tmi_filterBackground, "tmi_filterBackground");
            // 
            // tmi_filterTerrain
            // 
            this.tmi_filterTerrain.CheckOnClick = true;
            this.tmi_filterTerrain.Name = "tmi_filterTerrain";
            resources.ApplyResources(this.tmi_filterTerrain, "tmi_filterTerrain");
            // 
            // tmi_filterObstacle
            // 
            this.tmi_filterObstacle.CheckOnClick = true;
            this.tmi_filterObstacle.Name = "tmi_filterObstacle";
            resources.ApplyResources(this.tmi_filterObstacle, "tmi_filterObstacle");
            // 
            // tmi_filterProch
            // 
            this.tmi_filterProch.CheckOnClick = true;
            this.tmi_filterProch.Name = "tmi_filterProch";
            resources.ApplyResources(this.tmi_filterProch, "tmi_filterProch");
            // 
            // tmi_filterGravity
            // 
            this.tmi_filterGravity.CheckOnClick = true;
            this.tmi_filterGravity.Name = "tmi_filterGravity";
            resources.ApplyResources(this.tmi_filterGravity, "tmi_filterGravity");
            // 
            // tmi_filterTrigger
            // 
            this.tmi_filterTrigger.CheckOnClick = true;
            this.tmi_filterTrigger.Name = "tmi_filterTrigger";
            resources.ApplyResources(this.tmi_filterTrigger, "tmi_filterTrigger");
            // 
            // tmi_filterCase
            // 
            this.tmi_filterCase.CheckOnClick = true;
            this.tmi_filterCase.Name = "tmi_filterCase";
            resources.ApplyResources(this.tmi_filterCase, "tmi_filterCase");
            // 
            // tmi_filterSupply
            // 
            this.tmi_filterSupply.CheckOnClick = true;
            this.tmi_filterSupply.Name = "tmi_filterSupply";
            resources.ApplyResources(this.tmi_filterSupply, "tmi_filterSupply");
            // 
            // tmi_filterForeground
            // 
            this.tmi_filterForeground.CheckOnClick = true;
            this.tmi_filterForeground.Name = "tmi_filterForeground";
            resources.ApplyResources(this.tmi_filterForeground, "tmi_filterForeground");
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // tsi_cornerCoordinate
            // 
            this.tsi_cornerCoordinate.Checked = true;
            this.tsi_cornerCoordinate.CheckOnClick = true;
            this.tsi_cornerCoordinate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsi_cornerCoordinate.Name = "tsi_cornerCoordinate";
            resources.ApplyResources(this.tsi_cornerCoordinate, "tsi_cornerCoordinate");
            this.tsi_cornerCoordinate.CheckedChanged += new System.EventHandler(this.tsi_cornerCoordinate_CheckedChanged);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // tsi_focusItem
            // 
            this.tsi_focusItem.Name = "tsi_focusItem";
            resources.ApplyResources(this.tsi_focusItem, "tsi_focusItem");
            this.tsi_focusItem.Click += new System.EventHandler(this.tsi_focusItem_Click);
            // 
            // tsi_focusZero
            // 
            this.tsi_focusZero.Name = "tsi_focusZero";
            resources.ApplyResources(this.tsi_focusZero, "tsi_focusZero");
            this.tsi_focusZero.Click += new System.EventHandler(this.tsi_focusZero_Click);
            // 
            // 项目ToolStripMenuItem
            // 
            this.项目ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_config,
            this.toolStripSeparator3,
            this.tmi_release,
            this.独立运行ToolStripMenuItem});
            this.项目ToolStripMenuItem.Name = "项目ToolStripMenuItem";
            resources.ApplyResources(this.项目ToolStripMenuItem, "项目ToolStripMenuItem");
            // 
            // tmi_config
            // 
            this.tmi_config.Name = "tmi_config";
            resources.ApplyResources(this.tmi_config, "tmi_config");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tmi_release
            // 
            this.tmi_release.Name = "tmi_release";
            resources.ApplyResources(this.tmi_release, "tmi_release");
            // 
            // 独立运行ToolStripMenuItem
            // 
            this.独立运行ToolStripMenuItem.Name = "独立运行ToolStripMenuItem";
            resources.ApplyResources(this.独立运行ToolStripMenuItem, "独立运行ToolStripMenuItem");
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_animEditor,
            this.ims_itemEditor,
            this.renderMapToolStripMenuItem,
            this.toolStripSeparator10,
            this.tsi_makeDecorate,
            this.tsi_makeStatic,
            this.tsi_makeActive,
            this.toolStripSeparator13,
            this.tsi_configControl});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            resources.ApplyResources(this.toolToolStripMenuItem, "toolToolStripMenuItem");
            // 
            // tmi_animEditor
            // 
            this.tmi_animEditor.Name = "tmi_animEditor";
            resources.ApplyResources(this.tmi_animEditor, "tmi_animEditor");
            this.tmi_animEditor.Click += new System.EventHandler(this.tmi_animEditor_Click);
            // 
            // ims_itemEditor
            // 
            this.ims_itemEditor.Name = "ims_itemEditor";
            resources.ApplyResources(this.ims_itemEditor, "ims_itemEditor");
            this.ims_itemEditor.Click += new System.EventHandler(this.ims_itemEditor_Click);
            // 
            // renderMapToolStripMenuItem
            // 
            this.renderMapToolStripMenuItem.Name = "renderMapToolStripMenuItem";
            resources.ApplyResources(this.renderMapToolStripMenuItem, "renderMapToolStripMenuItem");
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // tsi_makeDecorate
            // 
            this.tsi_makeDecorate.Name = "tsi_makeDecorate";
            resources.ApplyResources(this.tsi_makeDecorate, "tsi_makeDecorate");
            this.tsi_makeDecorate.Click += new System.EventHandler(this.tsi_makeDecorate_Click);
            // 
            // tsi_makeStatic
            // 
            this.tsi_makeStatic.Name = "tsi_makeStatic";
            resources.ApplyResources(this.tsi_makeStatic, "tsi_makeStatic");
            this.tsi_makeStatic.Click += new System.EventHandler(this.tsi_makeStatic_Click);
            // 
            // tsi_makeActive
            // 
            this.tsi_makeActive.Name = "tsi_makeActive";
            resources.ApplyResources(this.tsi_makeActive, "tsi_makeActive");
            this.tsi_makeActive.Click += new System.EventHandler(this.tsi_makeActive_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
            // 
            // tsi_configControl
            // 
            this.tsi_configControl.Name = "tsi_configControl";
            resources.ApplyResources(this.tsi_configControl, "tsi_configControl");
            this.tsi_configControl.Click += new System.EventHandler(this.tsi_controlConfig_Click);
            // 
            // 资源ToolStripMenuItem
            // 
            this.资源ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_texture,
            this.tmi_audio});
            this.资源ToolStripMenuItem.Name = "资源ToolStripMenuItem";
            resources.ApplyResources(this.资源ToolStripMenuItem, "资源ToolStripMenuItem");
            // 
            // tmi_texture
            // 
            this.tmi_texture.Name = "tmi_texture";
            resources.ApplyResources(this.tmi_texture, "tmi_texture");
            // 
            // tmi_audio
            // 
            this.tmi_audio.Name = "tmi_audio";
            resources.ApplyResources(this.tmi_audio, "tmi_audio");
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_help,
            this.tmi_tutorial,
            this.tmi_feedback,
            this.toolStripSeparator4,
            this.tmi_about});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            resources.ApplyResources(this.帮助ToolStripMenuItem, "帮助ToolStripMenuItem");
            // 
            // tmi_help
            // 
            this.tmi_help.Name = "tmi_help";
            resources.ApplyResources(this.tmi_help, "tmi_help");
            // 
            // tmi_tutorial
            // 
            this.tmi_tutorial.Name = "tmi_tutorial";
            resources.ApplyResources(this.tmi_tutorial, "tmi_tutorial");
            // 
            // tmi_feedback
            // 
            this.tmi_feedback.Name = "tmi_feedback";
            resources.ApplyResources(this.tmi_feedback, "tmi_feedback");
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // tmi_about
            // 
            this.tmi_about.Name = "tmi_about";
            resources.ApplyResources(this.tmi_about, "tmi_about");
            // 
            // btn_deleteItem
            // 
            resources.ApplyResources(this.btn_deleteItem, "btn_deleteItem");
            this.btn_deleteItem.Name = "btn_deleteItem";
            this.btn_deleteItem.UseVisualStyleBackColor = true;
            this.btn_deleteItem.Click += new System.EventHandler(this.btn_deleteItem_Click);
            // 
            // btn_transformItem
            // 
            resources.ApplyResources(this.btn_transformItem, "btn_transformItem");
            this.btn_transformItem.Name = "btn_transformItem";
            this.btn_transformItem.UseVisualStyleBackColor = true;
            this.btn_transformItem.Click += new System.EventHandler(this.btn_transformItem_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btn_createItem
            // 
            resources.ApplyResources(this.btn_createItem, "btn_createItem");
            this.btn_createItem.Name = "btn_createItem";
            this.btn_createItem.UseVisualStyleBackColor = true;
            this.btn_createItem.Click += new System.EventHandler(this.btn_createItem_Click_1);
            // 
            // btn_selectItem
            // 
            resources.ApplyResources(this.btn_selectItem, "btn_selectItem");
            this.btn_selectItem.Name = "btn_selectItem";
            this.btn_selectItem.UseVisualStyleBackColor = true;
            this.btn_selectItem.Click += new System.EventHandler(this.btn_selectItem_Click);
            // 
            // btn_getTexture
            // 
            resources.ApplyResources(this.btn_getTexture, "btn_getTexture");
            this.btn_getTexture.Name = "btn_getTexture";
            this.btn_getTexture.UseVisualStyleBackColor = true;
            this.btn_getTexture.Click += new System.EventHandler(this.btn_getTexture_Click);
            // 
            // btn_copyItem
            // 
            resources.ApplyResources(this.btn_copyItem, "btn_copyItem");
            this.btn_copyItem.Name = "btn_copyItem";
            this.btn_copyItem.UseVisualStyleBackColor = true;
            this.btn_copyItem.Click += new System.EventHandler(this.btn_copyItem_Click_1);
            // 
            // btn_alignVerticalMiddle
            // 
            resources.ApplyResources(this.btn_alignVerticalMiddle, "btn_alignVerticalMiddle");
            this.btn_alignVerticalMiddle.Name = "btn_alignVerticalMiddle";
            this.btn_alignVerticalMiddle.UseVisualStyleBackColor = true;
            // 
            // btn_alignHorizonalMiddle
            // 
            resources.ApplyResources(this.btn_alignHorizonalMiddle, "btn_alignHorizonalMiddle");
            this.btn_alignHorizonalMiddle.Name = "btn_alignHorizonalMiddle";
            this.btn_alignHorizonalMiddle.UseVisualStyleBackColor = true;
            // 
            // btn_alignHorizonalBottom
            // 
            resources.ApplyResources(this.btn_alignHorizonalBottom, "btn_alignHorizonalBottom");
            this.btn_alignHorizonalBottom.Name = "btn_alignHorizonalBottom";
            this.btn_alignHorizonalBottom.UseVisualStyleBackColor = true;
            // 
            // btn_alignHorizonalTop
            // 
            resources.ApplyResources(this.btn_alignHorizonalTop, "btn_alignHorizonalTop");
            this.btn_alignHorizonalTop.Name = "btn_alignHorizonalTop";
            this.btn_alignHorizonalTop.UseVisualStyleBackColor = true;
            // 
            // btn_alignVerticalRight
            // 
            resources.ApplyResources(this.btn_alignVerticalRight, "btn_alignVerticalRight");
            this.btn_alignVerticalRight.Name = "btn_alignVerticalRight";
            this.btn_alignVerticalRight.UseVisualStyleBackColor = true;
            // 
            // btn_alignVerticalLeft
            // 
            resources.ApplyResources(this.btn_alignVerticalLeft, "btn_alignVerticalLeft");
            this.btn_alignVerticalLeft.Name = "btn_alignVerticalLeft";
            this.btn_alignVerticalLeft.UseVisualStyleBackColor = true;
            // 
            // btn_layerUp
            // 
            resources.ApplyResources(this.btn_layerUp, "btn_layerUp");
            this.btn_layerUp.Name = "btn_layerUp";
            this.btn_layerUp.UseVisualStyleBackColor = true;
            this.btn_layerUp.Click += new System.EventHandler(this.btn_layerUp_Click);
            // 
            // btn_layerTop
            // 
            resources.ApplyResources(this.btn_layerTop, "btn_layerTop");
            this.btn_layerTop.Name = "btn_layerTop";
            this.btn_layerTop.UseVisualStyleBackColor = true;
            this.btn_layerTop.Click += new System.EventHandler(this.btn_layerTop_Click);
            // 
            // btn_layerBottom
            // 
            resources.ApplyResources(this.btn_layerBottom, "btn_layerBottom");
            this.btn_layerBottom.Name = "btn_layerBottom";
            this.btn_layerBottom.UseVisualStyleBackColor = true;
            this.btn_layerBottom.Click += new System.EventHandler(this.btn_layerBottom_Click);
            // 
            // btn_layerDown
            // 
            resources.ApplyResources(this.btn_layerDown, "btn_layerDown");
            this.btn_layerDown.Name = "btn_layerDown";
            this.btn_layerDown.UseVisualStyleBackColor = true;
            this.btn_layerDown.Click += new System.EventHandler(this.btn_layerDown_Click);
            // 
            // trb_zoom
            // 
            resources.ApplyResources(this.trb_zoom, "trb_zoom");
            this.trb_zoom.Maximum = 3000;
            this.trb_zoom.Minimum = 125;
            this.trb_zoom.Name = "trb_zoom";
            this.trb_zoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trb_zoom.Value = 125;
            this.trb_zoom.ValueChanged += new System.EventHandler(this.trb_zoom_ValueChanged);
            // 
            // btn_freeCamera
            // 
            resources.ApplyResources(this.btn_freeCamera, "btn_freeCamera");
            this.btn_freeCamera.Name = "btn_freeCamera";
            this.btn_freeCamera.UseVisualStyleBackColor = true;
            this.btn_freeCamera.Click += new System.EventHandler(this.btn_freeCamera_Click);
            // 
            // btn_editAnim
            // 
            resources.ApplyResources(this.btn_editAnim, "btn_editAnim");
            this.btn_editAnim.Name = "btn_editAnim";
            this.btn_editAnim.UseVisualStyleBackColor = true;
            this.btn_editAnim.Click += new System.EventHandler(this.btn_editAnim_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // cbb_zoom
            // 
            this.cbb_zoom.FormattingEnabled = true;
            this.cbb_zoom.Items.AddRange(new object[] {
            resources.GetString("cbb_zoom.Items"),
            resources.GetString("cbb_zoom.Items1"),
            resources.GetString("cbb_zoom.Items2"),
            resources.GetString("cbb_zoom.Items3"),
            resources.GetString("cbb_zoom.Items4"),
            resources.GetString("cbb_zoom.Items5")});
            resources.ApplyResources(this.cbb_zoom, "cbb_zoom");
            this.cbb_zoom.Name = "cbb_zoom";
            this.cbb_zoom.SelectedIndexChanged += new System.EventHandler(this.cbb_zoom_SelectedIndexChanged);
            // 
            // ttb_texturePicker
            // 
            resources.ApplyResources(this.ttb_texturePicker, "ttb_texturePicker");
            this.ttb_texturePicker.Name = "ttb_texturePicker";
            this.ttb_texturePicker.TexturePath = null;
            this.ttb_texturePicker.Click += new System.EventHandler(this.ptb_curTexture_Click);
            // 
            // editMainControl1
            // 
            resources.ApplyResources(this.editMainControl1, "editMainControl1");
            this.editMainControl1.Name = "editMainControl1";
            // 
            // tbp_dramas
            // 
            this.tbp_dramas.Controls.Add(this.button7);
            this.tbp_dramas.Controls.Add(this.button6);
            this.tbp_dramas.Controls.Add(this.button1);
            this.tbp_dramas.Controls.Add(this.button3);
            this.tbp_dramas.Controls.Add(this.treeView1);
            resources.ApplyResources(this.tbp_dramas, "tbp_dramas");
            this.tbp_dramas.Name = "tbp_dramas";
            this.tbp_dramas.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.Name = "treeView1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // EditorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbb_zoom);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_editAnim);
            this.Controls.Add(this.ttb_texturePicker);
            this.Controls.Add(this.btn_freeCamera);
            this.Controls.Add(this.trb_zoom);
            this.Controls.Add(this.btn_layerUp);
            this.Controls.Add(this.btn_layerTop);
            this.Controls.Add(this.btn_layerBottom);
            this.Controls.Add(this.btn_layerDown);
            this.Controls.Add(this.btn_alignVerticalMiddle);
            this.Controls.Add(this.btn_alignHorizonalMiddle);
            this.Controls.Add(this.btn_alignHorizonalBottom);
            this.Controls.Add(this.btn_alignHorizonalTop);
            this.Controls.Add(this.btn_alignVerticalRight);
            this.Controls.Add(this.btn_alignVerticalLeft);
            this.Controls.Add(this.btn_copyItem);
            this.Controls.Add(this.btn_getTexture);
            this.Controls.Add(this.btn_deleteItem);
            this.Controls.Add(this.btn_transformItem);
            this.Controls.Add(this.cbb_itemType);
            this.Controls.Add(this.editMainControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_createItem);
            this.Controls.Add(this.btn_selectItem);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditorForm";
            this.tabControl1.ResumeLayout(false);
            this.tbp_project.ResumeLayout(false);
            this.tbp_project.PerformLayout();
            this.tbp_item.ResumeLayout(false);
            this.tbp_library.ResumeLayout(false);
            this.tbp_library.PerformLayout();
            this.tbp_property.ResumeLayout(false);
            this.tbp_test.ResumeLayout(false);
            this.tbp_test.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_zoom)).EndInit();
            this.tbp_dramas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbp_project;
        private System.Windows.Forms.TabPage tbp_property;
        private System.Windows.Forms.PropertyGrid prg_itemProperty;
        private System.Windows.Forms.ComboBox cbb_itemType;
        private System.Windows.Forms.TextBox tb_sceneName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tbp_test;
        private System.Windows.Forms.Button btn_respawnAskia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_respawnRole;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_selectItem;
        private System.Windows.Forms.Button btn_createItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_transformItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmi_new;
        private System.Windows.Forms.ToolStripMenuItem tmi_open;
        private System.Windows.Forms.ToolStripMenuItem tmi_close;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tmi_add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tmi_quit;
        private System.Windows.Forms.ToolStripMenuItem 项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmi_config;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tmi_release;
        private System.Windows.Forms.ToolStripMenuItem 资源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmi_texture;
        private System.Windows.Forms.ToolStripMenuItem tmi_audio;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmi_help;
        private System.Windows.Forms.ToolStripMenuItem tmi_tutorial;
        private System.Windows.Forms.ToolStripMenuItem tmi_feedback;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tmi_about;
        private System.Windows.Forms.Button btn_deleteItem;
        private System.Windows.Forms.Button btn_getTexture;
        private System.Windows.Forms.Button btn_copyItem;
        private System.Windows.Forms.Button btn_alignVerticalMiddle;
        private System.Windows.Forms.Button btn_alignHorizonalMiddle;
        private System.Windows.Forms.Button btn_alignHorizonalBottom;
        private System.Windows.Forms.Button btn_alignHorizonalTop;
        private System.Windows.Forms.Button btn_alignVerticalRight;
        private System.Windows.Forms.Button btn_alignVerticalLeft;
        private System.Windows.Forms.Button btn_layerUp;
        private System.Windows.Forms.Button btn_layerTop;
        private System.Windows.Forms.Button btn_layerBottom;
        private System.Windows.Forms.Button btn_layerDown;
        private System.Windows.Forms.ToolStripMenuItem 独立运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmi_showAABB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tmi_physicsEnabled;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tmi_filterAll;
        private System.Windows.Forms.ToolStripMenuItem tmi_filterBackground;
        private System.Windows.Forms.ToolStripMenuItem tmi_filterTerrain;
        private System.Windows.Forms.ToolStripMenuItem tmi_filterObstacle;
        private System.Windows.Forms.ToolStripMenuItem tmi_filterProch;
        private System.Windows.Forms.ToolStripMenuItem tmi_filterGravity;
        private System.Windows.Forms.ToolStripMenuItem tmi_filterTrigger;
        private System.Windows.Forms.ToolStripMenuItem tmi_filterCase;
        private System.Windows.Forms.ToolStripMenuItem tmi_filterSupply;
        private System.Windows.Forms.ToolStripMenuItem tmi_filterForeground;
        private System.Windows.Forms.TabPage tbp_library;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem tmi_newProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tmi_newScene;
        private System.Windows.Forms.ToolStripMenuItem tmi_newDrama;
        private System.Windows.Forms.ToolStripMenuItem tmi_newTemplete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.TrackBar trb_zoom;
        private System.Windows.Forms.Button btn_freeCamera;
        private TextureBox ttb_texturePicker;
        private System.Windows.Forms.Button btn_editAnim;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmi_animEditor;
        private System.Windows.Forms.TabPage tbp_item;
        private System.Windows.Forms.Button btn_deleteGroup;
        private System.Windows.Forms.Button btn_groupDown;
        private System.Windows.Forms.Button btn_groupUp;
        private System.Windows.Forms.Button btn_addGroup;
        private System.Windows.Forms.TreeView trv_itemCollection;
        private System.Windows.Forms.Button btn_removeFx;
        private System.Windows.Forms.Button btn_addFx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView trv_scenes;
        private System.Windows.Forms.Button btn_loadItems;
        private System.Windows.Forms.Button btn_deleteScene;
        private System.Windows.Forms.Button btn_newScene;
        private System.Windows.Forms.ToolStripMenuItem tmi_saveScene;
        private System.Windows.Forms.Button btn_saveScene;
        private System.Windows.Forms.Button btn_editScene;
        private System.Windows.Forms.ToolStripMenuItem ims_itemEditor;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem renderMapToolStripMenuItem;
        private EditMainControl editMainControl1;
        private System.Windows.Forms.ToolStripMenuItem scenePropertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem tsi_makeDecorate;
        private System.Windows.Forms.ToolStripMenuItem tsi_makeStatic;
        private System.Windows.Forms.ToolStripMenuItem tsi_makeActive;
        private System.Windows.Forms.ComboBox cbb_zoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem tsi_cornerCoordinate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem tsi_focusItem;
        private System.Windows.Forms.ToolStripMenuItem tsi_focusZero;
        private System.Windows.Forms.Button btn_clearScene;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem tsi_configControl;
        private System.Windows.Forms.TabPage tbp_dramas;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;

    }
}