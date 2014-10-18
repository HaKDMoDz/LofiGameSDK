using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Action = Lofinil.GameSDK.Engine.Action;
using Lofinil.Architecture;

namespace Lofinil.GameSDK.Engine
{
    // 行为堆栈
    // 记录简单行为集中依次执行
    // 依赖模块： 无
    // 可选模块： 任何组件
    public class ActionStack : BaseModule, IModule
    {
        public Stack<Action> Stack;

        public ActionStack()
        {
            Stack = new Stack<Action>();
        }

        public override void Update()
        {
            while (Stack.Count > 0)
            {
                Action action = Stack.Pop();
                action.Run(GameService.Instance);
            }
        }

        public void Push(Action action)
        {
            Stack.Push(action);
        }
    }
}
