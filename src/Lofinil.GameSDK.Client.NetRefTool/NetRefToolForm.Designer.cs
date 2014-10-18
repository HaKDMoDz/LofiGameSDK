namespace NetRefTool
{
    partial class NetRefToolForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lsbModules = new System.Windows.Forms.ListBox();
            this.lsbComponents = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "管理模块";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "游戏组件";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lsbModules, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lsbComponents, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(418, 418);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // lsbModules
            // 
            this.lsbModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbModules.FormattingEnabled = true;
            this.lsbModules.HorizontalScrollbar = true;
            this.lsbModules.ItemHeight = 12;
            this.lsbModules.Location = new System.Drawing.Point(3, 3);
            this.lsbModules.Name = "lsbModules";
            this.lsbModules.Size = new System.Drawing.Size(191, 412);
            this.lsbModules.TabIndex = 6;
            this.lsbModules.SelectedIndexChanged += new System.EventHandler(this.lsbModules_SelectedIndexChanged);
            this.lsbModules.DoubleClick += new System.EventHandler(this.lsbModules_DoubleClick);
            // 
            // lsbComponents
            // 
            this.lsbComponents.FormattingEnabled = true;
            this.lsbComponents.ItemHeight = 12;
            this.lsbComponents.Location = new System.Drawing.Point(200, 3);
            this.lsbComponents.Name = "lsbComponents";
            this.lsbComponents.Size = new System.Drawing.Size(215, 412);
            this.lsbComponents.TabIndex = 2;
            this.lsbComponents.SelectedIndexChanged += new System.EventHandler(this.lsbComponents_SelectedIndexChanged);
            this.lsbComponents.DoubleClick += new System.EventHandler(this.lsbComponents_DoubleClick);
            // 
            // NetRefToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 490);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NetRefToolForm";
            this.Text = "程序集分析定制工具";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lsbComponents;
        private System.Windows.Forms.ListBox lsbModules;
    }
}

