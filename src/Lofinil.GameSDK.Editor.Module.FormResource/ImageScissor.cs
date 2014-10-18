using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor.App;
using Lofinil.GameSDK.Editor;
using Lofinil.GameSDK.Editor.SharedRes;

namespace LofiEditor
{
    // TODO [裁剪器] 输入操作
    // TODO [裁剪器] 实际数据
    // TODO [裁剪器] 选区绘制
    // TODO [裁剪器] 完全选区
    // TODO [裁剪器] 标尺
    // TODO [裁剪器] 全透明像素边缘吸附
    // TODO [裁剪器] 导入区域数据
    public partial class ImageScissor : PictureBox
    {
        // 共存控件
        public ScissorControl SsrCtrl;

        public Rectangle CurSel 
        {
            get { return curSel; }
            set { curSel = value; SelChanged(this, null); } 
        }
        private Rectangle curSel;

        private Rectangle selRectTop;
        private Rectangle selRectLeft;
        private Rectangle selRectBottom;
        private Rectangle selRectRight;
        private Point hdlTL;
        private Point hdlTR;
        private Point hdlBL;
        private Point hdlBR;

        public event EventHandler SelChanged;

        public ImageScissor()
        {
            InitializeComponent();

            this.SelChanged += OnSelChanged;
        }

        protected void OnSelChanged(Object sender, EventArgs e)
        {
            updateSpRect();
        }

        private void updateSpRect()
        {
            if (!curSel.Size.IsEmpty)
            {
                selRectTop = new Rectangle(curSel.Left, curSel.Top - 1, curSel.Width, 3);
                selRectLeft = new Rectangle(curSel.Left - 1, curSel.Top, 3, curSel.Height);
                selRectBottom = new Rectangle(curSel.Left, curSel.Bottom - 1, curSel.Width, 3);
                selRectRight = new Rectangle(curSel.Right - 1, curSel.Top, 3, curSel.Height);
                hdlTL = new Point(curSel.Left - 3, curSel.Top - 3);
                hdlTR = new Point(curSel.Right - 3, curSel.Top - 3);
                hdlBL = new Point(curSel.Left - 3, curSel.Bottom - 3);
                hdlBR = new Point(curSel.Right - 3, curSel.Bottom - 3);
            }
        }

        private void TexScissor_Paint(object sender, PaintEventArgs e)
        {
            drawSelection(e.Graphics);
        }

        private void drawSelection(Graphics g)
        {
            if (!CurSel.Size.IsEmpty)
            {
                Brush b = new TextureBrush(Lofinil.GameSDK.Editor.SharedRes.Resources.ResizeHLine);
                g.FillRectangle(b, selRectTop);
                g.FillRectangle(b, selRectBottom);
                b = new TextureBrush(Lofinil.GameSDK.Editor.SharedRes.Resources.ResizeVLine);
                g.FillRectangle(b, selRectLeft);
                g.FillRectangle(b, selRectRight);

                Color c = Color.FromArgb(100, 0, 0, 0);
                b = new SolidBrush(c);
                g.FillRectangle(b, curSel);

                g.DrawImage(Lofinil.GameSDK.Editor.SharedRes.Resources.ResizeControl, hdlBL);
                g.DrawImage(Lofinil.GameSDK.Editor.SharedRes.Resources.ResizeControl, hdlBR);
                g.DrawImage(Lofinil.GameSDK.Editor.SharedRes.Resources.ResizeControl, hdlTL);
                g.DrawImage(Lofinil.GameSDK.Editor.SharedRes.Resources.ResizeControl, hdlTR);
            }
        }

        public void MakeSelAll()
        {
            if (this.Image != null)
            {
                CurSel = new Rectangle(0, 0, Image.Width, Image.Height);
            }
            else
            {
                CurSel = new Rectangle(0, 0, 100, 100);
            }
            this.Invalidate();
        }

        public void ClearSel()
        {
            curSel = Rectangle.Empty;
        }
    }
}
