using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Drawing;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using System.ComponentModel.Design;

namespace Lofinil.GameSDK.Engine.WinControl
{
    // 
    public class XNAControl : UserControl
    {
        public GraphicsDevice GraphicsDevice { get { return graphicsDeviceService.GraphicsDevice; } }
        public static GraphicsDevice graphicsDevice;

        public ServiceContainer Services { get { return services; } }
        private ServiceContainer services = new ServiceContainer();

        private GraphicsDeviceService graphicsDeviceService;

        protected Viewport viewport = new Viewport(0,0,800,600);
        protected Rectangle sourceRect;

        public new event EventHandler               Update;         // 引擎更新事件
        public event EventHandler<PaintEventArgs>   FormDrawBefore; // 引擎绘制前窗体附加绘制
        public event EventHandler                   Draw;           // 引擎绘制事件
        public event EventHandler<PaintEventArgs>   FormDrawAfter;  // 引擎绘制后窗体附加绘制

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // XNAControl
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "XNAControl";
            this.ResumeLayout(false);
        }

        protected override void OnCreateControl()
        {
            if (!DesignMode)
            {
                graphicsDeviceService = GraphicsDeviceService.AddRef(this.Handle, this.Width, this.Height);
                services.AddService(typeof(IGraphicsDeviceService), graphicsDeviceService);
                Initialize();
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.Update += new EventHandler(XNAControl_Update);
                this.FormDrawBefore += new EventHandler<PaintEventArgs>(XNAControl_FormDrawBefore);
                this.Draw += new EventHandler(XNAControl_Draw);
                this.FormDrawAfter += new EventHandler<PaintEventArgs>(XNAControl_FormDrawAfter);

                // TODO XNA输入绑定句柄管理
                Microsoft.Xna.Framework.Input.Mouse.WindowHandle = this.Handle;

            }
            base.OnCreateControl();
        }

        protected virtual void Initialize()
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!DesignMode && beginDraw())
            {
                GraphicsDevice.Viewport = viewport;

                // 逻辑更新
                Update(this, null);

                // GDI前绘制
                FormDrawBefore(this, e);

                // 引擎函数调用绘制到纹理，随后由GDI绘制
                Bitmap bmp = GameService.Instance.RenderCallToBitmap(delegate { Draw(this, null); });
                e.Graphics.DrawImage(bmp, new PointF(0, 0));

                // GDI后绘制
                FormDrawAfter(this, e);
            }
        }

        // 逻辑更新消息处理虚函数
        protected virtual void XNAControl_Update(object sender, EventArgs e)
        {
        }

        // GDI前绘制消息处理虚函数
        protected virtual void XNAControl_FormDrawBefore(object sender, PaintEventArgs e)
        {
        }

        // 绘制到纹理回调消息处理虚函数
        protected virtual void XNAControl_Draw(object sender, EventArgs e)
        {
        }

        // GDI后绘制消息处理虚函数
        protected virtual void XNAControl_FormDrawAfter(object sender, PaintEventArgs e)
        {
        }

        bool beginDraw()
        {
            if (graphicsDeviceService == null || handleDeviceReset() == false)
                return false;

            Viewport viewport = new Viewport();
            viewport.X = 0;
            viewport.Y = 0;
            viewport.Width = ClientSize.Width;
            viewport.Height = ClientSize.Height;
            viewport.MinDepth = 0;
            viewport.MaxDepth = 1;
            GraphicsDevice.Viewport = viewport;

            return true;
        }

        bool handleDeviceReset()
        {
            bool deviceNeedsReset = false;

            switch (GraphicsDevice.GraphicsDeviceStatus)
            {
                case GraphicsDeviceStatus.Lost:
                    return false;
                case GraphicsDeviceStatus.NotReset:
                    deviceNeedsReset = true;
                    break;
                default:
                    PresentationParameters pp = GraphicsDevice.PresentationParameters;
                    deviceNeedsReset = (ClientSize.Width > pp.BackBufferWidth) ||
                                       (ClientSize.Height > pp.BackBufferHeight);
                    break;
            }

            if (deviceNeedsReset)
            {
                graphicsDeviceService.ResetDevice(ClientSize.Width,
                                                      ClientSize.Height);
            }
            return true;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            viewport = new Viewport();
            viewport.X = 0;
            viewport.Y = 0;
            viewport.Width = ClientSize.Width;
            viewport.Height = ClientSize.Height;
            viewport.MinDepth = 0;
            viewport.MaxDepth = 1;

            sourceRect = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // NOTE 运行时留空 避免闪烁
            if (DesignMode)
                pevent.Graphics.FillRectangle(Brushes.Chocolate, this.ClientRectangle);
            
        }

        protected override void Dispose(bool disposing)
        {
            if (graphicsDeviceService != null)
            {
                graphicsDeviceService.Release(disposing);
                graphicsDeviceService = null;
            }
            base.Dispose(disposing);
        }
    }
}
