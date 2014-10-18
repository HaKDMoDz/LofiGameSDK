using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.Module.FormView;
using System.Windows.Forms;

namespace Lofinil.GameSDK.Editor.Module.PropertyEditor
{
    [ModuleDependency("FormViewModule")]
    public class PropertyEditorModule : EditorModule
    {
        private PropertyEditor pe;

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            pe = new PropertyEditor();
            EditorService.Instance.QueryModule<FormViewModule>().RegisterView(pe, "PropertyTab");
        }

        public void SetTarget(Object target)
        {
            pe.propertyGrid1.SelectedObject = target;
        }
    }
}
