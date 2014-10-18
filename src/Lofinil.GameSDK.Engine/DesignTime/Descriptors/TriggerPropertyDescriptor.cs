using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Lofinil.GameSDK.Engine
{
    // wiki:///E:/CodeDir/LofiGameSDK/Wiki/LofiGameSDK/Lofinil%20Game%20SDK.wiki?page=TriggerPropertyDescriptor%20Class
    public class TriggerPropertyDescriptor : PropertyDescriptor
    {
        public TriggerPropertyDescriptor(String triggerName) : base(triggerName, new Attribute[]{})
        {
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get { return typeof(Trigger); }
        }

        public override object GetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get { return typeof(String); }
        }

        public override void ResetValue(object component)
        {
            Trigger trigger = (Trigger)component;
            trigger.ConditionList.Clear();
            trigger.ActionList.Clear();
        }

        public override void SetValue(object component, object value)
        {
            component = value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
