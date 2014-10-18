using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Componsite;
using LofiEngine.TileEngine.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.DesignTime.Attributes;

namespace LofiEngine.TileEngine.Componsite
{
    // 图块绘制载体组件
    [Component(new Type[] { typeof(TileTransform) }, true, true)]
    public class Tile : BaseComponent
    {
        // 资源
        public TileTexture Texture { get; set; }

        // 依赖组件
        public TileTransform Trans;

        public override void Draw()
        {
            Texture.Draw(Trans.Origin, Trans.Position, Trans.Rotation, Trans.Scale, SpriteEffects.None);

            base.Draw();
        }
    }
}
