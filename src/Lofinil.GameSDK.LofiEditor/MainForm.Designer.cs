namespace Lofinil.GameSDK.Editor.Shell
{
    partial class MainForm
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.pnlTabViews = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgProject = new System.Windows.Forms.TabPage();
            this.tpgStage = new System.Windows.Forms.TabPage();
            this.tpgProperty = new System.Windows.Forms.TabPage();
            this.pnlStage = new System.Windows.Forms.Panel();
            this.pnlTabViews.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoSize = true;
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.MinimumSize = new System.Drawing.Size(0, 24);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(720, 24);
            this.pnlMenu.TabIndex = 0;
            // 
            // pnlStatus
            // 
            this.pnlStatus.AutoSize = true;
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 429);
            this.pnlStatus.MinimumSize = new System.Drawing.Size(0, 22);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(720, 22);
            this.pnlStatus.TabIndex = 1;
            // 
            // pnlTools
            // 
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTools.Location = new System.Drawing.Point(0, 24);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(131, 405);
            this.pnlTools.TabIndex = 2;
            // 
            // pnlTabViews
            // 
            this.pnlTabViews.Controls.Add(this.tabControl1);
            this.pnlTabViews.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTabViews.Location = new System.Drawing.Point(520, 24);
            this.pnlTabViews.Name = "pnlTabViews";
            this.pnlTabViews.Size = new System.Drawing.Size(200, 405);
            this.pnlTabViews.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgProject);
            this.tabControl1.Controls.Add(this.tpgStage);
            this.tabControl1.Controls.Add(this.tpgProperty);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 405);
            this.tabControl1.TabIndex = 0;
            // 
            // tpgProject
            // 
            this.tpgProject.Location = new System.Drawing.Point(4, 22);
            this.tpgProject.Name = "tpgProject";
            this.tpgProject.Size = new System.Drawing.Size(192, 379);
            this.tpgProject.TabIndex = 0;
            this.tpgProject.Text = "项目";
            this.tpgProject.UseVisualStyleBackColor = true;
            // 
            // tpgStage
            // 
            this.tpgStage.Location = new System.Drawing.Point(4, 22);
            this.tpgStage.Name = "tpgStage";
            this.tpgStage.Size = new System.Drawing.Size(192, 379);
            this.tpgStage.TabIndex = 1;
            this.tpgStage.Text = "舞台";
            this.tpgStage.UseVisualStyleBackColor = true;
            // 
            // tpgProperty
            // 
            this.tpgProperty.Location = new System.Drawing.Point(4, 22);
            this.tpgProperty.Name = "tpgProperty";
            this.tpgProperty.Size = new System.Drawing.Size(192, 379);
            this.tpgProperty.TabIndex = 2;
            this.tpgProperty.Text = "属性";
            this.tpgProperty.UseVisualStyleBackColor = true;
            // 
            // pnlStage
            // 
            this.pnlStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStage.Location = new System.Drawing.Point(131, 24);
            this.pnlStage.Name = "pnlStage";
            this.pnlStage.Size = new System.Drawing.Size(389, 405);
            this.pnlStage.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 451);
            this.Controls.Add(this.pnlStage);
            this.Controls.Add(this.pnlTabViews);
            this.Controls.Add(this.pnlTools);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlMenu);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lofinil Game Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.pnlTabViews.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTabViews;
        public System.Windows.Forms.Panel pnlMenu;
        public System.Windows.Forms.Panel pnlTools;
        public System.Windows.Forms.Panel pnlStage;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.Panel pnlStatus;
        public System.Windows.Forms.TabPage tpgProject;
        public System.Windows.Forms.TabPage tpgProperty;
        public System.Windows.Forms.TabPage tpgStage;

    }
}