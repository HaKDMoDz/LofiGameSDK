using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Lofinil.GameSDK.Engine
{
    // wiki:///E:/CodeDir/LofiGameSDK/Wiki/LofiGameSDK/Lofinil%20Game%20SDK.wiki?page=Variable%20Class
    public abstract class Variable
    {
        public String Name;

        public abstract Object GetValue();

        public abstract void SetValue(Object val);
    }

    public class VarNumber : Variable
    {
        public double Value;

        public override object GetValue() { return Value; }

        public override void SetValue(Object val){ Value = (double)val; }
    }

    public class VarBool : Variable
    {
        public bool Value;

        public override object GetValue() { return Value; }

        public override void SetValue(object val) { Value = (bool)val; }
    }

    public class VarString : Variable
    {
        public String Value;

        public override object GetValue() { return Value; }

        public override void SetValue(object val) { Value = (String)val; }
    }

    public class VarVector2 : Variable
    {
        public Vector2 Value;

        public override object GetValue() { return Value; }

        public override void SetValue(object val)
        {
            Value = (Vector2)val;
        }
    }
}