using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.ComponentModel;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

namespace Lofinil.GameSDK.Engine
{
    // wiki:///E:/CodeDir/LofiGameSDK/Wiki/LofiGameSDK/Lofinil%20Game%20SDK.wiki?page=FrameAnimator%20Class
    [Component(new Type[] { typeof(Sprite) }, true, true)]
    public class FrameAnimator : GameComponent
    {
        // 装饰组件
        public Sprite Sprite;

        public List<FrameSequenceData> FrameSeqList = new List<FrameSequenceData>();

        public FrameSequenceData CurSeq { get; set; }

        [XmlAttribute]
        public bool IsIdle { get; set; }

        private long curTimeMs;

        private long totalMsCurSeq;

        public Rectangle CurSourceRect { get; set; }

        public float CurRotation { get; set; }

        public Vector2 CurOrigin { get; set; }

        public override void Update()
        {
            if (IsIdle) return;

            curTimeMs += GameService.Instance.FrameTimeInMs;

            if (CurSeq.IsLoop)
                curTimeMs %= totalMsCurSeq;

            if (curTimeMs >= totalMsCurSeq)
            {
                IsIdle = true;      // NOTE 这里需要事件通知
            }
            else
            {
                long sum = 0;
                foreach (FrameSeqPieceData fs in CurSeq.Pieces)
                {
                    sum += fs.TimeInMs;
                    if (sum >= curTimeMs)
                    {
                        CurSourceRect = fs.SourceRect;
                        CurRotation = fs.Rotation;
                        CurOrigin = fs.Origin;
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
            FrameSequenceData fs = GetSeq(seqName);
            playSeq(fs);
        }

        protected void playSeq(FrameSequenceData fs)
        {
            IsIdle = false;
            CurSeq = fs;
            curTimeMs = 0;
            totalMsCurSeq = 0;
            foreach (FrameSeqPieceData fsp in CurSeq.Pieces)
                totalMsCurSeq += fsp.TimeInMs;
        }

        public FrameSequenceData GetSeq(String name)
        {
            return FrameSeqList.Find(fs => fs.Name == name);
        }

        public Rectangle GetFrameRect()
        {
            Rectangle frameRect = new Rectangle();
            return frameRect;
        }
    }
}
