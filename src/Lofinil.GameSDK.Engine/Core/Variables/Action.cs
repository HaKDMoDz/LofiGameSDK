using System;
using System.Collections.Generic;
using System.Collections;

namespace Lofinil.GameSDK.Engine
{
    // 行为
    public class Action
    {
        public virtual void Run(GameService game) { }
    }

    // 属性更改行为
    public class ActionModProperty : Action
    {
        public Accessor Holder;     // 属性供体

        public String PropName;     // 属性名称

        public Accessor Value;      // 属性新值

        public override void Run(GameService game)
        {
            object holder = Holder.Access(game);
            object value = Value.Access(game);

            if (Holder.IsEnumerable)
                foreach (object obj in (IEnumerable<object>)holder)
                    runOnOne(obj, value);
            else
                runOnOne(holder, value);
        }

        protected void runOnOne(object obj, object value)
        {
            NETFramework.SetPropertyByName(obj, PropName, value);
        }
    }

    // 函数行为
    public class ActionFunction : Action
    {
        public Accessor Caller;         // 函数供体

        public String FuncName;         // 函数名称

        public List<Accessor> Params;   // 函数参数

        public override void Run(GameService game)
        {
            Object caller = Caller.Access(game);
            Object[] param = new Object[Params.Count];
            for(int i=0; i<Params.Count; i++)
            {
                param[i] = Params[i].Access(game);
            }

            if (Caller.IsEnumerable)
                foreach (object obj in (IEnumerable<object>)caller)
                    runOnOne(obj, param);
            else
                runOnOne(caller, param);
        }

        protected void runOnOne(object obj, object[] param)
        {
            NETFramework.ActionCall(obj, FuncName, param);
        }
    }
}