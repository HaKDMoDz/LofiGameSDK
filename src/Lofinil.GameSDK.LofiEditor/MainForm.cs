using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Engine;

namespace Lofinil.GameSDK.Editor.Shell
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void onProjectLoad()
        {
            // this.Text = "LofiEditor - " + EditorService.Instance.QueryModule("ProjectModule").CurProject.GameName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EditorService.Instance.graphics = GameService.Instance.QueryModule<GraphicsModule>();
            EditorService.Instance.PlayerMgr = GameService.Instance.QueryModule<PlayerModule>();
            EditorService.Instance.SceneMgr = GameService.Instance.QueryModule<StageModule>();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
        }
    }
}
