using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine;
using LofiEngine.Graphics;
using LofiEngine.Items;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Helpers;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using LofiEngine.Scenes;
using Point = System.Drawing.Point;
using XMediaService;

namespace LofiEditor.Forms
{
    public class ItemEditControl : GraphicsDeviceControl
    {
        static Texture2D bodyTexture = LoadHelper.LoadTexture2D("Common/Body");
        static Texture2D sysHTexture = LoadHelper.LoadTexture2D("Grid/SystemH5");
        static Texture2D sysVTexture = LoadHelper.LoadTexture2D("Grid/SystemV5");

        private AnimTexture animTexture { get { return CurrentItem.AnimTexture; } }
        private PhysicsBody physicsBody { get { return CurrentItem.PhysicsBody; } }
        private Vector2 canvasCenter;

        private Camera camera;

        public Item CurrentItem;
        public enum EEditMode
        {
            Idle,
            Pan,
            TransformTexture,
            RotateTexture,
            TransformBody,
            RotateBody,
        }
        public EEditMode EditMode;
        public bool ShowTexture = true;
        public bool ShowBody = true;
        public bool ShowGrid = true;
        // public bool 

        protected override void Initialize()
        {
            base.Initialize();
            canvasCenter = new Vector2(Width / 2f, Height / 2f);

            camera = new Camera(0);
            camera.WindowSize = new Vector2(this.Width, this.Height);
            camera.Focus = new Vector2(0, 0);
        }

        protected override void Draw()
        {
            if(CurrentItem == null)
                return;

            ModuleSharer.GraphicsMgr.DrawBegin();

            // Logic Here!
            // Do not draw the whole Item, seperate it to draw edit controls

            // Draw grid or system 
            if (ShowGrid) 
                drawGrid();

            // Draw physics layer
            if(ShowBody && physicsBody != null)
                drawBody();

            // Draw physics layer control
            if(EditMode == EEditMode.RotateBody || EditMode == EEditMode.TransformBody)
                drawBodyControl();

            // Draw texture layer
            if(ShowTexture && animTexture != null)
                drawTexture();

            // Draw texture layer control
            if(EditMode == EEditMode.TransformTexture || EditMode == EEditMode.RotateTexture)
                drawTextureControl();

            ModuleSharer.GraphicsMgr.DrawEnd();
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
            ModuleSharer.GraphicsMgr.Draw(sysHTexture, rectSysH);
            ModuleSharer.GraphicsMgr.Draw(sysVTexture, rectSysV);
        }

        private void drawBody()
        {
            Rectangle bodyRect = new Rectangle(
                (int)(-physicsBody.Size.X / 2),
                (int)(-physicsBody.Size.Y / 2),
                (int)physicsBody.Size.X,
                (int)physicsBody.Size.Y);
            Rectangle camRect = camera.RectangleToScreen(bodyRect);
            ModuleSharer.GraphicsMgr.Draw(bodyTexture, camRect);
        }

        private void drawBodyControl()
        {
            Rectangle r = CurrentItem.PhysicsBody.GetAABB();
            Rectangle camR = camera.RectangleToScreen(r);
            TransHelper.DrawRectTransControl(camR);
        }

        private void drawTexture()
        {
            CurrentItem.AnimTexture.Draw(camera, 0, null, null, null);
        }

        private void drawTextureControl()
        {
            Rectangle r = CurrentItem.AnimTexture.GetAABB();
            Rectangle camR = camera.RectangleToScreen(r);
            TransHelper.DrawRectTransControl(camR);
        }

        public void DrawRectTransControl()
        {
            Rectangle r = CurrentItem.PhysicsBody.GetAABB();
            TransHelper.DrawRectTransControl(r);
        }

        bool dragging = false;
        Point dragStartPoint = new Point();
        ETransformType transType;
        protected override void Update()
        {
            if (CurrentItem == null)
                return;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (EditMode == EEditMode.Pan)
            {
                dragging = true;
                dragStartPoint = e.Location;
            }
            else if (EditMode == EEditMode.TransformTexture)
            {
                Point p = e.Location;
                Rectangle r = animTexture.GetAABB();
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
            else if (EditMode == EEditMode.TransformBody)
            {
                Point p = e.Location;
                Rectangle r = physicsBody.GetAABB();
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
            else if (EditMode == EEditMode.TransformTexture && dragging)
            {
                Vector2 pDelta = new Vector2(e.X - dragStartPoint.X, e.Y - dragStartPoint.Y);
                // TODO show temp rect
                animTexture.Transform(transType, pDelta);
            }
            else if (EditMode == EEditMode.TransformBody && dragging)
            {
                Vector2 pDelta = new Vector2(e.X - dragStartPoint.X, e.Y - dragStartPoint.Y);
                physicsBody.Transform(transType, pDelta);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
