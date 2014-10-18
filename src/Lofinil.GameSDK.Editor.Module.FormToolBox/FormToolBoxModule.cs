using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.Module.FormView;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor.Module.Menu;
using MenuItem = Lofinil.GameSDK.Editor.Module.Menu.MenuItem;
using Lofinil.GameSDK.Editor.Module.StatusBar;

namespace Lofinil.GameSDK.Editor.Module.FormToolBox
{
    public class FormToolBoxModule : ToolBoxModule
    {
        ToolBox ctrl;

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            ctrl = new ToolBox();
            EditorService.Instance.QueryModule<FormViewModule>().RegisterView(ctrl, "Tools");

            base.ToolListChanged += ctrl.toolBoxControl1.OnToolListChanged;

            MenuModule menu = EditorService.Instance.QueryModule<MenuModule>();
            MenuItem mItem = new MenuItem();
            mItem.Name = "工具配置";
            mItem.Index = 0;
            menu.AddMenuItem("", mItem);

            StatusBarModule sbm = EditorService.Instance.QueryModule<StatusBarModule>();
            sbm.AddIndicator("当前工具");
            sbm.SetIndicator("当前工具", "当前工具：无");

            
        }

        #region 工具上下文呈现
        public void SetToolContextControl(Control control)
        {
            ctrl.customControl1.Controls.Clear();
            ctrl.customControl1.Controls.Add(control);
        }
        #endregion 工具上下文呈现
    }
}
