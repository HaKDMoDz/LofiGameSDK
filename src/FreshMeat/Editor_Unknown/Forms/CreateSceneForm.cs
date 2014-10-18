using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LofiEngine.Scenes;
using System.IO;
using LofiEngine.Helpers;
using LofiEngine;

namespace LofiEditor.SupportForms
{
    public partial class CreateSceneForm : Form
    {
        public String RelaPath;

        public CreateSceneForm()
        {
            InitializeComponent();
        }

        private void btn_browseScene_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), LoadHelper.ScenePath));
            fbd.SelectedPath = dirInfo.FullName;

            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Uri absUri = new Uri(fbd.SelectedPath);
                Uri baseUri = new Uri(Path.Combine(Directory.GetCurrentDirectory(), LoadHelper.ScenePath));
                Uri relaUri = baseUri.MakeRelativeUri(absUri);
                RelaPath = relaUri.ToString();
                tb_path.Text = RelaPath;
            }
        }

        private void btn_comfirm_Click(object sender, EventArgs e)
        {
            ModuleSharer.SceneMgr.CreateScene(RelaPath, tb_sceneName.Text);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
