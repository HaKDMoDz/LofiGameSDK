namespace Lofinil.GameSDK.Editor.Module.Project
{
    partial class CreateProjectForm
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
            this.btn_create = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_browseProjectPath = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_gameIcon = new System.Windows.Forms.TextBox();
            this.tb_auther = new System.Windows.Forms.TextBox();
            this.tb_gameName = new System.Windows.Forms.TextBox();
            this.tb_projectPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chbCreateFolder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(272, 265);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 23);
            this.btn_create.TabIndex = 1;
            this.btn_create.Text = "创建";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(355, 265);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_browseProjectPath
            // 
            this.btn_browseProjectPath.Location = new System.Drawing.Point(372, 15);
            this.btn_browseProjectPath.Name = "btn_browseProjectPath";
            this.btn_browseProjectPath.Size = new System.Drawing.Size(58, 23);
            this.btn_browseProjectPath.TabIndex = 33;
            this.btn_browseProjectPath.Text = "浏览...";
            this.btn_browseProjectPath.UseVisualStyleBackColor = true;
            this.btn_browseProjectPath.Click += new System.EventHandler(this.btn_browseProjectPath_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "浏览...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tb_gameIcon
            // 
            this.tb_gameIcon.Location = new System.Drawing.Point(73, 131);
            this.tb_gameIcon.Name = "tb_gameIcon";
            this.tb_gameIcon.Size = new System.Drawing.Size(293, 21);
            this.tb_gameIcon.TabIndex = 31;
            // 
            // tb_auther
            // 
            this.tb_auther.Location = new System.Drawing.Point(73, 93);
            this.tb_auther.Name = "tb_auther";
            this.tb_auther.Size = new System.Drawing.Size(293, 21);
            this.tb_auther.TabIndex = 30;
            // 
            // tb_gameName
            // 
            this.tb_gameName.Location = new System.Drawing.Point(73, 55);
            this.tb_gameName.Name = "tb_gameName";
            this.tb_gameName.Size = new System.Drawing.Size(293, 21);
            this.tb_gameName.TabIndex = 29;
            // 
            // tb_projectPath
            // 
            this.tb_projectPath.Location = new System.Drawing.Point(73, 17);
            this.tb_projectPath.Name = "tb_projectPath";
            this.tb_projectPath.Size = new System.Drawing.Size(293, 21);
            this.tb_projectPath.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "作者";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "图标";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "目录";
            // 
            // chbCreateFolder
            // 
            this.chbCreateFolder.AutoSize = true;
            this.chbCreateFolder.Checked = true;
            this.chbCreateFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCreateFolder.Location = new System.Drawing.Point(73, 184);
            this.chbCreateFolder.Name = "chbCreateFolder";
            this.chbCreateFolder.Size = new System.Drawing.Size(108, 16);
            this.chbCreateFolder.TabIndex = 34;
            this.chbCreateFolder.Text = "创建项目文件夹";
            this.chbCreateFolder.UseVisualStyleBackColor = true;
            // 
            // CreateProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 308);
            this.Controls.Add(this.chbCreateFolder);
            this.Controls.Add(this.btn_browseProjectPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_gameIcon);
            this.Controls.Add(this.tb_auther);
            this.Controls.Add(this.tb_gameName);
            this.Controls.Add(this.tb_projectPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_create);
            this.Name = "CreateProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "创建项目";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_browseProjectPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_gameIcon;
        private System.Windows.Forms.TextBox tb_auther;
        private System.Windows.Forms.TextBox tb_gameName;
        private System.Windows.Forms.TextBox tb_projectPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbCreateFolder;
    }
}