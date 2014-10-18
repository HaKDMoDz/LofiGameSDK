using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Stage;
using LofiEngine.Content;
using LofiEngine.Core;
using LofiEngine.Componsite;

namespace LofiEngine.TileEngine.Prefab
{
    // 图块组件
    public class TileItem : BaseComponent
    {
        // 资源引用
        public Sprite Texture;

        public int TileId;

        // 运行时 反序列化
        public TileItem()
        {
        }

        // 设计时 含初始化
        public TileItem(Sprite texture, int tileId)
        {
            this.Texture = texture;
            this.TileId = tileId;
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            // UNDONE TileItem.Draw
        }
    }
}
