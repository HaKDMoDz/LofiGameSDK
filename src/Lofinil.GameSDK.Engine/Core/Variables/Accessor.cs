using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Lofinil.GameSDK.Engine
{
    // wiki:///E:/CodeDir/LofiGameSDK/Wiki/LofiGameSDK/Lofinil%20Game%20SDK.wiki?page=Accessor%20Class
    public class Accessor
    {
        // 指示该访问器是否迭代访问器
        // 若是，该Accessor只能成为Action的供体
        // 迭代器的Accessor后续行为会自动应用到每个迭代对象上面，这个约定由Action去达成
        public bool IsEnumerable;       
        
        // 访问变量值
        public virtual Object Access(GameService game){return null;}
    }

    // 基本类型访问器
    // NOTE 实际数据可以是任何
    public class PlainAccessor : Accessor
    {
        public Object Data;

        public override Object Access(GameService game)
        {
            return Data;
        }
    }

    // TODO [多余的命名变量访问器] 该类只是缩短了访问命名变量的路径，可以移除
    public class VariableAccessor : Accessor
    {
        public Variable Variable;       

        public VariableAccessor()
        {
        }

        public VariableAccessor(Object var)
        {
            Variable = new VarString();
            Variable.Name = "";
            Variable.SetValue(var.ToString());
        }

        public override Object Access(GameService game)
        {
            return Variable.GetValue();
        }
    }

    // 通过顶级访问器访问各游戏模块管理器
    public class TopAccessor : Accessor
    {
        public Type ModuleType;

        public TopAccessor()
        {
            ModuleType = null;
        }

        public TopAccessor(Object type)
        {
            ModuleType = (Type)type;
        }

        public override object Access(GameService game)
        {
            // TODO 触发器的参数化模块访问
            return null;
        }
    }

    // 实际上属性访问器可以通过直接调用GameObject的GetPropertyByName构成函数访问器来实现
    // 不过考虑到编辑方式上的区别，还是不要公开GetPropertyByName,而使用这个来实现
    public class PropertyAccessor : Accessor
    {
        public Accessor Holder;     // 属性拥有者 - 编辑器要保证Holder访问结果是一个支持开放属性的GameObject

        public String PropertyName; // 访问属性名

        public override Object Access(GameService game)
        {
            // NOTE 注意这里是访问器，取得的属性不能够直接修改，因为对于值类型数据，对其装箱返回值的修改无法影响原对象
            Object obj = Holder.Access(game);
            return NETFramework.GetPropertyByName(obj, PropertyName);
        }
    }
    
    public class FunctionAccessor : Accessor
    {
        public Accessor Caller;     // 

        // 函数名称
        public String AccessorFuncName;

        // 函数参数
        public List<Accessor> Parameters;

        public FunctionAccessor(String funcName, List<Accessor> parameters)
        {
            AccessorFuncName = funcName;
            Parameters = parameters;
        }

        public override object Access(GameService game)
        {
            Object caller = Caller.Access(game);

            // 产生参数表
            Object[] parameters = new Object[Parameters.Count];
            for (int i = 0; i < Parameters.Count; i++)
                parameters[i] = Parameters[i].Access(game);

            // 执行访问调用
            return NETFramework.FuncCall(caller, AccessorFuncName, parameters);
        }
    }
}
