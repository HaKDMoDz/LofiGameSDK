using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor.Module.FormView;

namespace Lofinil.GameSDK.Editor.Module.StatusBar
{
    [ModuleDependency("FormViewModule")]
    public class StatusBarModule : EditorModule
    {
        private StatusBar bar;

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            bar = new StatusBar();
            EditorService.Instance.QueryModule<FormViewModule>().RegisterView(bar, "Status");

            Application.Idle += delegate { Idle(); };
        }

        private void Idle()
        {
            bar.statusStrip1.Items[0].Text = "参考FPS: " + GameService.Instance.QueryModule<TimeModule>().FrameRate;
        }

        public void AddIndicator(String name)
        {
            ToolStripItem i = new ToolStripLabel("", null, false, null, name);
            bar.statusStrip1.Items.Add(i);
        }

        public void SetIndicator(String name, String text)
        {
            bar.statusStrip1.Items.Find(name, false).First().Text = text;
        }
    }
}
