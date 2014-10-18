using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using LofiUtil.Inputs;

namespace LofiUtil.Helpers
{
    public static class TimeHelper
    {
        #region Initialize
        public static void Initialize()
        {
            timer = Stopwatch.StartNew();
            lastMilliseconds = 0;
            timeLastFRUpdateMs = 0;
            frameCount = 0;
        }
        #endregion

        #region Variables
        public static Stopwatch timer;
        private static double lastMilliseconds;
        public static int FrameRate;

        private static float timeLastFRUpdateMs;
        private static int frameCount;
        #endregion

        #region Properties
        public static float MillisecondsLastUpdate
        {
            get { return (float)(timer.ElapsedMilliseconds - lastMilliseconds); }
        }
        // TODO 删除重构中间量
        /// <summary>
        /// 当前帧经过时间
        /// </summary>
        public static float ElapsedTimeThisFrameInMilliseconds
        {
            get { return MillisecondsLastUpdate; }
        }
        /// <summary>
        /// 总时间 - 秒
        /// </summary>
        public static float TotalTime
        {
            get { return (float)(timer.Elapsed.TotalSeconds / 1000); }
        }
        /// <summary>
        /// 总时间 - 毫秒
        /// </summary>
        public static float TotalTimeMilliseconds
        {
            get
            {
                return timer.ElapsedMilliseconds;
            }
        }
        #endregion

        #region Update
        public static void Update()
        {
            // Console.WriteLine("上次时间：" + lastMilliseconds + " -- 本次时间" + timer.ElapsedMilliseconds);
            frameCount++;
            timeLastFRUpdateMs += ElapsedTimeThisFrameInMilliseconds;
            //Console.WriteLine("时间差：" + ElapsedTimeThisFrameInMilliseconds);
            if (timeLastFRUpdateMs > 1000)
            {
                timeLastFRUpdateMs = 0;
                FrameRate = frameCount;
                frameCount = 0;
                Console.WriteLine("足时：" + FrameRate);
            }

            lastMilliseconds = timer.ElapsedMilliseconds;
        }
        #endregion
    }
}
