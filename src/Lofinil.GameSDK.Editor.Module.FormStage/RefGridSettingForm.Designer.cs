namespace Lofinil.GameSDK.Editor.App
{
    partial class RefGridSettingForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCenterOfStage = new System.Windows.Forms.RadioButton();
            this.rbCenterOfView = new System.Windows.Forms.RadioButton();
            this.rbTopLeftOfView = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbUnitGame = new System.Windows.Forms.RadioButton();
            this.rbUnitPixel = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRowStep = new System.Windows.Forms.TextBox();
            this.tbColumnStep = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbSnapGap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbShow = new System.Windows.Forms.CheckBox();
            this.cbSnap = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCenterOfStage);
            this.groupBox1.Controls.Add(this.rbCenterOfView);
            this.groupBox1.Controls.Add(this.rbTopLeftOfView);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原点";
            // 
            // rbCenterOfStage
            // 
            this.rbCenterOfStage.AutoSize = true;
            this.rbCenterOfStage.Location = new System.Drawing.Point(208, 20);
            this.rbCenterOfStage.Name = "rbCenterOfStage";
            this.rbCenterOfStage.Size = new System.Drawing.Size(71, 16);
            this.rbCenterOfStage.TabIndex = 2;
            this.rbCenterOfStage.TabStop = true;
            this.rbCenterOfStage.Text = "舞台中心";
            this.rbCenterOfStage.UseVisualStyleBackColor = true;
            this.rbCenterOfStage.CheckedChanged += new System.EventHandler(this.rbCenterOfStage_CheckedChanged);
            // 
            // rbCenterOfView
            // 
            this.rbCenterOfView.AutoSize = true;
            this.rbCenterOfView.Location = new System.Drawing.Point(107, 20);
            this.rbCenterOfView.Name = "rbCenterOfView";
            this.rbCenterOfView.Size = new System.Drawing.Size(71, 16);
            this.rbCenterOfView.TabIndex = 1;
            this.rbCenterOfView.TabStop = true;
            this.rbCenterOfView.Text = "视图中心";
            this.rbCenterOfView.UseVisualStyleBackColor = true;
            this.rbCenterOfView.CheckedChanged += new System.EventHandler(this.rbCenterOfView_CheckedChanged);
            // 
            // rbTopLeftOfView
            // 
            this.rbTopLeftOfView.AutoSize = true;
            this.rbTopLeftOfView.Location = new System.Drawing.Point(6, 20);
            this.rbTopLeftOfView.Name = "rbTopLeftOfView";
            this.rbTopLeftOfView.Size = new System.Drawing.Size(83, 16);
            this.rbTopLeftOfView.TabIndex = 0;
            this.rbTopLeftOfView.TabStop = true;
            this.rbTopLeftOfView.Text = "视图左上角";
            this.rbTopLeftOfView.UseVisualStyleBackColor = true;
            this.rbTopLeftOfView.CheckedChanged += new System.EventHandler(this.rbTopLeftOfView_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbUnitGame);
            this.groupBox2.Controls.Add(this.rbUnitPixel);
            this.groupBox2.Location = new System.Drawing.Point(13, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 47);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "单位类型";
            // 
            // rbUnitGame
            // 
            this.rbUnitGame.AutoSize = true;
            this.rbUnitGame.Location = new System.Drawing.Point(107, 25);
            this.rbUnitGame.Name = "rbUnitGame";
            this.rbUnitGame.Size = new System.Drawing.Size(71, 16);
            this.rbUnitGame.TabIndex = 4;
            this.rbUnitGame.TabStop = true;
            this.rbUnitGame.Text = "游戏单位";
            this.rbUnitGame.UseVisualStyleBackColor = true;
            this.rbUnitGame.CheckedChanged += new System.EventHandler(this.rbUnitGame_CheckedChanged);
            // 
            // rbUnitPixel
            // 
            this.rbUnitPixel.AutoSize = true;
            this.rbUnitPixel.Location = new System.Drawing.Point(6, 25);
            this.rbUnitPixel.Name = "rbUnitPixel";
            this.rbUnitPixel.Size = new System.Drawing.Size(71, 16);
            this.rbUnitPixel.TabIndex = 3;
            this.rbUnitPixel.TabStop = true;
            this.rbUnitPixel.Text = "屏幕像素";
            this.rbUnitPixel.UseVisualStyleBackColor = true;
            this.rbUnitPixel.CheckedChanged += new System.EventHandler(this.rbUnitPixel_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "行间隔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "列间隔";
            // 
            // tbRowStep
            // 
            this.tbRowStep.Location = new System.Drawing.Point(69, 114);
            this.tbRowStep.Name = "tbRowStep";
            this.tbRowStep.Size = new System.Drawing.Size(89, 21);
            this.tbRowStep.TabIndex = 4;
            // 
            // tbColumnStep
            // 
            this.tbColumnStep.Location = new System.Drawing.Point(69, 142);
            this.tbColumnStep.Name = "tbColumnStep";
            this.tbColumnStep.Size = new System.Drawing.Size(89, 21);
            this.tbColumnStep.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(238, 219);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(330, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbSnapGap
            // 
            this.tbSnapGap.Location = new System.Drawing.Point(69, 169);
            this.tbSnapGap.Name = "tbSnapGap";
            this.tbSnapGap.Size = new System.Drawing.Size(89, 21);
            this.tbSnapGap.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "吸附距离";
            // 
            // cbShow
            // 
            this.cbShow.AutoSize = true;
            this.cbShow.Location = new System.Drawing.Point(221, 119);
            this.cbShow.Name = "cbShow";
            this.cbShow.Size = new System.Drawing.Size(48, 16);
            this.cbShow.TabIndex = 10;
            this.cbShow.Text = "显示";
            this.cbShow.UseVisualStyleBackColor = true;
            this.cbShow.CheckedChanged += new System.EventHandler(this.cbShow_CheckedChanged);
            // 
            // cbSnap
            // 
            this.cbSnap.AutoSize = true;
            this.cbSnap.Location = new System.Drawing.Point(300, 119);
            this.cbSnap.Name = "cbSnap";
            this.cbSnap.Size = new System.Drawing.Size(48, 16);
            this.cbSnap.TabIndex = 11;
            this.cbSnap.Text = "吸附";
            this.cbSnap.UseVisualStyleBackColor = true;
            this.cbSnap.CheckedChanged += new System.EventHandler(this.cbSnap_CheckedChanged);
            // 
            // RefGridSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 242);
            this.Controls.Add(this.cbSnap);
            this.Controls.Add(this.cbShow);
            this.Controls.Add(this.tbSnapGap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbColumnStep);
            this.Controls.Add(this.tbRowStep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RefGridSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参考网格设置";
            this.VisibleChanged += new System.EventHandler(this.RefGridSettingForm_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCenterOfStage;
        private System.Windows.Forms.RadioButton rbCenterOfView;
        private System.Windows.Forms.RadioButton rbTopLeftOfView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbUnitGame;
        private System.Windows.Forms.RadioButton rbUnitPixel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRowStep;
        private System.Windows.Forms.TextBox tbColumnStep;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbSnapGap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbShow;
        private System.Windows.Forms.CheckBox cbSnap;
    }
}