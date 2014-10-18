using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Lofinil.GameSDK.Engine;

namespace Lofinil.GameSDK.Editor.Module.Project
{
    public partial class CreateStageForm : Form
    {
        private GameService gameMgr = GameService.Instance;

        public String RelaPath;

        public CreateStageForm()
        {
            InitializeComponent();
        }

        private void btn_browseScene_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), GameService.Instance.GameConfig.ContentPath));
            fbd.SelectedPath = dirInfo.FullName;

            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Uri absUri = new Uri(fbd.SelectedPath);
                Uri baseUri = new Uri(Path.Combine(Directory.GetCurrentDirectory(), GameService.Instance.GameConfig.ContentPath));
                Uri relaUri = baseUri.MakeRelativeUri(absUri);
                RelaPath = relaUri.ToString();
                tb_path.Text = RelaPath;
            }
        }

        private void btn_comfirm_Click(object sender, EventArgs e)
        {
            gameMgr.QueryModule<StageModule>().NewScene(RelaPath, tb_sceneName.Text);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
