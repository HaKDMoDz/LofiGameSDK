using Lofinil.GameSDK.LofiEditor;
using Lofinil.GameSDK.Engine.WinControl;
namespace LofiEditor.Forms
{
    partial class AnimEditForm
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
            this.components = new System.ComponentModel.Container();
            this.btn_browseTexture = new System.Windows.Forms.Button();
            this.lsb_animSequences = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_addSequence = new System.Windows.Forms.Button();
            this.btn_deleteSequence = new System.Windows.Forms.Button();
            this.ppg_textureInfo = new System.Windows.Forms.PropertyGrid();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_stepForward = new System.Windows.Forms.Button();
            this.btn_stepBackward = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.ppg_animSeq = new System.Windows.Forms.PropertyGrid();
            this.cms_tInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSourceRectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editOriginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tODO将该选单整合进控件中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tte_texture = new Lofinil.GameSDK.LofiEditor.TextureEditor();
            this.anv_anim = new XNAControl();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.cms_tInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_browseTexture
            // 
            this.btn_browseTexture.Location = new System.Drawing.Point(1, 350);
            this.btn_browseTexture.Name = "btn_browseTexture";
            this.btn_browseTexture.Size = new System.Drawing.Size(100, 23);
            this.btn_browseTexture.TabIndex = 0;
            this.btn_browseTexture.Text = "浏览...";
            this.btn_browseTexture.UseVisualStyleBackColor = true;
            this.btn_browseTexture.Click += new System.EventHandler(this.btn_browseTexture_Click);
            // 
            // lsb_animSequences
            // 
            this.lsb_animSequences.FormattingEnabled = true;
            this.lsb_animSequences.ItemHeight = 12;
            this.lsb_animSequences.Location = new System.Drawing.Point(372, 370);
            this.lsb_animSequences.Name = "lsb_animSequences";
            this.lsb_animSequences.Size = new System.Drawing.Size(111, 124);
            this.lsb_animSequences.TabIndex = 4;
            this.lsb_animSequences.SelectedIndexChanged += new System.EventHandler(this.lsb_animSequences_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "动画序列";
            // 
            // btn_addSequence
            // 
            this.btn_addSequence.Location = new System.Drawing.Point(489, 495);
            this.btn_addSequence.Name = "btn_addSequence";
            this.btn_addSequence.Size = new System.Drawing.Size(104, 23);
            this.btn_addSequence.TabIndex = 6;
            this.btn_addSequence.Text = "添加";
            this.btn_addSequence.UseVisualStyleBackColor = true;
            this.btn_addSequence.Click += new System.EventHandler(this.btn_addSequence_Click);
            // 
            // btn_deleteSequence
            // 
            this.btn_deleteSequence.Location = new System.Drawing.Point(372, 495);
            this.btn_deleteSequence.Name = "btn_deleteSequence";
            this.btn_deleteSequence.Size = new System.Drawing.Size(111, 23);
            this.btn_deleteSequence.TabIndex = 7;
            this.btn_deleteSequence.Text = "删除";
            this.btn_deleteSequence.UseVisualStyleBackColor = true;
            this.btn_deleteSequence.Click += new System.EventHandler(this.btn_deleteSequence_Click);
            // 
            // ppg_textureInfo
            // 
            this.ppg_textureInfo.Location = new System.Drawing.Point(115, 350);
            this.ppg_textureInfo.Name = "ppg_textureInfo";
            this.ppg_textureInfo.Size = new System.Drawing.Size(246, 219);
            this.ppg_textureInfo.TabIndex = 12;
            this.ppg_textureInfo.Click += new System.EventHandler(this.propertyGrid1_Click);
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(418, 546);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(40, 23);
            this.btn_play.TabIndex = 14;
            this.btn_play.Text = "播放";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // btn_stepForward
            // 
            this.btn_stepForward.Location = new System.Drawing.Point(464, 546);
            this.btn_stepForward.Name = "btn_stepForward";
            this.btn_stepForward.Size = new System.Drawing.Size(40, 23);
            this.btn_stepForward.TabIndex = 15;
            this.btn_stepForward.Text = "最后";
            this.btn_stepForward.UseVisualStyleBackColor = true;
            // 
            // btn_stepBackward
            // 
            this.btn_stepBackward.Location = new System.Drawing.Point(372, 546);
            this.btn_stepBackward.Name = "btn_stepBackward";
            this.btn_stepBackward.Size = new System.Drawing.Size(40, 23);
            this.btn_stepBackward.TabIndex = 16;
            this.btn_stepBackward.Text = "开始";
            this.btn_stepBackward.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(372, 524);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(178, 45);
            this.trackBar1.TabIndex = 17;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(657, 547);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 20;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(576, 547);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 19;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // ppg_animSeq
            // 
            this.ppg_animSeq.Location = new System.Drawing.Point(489, 350);
            this.ppg_animSeq.Name = "ppg_animSeq";
            this.ppg_animSeq.Size = new System.Drawing.Size(243, 144);
            this.ppg_animSeq.TabIndex = 22;
            // 
            // cms_tInfo
            // 
            this.cms_tInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.editSourceRectangleToolStripMenuItem,
            this.editOriginToolStripMenuItem,
            this.toolStripSeparator1,
            this.tODO将该选单整合进控件中ToolStripMenuItem});
            this.cms_tInfo.Name = "cms_tInfo";
            this.cms_tInfo.Size = new System.Drawing.Size(237, 120);
            this.cms_tInfo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cms_tInfo_ItemClicked);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.viewToolStripMenuItem.Text = "查看";
            // 
            // editSourceRectangleToolStripMenuItem
            // 
            this.editSourceRectangleToolStripMenuItem.Name = "editSourceRectangleToolStripMenuItem";
            this.editSourceRectangleToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.editSourceRectangleToolStripMenuItem.Text = "编辑源矩形";
            // 
            // editOriginToolStripMenuItem
            // 
            this.editOriginToolStripMenuItem.Name = "editOriginToolStripMenuItem";
            this.editOriginToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.editOriginToolStripMenuItem.Text = "设置原点";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(233, 6);
            // 
            // tODO将该选单整合进控件中ToolStripMenuItem
            // 
            this.tODO将该选单整合进控件中ToolStripMenuItem.Name = "tODO将该选单整合进控件中ToolStripMenuItem";
            this.tODO将该选单整合进控件中ToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.tODO将该选单整合进控件中ToolStripMenuItem.Text = "TODO 将该选单整合进控件中";
            // 
            // tte_texture
            // 
            this.tte_texture.ContextMenuStrip = this.cms_tInfo;
            this.tte_texture.Location = new System.Drawing.Point(5, 2);
            this.tte_texture.Name = "tte_texture";
            this.tte_texture.Size = new System.Drawing.Size(360, 342);
            this.tte_texture.TabIndex = 24;
            this.tte_texture.TexturePath = null;
            this.tte_texture.Click += new System.EventHandler(this.tte_texture_Click);
            this.tte_texture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tte_texture_MouseMove);
            this.tte_texture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tte_texture_MouseUp);
            // 
            // anv_anim
            // 
            this.anv_anim.Location = new System.Drawing.Point(372, 2);
            this.anv_anim.Name = "anv_anim";
            this.anv_anim.Size = new System.Drawing.Size(360, 342);
            this.anv_anim.TabIndex = 25;
            this.anv_anim.Update += new System.EventHandler(this.anv_anim_Update);
            this.anv_anim.Draw += new System.EventHandler(this.anv_anim_Draw);
            // 
            // AnimEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 575);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Controls.Add(this.anv_anim);
            this.Controls.Add(this.tte_texture);
            this.Controls.Add(this.ppg_animSeq);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_stepBackward);
            this.Controls.Add(this.btn_stepForward);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.ppg_textureInfo);
            this.Controls.Add(this.btn_deleteSequence);
            this.Controls.Add(this.btn_addSequence);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsb_animSequences);
            this.Controls.Add(this.btn_browseTexture);
            this.Name = "AnimEditForm";
            this.Text = "逐帧动画编辑器";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.cms_tInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_browseTexture;
        private System.Windows.Forms.ListBox lsb_animSequences;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_addSequence;
        private System.Windows.Forms.Button btn_deleteSequence;
        private System.Windows.Forms.PropertyGrid ppg_textureInfo;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_stepForward;
        private System.Windows.Forms.Button btn_stepBackward;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.PropertyGrid ppg_animSeq;
        private System.Windows.Forms.ContextMenuStrip cms_tInfo;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSourceRectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editOriginToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private TextureEditor tte_texture;
        private System.Windows.Forms.ToolStripMenuItem tODO将该选单整合进控件中ToolStripMenuItem;
        private XNAControl anv_anim;
    }
}