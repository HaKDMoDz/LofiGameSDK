using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lofinil.GameSDK.Editor.App
{
    public partial class RefGridSettingForm : Form
    {
        public RefGridSetting RefGridSetting;

        public RefGridSettingForm()
        {
            InitializeComponent();
        }

        private void RefGridSettingForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                switch(RefGridSetting.OriginMode)
                {
                    case RefGridOriginMode.TopLeftOfView:
                        rbTopLeftOfView.Checked = true;
                        break;
                    case RefGridOriginMode.CenterOfView:
                        rbCenterOfView.Checked = true;
                        break;
                    case RefGridOriginMode.CenterOfStage:
                        rbCenterOfStage.Checked = true;
                        break;
                }
                switch(RefGridSetting.UnitMode)
                {
                    case RefGridUnitMode.PixelOfScreen:
                        rbUnitPixel.Checked = true;
                        break;
                    case RefGridUnitMode.UseGameUnit:
                        rbUnitGame.Checked = true;
                        break;
                }
                tbRowStep.Text = RefGridSetting.RowStep.ToString();
                tbColumnStep.Text = RefGridSetting.ColumnStep.ToString();
                tbSnapGap.Text = RefGridSetting.SnapGap.ToString();
                cbShow.Checked = RefGridSetting.ShowGrid;
                cbSnap.Checked = RefGridSetting.SnapToGrid;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            RefGridSetting.RowStep = int.Parse(tbRowStep.Text.Trim());
            RefGridSetting.ColumnStep = int.Parse(tbColumnStep.Text.Trim());
            RefGridSetting.SnapGap = int.Parse(tbSnapGap.Text.Trim());

            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void rbTopLeftOfView_CheckedChanged(object sender, EventArgs e)
        {
            RefGridSetting.OriginMode = RefGridOriginMode.TopLeftOfView;
        }

        private void rbCenterOfView_CheckedChanged(object sender, EventArgs e)
        {
            RefGridSetting.OriginMode = RefGridOriginMode.CenterOfView;
        }

        private void rbCenterOfStage_CheckedChanged(object sender, EventArgs e)
        {
            RefGridSetting.OriginMode = RefGridOriginMode.CenterOfStage;
        }

        private void rbUnitPixel_CheckedChanged(object sender, EventArgs e)
        {
            RefGridSetting.UnitMode = RefGridUnitMode.PixelOfScreen;
        }

        private void rbUnitGame_CheckedChanged(object sender, EventArgs e)
        {
            RefGridSetting.UnitMode = RefGridUnitMode.UseGameUnit;
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            RefGridSetting.ShowGrid = cbShow.Checked;
        }

        private void cbSnap_CheckedChanged(object sender, EventArgs e)
        {
            RefGridSetting.SnapToGrid = cbSnap.Checked;
        }
    }

    public enum RefGridOriginMode
    {
        TopLeftOfView,
        CenterOfView,
        CenterOfStage,
    }

    public enum RefGridUnitMode
    {
        PixelOfScreen,
        UseGameUnit,
    }

    public class RefGridSetting
    {
        public RefGridOriginMode OriginMode;

        public RefGridUnitMode UnitMode;

        public float RowStep;

        public float ColumnStep;

        public float SnapGap;

        public bool ShowGrid;

        public bool SnapToGrid;

        public RefGridSetting()
        {
            OriginMode = RefGridOriginMode.TopLeftOfView;
            UnitMode = RefGridUnitMode.PixelOfScreen;
            RowStep = 80;
            ColumnStep = 80;
            SnapGap = 5;
            ShowGrid = true;
            SnapToGrid = false;
        }

        // TODO 寻找从外部实现浅层拷贝的方法
        public RefGridSetting ShallowCopy()
        {
            return (RefGridSetting)this.MemberwiseClone();
        }
    }

}
