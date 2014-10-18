using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Lofinil.GameSDK.Engine;

namespace NetRefTool
{
    public partial class NetRefToolForm : Form
    {
        Assembly ass;
        Type[] allTypes;

        public NetRefToolForm()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ass = Assembly.Load("LofiEngine");
            allTypes = ass.GetTypes();

            RefreshModule();
            RefreshComponent();
        }

        private void RefreshModule()
        {
            lsbModules.Items.Clear();
            foreach (Type t in allTypes)
            {
                if (NETFramework.IsModule(t))
                    lsbModules.Items.Add(t);
            }
        }

        private void RefreshComponent()
        {
            lsbComponents.Items.Clear();

            foreach (Type t in allTypes)
            {
                if (NETFramework.IsComponent(t, true))
                    lsbComponents.Items.Add(t);
            }
        }

        private void lsbModules_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lsbComponents_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void rbAction_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbAccess_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbCheck_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void lsbModules_DoubleClick(object sender, EventArgs e)
        {
            InteractFrom form = new InteractFrom();
            form.Type = lsbModules.SelectedItem as Type;

            form.Show();
        }

        private void lsbComponents_DoubleClick(object sender, EventArgs e)
        {
            InteractFrom form = new InteractFrom();
            form.Type = lsbComponents.SelectedItem as Type;

            form.Show();
        }
    }
}
