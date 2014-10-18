namespace LofiEditor.Editors
{
    partial class ConfigControlForm
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
            this.lsb_gameKeys = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_loadConfig = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.btn_saveConfig = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_clearKey = new System.Windows.Forms.Button();
            this.btn_clearAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsb_gameKeys
            // 
            this.lsb_gameKeys.FormattingEnabled = true;
            this.lsb_gameKeys.ItemHeight = 12;
            this.lsb_gameKeys.Location = new System.Drawing.Point(3, 16);
            this.lsb_gameKeys.Name = "lsb_gameKeys";
            this.lsb_gameKeys.Size = new System.Drawing.Size(174, 172);
            this.lsb_gameKeys.TabIndex = 0;
            this.lsb_gameKeys.SelectedIndexChanged += new System.EventHandler(this.lsb_gameKeys_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game Keys";
            // 
            // btn_loadConfig
            // 
            this.btn_loadConfig.Enabled = false;
            this.btn_loadConfig.Location = new System.Drawing.Point(201, 151);
            this.btn_loadConfig.Name = "btn_loadConfig";
            this.btn_loadConfig.Size = new System.Drawing.Size(106, 23);
            this.btn_loadConfig.TabIndex = 2;
            this.btn_loadConfig.Text = "Load Config...";
            this.btn_loadConfig.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Keyboard";
            // 
            // tb_key
            // 
            this.tb_key.Location = new System.Drawing.Point(3, 211);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(174, 21);
            this.tb_key.TabIndex = 5;
            this.tb_key.Text = "Press a key ...";
            this.tb_key.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_key_KeyUp);
            // 
            // btn_saveConfig
            // 
            this.btn_saveConfig.Enabled = false;
            this.btn_saveConfig.Location = new System.Drawing.Point(201, 180);
            this.btn_saveConfig.Name = "btn_saveConfig";
            this.btn_saveConfig.Size = new System.Drawing.Size(106, 23);
            this.btn_saveConfig.TabIndex = 6;
            this.btn_saveConfig.Text = "Save Config...";
            this.btn_saveConfig.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(201, 251);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(106, 23);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "Close";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_clearKey
            // 
            this.btn_clearKey.Location = new System.Drawing.Point(201, 12);
            this.btn_clearKey.Name = "btn_clearKey";
            this.btn_clearKey.Size = new System.Drawing.Size(106, 23);
            this.btn_clearKey.TabIndex = 9;
            this.btn_clearKey.Text = "Clear Key";
            this.btn_clearKey.UseVisualStyleBackColor = true;
            this.btn_clearKey.Click += new System.EventHandler(this.btn_clearKey_Click);
            // 
            // btn_clearAll
            // 
            this.btn_clearAll.Location = new System.Drawing.Point(201, 41);
            this.btn_clearAll.Name = "btn_clearAll";
            this.btn_clearAll.Size = new System.Drawing.Size(106, 23);
            this.btn_clearAll.TabIndex = 9;
            this.btn_clearAll.Text = "Clear All";
            this.btn_clearAll.UseVisualStyleBackColor = true;
            this.btn_clearAll.Click += new System.EventHandler(this.btn_clearAll_Click);
            // 
            // ConfigControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 276);
            this.Controls.Add(this.btn_clearAll);
            this.Controls.Add(this.btn_clearKey);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_saveConfig);
            this.Controls.Add(this.tb_key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_loadConfig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsb_gameKeys);
            this.Name = "ConfigControlForm";
            this.Text = "ConfigControlForm";
            this.Load += new System.EventHandler(this.ConfigControlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsb_gameKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_loadConfig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.Button btn_saveConfig;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_clearKey;
        private System.Windows.Forms.Button btn_clearAll;
    }
}