using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lofinil.GameSDK.Engine
{
    // 标记类为组件
    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentAttribute : Attribute
    {
        // 父级组件限定 / 装饰组件限定
        public Type[] DepParents;

        public bool InEditor;       // 编辑器可视创建

        public bool CanStore;       // 支持序列化数据

        public ComponentAttribute(Type[] depParents, bool inEditor, bool canStore)
        {
            DepParents = depParents;
            InEditor = inEditor;
            CanStore = canStore;
        }
    }
}
