using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LofiEditor.Forms;
using Lofinil.GameSDK.Engine;

namespace LofiEditor.Forms
{
    // ItemEditor 用于编辑组件各层级空间变换 和层级组件的增减
    // 它不对对象的组件做任何要求
    public partial class ItemEditForm : Form
    {
        public AbstractComponent Item 
        {
            get { return itemEditorControl1.CurrentItem; }
            set { itemEditorControl1.CurrentItem = value; }
        }

        public ItemEditControl.EEditMode EditMode 
        {
            get { return itemEditorControl1.EditMode; }
            set { itemEditorControl1.EditMode = value; }
        }

        public ItemEditForm()
        {
            InitializeComponent();

            Item = null;

        }

        public ItemEditForm(AbstractComponent item)
        {
            InitializeComponent();
        }

        private void ItemEditorForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_idle_Click(object sender, EventArgs e)
        {
            EditMode = ItemEditControl.EEditMode.Idle;
        }

        private void btn_pan_Click(object sender, EventArgs e)
        {
            EditMode = ItemEditControl.EEditMode.Pan;
        }

        private void btn_transformTexture_Click(object sender, EventArgs e)
        {
            EditMode = ItemEditControl.EEditMode.Transform;
        }

        private void btn_rotateTexture_Click(object sender, EventArgs e)
        {
            EditMode = ItemEditControl.EEditMode.RotateTexture;
        }

        private void btn_editAnim_Click(object sender, EventArgs e)
        {
            AnimEditForm aef = new AnimEditForm();
            aef.ShowEditor(Item);
        }

        private void chb_showTexture_CheckedChanged(object sender, EventArgs e)
        {
            itemEditorControl1.ShowTexture = chb_showTexture.Checked;
        }

        private void chb_showBody_CheckedChanged(object sender, EventArgs e)
        {
            itemEditorControl1.ShowBody = chb_showBody.Checked;
        }

        private void chb_showGrid_CheckedChanged(object sender, EventArgs e)
        {
            itemEditorControl1.ShowGrid = chb_showGrid.Checked;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
