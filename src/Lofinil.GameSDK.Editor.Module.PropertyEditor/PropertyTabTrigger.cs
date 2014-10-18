using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor.SharedRes;

namespace Lofinil.GameSDK.Editor.App
{
    // 触发器组件的触发器编辑页
    public class PropertyTabTrigger : PropertyTab
    {
        private static Bitmap image;

        private GameComponent Component;

        public PropertyTabTrigger()
        {
            image = Resources._16_Trigger;
            Component = null;
        }

        public override string TabName{get { return "触发器"; }}

        public override Bitmap Bitmap{get {return image; }}

        public override PropertyDescriptorCollection GetProperties(object component, Attribute[] attributes)
        {
            List<PropertyDescriptor> PDList = new List<PropertyDescriptor>();

            foreach(Trigger tgr in Component.Triggers)
            {
                PropertyDescriptor pd = new TriggerPropertyDescriptor(tgr.Event.EventName);
            }
            return new PropertyDescriptorCollection(PDList.ToArray());
        }

        public override PropertyDescriptorCollection GetProperties(object component)
        {
            return GetProperties(component, null);
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object component, Attribute[] attributes)
        {
            return GetProperties(component, null);
        }
    }
}
