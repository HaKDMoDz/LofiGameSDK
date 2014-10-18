using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lofinil.GameSDK.Engine
{
    // Refer Texture 是对非托管Texture资源的引用
    // 在XNA的框架中Texture2D已经是一个智能指针了
    // XNA负责资源释放，而我希望自己能够控制，因此Resource命名空间中至少保留最后一个引用来保留控制权。

    // Basic Texture 实际上是一个2D图片采样源的引用，它包含了一个Texture2D引用以及源矩形、颜色
    // 所以前面的说法是错误的，对Texture2D的第一个也是最后一个引用都在ResourceManager的List<Texture2D>当中

    // 对于一个源描述来说，原点和尺寸是必须的，内部的旋转、颜色、效果等等则是可选的。Scale则是完全没有必要的
    public class ReferTexture
    {
        public String Name 
        {
            get { return name; } 
            set 
            {
                name = value;
                texture = (Texture2D)GameService.Instance.QueryModule<ContentModule>().GetContent(ContentType.Texture, value);
            }
        }
        protected String name;

        public Texture2D Texture
        {
            get { return texture; }
            set 
            {
                texture = value;
                name = texture.Name;
            }
        }
        protected Texture2D texture;

        public Color Color { get; set; }

        public Rectangle SourceRect { get; set; }

        public TextureAddressMode AddrModeX;

        public TextureAddressMode AddrModeY;

        // 运行时 反序列化
        public ReferTexture(){}

        // 设计时 含初始化
        public ReferTexture(String texturePath)
        {
            Color = Color.White;
            Name = texturePath;
        }

        public ReferTexture(ReferTextureData trd)
        {
            this.Color = new Color(trd.Color.R, trd.Color.G, trd.Color.B, trd.Color.A);
            this.AddrModeX = trd.AdrModX;
            this.AddrModeY = trd.AdrModY;
            this.SourceRect = new Rectangle(trd.SrcRect.X, trd.SrcRect.Y, trd.SrcRect.Width, trd.SrcRect.Height);
            this.texture = (Texture2D)GameService.Instance.QueryModule<ContentModule>().GetContent(ContentType.Texture, trd.UID);
            this.name = trd.Key;
        }

        public void Draw(Vector2 origin, Vector2 position,
            float rotation, Vector2 scale, SpriteEffects se)
        {
            // TODO [采样状态变更设计] 目前不做复杂渲染调度，但是这里的SamplerState切换丢失了信息
            SamplerState ss = new SamplerState();
            ss.AddressU = AddrModeX;
            ss.AddressV = AddrModeY;

            GameService.Instance.Device.SamplerStates[0] = ss;

            GameService.Instance.QueryModule<GraphicsModule>().Draw(
                Texture, SourceRect, Color, origin, position, scale, rotation, se);
        }
    }
}