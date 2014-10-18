using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lofinil.GameSDK.Editor.Module.FormView
{
    public class FormRegion : IRegion
    {
        public String Name { get; set; }

        public Control Holder;

        public FormRegion(String name, Control holder)
        {
            Name = name;
            Holder = holder;
        }

        public void Show()
        {
            if (Holder is TabPage)
            {
                ((TabControl)((TabPage)Holder).Parent).SelectedTab = (TabPage)Holder;
            }
        }

    }
}
