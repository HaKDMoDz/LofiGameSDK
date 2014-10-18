using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lofinil.GameSDK.Engine
{
    // 变量集组件，维护动态属性列表
    public class VariableSet : GameComponent
    {
        public List<Variable> VariableList;

        public VariableSet()
        {
            VariableList = new List<Variable>();
        }

        public Variable GetVariable(String name)
        {
            return VariableList.Find(var => var.Name == name);
        }

        public Variable GetVariable(int id)
        {
            return VariableList[id];
        }

        public void SetVariable(String name, Object val)
        {
            Variable var = GetVariable(name);
            var.SetValue(val);
        }

        public void AddVarNumber(String name, double value)
        {
            VarNumber var = new VarNumber();
            var.Name = name;
            var.SetValue(value);
            VariableList.Add(var);
        }

        public void DeleteVariable(String name)
        {
            Variable var = GetVariable(name);
            VariableList.Remove(var);
        }
    }
}
