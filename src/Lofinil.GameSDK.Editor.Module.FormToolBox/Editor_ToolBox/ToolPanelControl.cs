using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Lofinil.GameSDK.Editor;
using Lofinil.GameSDK.Editor.Interception;

namespace Lofinil.GameSDK.Editor.Module.FormToolBox
{
    public partial class ToolBox : UserControl, IToolBoxView, IView
    {
        private EditorService editMgr;

        public ToolBox()
        {
            InitializeComponent();
        }
    }
}
