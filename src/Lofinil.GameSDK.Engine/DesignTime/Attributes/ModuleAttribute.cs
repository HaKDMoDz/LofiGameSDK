using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Engine
{
    // 将类标记为模块
    [AttributeUsage(AttributeTargets.Class)]
    public class ModuleAttribute : Attribute
    {
        public Type[] Depends;
        
        public ModuleAttribute(Type[] depParents)
        {
            Depends = depParents;
        }

        public ModuleAttribute()
        {
            Depends = new Type[0];
        }
    }
}
