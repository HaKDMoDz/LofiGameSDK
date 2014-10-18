using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using Point = System.Drawing.Point;
using Lofinil.GameSDK.Editor;
using Lofinil.GameSDK.Engine.WinControl;
using Lofinil.GameSDK.Engine;

namespace LofiEditor.Forms
{
    // 参考ItemEditForm
    public class ItemEditControl : XNAControl
    {
        private Vector2 canvasCenter;

        private Camera camera;

        public AbstractComponent CurrentItem;
        public enum EEditMode
        {
            Idle,
            Pan,
            Transform,
            RotateTexture,
        }
        public EEditMode EditMode;
        public bool ShowTexture = true;
        public bool ShowBody = true;
        public bool ShowGrid = true;

        bool dragging = false;
        Point dragStartPoint = new Point();
        ETransformType transType;

        protected override void Initialize()
        {
            base.Initialize();

            // base.Initialize();
            canvasCenter = new Vector2(Width / 2f, Height / 2f);

            camera = new Camera(0);
            camera.WindowSize = new Vector2(this.Width, this.Height);
            camera.Focus = new Vector2(0, 0);

        }

        protected override void XNAControl_Update(object sender, EventArgs e)
        {
            base.XNAControl_Update(sender, e);

            if (CurrentItem == null)
                return;
        }

        protected override void XNAControl_Draw(object sender, EventArgs e)
        {
            base.XNAControl_Draw(sender, e);
            if(CurrentItem == null)
                return;

            GameManager.Instance.GraphicsMgr.DrawBegin();

            // Logic Here!
            // Do not draw the whole Item, seperate it to draw edit controls

            // Draw grid or system 
            if (ShowGrid) 
                drawGrid();

            // Draw texture layer
            if(ShowTexture)
                drawTexture();

            // Draw texture layer control
            if(EditMode == EEditMode.Transform || EditMode == EEditMode.RotateTexture)
                drawTextureControl();

            GameManager.Instance.GraphicsMgr.DrawEnd();
        }

        private void drawGrid()
        {
            Rectangle rectSysH = new Rectangle(
                (int)0,
                (int)(canvasCenter.Y - 2),
                (int)this.Width,
                5);
            Rectangle rectSysV = new Rectangle(
                (int)(canvasCenter.X - 2),
                (int)0,
                5,
                (int)this.Height);
            //GameManager.Instance.GraphicsMgr.Draw(sysHTexture, rectSysH);
            //GameManager.Instance.GraphicsMgr.Draw(sysVTexture, rectSysV);
        }

        private void drawTexture()
        {
            CurrentItem.Draw();
        }

        private void drawTextureControl()
        {
            Rectangle r = (CurrentItem.GetCompByType(typeof(Transform)) as Transform).GetOrthoBox();
            Rectangle camR = camera.RectangleToScreen(r);
            TransHelper.DrawRectTransControl(camR);
        }

        public void DrawRectTransControl()
        {
            Rectangle r = (CurrentItem.GetCompByType(typeof(Transform)) as Transform).GetOrthoBox();
            TransHelper.DrawRectTransControl(r);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (EditMode == EEditMode.Pan)
            {
                dragging = true;
                dragStartPoint = e.Location;
            }
            else if (EditMode == EEditMode.Transform)
            {
                Point p = e.Location;
                Rectangle r = (CurrentItem.GetCompByType(typeof(Transform)) as Transform).GetOrthoBox();
                Rectangle camR = camera.RectangleToScreen(r);
                transType = TransHelper.CheckTransformRect(camR, p);
                if (transType != ETransformType.None)
                {
                    dragStartPoint = p;
                    dragging = true;
                }
                else
                {
                    EditMode = EEditMode.Idle;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (EditMode == EEditMode.Pan && dragging)
            {
                Vector2 delta = new Vector2(
                    e.X - dragStartPoint.X, e.Y - dragStartPoint.Y);
                camera.SetAbsFocus(new Vector2(camera.Focus.X - delta.X, camera.Focus.Y - delta.Y));
                dragStartPoint = e.Location;
            }
            else if (EditMode == EEditMode.Transform && dragging)
            {
                Vector2 pDelta = new Vector2(e.X - dragStartPoint.X, e.Y - dragStartPoint.Y);
                // UNDONE [绘制变换控件]
                TransHelper.Transform(transType, pDelta, (Transform)CurrentItem.GetCompByType(typeof(Transform)));
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
