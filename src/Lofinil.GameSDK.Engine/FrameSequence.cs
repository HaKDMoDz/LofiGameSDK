using System;
using System.ComponentModel;
using System.Drawing;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using System.Collections.Generic;

namespace Lofinil.GameSDK.Engine
{
    public class FrameSeqPieceData
    {
        public Rectangle SourceRect;

        public Vector2 Origin;          // 对齐原点

        public float Rotation;

        public long TimeInMs;
    }

    public class FrameSequenceData
    {
        public String Name { get; set; }

        public List<FrameSeqPieceData> Pieces { get; set; }

        public bool EnableDisturb { get; set; }

        public bool IsLoop { get; set; }

    }
}