using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Engine.Game
{
    public class GameDesignConfig
    {
        // NOTE 属性对客户代码隐藏 或 要求该属性在项目创建后不可修改
        public int IdStackSize = 10000;     // Id 堆栈的初始容量
        public int IdStackIncrease = 1000;  // Id 堆栈扩容步长
    }
}
