using Lofinil.GameSDK.Editor.App;
namespace Lofinil.GameSDK.Editor.Module.FormToolBox
{
    partial class ContextToolBox
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
            this.customControl = new Lofinil.GameSDK.Editor.App.CustomControl();
            this.SuspendLayout();
            // 
            // customControl
            // 
            this.customControl.ControlDock = System.Windows.Forms.DockStyle.Left;
            this.customControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customControl.Location = new System.Drawing.Point(0, 0);
            this.customControl.Name = "customControl";
            this.customControl.Size = new System.Drawing.Size(651, 26);
            this.customControl.TabIndex = 0;
            // 
            // ContextToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customControl);
            this.Name = "ContextToolBox";
            this.Size = new System.Drawing.Size(651, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControl customControl;

    }
}
