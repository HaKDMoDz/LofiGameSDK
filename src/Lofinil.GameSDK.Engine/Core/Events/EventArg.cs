using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lofinil.GameSDK.Engine
{
    public class EA_Vector2 : EventArgs
    {
        public Vector2 Value;

        public EA_Vector2(Vector2 value)
        {
            Value = value;
        }
    }

    public class EA_Float : EventArgs
    {
        public float Value;

        public EA_Float(float value)
        {
            Value = value;
        }
    }
}
