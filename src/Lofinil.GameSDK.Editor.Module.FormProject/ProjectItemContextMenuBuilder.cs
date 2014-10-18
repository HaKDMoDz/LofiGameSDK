using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor.Module.Menu;

namespace Lofinil.GameSDK.Editor.Module.FormProject
{
    public class ProjectItemContextMenuBuilder
    {
        public ContextMenuStrip Menu;

        public void SetMenu(Lofinil.GameSDK.Editor.Module.Menu.MenuItem[] items)
        {
            Menu.Items.Clear();
            // HACK
            foreach (Lofinil.GameSDK.Editor.Module.Menu.MenuItem i in items)
            {
                if (i is Menu.MenuItem)
                {
                    Menu.MenuItem ci = (Menu.MenuItem)i;
                    Menu.Items.Add(ci.Name, null, delegate { if(ci.Command!=null) ci.Command(); });
                }
            }
        }
    }
}
