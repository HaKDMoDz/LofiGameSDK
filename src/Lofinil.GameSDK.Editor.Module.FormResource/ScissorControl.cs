using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LofiEditor
{
    public partial class ScissorControl : UserControl
    {
        // 共存控件
        public ImageScissor TexSsr;

        public ScissorControl()
        {
            InitializeComponent();
        }

        private void btnSelAll_Click(object sender, EventArgs e)
        {
            TexSsr.MakeSelAll();
        }
    }
}
