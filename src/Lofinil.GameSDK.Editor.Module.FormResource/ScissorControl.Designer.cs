namespace LofiEditor
{
    partial class ScissorControl
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
            this.btnSelAll = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.cbTransSnag = new System.Windows.Forms.CheckBox();
            this.cbRuler = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSelAll
            // 
            this.btnSelAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelAll.Location = new System.Drawing.Point(0, 0);
            this.btnSelAll.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnSelAll.Name = "btnSelAll";
            this.btnSelAll.Size = new System.Drawing.Size(55, 26);
            this.btnSelAll.TabIndex = 0;
            this.btnSelAll.Text = "全选区";
            this.btnSelAll.UseVisualStyleBackColor = true;
            this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImport.Location = new System.Drawing.Point(55, 0);
            this.btnImport.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(43, 26);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnInput
            // 
            this.btnInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInput.Location = new System.Drawing.Point(98, 0);
            this.btnInput.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(43, 26);
            this.btnInput.TabIndex = 5;
            this.btnInput.Text = "输入";
            this.btnInput.UseVisualStyleBackColor = true;
            // 
            // cbTransSnag
            // 
            this.cbTransSnag.AutoSize = true;
            this.cbTransSnag.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbTransSnag.Location = new System.Drawing.Point(189, 0);
            this.cbTransSnag.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cbTransSnag.Name = "cbTransSnag";
            this.cbTransSnag.Size = new System.Drawing.Size(72, 26);
            this.cbTransSnag.TabIndex = 7;
            this.cbTransSnag.Text = "透明吸附";
            this.cbTransSnag.UseVisualStyleBackColor = true;
            // 
            // cbRuler
            // 
            this.cbRuler.AutoSize = true;
            this.cbRuler.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbRuler.Location = new System.Drawing.Point(141, 0);
            this.cbRuler.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cbRuler.Name = "cbRuler";
            this.cbRuler.Size = new System.Drawing.Size(48, 26);
            this.cbRuler.TabIndex = 6;
            this.cbRuler.Text = "标尺";
            this.cbRuler.UseVisualStyleBackColor = true;
            // 
            // ScissorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbTransSnag);
            this.Controls.Add(this.cbRuler);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnSelAll);
            this.Name = "ScissorControl";
            this.Size = new System.Drawing.Size(269, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelAll;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.CheckBox cbTransSnag;
        private System.Windows.Forms.CheckBox cbRuler;
    }
}
