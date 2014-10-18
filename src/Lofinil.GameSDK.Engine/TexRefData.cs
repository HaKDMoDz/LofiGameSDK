using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace Lofinil.GameSDK.Engine
{
    [Serializable]
    public class ReferTextureData
    {
        public int UID;
        public String Key;
        public Rectangle SrcRect;
        public Color Color;
        public TextureAddressMode AdrModX;
        public TextureAddressMode AdrModY;

        public ReferTextureData()
        {
            UID = -1;
            Key = "";
            SrcRect = Rectangle.Empty;
            Color = Color.White;
            AdrModX = TextureAddressMode.Clamp;
            AdrModY = TextureAddressMode.Clamp;
        }
    }
}
