using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Content;
using LofiEngine.DesignTime.Attributes;
using LofiEngine.TileEngine.Componsite;
using LofiEngine.Componsite;

namespace LofiEngine.TileEngine.Prefab
{
    [Prefab(new Type[]{typeof(TileTransform), typeof(Sprite)})]
    public class TileTerrain
    {
        public TileTransform Transform;

        public Sprite Texture;

        public int TileId;
    }
}
