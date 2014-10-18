using System;
using Microsoft.Xna.Framework;

namespace Lofinil.GameSDK.Engine
{
    public class RelaRateModifier : PropertyModifier
    {
        #region Variables

        private Vector2 startValue;

        #endregion Variables

        public override Object StartValue
        {
            get
            {
                return startValue;
            }
            set
            {
                startValue = (Vector2)value;
            }
        }

        public Vector2 Speed { get; set; }

        public RelaRateModifier(String name, String propertyName)
            : base(name, propertyName)
        {
        }

        public RelaRateModifier(String name, String propertyName, Vector2 startPos, Vector2 speed, float time)
            : base(name, propertyName)
        {
            this.StartValue = startPos;
            this.Speed = speed;
            this.TotalTimeMS = time;
            this.EndValue = startPos + Speed * (TotalTimeMS / 1000);
        }

        public RelaRateModifier()
        {
        }
    }
}