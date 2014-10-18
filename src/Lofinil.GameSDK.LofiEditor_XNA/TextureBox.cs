using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Lofinil.GameSDK.Engine.WinControl;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor;

namespace Lofinil.GameSDK.LofiEditor
{
    class TextureBox : XNAControl
    {
        // Data Level Out   [DataStore]
        public TexRefData TexRefData;
        // Data Level 1     [Runtime]
        // protected BaseTexture BaseTex;
        // Data Level 2     [ResObject]
        protected Texture2D Texture;

        public PictureBoxSizeMode SizeMode = PictureBoxSizeMode.Normal;

        public TextureBox()
        {
            Texture = null;
        }

        public virtual void SetTexRefData(TexRefData trd)
        {
            TexRefData = trd;
            if (EditorManager.Instance.Initialized)
            {
                Texture = (Texture2D)GameManager.Instance.ContentMgr.GetContent(ContentType.Texture, TexRefData.Name);
            }
        }

        public virtual String TexturePath
        {
            get
            {
                return TexRefData.Name;
            }
            set
            {
                if(String.IsNullOrEmpty(value))
                    return;
                TexRefData = new TexRefData();
                TexRefData.Name = value;
                Texture = (Texture2D)GameManager.Instance.ContentMgr.GetContent(ContentType.Texture, value);
            }
        }

        protected override void XNAControl_Draw(object sender, EventArgs e)
        {
            base.XNAControl_Draw(sender, e);

            if (Texture == null)
                return;

            GameManager.Instance.GraphicsMgr.DrawBegin();
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
            GameManager.Instance.GraphicsMgr.Draw(Texture, rect);
            GameManager.Instance.GraphicsMgr.DrawEnd();
        }
    }
}
