using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor;

namespace Lofinil.GameSDK.Editor.App
{
    public partial class WizardForm : Form, IWizardView
    {
        private WizardModule wizardMod;

        public WizardForm()
        {
            InitializeComponent();

            wizardMod = EditorService.Instance.QueryModule<WizardModule>();            
        }

        public void ShowView()
        {
            this.ShowDialog();
        }

        public void HideView()
        {
            this.Hide();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void AddYesNoChooser(string name, string text, bool initChoice)
        {
            customControl.AddCheckBox(name, text, initChoice);
        }

        public bool GetYesOrNo(string name)
        {
            return customControl.GetCheckBoxChecked(name);
        }

        public void AddPickOneChooser(string name, string[] options, int initCheck)
        {
            customControl.AddRadioGroup(name, options, initCheck);
        }

        public int GetPickedOne(string name)
        {
            return customControl.GetRadioGroupChecked(name);
        }

        public void AddPickOneChooser2(string name, string[] options, int initVal)
        {
            customControl.AddComboBox(name, options, initVal);
        }

        public string GetPickedOne2(string name)
        {
            return customControl.GetComboBoxText(name);
        }

        public void AddCommander(string text, Action callBack)
        {
            customControl.AddButton(text, callBack);
        }

        public void Clear()
        {
            customControl.Clear();
        }

        public void AddInput(string name, string title, string initVal)
        {
            customControl.AddTextBox(name, title, initVal);
        }

        public string GetInput(string name)
        {
            return customControl.GetTextBoxText(name);
        }

        public void AddPathInput(string name, string title, string initVal)
        {
            customControl.AddPathInput(name, title, initVal);
        }

        public string GetPathInput(string name)
        {
            return customControl.GetPathInput(name);
        }

        public void AddFileInput(string name, string title, string initVal, string filter)
        {
            customControl.AddFileInput(name, title, initVal, filter);
        }

        public string GetFileInput(string name)
        {
            return customControl.GetFileInput(name);
        }

        public void SetTitle(string title)
        {
            this.Text = title;
        }


        public void AddInformation(string info)
        {
            customControl.AddMultiLineLabel(info);
        }

        public void OnPageChanged(WizardModule mgr, int curPageNum)
        {
            if (mgr.IsFirstPage(curPageNum))
            {
                btnLast.Visible = false;
                btnNext.Text = "下一页";
            }
            else if (mgr.IsLastPage(curPageNum))
            {
                btnNext.Text = "完成";
            }
            else 
            {
                btnLast.Visible = true;
                btnLast.Text = "上一页";
                btnNext.Visible = true;
                btnNext.Text = "下一页";
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            wizardMod.LastPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            wizardMod.NextPage();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            wizardMod.Cancel();
        }
    }
}
