namespace LofiEditor.Forms
{
    partial class ItemEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditForm));
            this.btn_editAnim = new System.Windows.Forms.Button();
            this.btn_transformTexture = new System.Windows.Forms.Button();
            this.btn_rotateTexture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.prg_info = new System.Windows.Forms.PropertyGrid();
            this.btn_transformBody = new System.Windows.Forms.Button();
            this.btn_rotateBody = new System.Windows.Forms.Button();
            this.trb_zoom = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_idle = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chb_showGrid = new System.Windows.Forms.CheckBox();
            this.btn_pan = new System.Windows.Forms.Button();
            this.chb_showTexture = new System.Windows.Forms.CheckBox();
            this.chb_showBody = new System.Windows.Forms.CheckBox();
            this.itemEditorControl1 = new LofiEditor.Forms.ItemEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.trb_zoom)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_editAnim
            // 
            this.btn_editAnim.Image = ((System.Drawing.Image)(resources.GetObject("btn_editAnim.Image")));
            this.btn_editAnim.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_editAnim.Location = new System.Drawing.Point(7, 166);
            this.btn_editAnim.Name = "btn_editAnim";
            this.btn_editAnim.Size = new System.Drawing.Size(31, 31);
            this.btn_editAnim.TabIndex = 100;
            this.btn_editAnim.UseVisualStyleBackColor = true;
            this.btn_editAnim.Click += new System.EventHandler(this.btn_editAnim_Click);
            // 
            // btn_transformTexture
            // 
            this.btn_transformTexture.Image = ((System.Drawing.Image)(resources.GetObject("btn_transformTexture.Image")));
            this.btn_transformTexture.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_transformTexture.Location = new System.Drawing.Point(7, 92);
            this.btn_transformTexture.Name = "btn_transformTexture";
            this.btn_transformTexture.Size = new System.Drawing.Size(31, 32);
            this.btn_transformTexture.TabIndex = 95;
            this.btn_transformTexture.UseVisualStyleBackColor = true;
            this.btn_transformTexture.Click += new System.EventHandler(this.btn_transformTexture_Click);
            // 
            // btn_rotateTexture
            // 
            this.btn_rotateTexture.Enabled = false;
            this.btn_rotateTexture.Image = ((System.Drawing.Image)(resources.GetObject("btn_rotateTexture.Image")));
            this.btn_rotateTexture.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_rotateTexture.Location = new System.Drawing.Point(7, 129);
            this.btn_rotateTexture.Name = "btn_rotateTexture";
            this.btn_rotateTexture.Size = new System.Drawing.Size(31, 31);
            this.btn_rotateTexture.TabIndex = 93;
            this.btn_rotateTexture.UseVisualStyleBackColor = true;
            this.btn_rotateTexture.Click += new System.EventHandler(this.btn_rotateTexture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 101;
            this.label1.Text = "Component Property - AnimTexture";
            // 
            // prg_info
            // 
            this.prg_info.Location = new System.Drawing.Point(616, 23);
            this.prg_info.Name = "prg_info";
            this.prg_info.Size = new System.Drawing.Size(215, 521);
            this.prg_info.TabIndex = 102;
            // 
            // btn_transformBody
            // 
            this.btn_transformBody.Image = ((System.Drawing.Image)(resources.GetObject("btn_transformBody.Image")));
            this.btn_transformBody.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_transformBody.Location = new System.Drawing.Point(7, 222);
            this.btn_transformBody.Name = "btn_transformBody";
            this.btn_transformBody.Size = new System.Drawing.Size(31, 32);
            this.btn_transformBody.TabIndex = 105;
            this.btn_transformBody.UseVisualStyleBackColor = true;
            this.btn_transformBody.Click += new System.EventHandler(this.btn_transformBody_Click);
            // 
            // btn_rotateBody
            // 
            this.btn_rotateBody.Enabled = false;
            this.btn_rotateBody.Image = ((System.Drawing.Image)(resources.GetObject("btn_rotateBody.Image")));
            this.btn_rotateBody.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_rotateBody.Location = new System.Drawing.Point(7, 259);
            this.btn_rotateBody.Name = "btn_rotateBody";
            this.btn_rotateBody.Size = new System.Drawing.Size(31, 31);
            this.btn_rotateBody.TabIndex = 103;
            this.btn_rotateBody.UseVisualStyleBackColor = true;
            this.btn_rotateBody.Click += new System.EventHandler(this.btn_rotateBody_Click);
            // 
            // trb_zoom
            // 
            this.trb_zoom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trb_zoom.Location = new System.Drawing.Point(68, 549);
            this.trb_zoom.Maximum = 3000;
            this.trb_zoom.Minimum = 125;
            this.trb_zoom.Name = "trb_zoom";
            this.trb_zoom.Size = new System.Drawing.Size(104, 45);
            this.trb_zoom.TabIndex = 113;
            this.trb_zoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trb_zoom.Value = 125;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(44, 547);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 114;
            this.button1.Text = "、";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(170, 547);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 115;
            this.button2.Text = "、";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_idle
            // 
            this.btn_idle.Image = ((System.Drawing.Image)(resources.GetObject("btn_idle.Image")));
            this.btn_idle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_idle.Location = new System.Drawing.Point(7, 3);
            this.btn_idle.Name = "btn_idle";
            this.btn_idle.Size = new System.Drawing.Size(31, 31);
            this.btn_idle.TabIndex = 116;
            this.btn_idle.UseVisualStyleBackColor = true;
            this.btn_idle.Click += new System.EventHandler(this.btn_idle_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(634, 550);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 117;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(735, 550);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 118;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 551);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 119;
            this.label2.Text = "X: 1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 551);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 120;
            this.label3.Text = "Y: 1000";
            // 
            // chb_showGrid
            // 
            this.chb_showGrid.AutoSize = true;
            this.chb_showGrid.Checked = true;
            this.chb_showGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_showGrid.Location = new System.Drawing.Point(536, 551);
            this.chb_showGrid.Name = "chb_showGrid";
            this.chb_showGrid.Size = new System.Drawing.Size(72, 16);
            this.chb_showGrid.TabIndex = 121;
            this.chb_showGrid.Text = "ShowGrid";
            this.chb_showGrid.UseVisualStyleBackColor = true;
            this.chb_showGrid.CheckedChanged += new System.EventHandler(this.chb_showGrid_CheckedChanged);
            // 
            // btn_pan
            // 
            this.btn_pan.Image = ((System.Drawing.Image)(resources.GetObject("btn_pan.Image")));
            this.btn_pan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_pan.Location = new System.Drawing.Point(7, 40);
            this.btn_pan.Name = "btn_pan";
            this.btn_pan.Size = new System.Drawing.Size(31, 31);
            this.btn_pan.TabIndex = 122;
            this.btn_pan.UseVisualStyleBackColor = true;
            this.btn_pan.Click += new System.EventHandler(this.btn_pan_Click);
            // 
            // chb_showTexture
            // 
            this.chb_showTexture.AutoSize = true;
            this.chb_showTexture.Checked = true;
            this.chb_showTexture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_showTexture.Location = new System.Drawing.Point(366, 550);
            this.chb_showTexture.Name = "chb_showTexture";
            this.chb_showTexture.Size = new System.Drawing.Size(90, 16);
            this.chb_showTexture.TabIndex = 123;
            this.chb_showTexture.Text = "ShowTexture";
            this.chb_showTexture.UseVisualStyleBackColor = true;
            this.chb_showTexture.CheckedChanged += new System.EventHandler(this.chb_showTexture_CheckedChanged);
            // 
            // chb_showBody
            // 
            this.chb_showBody.AutoSize = true;
            this.chb_showBody.Checked = true;
            this.chb_showBody.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_showBody.Location = new System.Drawing.Point(462, 551);
            this.chb_showBody.Name = "chb_showBody";
            this.chb_showBody.Size = new System.Drawing.Size(72, 16);
            this.chb_showBody.TabIndex = 124;
            this.chb_showBody.Text = "ShowBody";
            this.chb_showBody.UseVisualStyleBackColor = true;
            this.chb_showBody.CheckedChanged += new System.EventHandler(this.chb_showBody_CheckedChanged);
            // 
            // itemEditorControl1
            // 
            this.itemEditorControl1.Location = new System.Drawing.Point(44, 6);
            this.itemEditorControl1.Name = "itemEditorControl1";
            this.itemEditorControl1.Size = new System.Drawing.Size(564, 538);
            this.itemEditorControl1.TabIndex = 0;
            this.itemEditorControl1.Text = "itemEditorControl1";
            // 
            // ItemEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 572);
            this.Controls.Add(this.chb_showBody);
            this.Controls.Add(this.chb_showTexture);
            this.Controls.Add(this.btn_pan);
            this.Controls.Add(this.chb_showGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_idle);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trb_zoom);
            this.Controls.Add(this.btn_transformBody);
            this.Controls.Add(this.btn_rotateBody);
            this.Controls.Add(this.prg_info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_editAnim);
            this.Controls.Add(this.btn_transformTexture);
            this.Controls.Add(this.btn_rotateTexture);
            this.Controls.Add(this.itemEditorControl1);
            this.Name = "ItemEditForm";
            this.Text = "ItemEditorForm";
            this.Load += new System.EventHandler(this.ItemEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trb_zoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ItemEditControl itemEditorControl1;
        private System.Windows.Forms.Button btn_editAnim;
        private System.Windows.Forms.Button btn_transformTexture;
        private System.Windows.Forms.Button btn_rotateTexture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PropertyGrid prg_info;
        private System.Windows.Forms.Button btn_transformBody;
        private System.Windows.Forms.Button btn_rotateBody;
        private System.Windows.Forms.TrackBar trb_zoom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_idle;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chb_showGrid;
        private System.Windows.Forms.Button btn_pan;
        private System.Windows.Forms.CheckBox chb_showTexture;
        private System.Windows.Forms.CheckBox chb_showBody;
    }
}