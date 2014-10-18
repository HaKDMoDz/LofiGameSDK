using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LofiEngine.Items;
using LofiEditor.Forms;

namespace LofiEditor.Forms
{
    public partial class ItemEditForm : Form
    {
        public Item Item 
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

            Item = new Item();
            Item.AnimTexture = new AnimTexture("Common/Item");
            Item.PhysicsBody = new PhysicsBody();
        }

        public ItemEditForm(Item item)
        {
            InitializeComponent();
        }

        private void ItemEditorForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_idle_Click(object sender, EventArgs e)
        {
            EditMode = ItemEditControl.EEditMode.Idle;
            prg_info.SelectedObject = Item;
        }

        private void btn_pan_Click(object sender, EventArgs e)
        {
            EditMode = ItemEditControl.EEditMode.Pan;
        }

        private void btn_transformTexture_Click(object sender, EventArgs e)
        {
            EditMode = ItemEditControl.EEditMode.TransformTexture;
            prg_info.SelectedObject = Item.AnimTexture;
        }

        private void btn_rotateTexture_Click(object sender, EventArgs e)
        {
            EditMode = ItemEditControl.EEditMode.RotateTexture;
        }

        private void btn_editAnim_Click(object sender, EventArgs e)
        {
            AnimEditeForm aef = new AnimEditeForm();
            aef.SetAnimTexture(Item.AnimTexture);
            DialogResult dr = aef.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Item.AnimTexture = aef.AnimTexture;
            }
        }

        private void btn_transformBody_Click(object sender, EventArgs e)
        {
            EditMode = ItemEditControl.EEditMode.TransformBody;
            prg_info.SelectedObject = Item.PhysicsBody;
        }

        private void btn_rotateBody_Click(object sender, EventArgs e)
        {
            EditMode = ItemEditControl.EEditMode.RotateBody;
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
