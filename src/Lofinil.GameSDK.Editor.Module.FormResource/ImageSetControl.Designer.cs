namespace Lofinil.GameSDK.Editor.App
{
    partial class ImageSetControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSetControl));
            this.lsvTexture = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.rbTile = new System.Windows.Forms.RadioButton();
            this.rbDetail = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvTexture
            // 
            this.lsvTexture.BackColor = System.Drawing.SystemColors.Control;
            this.lsvTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvTexture.Location = new System.Drawing.Point(0, 30);
            this.lsvTexture.Name = "lsvTexture";
            this.lsvTexture.Size = new System.Drawing.Size(352, 297);
            this.lsvTexture.TabIndex = 8;
            this.lsvTexture.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbFilter);
            this.panel1.Controls.Add(this.rbTile);
            this.panel1.Controls.Add(this.rbDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 30);
            this.panel1.TabIndex = 7;
            // 
            // tbFilter
            // 
            this.tbFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbFilter.Location = new System.Drawing.Point(160, 0);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(192, 21);
            this.tbFilter.TabIndex = 3;
            this.tbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            // 
            // rbTile
            // 
            this.rbTile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbTile.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbTile.AutoSize = true;
            this.rbTile.Image = ((System.Drawing.Image)(resources.GetObject("rbTile.Image")));
            this.rbTile.Location = new System.Drawing.Point(27, 5);
            this.rbTile.Name = "rbTile";
            this.rbTile.Size = new System.Drawing.Size(22, 22);
            this.rbTile.TabIndex = 1;
            this.rbTile.UseVisualStyleBackColor = true;
            this.rbTile.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbDetail
            // 
            this.rbDetail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbDetail.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDetail.Checked = true;
            this.rbDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbDetail.ImageKey = "(无)";
            this.rbDetail.Location = new System.Drawing.Point(3, 5);
            this.rbDetail.Name = "rbDetail";
            this.rbDetail.Size = new System.Drawing.Size(22, 22);
            this.rbDetail.TabIndex = 0;
            this.rbDetail.TabStop = true;
            this.rbDetail.UseVisualStyleBackColor = true;
            this.rbDetail.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // TexViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsvTexture);
            this.Controls.Add(this.panel1);
            this.Name = "TexViewControl";
            this.Size = new System.Drawing.Size(352, 327);
            this.Load += new System.EventHandler(this.TexViewControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.RadioButton rbTile;
        private System.Windows.Forms.RadioButton rbDetail;
        public System.Windows.Forms.ListView lsvTexture;

    }
}
