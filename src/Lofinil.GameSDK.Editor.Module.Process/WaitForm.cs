using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Lofinil.GameSDK.Editor;

namespace Lofinil.GameSDK.Editor.App
{
    public partial class WaitForm : Form, IWaitView
    {
        public static WaitForm Instance { get { if (inst == null) inst = new WaitForm(); return inst; } }
        private static WaitForm inst;

        private WaitForm()
        {
            InitializeComponent();
        }

        private Action taskBeginCallback;

        public void StartTask()
        {
            taskBeginCallback();
            this.ShowDialog();
        }

        public void SetTaskBeginCallback(Action c)
        {
            taskBeginCallback = c;
        }

        public void TextInfoCallback(string info)
        {
            this.Invoke(new Action(delegate { tbInfo.Text += info; }));
            
        }


        public void TaskEndCallback(int code)
        {
            if (code == 0)
            {
                this.Invoke(new Action(delegate { this.Hide(); }));
            }
            else
            {
                this.Invoke(new Action(delegate { btnClose.Enabled = false; }));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void WaitForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                btnClose.Enabled = false;
                tbInfo.Text = "";
            }
        }
    }
}
