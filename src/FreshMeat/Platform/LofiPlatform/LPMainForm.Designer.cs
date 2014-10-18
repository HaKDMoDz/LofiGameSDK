using LofiEngine;
namespace MiniPlatform
{
    partial class LPMainForm
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
            this.gameControl1 = new LofiEngine.GameControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lsb_games = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameControl1
            // 
            this.gameControl1.Location = new System.Drawing.Point(154, 18);
            this.gameControl1.Name = "gameControl1";
            this.gameControl1.Size = new System.Drawing.Size(420, 340);
            this.gameControl1.TabIndex = 0;
            this.gameControl1.Text = "gameControl1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game List";
            // 
            // lsb_games
            // 
            this.lsb_games.FormattingEnabled = true;
            this.lsb_games.ItemHeight = 12;
            this.lsb_games.Location = new System.Drawing.Point(5, 18);
            this.lsb_games.Name = "lsb_games";
            this.lsb_games.Size = new System.Drawing.Size(143, 340);
            this.lsb_games.TabIndex = 2;
            this.lsb_games.DoubleClick += new System.EventHandler(this.lsb_games_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = " [Double click to start]";
            // 
            // MPMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 379);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsb_games);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameControl1);
            this.Name = "MPMainForm";
            this.Text = "Mini Platform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GameControl gameControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsb_games;
        private System.Windows.Forms.Label label2;


    }
}

