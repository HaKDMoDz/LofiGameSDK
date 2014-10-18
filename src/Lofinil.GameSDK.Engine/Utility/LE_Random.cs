using System;

namespace Lofinil.GameSDK.Engine
{
    public class LE_Random : BaseModule
    {
        public LE_Random()
        {
        }

        private int randomSeed = 0;

        // high必须大于low
        public int GetRandomInt(int low, int high)
        {
            updateSeed();
            Random r = new Random(randomSeed);
            int rn = r.Next(high - low + 1);
            return low + rn;
        }

        private void updateSeed()
        {
            // 保证在每次更新中也不会出现相同的随机序列
            randomSeed += (int)GameService.FrameTimeInMs;
            if (randomSeed > 9999999)
            {
                randomSeed = 0;
            }
        }
    }
}