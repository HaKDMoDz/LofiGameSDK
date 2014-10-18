using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor.Interception;
using Lofinil.GameSDK.Editor.Interception.ModuleInterface;

namespace Lofinil.GameSDK.Editor.Module.Menu
{
    public partial class MenuControl : UserControl, IView
    {
        public MenuControl()
        {
            InitializeComponent();
        }
    }
}
