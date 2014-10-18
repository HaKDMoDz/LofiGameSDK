using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LofiUtil.Helpers
{
    public class StringHelper
    {
        public static bool IsNullOrEmpty(string str)
        {
            if (str == null || str == "")
            {
                return true;
            }
            return false;
        }

        // 类型转换 为不提供Parse(String str)方法的系统类型提供转换
        public static Vector2 Str2Vector2(String str)
        {
            int subS,subE;
            subS = 1;
            subE = str.IndexOf('}') - subS;
            String vecStr = str.Substring(subS, subE);
            String[] vecAry = vecStr.Split(' ');
            float[] xy = new float[2];
            for (int i = 0; i < 2; i++)
            {
                xy[i] = float.Parse(vecAry[i].Substring(2));
            }
            return new Vector2(xy[0],xy[1]);
        }
        public static Color Str2Color(String str)
        { 
            int subS,subE;
            subS = 1;
            subE = str.IndexOf('}')-subS;
            String colorStr = str.Substring(subS, subE);
            String[] colAry = colorStr.Split(' ');
            byte[] rgba = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                rgba[i] = byte.Parse(colAry[i].Substring(2));
            }
            return new Color(rgba[0],rgba[1],rgba[2],rgba[3]);
        }
    }
}
