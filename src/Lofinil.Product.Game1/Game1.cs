using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn;
using LPGView;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    [AddIn("Game1", Publisher = "Lofi", Version = "1.0.0.0", Description = "Game1 draws Texture2D")]
    public class Game1 : LPGame
    {
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Vector2 position;


        public override void OnStart(object sender, EventArgs e)
        {
            // Initial SpriteBatch
            //GameControl gameControl = (GameControl)sender;
            //spriteBatch = new SpriteBatch(gameControl.GraphicsDevice);

            // Load content
            //texture = gameControl.ContentMgr.Load<Texture2D>("Content/Tord");
            //position = new Vector2(100, 100);
        }

        public override void OnStop(object sender, EventArgs e)
        {
            if (texture != null)
                texture.Dispose();
        }

        public override void OnUpdate(object sender, EventArgs e)
        {
        }

        public override void OnDraw(object sender, EventArgs e)
        {
        }
    }
}
