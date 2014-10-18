using System.Collections.Generic;
namespace Lofinil.GameSDK.Engine
{
    // 游戏的条件检查模块
    // 作为一大部件直接支持TriggerAction系统
    public enum ConditionType
    {
        Compare,
        Logic,
    }

    public enum CompareType
    {
        EqualTo,
        GreaterThan,
        GreaterThanOrEqualTo,
        LessThan,
        LessThanOrEqualTo,
        // TODO [其他的比较条件] 例如Between等
    }

    public enum LogicType
    {
        And,
        Or,
        Not,
        Xor,
    }

    // 条件
    public class Condition
    {
        public ConditionType Type;
        
        // 支持序列化
        public Condition() { }

        public Condition(ConditionType type) { Type = type; }

        public virtual bool Check(GameService game){return false;}
    }

    // 关系条件
    public class ConditionCompare : Condition
    {
        // 关系比较类型
        public CompareType CompareType;

        // NOTE 目前仅支持双目关系比较
        public List<Accessor> AccessorList;

        // 支持序列化
        public ConditionCompare() : base(ConditionType.Compare) { }

        public ConditionCompare(CompareType type) : base(ConditionType.Compare) { CompareType = type; }

        public override bool Check(GameService game)
        {
            // TODO [非法参数检查] 由编辑器保证参数量正确
            object obj1 = AccessorList[0].Access(game);
            object obj2 = AccessorList[1].Access(game);

            // ACHACK [条件检查的对象比较] 等于可应用于所有object，而比较只用于数字，用if区分两情况
            // 来解决因为关系运算符可能未重载出现运行异常
            double d1 = 0;
            double d2 = 0;
            if(CompareType != CompareType.EqualTo)
            {
                d1 = (double)obj1;  // NOTE 解决对齐小数点、溢出等问题
                d2 = (double)obj2;
            }

            switch(CompareType)
            {
                case CompareType.EqualTo:
                    return obj1 == obj2;
                case CompareType.GreaterThan:
                    return d1 > d2;
                case CompareType.GreaterThanOrEqualTo:
                    return d1 >= d2;
                case CompareType.LessThan:
                    return d1 < d2;
                case CompareType.LessThanOrEqualTo:
                    return d1 <= d2;
            }
            return false;
        }
    }

    // 逻辑条件
    public class ConditionLogic : Condition
    {
        // 逻辑类型
        public LogicType LogicType;

        // 
        public List<Condition> ConditionList;

        // 支持序列化
        public ConditionLogic() : base(ConditionType.Logic) { }

        public ConditionLogic(LogicType type) : base(ConditionType.Logic) { LogicType = type; }

        // NOTE 检查函数并不会确认参数数量是否正确 这个应该由编辑器去保证
        public override bool Check(GameService game)
        {
            bool res1 = ConditionList[0].Check(game);
            bool res2 = ConditionList[1].Check(game);

            switch(LogicType)
            {
                case LogicType.And:
                    return res1 && res2;
                case LogicType.Or:
                    return res1 || res2;
                case LogicType.Not:
                    return !res1;
                case LogicType.Xor:
                    return res1 ^ res2;
            }
            return false;
        }
    }
}