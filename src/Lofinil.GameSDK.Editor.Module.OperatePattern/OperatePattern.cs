using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor
{
    public abstract class OperatePattern
    {
        public String Name { get; set; }

        // 注册此操作模式时发生 用于定义入口，如工具箱项或菜单项
        public abstract void Regist();

        // 情况 选定组件类型之后，但未调用组件构造之前的初始设定
        public abstract void Startup();

        // 情况 操作执行完毕，做必要的清理工作等
        public abstract void End();

        // 情况 空闲 - 可以播放预览动画等
        public abstract void Idle();
    }
}
