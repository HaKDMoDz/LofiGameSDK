using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LofiPlayer
{
    public partial class PlayerForm : Form
    {
        private PlayerManager playerManager;
        private GameLoader gameLoader;
        private LPView.LPView gameAddIn;

        public PlayerForm(String gamePath)
        {
            InitializeComponent();

            playerManager = new PlayerManager(null);

            gameLoader = new GameLoader();
            gameLoader.SearchGames(gamePath);
        }

        public void LoadGame(String gameFullName)
        {
            gameAddIn = GameLoader.LoadGame(gameFullName);
            gameAddIn.Active();

            gameAddIn.LoadContent();

            playerManager.Run();
        }
    }
}
