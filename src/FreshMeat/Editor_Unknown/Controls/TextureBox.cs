using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Graphics;
using LofiEngine.Helpers;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using XMediaService;
using LofiEngine;

namespace LofiEditor.Controls
{
    class TextureBox : GraphicsDeviceControl
    {
        #region Variable
        public Texture2D Texture;
        public String texturePath;
        public PictureBoxSizeMode SizeMode; 
        #endregion

        #region Properties
        public virtual String TexturePath
        {
            get
            {
                return texturePath;
            }
            set
            {
                Texture = LoadHelper.LoadTexture2D(value);
                texturePath = value;
            }
        }
        #endregion

        protected override void Update()
        {
            
        }

        protected override void Draw()
        {
            if (Texture == null)
                return;
            ModuleSharer.GraphicsMgr.DrawBegin();
            Rectangle rect = new Rectangle();
            switch (SizeMode)
            {
                case PictureBoxSizeMode.Normal:
                    rect = new Rectangle(0, 0, Texture.Width, Texture.Height);
                    break;
                case PictureBoxSizeMode.Zoom:
                    float zoom = 1;
                    if(Texture.Width / Texture.Height > this.Width / this.Height)
                        zoom = this.Width / Texture.Width;
                    else
                        zoom = this.Height / Texture.Height;
                    rect = new Rectangle(0, 0, (int)(Texture.Width * zoom), (int)(Texture.Height * zoom));
                    break;
                case PictureBoxSizeMode.StretchImage:
                    rect = new Rectangle(0, 0, this.Width, this.Height);
                    break;
            }
            ModuleSharer.GraphicsMgr.Draw(Texture, rect);
            ModuleSharer.GraphicsMgr.DrawEnd();
        }
    }
}
