using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;

namespace XMediaService
{
    using Color = System.Drawing.Color;
    using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Microsoft.Xna.Framework.Content;

    public class GraphicsDeviceControl : Control
    {
        private GraphicsDeviceService graphicsDeviceService;

        public GraphicsDevice GraphicsDevice
        {
            get { return graphicsDeviceService.GraphicsDevice; }
        }

        public ServiceContainer Services
        {
            get { return services; }
        }
        private ServiceContainer services = new ServiceContainer();

        public ContentManager ContentMgr
        {
            get
            {
                return contentMgr;
            }
        }
        private ContentManager contentMgr;


        public GraphicsDeviceControl()
        {
            contentMgr = new ContentManager(services);
        }


        protected override void OnCreateControl()
        {
            if (!DesignMode)
            {
                graphicsDeviceService = GraphicsDeviceService.AddRef(this.Handle, this.Width, this.Height);
                services.AddService(typeof(IGraphicsDeviceService), graphicsDeviceService);
                Initialize();
            }
            base.OnCreateControl();
        }

        protected override void Dispose(bool disposing)
        {
            if (graphicsDeviceService != null)
            {
                graphicsDeviceService.Release(disposing);
                graphicsDeviceService = null;
            }
            if (disposing)
                contentMgr.Unload();
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            string beginDrawError = BeginDraw();
            if (string.IsNullOrEmpty(beginDrawError))
            {
                Update();
                Draw();
                EndDraw();
            }
            else
            {
                PaintUsingSystemDrawing(e.Graphics, beginDrawError);
            }
        }

        private string BeginDraw()
        {
            if (graphicsDeviceService == null)
            {
                return Text + "\n\n" + GetType();
            }
            string deviceResetError = HandleDeviceReset();
            if (!string.IsNullOrEmpty(deviceResetError))
                return deviceResetError;

            Viewport viewport = new Viewport();
            viewport.X = 0;
            viewport.Y = 0;

            viewport.Width = ClientSize.Width;
            viewport.Height = ClientSize.Height;
            viewport.MinDepth = 0;
            viewport.MaxDepth = 1;

            GraphicsDevice.Viewport = viewport;

            return null;
        }

        private void EndDraw()
        {
            try
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
                GraphicsDevice.Present(sourceRectangle, null, this.Handle);
            }
            catch
            {
            }
        }

        private string HandleDeviceReset()
        {
            bool deviceNeedsReset = false;
            switch (GraphicsDevice.GraphicsDeviceStatus)
            {
                case GraphicsDeviceStatus.Lost:
                    return "Graphics device lost";
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
                try
                {
                    graphicsDeviceService.ResetDevice(ClientSize.Width, ClientSize.Height);
                }
                catch(Exception ex)
                {
                    return "Graphics Device Reset Failed \n\n" + ex;
                }
            }
            return null;
        }

        protected virtual void PaintUsingSystemDrawing(Graphics graphics, String text)
        {
            graphics.Clear(Color.CornflowerBlue);
            using (Brush brush = new SolidBrush(Color.Black))
            {
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    graphics.DrawString(text, Font, brush, ClientRectangle, format);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            
        }

        protected virtual void Initialize()
        {
            Application.Idle += delegate { Invalidate(); };
        }
        protected virtual new void Update() { }
        protected virtual void Draw() { }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

    }
}
