using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Engine
{
    // TODO [将预制件标记更改为复杂组件的创建模式] 不再支持预制件标记，因为复杂组件只要提供了创建模式就可以方便得生成
    // 标记类为预制件
    [AttributeUsage(AttributeTargets.Class)]
    public class PrefabAttribute : Attribute
    {
        Type[] DependComps;       // 依赖组件

        public PrefabAttribute(Type[] dependComps)
        {
            DependComps = dependComps;
        }
    }
}
