using System.Windows.Forms;
using LofiEngine.Games;
using LofiEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XMediaService;

namespace LofiEngine
{
    public class GameControl : GraphicsDeviceControl
    {
        #region Variables
        public GameManager GameManager;
        #endregion

        public GameControl()
        {
            GameManager = new GameManager(GraphicsDevice, Services);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void Update()
        {
            LofiXUtilManager.Instance.Update();

            GameManager.Update();
        }

        protected override void Draw()
        {
            Color cc = new Color(80, 109, 137, 255);
            GraphicsDevice.Clear(cc);
            GameManager.Draw();
        }
    }
}
