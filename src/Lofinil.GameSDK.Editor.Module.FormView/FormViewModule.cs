using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.Module.View;
using System.Windows.Forms;

namespace Lofinil.GameSDK.Editor.Module.FormView
{
    public class FormViewModule : ViewModule
    {
        public FormViewModule()
        {
        }

        public new void RegisterView(IView view, string regionName)
        {
            IRegion region = QueryRegion(regionName);

            ((FormRegion)region).Holder.Controls.Clear();
            ((Control)view).Dock = DockStyle.Fill;
            ((FormRegion)region).Holder.Controls.Add((Control)view);
        }

        public new void ShowRegion(String regionName)
        {
            FormRegion reg = (FormRegion)QueryRegion(regionName);
            reg.Show();
        }

    }
}
