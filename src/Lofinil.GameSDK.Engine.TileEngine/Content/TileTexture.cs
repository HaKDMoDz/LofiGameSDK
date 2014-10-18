using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LofiEngine.Game;

namespace LofiEngine.TileEngine.Content
{
    // 整齐图块图片引用
    public class TileTexture
    {
        public String TexturePath 
        {
            get { return texturePath; }
            set 
            { 
                texturePath = value; 
                texture = GameManager.Instance.ResMgr.GetTexture(value);
                rebuildSlice();
                rebuildSourceRect();
            }
        }
        private String texturePath;

        public Texture2D Texture 
        {
            get { return texture; }
            // UNDONE Texture2D.Name必须由资源系统赋值
            set 
            { 
                texture = value;
                texturePath = texture.Name;
                rebuildSlice();
                rebuildSourceRect();
            }
        }
        private Texture2D texture;

        public Color Color { get; set; }

        public Rectangle SourceRect { get; private set; }

        public int TileId 
        {
            get { return tileId; }
            set { tileId = value; rebuildSourceRect(); }
        }

        protected int tileId;

        public Point TileSize
        {
            get { return tileSize;}
            set { tileSize = value; rebuildSlice(); rebuildSourceRect(); }
        }
        private Point tileSize;

        public int Columns { get; protected set; }

        public int Rows { get; protected set; }

        public int TileCount { get; protected set; }

        public TextureAddressMode AddrModeX;

        public TextureAddressMode AddrModeY;

        protected void rebuildSlice()
        {
            Columns = Texture.Width / TileSize.X;
            Rows = Texture.Height / TileSize.Y;
            TileCount = Columns * Rows;
        }

        protected void rebuildSourceRect()
        {
            int x = TileId * TileSize.X % Columns;
            int y = TileId * TileSize.Y / Columns;
            SourceRect = new Rectangle(x, y, TileSize.X, TileSize.Y);
        }

        public void Draw(Vector2 origin, Vector2 position, float rotation, Vector2 scale, SpriteEffects se)
        {
            GameManager.Instance.Device.SamplerStates[0].AddressU = AddrModeX;
            GameManager.Instance.Device.SamplerStates[0].AddressV = AddrModeY;

            GameManager.Instance.GraphicsMgr.Draw(
                Texture, SourceRect, Color, origin, position, scale, rotation, se);
        }
    }
}
