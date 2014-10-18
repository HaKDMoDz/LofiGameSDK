
using Lofinil.GameSDK.Engine.WinControl;
namespace EngineTest
{
    partial class TestForm1
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
            this.xnaControl1 = new XNAControl();
            this.SuspendLayout();
            // 
            // xnaControl1
            // 
            this.xnaControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xnaControl1.Location = new System.Drawing.Point(0, 0);
            this.xnaControl1.Name = "xnaControl1";
            this.xnaControl1.Size = new System.Drawing.Size(258, 275);
            this.xnaControl1.TabIndex = 0;
            this.xnaControl1.Text = "xnaControl1";
            this.xnaControl1.Update += new System.EventHandler(this.xnaControl1_Update);
            this.xnaControl1.Draw += new System.EventHandler(this.xnaControl1_Draw);
            // 
            // TestForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 275);
            this.Controls.Add(this.xnaControl1);
            this.Name = "TestForm1";
            this.Text = "测试1";
            this.Load += new System.EventHandler(this.TestForm1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private XNAControl xnaControl1;
    }
}

