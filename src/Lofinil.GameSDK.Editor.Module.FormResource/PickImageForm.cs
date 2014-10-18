using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Lofinil.GameSDK.Editor;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor.Interception.ModuleInterface;
using Lofinil.GameSDK.Editor.Module.Project;

namespace LofiEditor.SupportForms
{
    public partial class PickImageForm : Form
    {
        enum FormMode
        {
            Select,
            Preview,
            Scissor,
        }

        private FormMode formMode = FormMode.Select;

        public String TexturePath;

        public ReferTextureData TexRefData;

        public PickImageForm()
        {
            InitializeComponent();
            texViewControl1.lsvTexture.SelectedIndexChanged += delegate { updateSelect(); };

            texScissor1.SsrCtrl = scissorControl1;
            scissorControl1.TexSsr = texScissor1;

            TexRefData = new ReferTextureData();
        }

        private void PickTextureForm_Load(object sender, EventArgs e)
        {

        }

        private void setFormMode(FormMode mode)
        {
            formMode = mode;
            if(mode == FormMode.Select)
            {
                tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanel1.ColumnStyles[0].Width = Math.Max(tableLayoutPanel1.Width - 85,0);
                tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Absolute;
                tableLayoutPanel1.ColumnStyles[1].Width = 45;
                tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.Absolute;
                tableLayoutPanel1.ColumnStyles[2].Width = 45;

            }
            else if(mode == FormMode.Preview)
            {
                tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanel1.ColumnStyles[0].Width = 45;
                tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Absolute;
                tableLayoutPanel1.ColumnStyles[1].Width = Math.Max(tableLayoutPanel1.Width - 85,0);
                tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.Absolute;
                tableLayoutPanel1.ColumnStyles[2].Width = 45;
            }
            else if(mode == FormMode.Scissor)
            {
                tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanel1.ColumnStyles[0].Width = 45;
                tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Absolute;
                tableLayoutPanel1.ColumnStyles[1].Width = 45;
                tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.Absolute;
                tableLayoutPanel1.ColumnStyles[2].Width = Math.Max(tableLayoutPanel1.Width - 85, 0);
            }
        }

        private void pnlSelect_Click(object sender, EventArgs e)
        {
            setFormMode(FormMode.Select);
        }

        private void pnlPreview_Click(object sender, EventArgs e)
        {
            setFormMode(FormMode.Preview);
        }

        private void pnlScissor_Click(object sender, EventArgs e)
        {
            setFormMode(FormMode.Scissor);
        }

        private void PickTextureForm_SizeChanged(object sender, EventArgs e)
        {
            setFormMode(formMode);
        }

        private void PickTextureForm_Shown(object sender, EventArgs e)
        {
        }

        private void updateSelect()
        {
            if (texViewControl1.lsvTexture.SelectedItems.Count > 0)
            {
                ListViewItem item = texViewControl1.lsvTexture.SelectedItems[0];
                String srcFile = item.SubItems[0].Text;
                texScissor1.ImageLocation = Path.Combine(EditorService.Instance.QueryModule<ProjectModule>(null).CurProjDir, EditorService.Instance.QueryModule<ProjectModule>(null).CurProject.ResourcePath, srcFile);
                setFormMode(FormMode.Preview);
                texScissor1.ClearSel();

                TexRefData.Key = item.SubItems[2].Text;
                TexRefData.UID = int.Parse(item.SubItems[1].Text);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
                setFormMode(FormMode.Scissor);
            else if (me.Button == MouseButtons.Right)
                setFormMode(FormMode.Select);
        }

        private void btn_ok_Click_1(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void texScissor1_SelChanged(object sender, EventArgs e)
        {
            TexRefData.SrcRect = texScissor1.CurSel;
        }
    }
}
