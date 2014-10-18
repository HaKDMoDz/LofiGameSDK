namespace Lofinil.GameSDK.Editor.Module.FormToolBox
{
    partial class ToolSettingForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolBoxControl2 = new ToolBoxControl();
            this.dialogButtonControl1 = new Lofinil.GameSDK.Editor.App.GUI.Utility.DialogButtonControl();
            this.toolBoxControl1 = new ToolBoxControl();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(75, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(475, 29);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "将右侧的工具按钮拖拽到左侧以更改主界面工具条。";
            // 
            // toolBoxControl2
            // 
            this.toolBoxControl2.AutoScroll = true;
            this.toolBoxControl2.AutoSize = true;
            this.toolBoxControl2.BackColor = System.Drawing.SystemColors.Control;
            this.toolBoxControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBoxControl2.Location = new System.Drawing.Point(75, 29);
            this.toolBoxControl2.MinimumSize = new System.Drawing.Size(75, 0);
            this.toolBoxControl2.Name = "toolBoxControl2";
            this.toolBoxControl2.Size = new System.Drawing.Size(475, 282);
            this.toolBoxControl2.TabIndex = 5;
            // 
            // dialogButtonControl1
            // 
            this.dialogButtonControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dialogButtonControl1.Location = new System.Drawing.Point(75, 311);
            this.dialogButtonControl1.MinimumSize = new System.Drawing.Size(0, 40);
            this.dialogButtonControl1.Name = "dialogButtonControl1";
            this.dialogButtonControl1.Size = new System.Drawing.Size(475, 40);
            this.dialogButtonControl1.TabIndex = 3;
            // 
            // toolBoxControl1
            // 
            this.toolBoxControl1.AutoScroll = true;
            this.toolBoxControl1.AutoSize = true;
            this.toolBoxControl1.BackColor = System.Drawing.SystemColors.Desktop;
            this.toolBoxControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.toolBoxControl1.MinimumSize = new System.Drawing.Size(75, 0);
            this.toolBoxControl1.Name = "toolBoxControl1";
            this.toolBoxControl1.Size = new System.Drawing.Size(75, 351);
            this.toolBoxControl1.TabIndex = 0;
            // 
            // ToolSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 351);
            this.Controls.Add(this.toolBoxControl2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dialogButtonControl1);
            this.Controls.Add(this.toolBoxControl1);
            this.Name = "ToolSettingForm";
            this.Text = "自定义工具箱";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolBoxControl toolBoxControl1;
        private Lofinil.GameSDK.Editor.App.GUI.Utility.DialogButtonControl dialogButtonControl1;
        private System.Windows.Forms.TextBox textBox1;
        private ToolBoxControl toolBoxControl2;
    }
}