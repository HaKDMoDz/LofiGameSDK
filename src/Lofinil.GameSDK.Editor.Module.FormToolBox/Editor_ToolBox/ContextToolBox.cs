using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor;

namespace Lofinil.GameSDK.Editor.Module.FormToolBox
{
    partial class ContextToolBox : UserControl, ICustomView
    {
        public ContextToolBox()
        {
            InitializeComponent();
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

        public int GetPickedOne(String name)
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


        public void AddCommander(string text, Action callBack)
        {
            customControl.AddButton(text, callBack);
        }


        public void SetTitle(string title)
        {
            
        }


        public void AddInformation(string info)
        {
            throw new NotImplementedException();
        }
    }
}
