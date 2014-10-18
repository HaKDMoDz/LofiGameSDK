using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Graphics;
using LofiEngine.Games;
using System.Windows.Forms;

namespace LofiEngine
{
    public class EditorManager : IGameManager
    {
        #region Variables
        public bool ShowBound = false;
        public bool ShowBody = false;
        public bool PhysicsEnabled = false;
        #endregion

        #region IGameManager 成员

        public void Quit()
        {
            Application.Exit();
        }

        #endregion
    }
}
