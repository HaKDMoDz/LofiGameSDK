using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LofiUtil.Helpers
{
    public static class RandomHelper
    {
        private static int randomSeed = 0;
        public static int GetRandomInt(int low, int high)
        {
            if (low > high)
            {
                Console.WriteLine("警告：获取随机整数的范围设置错误，返回0");
                return 0;
            }
            updateSeed();
            Random r = new Random(randomSeed);
            int rn = r.Next(high - low + 1);
            return low + rn;
        }

        private static void updateSeed()
        {
            // 保证在每次更新中也不会出现相同的随机序列
            randomSeed += (int)TimeHelper.ElapsedTimeThisFrameInMilliseconds;
            if (randomSeed > 9999999)
            {
                randomSeed = 0;
            }
        }
    }
}
