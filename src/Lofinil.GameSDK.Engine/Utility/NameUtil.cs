using System;

namespace Lofinil.GameSDK.Engine
{
    public static class NameUtil
    {
        private static int incId = 0;

        public static void RestartNameInc(int inc)
        {
            incId = inc;
        }

        public static String GetNextName(String prefix)
        {
            String name = prefix + incId;
            incId++;
            return name;
        }
    }
}