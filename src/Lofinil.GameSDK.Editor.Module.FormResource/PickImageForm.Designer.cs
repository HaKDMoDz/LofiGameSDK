using Lofinil.GameSDK.Editor.App;
namespace LofiEditor.SupportForms
{
    partial class PickImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickImageForm));
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pnlScissor = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.texScissor1 = new LofiEditor.ImageScissor();
            this.scissorControl1 = new LofiEditor.ScissorControl();
            this.texViewControl1 = new Lofinil.GameSDK.Editor.App.ImageSetControl();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.pnlScissor.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texScissor1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_ok);
            this.panel4.Controls.Add(this.btn_cancel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 406);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(659, 35);
            this.panel4.TabIndex = 34;
            // 
            // btn_ok
            // 
            this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_ok.Location = new System.Drawing.Point(491, 0);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(84, 35);
            this.btn_ok.TabIndex = 36;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click_1);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cancel.Location = new System.Drawing.Point(575, 0);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(84, 35);
            this.btn_cancel.TabIndex = 35;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.Controls.Add(this.panel9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(659, 406);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.Control;
            this.panel9.Controls.Add(this.pnlScissor);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(442, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(214, 400);
            this.panel9.TabIndex = 30;
            // 
            // pnlScissor
            // 
            this.pnlScissor.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlScissor.Controls.Add(this.label6);
            this.pnlScissor.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlScissor.Location = new System.Drawing.Point(0, 0);
            this.pnlScissor.Name = "pnlScissor";
            this.pnlScissor.Size = new System.Drawing.Size(37, 400);
            this.pnlScissor.TabIndex = 30;
            this.pnlScissor.Click += new System.EventHandler(this.pnlScissor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 56);
            this.label6.TabIndex = 28;
            this.label6.Text = "裁\r\n剪\r\n记\r\n录";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.pnlPreview);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(216, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(220, 400);
            this.panel6.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.texScissor1);
            this.panel2.Controls.Add(this.scissorControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(37, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 400);
            this.panel2.TabIndex = 34;
            // 
            // pnlPreview
            // 
            this.pnlPreview.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlPreview.Controls.Add(this.label4);
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPreview.Location = new System.Drawing.Point(0, 0);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(37, 400);
            this.pnlPreview.TabIndex = 30;
            this.pnlPreview.Click += new System.EventHandler(this.pnlPreview_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 56);
            this.label4.TabIndex = 28;
            this.label4.Text = "裁\r\n剪\r\n处\r\n理";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.texViewControl1);
            this.panel1.Controls.Add(this.pnlSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 400);
            this.panel1.TabIndex = 28;
            // 
            // pnlSelect
            // 
            this.pnlSelect.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlSelect.Controls.Add(this.label5);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSelect.Location = new System.Drawing.Point(0, 0);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(37, 400);
            this.pnlSelect.TabIndex = 30;
            this.pnlSelect.Click += new System.EventHandler(this.pnlSelect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 56);
            this.label5.TabIndex = 28;
            this.label5.Text = "选\r\n择\r\n文\r\n件\r\n";
            // 
            // texScissor1
            // 
            this.texScissor1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("texScissor1.BackgroundImage")));
            this.texScissor1.CurSel = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.texScissor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.texScissor1.Location = new System.Drawing.Point(0, 30);
            this.texScissor1.Name = "texScissor1";
            this.texScissor1.Size = new System.Drawing.Size(183, 370);
            this.texScissor1.TabIndex = 35;
            this.texScissor1.TabStop = false;
            this.texScissor1.SelChanged += new System.EventHandler(this.texScissor1_SelChanged);
            // 
            // scissorControl1
            // 
            this.scissorControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.scissorControl1.Location = new System.Drawing.Point(0, 0);
            this.scissorControl1.Name = "scissorControl1";
            this.scissorControl1.Size = new System.Drawing.Size(183, 30);
            this.scissorControl1.TabIndex = 34;
            // 
            // texViewControl1
            // 
            this.texViewControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.texViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.texViewControl1.Location = new System.Drawing.Point(37, 0);
            this.texViewControl1.Name = "texViewControl1";
            this.texViewControl1.Size = new System.Drawing.Size(170, 400);
            this.texViewControl1.TabIndex = 31;
            // 
            // PickTextureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Name = "PickTextureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择图片";
            this.Load += new System.EventHandler(this.PickTextureForm_Load);
            this.Shown += new System.EventHandler(this.PickTextureForm_Shown);
            this.SizeChanged += new System.EventHandler(this.PickTextureForm_SizeChanged);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.pnlScissor.ResumeLayout(false);
            this.pnlScissor.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texScissor1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel pnlScissor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private ImageSetControl texViewControl1;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Panel panel2;
        private ScissorControl scissorControl1;
        private ImageScissor texScissor1;


    }
}