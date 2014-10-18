using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Componsite;
using System.ComponentModel;
using LofiEngine.Content;
using LofiEngine.Game;
using Microsoft.Xna.Framework;
using LofiEngine.TileEngine.Content;
using LofiEngine.DesignTime.Attributes;

namespace LofiEngine.TileEngine.Componsite
{
    // 连续图块动画控制器组件
    [Component(new Type[] { typeof(Tile) }, true, true)]
    public class TileAnimator : BaseComponent
    {
        // 同级组件 - 控制对象
        public Tile Tile;

        public bool IsIdle { get; private set; }

        public List<TileSequence> TileSeqList = new List<TileSequence>();

        public TileSequence CurSeq { get; set; }

        private long curTimeMs;

        private long totalMsCurSeq = 0;

        public int CurTileId { get; private set; }

        public override void Update()
        {
            if (IsIdle) return;

            curTimeMs += GameManager.Instance.FrameTimeInMs;

            if (CurSeq.IsLoop)
                curTimeMs %= totalMsCurSeq;

            if (curTimeMs >= totalMsCurSeq)
            {
                IsIdle = true;      // NOTE 这里需要事件通知
            }
            else
            {
                long sum = 0;
                foreach (TileSeqPiece tsp in CurSeq.Pieces)
                {
                    sum += tsp.TimeInMs;
                    if (sum >= curTimeMs)
                    {
                        CurTileId = tsp.TileId;
                        break;
                    }
                }
            }
            base.Update();
        }

        public void PlaySeq(String seqName)
        {
            if (!IsIdle && CurSeq.EnableDisturb == false)
                return;
            TileSequence fs = GetSeq(seqName);
            PlaySeq(fs);
        }

        public void PlaySeq(TileSequence fs)
        {
            IsIdle = false;
            CurSeq = fs;
            curTimeMs = 0;
            totalMsCurSeq = 0;
            foreach (TileSeqPiece fsp in CurSeq.Pieces)
                totalMsCurSeq += fsp.TimeInMs;
        }

        public TileSequence GetSeq(String name)
        {
            return TileSeqList.Find(fs => fs.Name == name);
        }

        // Get source rectangle based on current frame
        public Rectangle GetFrameRect()
        {
            Rectangle frameRect = new Rectangle();
            //int posX, poxY;
            //int rowId, columnId;
            //rowId = CurrentFrameId / Texture.ColumnCount;
            //columnId = CurrentFrameId % Texture.ColumnCount;
            //posX = columnId * (int)Texture.SourceRect.Width;
            //poxY = rowId * (int)Texture.SourceRect.Height;
            //frameRect = new Rectangle(posX, poxY, (int)Texture.SourceRect.Width, (int)Texture.SourceRect.Height);
            return frameRect;
        }
    }
}
