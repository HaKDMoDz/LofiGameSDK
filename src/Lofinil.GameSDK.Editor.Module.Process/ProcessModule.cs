using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.App;
using Lofinil.GameSDK.Editor.Module.FormView;

namespace Lofinil.GameSDK.Editor.Module.Process
{
    [ModuleDependency("FormViewModule")]
    public class ProcessModule : EditorModule
    {
        public ProcessModule()
        {
        }

        public override void Load()
        {
            base.Load();
        }

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            EditorService.Instance.QueryModule<FormViewModule>().RegisterView(WaitForm.Instance, true);
        }

        public override void Unload()
        {
            base.Unload();
        }
    }
}
