using LofiEditor.Controls;
namespace LofiEditor.SupportForms
{
    partial class PickTextureForm
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
            this.trv_textures = new System.Windows.Forms.TreeView();
            this.btn_ok = new System.Windows.Forms.Button();
            this.lbl_height = new System.Windows.Forms.Label();
            this.lbl_width = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.ttb_textureShow = new LofiEditor.Controls.TextureBox();
            this.rdb_normal = new System.Windows.Forms.RadioButton();
            this.rdb_zoom = new System.Windows.Forms.RadioButton();
            this.rdb_stretch = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trv_textures
            // 
            this.trv_textures.Location = new System.Drawing.Point(2, 24);
            this.trv_textures.Name = "trv_textures";
            this.trv_textures.Size = new System.Drawing.Size(208, 323);
            this.trv_textures.TabIndex = 3;
            this.trv_textures.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trv_textures_NodeMouseClick);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(245, 329);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(84, 27);
            this.btn_ok.TabIndex = 17;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lbl_height
            // 
            this.lbl_height.AutoSize = true;
            this.lbl_height.Location = new System.Drawing.Point(255, 271);
            this.lbl_height.Name = "lbl_height";
            this.lbl_height.Size = new System.Drawing.Size(23, 12);
            this.lbl_height.TabIndex = 16;
            this.lbl_height.Text = "---";
            // 
            // lbl_width
            // 
            this.lbl_width.AutoSize = true;
            this.lbl_width.Location = new System.Drawing.Point(255, 250);
            this.lbl_width.Name = "lbl_width";
            this.lbl_width.Size = new System.Drawing.Size(23, 12);
            this.lbl_width.TabIndex = 15;
            this.lbl_width.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "高度:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "宽度:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "预览";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(365, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 40);
            this.button2.TabIndex = 10;
            this.button2.Text = "颜色叠加";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-1, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "选择文件";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(336, 329);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(84, 27);
            this.btn_cancel.TabIndex = 19;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // ttb_textureShow
            // 
            this.ttb_textureShow.Location = new System.Drawing.Point(215, 24);
            this.ttb_textureShow.Name = "ttb_textureShow";
            this.ttb_textureShow.Size = new System.Drawing.Size(205, 198);
            this.ttb_textureShow.TabIndex = 20;
            this.ttb_textureShow.Text = "textureBox1";
            // 
            // rdb_normal
            // 
            this.rdb_normal.AutoSize = true;
            this.rdb_normal.Checked = true;
            this.rdb_normal.Location = new System.Drawing.Point(257, 222);
            this.rdb_normal.Name = "rdb_normal";
            this.rdb_normal.Size = new System.Drawing.Size(47, 16);
            this.rdb_normal.TabIndex = 21;
            this.rdb_normal.TabStop = true;
            this.rdb_normal.Text = "正常";
            this.rdb_normal.UseVisualStyleBackColor = true;
            this.rdb_normal.CheckedChanged += new System.EventHandler(this.rdb_normal_CheckedChanged);
            // 
            // rdb_zoom
            // 
            this.rdb_zoom.AutoSize = true;
            this.rdb_zoom.Location = new System.Drawing.Point(310, 222);
            this.rdb_zoom.Name = "rdb_zoom";
            this.rdb_zoom.Size = new System.Drawing.Size(47, 16);
            this.rdb_zoom.TabIndex = 22;
            this.rdb_zoom.Text = "适应";
            this.rdb_zoom.UseVisualStyleBackColor = true;
            this.rdb_zoom.Click += new System.EventHandler(this.rdb_zoom_Click);
            // 
            // rdb_stretch
            // 
            this.rdb_stretch.AutoSize = true;
            this.rdb_stretch.Location = new System.Drawing.Point(363, 222);
            this.rdb_stretch.Name = "rdb_stretch";
            this.rdb_stretch.Size = new System.Drawing.Size(47, 16);
            this.rdb_stretch.TabIndex = 23;
            this.rdb_stretch.Text = "拉伸";
            this.rdb_stretch.UseVisualStyleBackColor = true;
            this.rdb_stretch.Click += new System.EventHandler(this.rdb_stretch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "比例";
            // 
            // PickTextureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 359);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rdb_stretch);
            this.Controls.Add(this.rdb_zoom);
            this.Controls.Add(this.rdb_normal);
            this.Controls.Add(this.ttb_textureShow);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_height);
            this.Controls.Add(this.lbl_width);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.trv_textures);
            this.Name = "PickTextureForm";
            this.Text = "TexturePicker";
            this.Load += new System.EventHandler(this.PickTextureForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trv_textures;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lbl_height;
        private System.Windows.Forms.Label lbl_width;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_cancel;
        private TextureBox ttb_textureShow;
        private System.Windows.Forms.RadioButton rdb_normal;
        private System.Windows.Forms.RadioButton rdb_zoom;
        private System.Windows.Forms.RadioButton rdb_stretch;
        private System.Windows.Forms.Label label7;

    }
}