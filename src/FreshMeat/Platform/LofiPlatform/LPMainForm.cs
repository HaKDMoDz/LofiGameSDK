using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using LofiPlatform.Properties;
using System.AddIn.Hosting;
using LPView;
using System.Collections.ObjectModel;
using LofiEngine.Helpers;
using LofiPlatform.Properties;
using LofiEngine.Graphics;

namespace MiniPlatform
{
    public partial class LPMainForm : Form
    {
        private Collection<AddInToken> addInTokens;

        private LPView.LPView activeGame = null;

        public LPMainForm()
        {
            InitializeComponent();


            // Load game module
            AddInStore.Update(Settings.Default.PipelinePath);
            findAddIns();
        }

        protected override void OnCreateControl()
        {
            // Initialize Lofi Engine
            TimeHelper.Initialize();
            LoadHelper.Initialize(gameControl1.ContentMgr);
            GraphicsManager.Initialize(gameControl1.GraphicsDevice);
            PhysicsManager.GDKeyMap(PhysicsManager.GravityDirection.Down);

            base.OnCreateControl();
        }

        private void findAddIns()
        {
            lsb_games.Items.Clear();
            addInTokens = AddInStore.FindAddIns(typeof(LPView.LPView), Settings.Default.PipelinePath);
            foreach(AddInToken a in addInTokens)
            {
                lsb_games.Items.Add(a.AddInFullName);
            }
        }

        private AddInToken getAddIn(String fullName)
        {
            foreach (AddInToken a in addInTokens)
            {
                if (fullName == a.AddInFullName)
                    return a;
            }
            return null;
        }

        private void startGame(String gameFullName)
        {
            //if (gameControl1.Running)
            //    gameControl1.Stop();

            AddInToken a = getAddIn(gameFullName);
            AddInProcess process = new AddInProcess();
            process.KeepAlive = false;
            
            activeGame = a.Activate<LPView.LPView>(process, AddInSecurityLevel.FullTrust);

            // Register delegate
            //gameControl1.OnStart += activeGame.OnStart;
            //gameControl1.OnUpdate += activeGame.OnUpdate;
            //gameControl1.OnDraw += activeGame.OnDraw;
            //gameControl1.OnStop += activeGame.OnStop;

            // Start!
            //gameControl1.Start();
        }

        private void lsb_games_DoubleClick(object sender, EventArgs e)
        {
            if (lsb_games.SelectedItem != null)
            {
                startGame(lsb_games.SelectedItem.ToString());
            }
        }
    }
}
