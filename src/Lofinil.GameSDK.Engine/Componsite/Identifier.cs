using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Lofinil.GameSDK.Engine
{
    // 唯一标识组件 - 用于在组件树中索引节点，当然客户也可以利用它
    [Component(new Type[0], true, true)]
    public class Identifier : GameComponent
    {
        // 装饰组件 - 任何组件
        public GameComponent Component;

        [Category("Basic"), Description("数字标识"), XmlAttribute]
        public int UID { get; set; }

        // Name为可选的区分项
        [Category("Basic"), Description("字符串标识"), XmlAttribute]
        public String Name { get; set; }

        [Category("Basic"), Description("唯一标识辖域 [设计中]"), XmlAttribute]
        public String Scope { get; set; }
    }
}
