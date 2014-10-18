using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LofiUtil.Helpers
{
    public static class NameHelper
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
