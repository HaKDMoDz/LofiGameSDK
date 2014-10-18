using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor;
using System.IO;

namespace Lofinil.GameSDK.Editor.App
{
    public partial class CreateContextControl : UserControl
    {
        public CreateContextControl()
        {
            InitializeComponent();
        }

        private void imagePicker1_Click(object sender, EventArgs e)
        {
            lbTexName.Text = imagePicker1.TexKey;
        }

        private void componentPicker1_Click(object sender, EventArgs e)
        {
            lbCompName.Text = componentPicker1.ComponentName;
        }
    }
}
