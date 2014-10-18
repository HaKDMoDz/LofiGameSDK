using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lofinil.GameSDK.LofiEditor;
using Lofinil.GameSDK.Engine;

namespace LofiEditor.Forms
{
    // 组件要求：动画编辑器要求具备FrameAnimator和Sprite组件
    public partial class AnimEditForm : Form
    {
        // 必要组件
        protected FrameAnimator FAnim;
        protected Sprite Sprite;

        public AbstractComponent Comp;

        public AnimEditForm()
        {
            InitializeComponent();
        }

        public void ShowEditor(AbstractComponent comp)
        {
            FAnim = comp.GetCompByType(typeof(FrameAnimator)) as FrameAnimator;
            Sprite = comp.GetCompByType(typeof(Sprite)) as Sprite;

            if (FAnim != null && Sprite != null)
            {
                this.Show();
            }
            else
            {
                FAnim = null;
                Sprite = null;
                MessageBox.Show("AnimEditor必要组件：FrameAnimator、Sprite");
            }
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {
        }

        private void btn_browseTexture_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        //    PickTextureForm ptf = new PickTextureForm();
        //    DialogResult dr = ptf.ShowDialog();
        //    if (dr == DialogResult.OK)
        //    {
        //        tte_texture.SetTexture(ptf.TexturePath);
        //        Sprite.Texture = new BaseTexture(ptf.TexturePath);

        //        ppg_textureInfo.SelectedObject = Comp;
        //        // Load Sequences
        //        lsb_animSequences.Items.Clear();

        //        foreach (FrameSequence fs in FAnim.FrameSeqList)
        //            lsb_animSequences.Items.Add(fs.Name);
        //    }
        }

        private void cms_tInfo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "View":
                    tte_texture.EditMode = TextureEditor.EEditMode.None;
                    break;
                case "Edit Source Rectangle":
                    tte_texture.EditMode = TextureEditor.EEditMode.SourceRectangle;
                    break;
                case "Edit Origin":
                    tte_texture.EditMode = TextureEditor.EEditMode.Origin;
                    break;

            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_addSequence_Click(object sender, EventArgs e)
        {
            // default name
            String name = "Default";
            for(int i=0;i<1000; i++)
            {
                bool nameUsed = false;
                foreach(String seqName in lsb_animSequences.Items)
                {
                    if (seqName == "Default" + i)
                    {
                        nameUsed = true;
                        break;
                    }
                }
                if (!nameUsed)
                {
                    name = "Default" + i;
                    break;
                }
            }
            FrameSequence animSeq = new FrameSequence();
            animSeq.Name = name;
            FAnim.FrameSeqList.Add(animSeq);
            lsb_animSequences.Items.Add(name);
        }

        private void btn_deleteSequence_Click(object sender, EventArgs e)
        {
            Object selectedItem = lsb_animSequences.SelectedItem;
            if (selectedItem != null)
            {
                String name = lsb_animSequences.SelectedItem.ToString();
                FrameSequence animSeq = FAnim.GetSeq(name);
                FAnim.FrameSeqList.Remove(animSeq);
                lsb_animSequences.Items.Remove(selectedItem);
            }
        }

        private void lsb_animSequences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsb_animSequences.SelectedItem == null)
                return;
            String name = lsb_animSequences.SelectedItem.ToString();
            FrameSequence animSeq = FAnim.GetSeq(name);
            ppg_animSeq.SelectedObject = animSeq;

        }

        private void tte_texture_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void tte_texture_MouseMove(object sender, MouseEventArgs e)
        {
            Microsoft.Xna.Framework.Rectangle srcRect = tte_texture.SourceRect;
            if (Comp != null && String.IsNullOrEmpty(tte_texture.TexturePath))
            {
                // UNDONE [鼠标反托矩形计算]
                if (srcRect.Width > 0 && srcRect.Height > 0)
                    Sprite.Texture.SourceRect = tte_texture.SourceRect;
            }
        }

        private void tte_texture_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                // UNDONE [设置采样原点]
                //if (Item != null)
                    //Sprite.Origin = tte_texture.Origin;
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            if(ppg_animSeq.SelectedObject != null)
            {
                String seqName = ((FrameSequence)ppg_animSeq.SelectedObject).Name;
                FAnim.PlaySeq(seqName);
            }
        }

        private void anv_anim_Draw(object sender, EventArgs e)
        {
            if (Comp == null)
                return;

            GameManager.Instance.GraphicsMgr.DrawBegin();
            Comp.Draw();
            GameManager.Instance.GraphicsMgr.DrawEnd();
        }

        private void anv_anim_Update(object sender, EventArgs e)
        {
            if (Comp != null)
                Comp.Update();
        }
    }
}
