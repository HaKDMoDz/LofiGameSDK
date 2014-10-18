using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor.Module.ToolBox;

namespace Lofinil.GameSDK.Editor.Module.FormToolBox
{
    public partial class ToolBoxControl : UserControl
    {
        public ToolBoxControl()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            if (Size.Height < ClientSize.Height)
                Size = new System.Drawing.Size(Size.Width, ClientSize.Height);
        }

        public void OnToolListChanged(List<ToolItem> toolList)
        {
            Control container = this.flowLayoutPanel1;
            container.Controls.Clear();

            foreach (ToolItem tool in toolList)
            {
                Button btn = new Button();
                btn.Size = new Size(31, 31);
                btn.Image = (Bitmap)tool.Image;
                btn.Tag = tool;
                btn.Click += delegate 
                {
                    ToolItem t = (ToolItem)btn.Tag;
                    if(t.TurnOn!=null) 
                        t.TurnOn(); 
                };
                container.Controls.Add(btn);
            }

            // 工具箱尺寸的宽度由容器决定，而高度则以能够显示全部工具为准
            int width = container.Width;
            int toolWidth = 37;      // 31 + 3 + 3
            int toolHeight = 37;     //  31+3+3
            int row = (int)Math.Ceiling(toolList.Count * (float)toolWidth / width);
            int height = row * toolHeight;
            this.Height = height;
        }
    }
}
