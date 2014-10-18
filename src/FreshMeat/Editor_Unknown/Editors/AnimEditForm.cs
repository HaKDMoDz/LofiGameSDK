using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LofiEngine.Items;
using LofiEngine.Helpers;
using LofiEditor.Controls;
using LofiEditor.SupportForms;

namespace LofiEditor.Forms
{
    public partial class AnimEditeForm : Form
    {
        #region Variables
        public AnimTexture AnimTexture { get { return anv_anim.AnimTexture; } }
        #endregion

        public AnimEditeForm()
        {
            InitializeComponent();
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {
        }

        private void btn_browseTexture_Click(object sender, EventArgs e)
        {
            PickTextureForm ptf = new PickTextureForm();
            DialogResult dr = ptf.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tte_texture.SetTexture(ptf.TexturePath);
                if (anv_anim.AnimTexture == null)
                    anv_anim.AnimTexture = new AnimTexture(ptf.TexturePath);
                else
                    anv_anim.AnimTexture.TexturePath = ptf.TexturePath;
                ppg_textureInfo.SelectedObject = anv_anim.AnimTexture;
                // Load Sequences
                lsb_animSequences.Items.Clear();
                List<String> seqNames = anv_anim.AnimTexture.GetSeqNames();
                foreach (String name in seqNames)
                {
                    lsb_animSequences.Items.Add(name);
                }
            }
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
            AnimSequence animSeq = new AnimSequence();
            animSeq.Name = name;
            anv_anim.AnimTexture.AnimSeqList.Add(animSeq);
            lsb_animSequences.Items.Add(name);
        }

        private void btn_deleteSequence_Click(object sender, EventArgs e)
        {
            Object selectedItem = lsb_animSequences.SelectedItem;
            if (selectedItem != null)
            {
                String name = lsb_animSequences.SelectedItem.ToString();
                AnimSequence animSeq = anv_anim.AnimTexture.GetSeq(name);
                anv_anim.AnimTexture.AnimSeqList.Remove(animSeq);
                lsb_animSequences.Items.Remove(selectedItem);
            }
        }

        private void lsb_animSequences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsb_animSequences.SelectedItem == null)
                return;
            String name = lsb_animSequences.SelectedItem.ToString();
            AnimSequence animSeq = anv_anim.AnimTexture.GetSeq(name);
            ppg_animSeq.SelectedObject = animSeq;

        }

        private void tte_texture_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void tte_texture_MouseMove(object sender, MouseEventArgs e)
        {
            if (anv_anim.AnimTexture != null && tte_texture.Texture != null)
            {
                if (tte_texture.SourceRect.Width > 0 && tte_texture.SourceRect.Height > 0)
                    anv_anim.AnimTexture.SourceRect = tte_texture.SourceRect;
            }
        }

        private void tte_texture_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                if(anv_anim.AnimTexture != null)
                    anv_anim.AnimTexture.Origin = tte_texture.Origin;
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            if(ppg_animSeq.SelectedObject != null)
            {
                String seqName = ((AnimSequence)ppg_animSeq.SelectedObject).Name;
                anv_anim.AnimTexture.PlaySeq(seqName);
            }
        }

        public void SetAnimTexture(AnimTexture animTexture)
        {
            tte_texture.TexturePath = animTexture.TexturePath;
            anv_anim.AnimTexture = animTexture;
        }
    }
}
