using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Helpers;
using LofiEngine.Inputs;
using Microsoft.Xna.Framework.Graphics;

namespace LofiEngine
{
    public class LofiXUtilManager
    {
        #region Instance
        private static LofiXUtilManager instance;
        public static LofiXUtilManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new LofiXUtilManager();
                return instance;
            }
        }
        private LofiXUtilManager()
        {
        }
        #endregion

        #region Variables
        public GraphicsDevice GraphicsDevice;
        #endregion

        public void Update()
        {
            TimeHelper.Update();
            Keyboard.Update();
            Mouse.Update();
        }
    }
}
