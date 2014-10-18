namespace Lofinil.GameSDK.Editor.Module.Project
{
    partial class ProjectControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectControl));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("场景1", 6, 6);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("场景2", 6, 6);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("场景", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("资源集1", 3, 3);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("资源集", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("图片1", 2, 2);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("声音1", 7, 7);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("素材库", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("项目1", 5, 5, new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5,
            treeNode8});
            this.tb_itemName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_saveScene = new System.Windows.Forms.Button();
            this.btn_editScene = new System.Windows.Forms.Button();
            this.btn_deleteScene = new System.Windows.Forms.Button();
            this.btn_newScene = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重新生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.在资源管理器中打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开方式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.从项目中排除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.剪切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlTreeHolder = new System.Windows.Forms.Panel();
            this.trv_items = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlTreeHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_itemName
            // 
            this.tb_itemName.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_itemName.Location = new System.Drawing.Point(0, 0);
            this.tb_itemName.Name = "tb_itemName";
            this.tb_itemName.Size = new System.Drawing.Size(232, 21);
            this.tb_itemName.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_saveScene);
            this.panel1.Controls.Add(this.btn_editScene);
            this.panel1.Controls.Add(this.btn_deleteScene);
            this.panel1.Controls.Add(this.btn_newScene);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 526);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 37);
            this.panel1.TabIndex = 31;
            // 
            // btn_saveScene
            // 
            this.btn_saveScene.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_saveScene.Image = ((System.Drawing.Image)(resources.GetObject("btn_saveScene.Image")));
            this.btn_saveScene.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_saveScene.Location = new System.Drawing.Point(114, 0);
            this.btn_saveScene.Name = "btn_saveScene";
            this.btn_saveScene.Size = new System.Drawing.Size(38, 37);
            this.btn_saveScene.TabIndex = 34;
            this.btn_saveScene.UseVisualStyleBackColor = true;
            // 
            // btn_editScene
            // 
            this.btn_editScene.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_editScene.Image = ((System.Drawing.Image)(resources.GetObject("btn_editScene.Image")));
            this.btn_editScene.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_editScene.Location = new System.Drawing.Point(76, 0);
            this.btn_editScene.Name = "btn_editScene";
            this.btn_editScene.Size = new System.Drawing.Size(38, 37);
            this.btn_editScene.TabIndex = 33;
            this.btn_editScene.UseVisualStyleBackColor = true;
            // 
            // btn_deleteScene
            // 
            this.btn_deleteScene.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_deleteScene.Image = ((System.Drawing.Image)(resources.GetObject("btn_deleteScene.Image")));
            this.btn_deleteScene.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_deleteScene.Location = new System.Drawing.Point(38, 0);
            this.btn_deleteScene.Name = "btn_deleteScene";
            this.btn_deleteScene.Size = new System.Drawing.Size(38, 37);
            this.btn_deleteScene.TabIndex = 32;
            this.btn_deleteScene.UseVisualStyleBackColor = true;
            // 
            // btn_newScene
            // 
            this.btn_newScene.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_newScene.Image = ((System.Drawing.Image)(resources.GetObject("btn_newScene.Image")));
            this.btn_newScene.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_newScene.Location = new System.Drawing.Point(0, 0);
            this.btn_newScene.Name = "btn_newScene";
            this.btn_newScene.Size = new System.Drawing.Size(38, 37);
            this.btn_newScene.TabIndex = 31;
            this.btn_newScene.UseVisualStyleBackColor = true;
            this.btn_newScene.Click += new System.EventHandler(this.btn_newScene_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成ToolStripMenuItem,
            this.重新生成ToolStripMenuItem,
            this.清理ToolStripMenuItem,
            this.toolStripSeparator1,
            this.添加ToolStripMenuItem,
            this.toolStripSeparator2,
            this.测试ToolStripMenuItem,
            this.toolStripSeparator3,
            this.在资源管理器中打开ToolStripMenuItem,
            this.toolStripSeparator4,
            this.属性ToolStripMenuItem,
            this.toolStripSeparator5,
            this.toolStripSeparator6,
            this.打开ToolStripMenuItem,
            this.打开方式ToolStripMenuItem,
            this.toolStripSeparator7,
            this.从项目中排除ToolStripMenuItem,
            this.toolStripSeparator8,
            this.剪切ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.重命名ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 360);
            // 
            // 生成ToolStripMenuItem
            // 
            this.生成ToolStripMenuItem.Name = "生成ToolStripMenuItem";
            this.生成ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.生成ToolStripMenuItem.Text = "生成";
            // 
            // 重新生成ToolStripMenuItem
            // 
            this.重新生成ToolStripMenuItem.Name = "重新生成ToolStripMenuItem";
            this.重新生成ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.重新生成ToolStripMenuItem.Text = "重新生成";
            // 
            // 清理ToolStripMenuItem
            // 
            this.清理ToolStripMenuItem.Name = "清理ToolStripMenuItem";
            this.清理ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.清理ToolStripMenuItem.Text = "清理";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "新建项";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem2.Text = "现有项";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem3.Text = "新建文件夹";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.测试ToolStripMenuItem.Text = "运行";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // 在资源管理器中打开ToolStripMenuItem
            // 
            this.在资源管理器中打开ToolStripMenuItem.Name = "在资源管理器中打开ToolStripMenuItem";
            this.在资源管理器中打开ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.在资源管理器中打开ToolStripMenuItem.Text = "在资源管理器中打开";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(181, 6);
            // 
            // 属性ToolStripMenuItem
            // 
            this.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem";
            this.属性ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.属性ToolStripMenuItem.Text = "属性";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(181, 6);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(181, 6);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 打开方式ToolStripMenuItem
            // 
            this.打开方式ToolStripMenuItem.Name = "打开方式ToolStripMenuItem";
            this.打开方式ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.打开方式ToolStripMenuItem.Text = "打开方式";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(181, 6);
            // 
            // 从项目中排除ToolStripMenuItem
            // 
            this.从项目中排除ToolStripMenuItem.Name = "从项目中排除ToolStripMenuItem";
            this.从项目中排除ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.从项目中排除ToolStripMenuItem.Text = "从项目中排除";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(181, 6);
            // 
            // 剪切ToolStripMenuItem
            // 
            this.剪切ToolStripMenuItem.Name = "剪切ToolStripMenuItem";
            this.剪切ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.剪切ToolStripMenuItem.Text = "剪切";
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder");
            this.imageList1.Images.SetKeyName(1, "Folder_Open");
            this.imageList1.Images.SetKeyName(2, "Image");
            this.imageList1.Images.SetKeyName(3, "DataSet");
            this.imageList1.Images.SetKeyName(4, "Trigger");
            this.imageList1.Images.SetKeyName(5, "basket-2.png");
            this.imageList1.Images.SetKeyName(6, "Stage");
            this.imageList1.Images.SetKeyName(7, "audio-keyboard.png");
            // 
            // pnlTreeHolder
            // 
            this.pnlTreeHolder.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlTreeHolder.Controls.Add(this.trv_items);
            this.pnlTreeHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTreeHolder.Location = new System.Drawing.Point(0, 21);
            this.pnlTreeHolder.Name = "pnlTreeHolder";
            this.pnlTreeHolder.Size = new System.Drawing.Size(232, 505);
            this.pnlTreeHolder.TabIndex = 32;
            // 
            // trv_items
            // 
            this.trv_items.ContextMenuStrip = this.contextMenuStrip1;
            this.trv_items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv_items.FullRowSelect = true;
            this.trv_items.HideSelection = false;
            this.trv_items.HotTracking = true;
            this.trv_items.ImageIndex = 0;
            this.trv_items.ImageList = this.imageList1;
            this.trv_items.Indent = 10;
            this.trv_items.ItemHeight = 20;
            this.trv_items.Location = new System.Drawing.Point(0, 0);
            this.trv_items.Name = "trv_items";
            treeNode1.ImageIndex = 6;
            treeNode1.Name = "节点3";
            treeNode1.SelectedImageIndex = 6;
            treeNode1.Text = "场景1";
            treeNode2.ImageIndex = 6;
            treeNode2.Name = "节点6";
            treeNode2.SelectedImageIndex = 6;
            treeNode2.Text = "场景2";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "节点2";
            treeNode3.SelectedImageIndex = 0;
            treeNode3.Text = "场景";
            treeNode4.ImageIndex = 3;
            treeNode4.Name = "节点12";
            treeNode4.SelectedImageIndex = 3;
            treeNode4.Text = "资源集1";
            treeNode5.Name = "节点7";
            treeNode5.Text = "资源集";
            treeNode6.ImageIndex = 2;
            treeNode6.Name = "节点10";
            treeNode6.SelectedImageIndex = 2;
            treeNode6.Text = "图片1";
            treeNode7.ImageIndex = 7;
            treeNode7.Name = "节点11";
            treeNode7.SelectedImageIndex = 7;
            treeNode7.Text = "声音1";
            treeNode8.Name = "节点8";
            treeNode8.Text = "素材库";
            treeNode9.ImageIndex = 5;
            treeNode9.Name = "节点1";
            treeNode9.SelectedImageIndex = 5;
            treeNode9.Text = "项目1";
            this.trv_items.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.trv_items.SelectedImageIndex = 0;
            this.trv_items.ShowLines = false;
            this.trv_items.ShowPlusMinus = false;
            this.trv_items.ShowRootLines = false;
            this.trv_items.Size = new System.Drawing.Size(232, 505);
            this.trv_items.TabIndex = 33;
            this.trv_items.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trv_items_MouseClick);
            this.trv_items.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trv_items_MouseDoubleClick);
            // 
            // ProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pnlTreeHolder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tb_itemName);
            this.DoubleBuffered = true;
            this.Name = "ProjectControl";
            this.Size = new System.Drawing.Size(232, 563);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlTreeHolder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_itemName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_saveScene;
        private System.Windows.Forms.Button btn_editScene;
        private System.Windows.Forms.Button btn_deleteScene;
        private System.Windows.Forms.Button btn_newScene;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem 生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重新生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 在资源管理器中打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开方式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem 从项目中排除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel pnlTreeHolder;
        public System.Windows.Forms.TreeView trv_items;
    }
}
