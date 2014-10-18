using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using LofiEngine.Componsite;
using LofiEngine.DesignTime.Attributes;

namespace LofiEngine.TileEngine.Componsite
{
    // 图块专用的空间变换组件
    [Component(new Type[0], true, true)]
    public class TileTransform : Transform
    {
        public int GridX { get; set; }

        public int GridY { get; set; }

        // Tile的Scale和Rotate只用作摄像机变换
    }
}
