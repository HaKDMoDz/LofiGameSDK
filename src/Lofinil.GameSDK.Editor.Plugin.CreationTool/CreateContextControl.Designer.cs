namespace Lofinil.GameSDK.Editor.App
{
    partial class CreateContextControl
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
            this.lbCompName = new System.Windows.Forms.Label();
            this.lbTexName = new System.Windows.Forms.Label();
            this.imagePicker1 = new Lofinil.GameSDK.Editor.Module.FormResource.ImagePicker();
            this.componentPicker1 = new Lofinil.GameSDK.Editor.Module.FormComponent.ComponentPicker();
            ((System.ComponentModel.ISupportInitialize)(this.imagePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentPicker1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCompName
            // 
            this.lbCompName.AutoSize = true;
            this.lbCompName.Location = new System.Drawing.Point(75, 61);
            this.lbCompName.Name = "lbCompName";
            this.lbCompName.Size = new System.Drawing.Size(53, 12);
            this.lbCompName.TabIndex = 134;
            this.lbCompName.Text = "组件名称";
            // 
            // lbTexName
            // 
            this.lbTexName.AutoSize = true;
            this.lbTexName.Location = new System.Drawing.Point(4, 58);
            this.lbTexName.Name = "lbTexName";
            this.lbTexName.Size = new System.Drawing.Size(53, 12);
            this.lbTexName.TabIndex = 133;
            this.lbTexName.Text = "纹理名称";
            // 
            // imagePicker1
            // 
            this.imagePicker1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.imagePicker1.Location = new System.Drawing.Point(3, 3);
            this.imagePicker1.Name = "imagePicker1";
            this.imagePicker1.Size = new System.Drawing.Size(54, 52);
            this.imagePicker1.TabIndex = 136;
            this.imagePicker1.TabStop = false;
            this.imagePicker1.Click += new System.EventHandler(this.imagePicker1_Click);
            // 
            // componentPicker1
            // 
            this.componentPicker1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.componentPicker1.Location = new System.Drawing.Point(74, 3);
            this.componentPicker1.Name = "componentPicker1";
            this.componentPicker1.Size = new System.Drawing.Size(54, 52);
            this.componentPicker1.TabIndex = 137;
            this.componentPicker1.TabStop = false;
            this.componentPicker1.Click += new System.EventHandler(this.componentPicker1_Click);
            // 
            // CreateContextControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.componentPicker1);
            this.Controls.Add(this.imagePicker1);
            this.Controls.Add(this.lbCompName);
            this.Controls.Add(this.lbTexName);
            this.Name = "CreateContextControl";
            this.Size = new System.Drawing.Size(132, 89);
            ((System.ComponentModel.ISupportInitialize)(this.imagePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentPicker1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCompName;
        private System.Windows.Forms.Label lbTexName;
        public Module.FormResource.ImagePicker imagePicker1;
        public Module.FormComponent.ComponentPicker componentPicker1;
    }
}
