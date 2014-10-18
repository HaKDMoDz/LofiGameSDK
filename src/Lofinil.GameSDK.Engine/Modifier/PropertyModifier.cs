using System;

namespace Lofinil.GameSDK.Engine
{
    /// <summary>
    /// ParamTween类
    /// </summary>
    public class PropertyModifier
    {
        public String Name { get; set; }

        public String ItemName { get; set; }

        public String PropertyName { get; set; }

        public bool Tweening { get; set; }

        public float TotalTimeMS = 0;

        public virtual Object StartValue { get; set; }

        public virtual Object EndValue { get; set; }

        public virtual Object CurrentValue { get; set; }

        public virtual Object Tag { get; set; }

        public event EventHandler OnStart;

        public event EventHandler OnFinish;

        public virtual void Update()
        {
            if (Tweening == false && OnFinish != null)
                OnFinish(this, null);
        }

        public void StartModify()
        {
            if (OnStart != null)
                OnStart(this, null);
            Tweening = true;
        }

        public void StopModify() { Tweening = false; }

        public void Reset()
        {
            CurrentValue = StartValue;
            Tweening = false;
        }

        public void SetToFinal()
        {
            CurrentValue = EndValue;
            if (OnFinish != null)
                OnFinish(this, null);
            Tweening = false;
        }

        public PropertyModifier(String name, String propertyName)
        {
            this.Name = name;
            this.PropertyName = propertyName;
        }

        // Serialize
        public PropertyModifier()
        {
        }
    }
}