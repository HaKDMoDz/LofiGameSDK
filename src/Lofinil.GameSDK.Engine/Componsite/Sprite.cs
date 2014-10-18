using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lofinil.GameSDK.Engine
{
    // 图片绘制载体组件
    [Component(new Type[0], true, true)]
    public class Sprite : GameComponent
    {
        // 资源
        public ReferTexture Texture { get; set;}

        // 依赖组件
        public Transform Trans;

        public Vector2 Position { get; set; }

        public float Rotation { get; set; }

        public Vector2 Scale { get; set; }

        public Vector2 Origin { get; set; }

        public Sprite()
        {
            Scale = new Vector2(1, 1);
        }

        public override void Draw()
        {
            Texture.Draw(Origin, Position, Rotation, Scale, SpriteEffects.None);

            base.Draw();
        }
    }
}