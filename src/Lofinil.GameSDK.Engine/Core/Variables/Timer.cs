using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Engine
{
    // 游戏计时器用两用使用途径
    // -触发器系统 (因为触发器系统不支持函数变量,因此和下面的用法不同,仅引起事件)
    // -代码的时间驱动回调 (一个很好的例子是引起触发器系统响应时间事件这一实现)
    public class Timer
    {
        public Double Interval;

        public bool Enabled;

        public ObjectEventHandler Elapsed;

        private long timeInMs;

        public Timer(String name, Double interval)
        {
            Interval = interval;
        }

        public void Start()
        {
            Enabled = true;
        }

        public void Stop()
        {
            Enabled = false;
        }

        public void Reset()
        {
            Enabled = false;
            timeInMs = 0;
        }

        public void Update()
        {
            if (!Enabled)
                return;

            timeInMs += GameService.Instance.FrameTimeInMs;

            if (timeInMs >= Interval)
            {
                if (Elapsed != null) Elapsed(this, null);
                Enabled = false;
                timeInMs = 0;
            }
        }
    }
}
