using System;
using Microsoft.Xna.Framework;

namespace Lofinil.GameSDK.Engine
{
    public class GloPosModifier : PropertyModifier
    {
        private Vector2 startValue;
        private Vector2 endValue;
        private Vector2 speed;
        private Vector2 currentValue;
        private float startTimeMs;

        public GloPosModifier()
        {
            Tweening = false;
        }

        // 设计时 - 访问器
        public Accessor TransAccessor;

        // 运行时 - 变形组件引用
        public Transform Transform
        {
            get { return (Transform)TransAccessor.Access(GameService.Instance); }
        }

        public override Object CurrentValue { get { return currentValue; } }

        public GloPosModifier(String name, String propertyName)
            : base(name, propertyName)
        {
        }

        public GloPosModifier(String name, String propertyName, Vector2 start, Vector2 end, float time)
            : base(name, propertyName)
        {
            startValue = start;
            endValue = end;
            TotalTimeMS = time;
        }

        public override void Update()
        {
            long timeInMs = GameService.Instance.TotalTimeInMs;

            // 终值
            if (timeInMs - startTimeMs >= TotalTimeMS)
            {
                Tweening = false;
                GameComponent item = GameService.Instance.QueryModule<StageModule>().GetItemByName(ItemName);
                NETFramework.SetPropertyByName(item, PropertyName, EndValue);
                StopModify();

                return;
            }
            else
            {
                // 中间值
                float percent = (timeInMs - startTimeMs) / TotalTimeMS;
                Vector2 pos1 = startValue;
                Vector2 pos2 = endValue;
                currentValue = new Vector2((pos2.X - pos1.X) * percent + pos1.X, (pos2.Y - pos1.Y) * percent + pos1.Y);
                NETFramework.SetPropertyByName(Transform, PropertyName, currentValue);
            }
            base.Update();
        }

        public void StartModify(GameComponent item)
        {
            Tweening = true;
            startTimeMs = GameService.Instance.TotalTimeInMs;
        }

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

        public override Object EndValue
        {
            get
            {
                return endValue;
            }
            set
            {
                endValue = (Vector2)value;
            }
        }

        public override Object Tag
        {
            get
            {
                return speed;
            }
            set
            {
                speed = (Vector2)value;
            }
        }
    }
}