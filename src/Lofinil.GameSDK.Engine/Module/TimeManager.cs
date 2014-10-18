using System.Diagnostics;

namespace Lofinil.GameSDK.Engine
{
    public class TimeModule : BaseModule
    {
        public TimeModule()
        {
            timer = Stopwatch.StartNew();
            lastFrameMS = 0;
            secondAddMS = 0;
            frameCount = 0;
        }

        public Stopwatch timer;
        private long lastFrameMS;
        public int FrameRate { get; protected set; }

        private float secondAddMS;
        private int frameCount;

        public long FrameTimeInMs { get; protected set; }

        public float FrameTimeInS { get; protected set; }

        public double TotalTimeInS { get; protected set; }

        public long TotalTimeInMs { get; protected set; }

        public override void Update()
        {
            lastFrameMS = TotalTimeInMs;
            TotalTimeInMs = timer.ElapsedMilliseconds;
            FrameTimeInMs = TotalTimeInMs - lastFrameMS;
            FrameTimeInS = FrameTimeInMs / 1000f;

            TotalTimeInS = timer.Elapsed.TotalSeconds;

            frameCount++;
            secondAddMS += FrameTimeInMs;
            if (secondAddMS > 1000)
            {
                FrameRate = frameCount;
                secondAddMS = 0;
                frameCount = 0;
            }
        }
    }
}