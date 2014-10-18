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
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            Microsoft.Xna.Framework.Input.Mouse.WindowHandle = gameControl1.Handle;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
        }
    }
}
