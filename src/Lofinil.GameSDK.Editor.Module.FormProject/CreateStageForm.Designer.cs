namespace Lofinil.GameSDK.Editor.Module.Project
{
    partial class CreateStageForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.btn_browseScene = new System.Windows.Forms.Button();
            this.tb_sceneName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_comfirm = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "路径";
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(41, 5);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(263, 21);
            this.tb_path.TabIndex = 1;
            // 
            // btn_browseScene
            // 
            this.btn_browseScene.Location = new System.Drawing.Point(307, 3);
            this.btn_browseScene.Name = "btn_browseScene";
            this.btn_browseScene.Size = new System.Drawing.Size(45, 23);
            this.btn_browseScene.TabIndex = 2;
            this.btn_browseScene.Text = "浏览";
            this.btn_browseScene.UseVisualStyleBackColor = true;
            this.btn_browseScene.Click += new System.EventHandler(this.btn_browseScene_Click);
            // 
            // tb_sceneName
            // 
            this.tb_sceneName.Location = new System.Drawing.Point(41, 35);
            this.tb_sceneName.Name = "tb_sceneName";
            this.tb_sceneName.Size = new System.Drawing.Size(263, 21);
            this.tb_sceneName.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "名称";
            // 
            // btn_comfirm
            // 
            this.btn_comfirm.Location = new System.Drawing.Point(201, 75);
            this.btn_comfirm.Name = "btn_comfirm";
            this.btn_comfirm.Size = new System.Drawing.Size(75, 23);
            this.btn_comfirm.TabIndex = 5;
            this.btn_comfirm.Text = "确定";
            this.btn_comfirm.UseVisualStyleBackColor = true;
            this.btn_comfirm.Click += new System.EventHandler(this.btn_comfirm_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(277, 75);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // CreateSceneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 105);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_comfirm);
            this.Controls.Add(this.tb_sceneName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_browseScene);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.label1);
            this.Name = "CreateSceneForm";
            this.Text = "创建场景";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button btn_browseScene;
        private System.Windows.Forms.TextBox tb_sceneName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_comfirm;
        private System.Windows.Forms.Button btn_cancel;
    }
}