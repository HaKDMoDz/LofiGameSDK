using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Engine
{
    // 将成员标记为公开
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Enum|AttributeTargets.Field|AttributeTargets.Method)]
    public class InteractAttribute : Attribute
    {
        // 归类
        public String Type;

        // 外部调用描述
        public String ExternDesc;

        // 返回值描述
        public String ReturnDesc;

        // 参数表描述
        public String[] ParamsDesc = new String[0];

        public InteractAttribute(String desc)
        {
            Type = "默认";
            ExternDesc = desc;
        }

        public InteractAttribute(String type, String desc)
        {
            Type = type;
            ExternDesc = desc;
        }

        public InteractAttribute(String type, String desc, String[] parDescs)
        {
            Type = type;
            ExternDesc = desc;
            ParamsDesc = parDescs;
        }

        public InteractAttribute(String type, String desc, String retDesc, String[] parDescs)
        {
            Type = type;
            ExternDesc = desc;
            ReturnDesc = retDesc;
            ParamsDesc = parDescs;
        }
    }
}
