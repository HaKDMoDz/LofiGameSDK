using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LofiEngine.TileEngine.Content
{
    public class TileSeqPiece
    {
        public int TileId;

        public long TimeInMs;
    }

    public class TileSequence
    {
        public String Name { get; set; }

        public List<TileSeqPiece> Pieces;

        public bool EnableDisturb { get; set; }

        public bool IsLoop { get; set; }
    }
}
