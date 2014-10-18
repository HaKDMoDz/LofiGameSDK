using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Point = System.Drawing.Point;
using Color = System.Drawing.Color;
using Rectangle = System.Drawing.Rectangle;
using GameComponent = Lofinil.GameSDK.Engine.GameComponent;
using GameComponentCollection = Lofinil.GameSDK.Engine.GameComponentCollection;
using IGameComponent = Lofinil.GameSDK.Engine.GameComponent;
using Lofinil.GameSDK.Engine.WinControl;
using Lofinil.GameSDK.Editor;
using Lofinil.GameSDK.Engine;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace Lofinil.GameSDK.Editor.App
{
    public class StageEditControl : XNAControl, IStageView, ICanvasView
    {
        public EditorService EditorService;
        public StageEditModule StageEditModule;
        public StageEditControlPresenter Presenter;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // StageEditControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "StageEditControl";
            this.Size = new System.Drawing.Size(447, 272);
            this.ResumeLayout(false);

        }

        protected override void Initialize()
        {
            base.Initialize();

            EditorService = EditorService.Instance;
            StageEditModule = EditorService.QueryModule<StageEditModule>();

            Presenter = new StageEditControlPresenter();
            Presenter.RefGridSetting = new RefGridSetting();

            // NOTE 标明该控件需要实时刷新 （并不是所有的XNAControl都要实时刷新）
            Application.Idle += delegate
            {
                Invalidate();
            };
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            GameService.Instance.Initialize(ExecuteMode.DesignTime, this.GraphicsDevice, Services);
        }

        protected override void XNAControl_Draw(object sender, EventArgs e)
        {
            base.XNAControl_Draw(sender, e);

            // TODO [XNA绘制问题解决] 图元绘制与纹理绘制同时使用会出现缓冲问题 
            // gameMgr.GraphicsMgr.DrawLine(Vector2.Zero, new Vector2(500, 500), Microsoft.Xna.Framework.Color.Chartreuse);

            StageEditModule.DrawStage();
        }

        protected override void XNAControl_FormDrawAfter(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            base.XNAControl_FormDrawAfter(sender, e);
            drawSeletingRect(e.Graphics);
            drawSelectionRectangle(e.Graphics);

            if (EditorService.Instance.QueryModule<StageEditModule>().StageLoaded)
                drawReferenceGrid(e.Graphics);
            else
                e.Graphics.DrawString("尚未打开场景", SystemFonts.DefaultFont, Brushes.Orange, 5,5);
        }

        private void drawSeletingRect(System.Drawing.Graphics g)
        {
            if (Presenter.dragVisible)
                g.FillRectangle(Presenter.dragTexture, Presenter.dragRect);
        }

        private void drawSelectionRectangle(System.Drawing.Graphics g)
        {
            //if (EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Transform &&
            //    StageEditModule.SelectedItems.Count > 0)
            //{
            //    TransHelper.DrawRectTransControl(StageEditModule.SelectedItems[0].Children.QueryComponent<Transform>().GetOrthoBox());
            //}
        }

        private void drawReferenceGrid(System.Drawing.Graphics g)
        {
            // TODO 可将参考网格绘制实现为次控件的装饰
            // TODO 缓存参考网格临时量以优化代码
            if (Presenter.RefGridSetting.ShowGrid)
            {
                if (Presenter.RefGridSetting.OriginMode == RefGridOriginMode.TopLeftOfView &&
                    Presenter.RefGridSetting.UnitMode == RefGridUnitMode.PixelOfScreen)
                {
                    if (Presenter.RefGridSetting.ColumnStep <= 1 || Presenter.RefGridSetting.RowStep <= 1)
                        return;
                    int thisWidth = this.Width;
                    int thisHeight = this.Height;
                    int colCount = (int)Math.Ceiling(thisWidth / Presenter.RefGridSetting.ColumnStep);
                    int rowCount = (int)Math.Ceiling(thisHeight / Presenter.RefGridSetting.RowStep);

                    Pen p = new Pen(Color.FromArgb(50, 0, 0, 0), 3);

                    for (int i = 0; i < colCount; i++)
                    {
                        float x = Presenter.RefGridSetting.ColumnStep * i;
                        g.DrawLine(p, new PointF(x - 1, 0), new PointF(x - 1, thisHeight));
                    }

                    for (int i = 0; i < rowCount; i++)
                    {
                        float y = Presenter.RefGridSetting.RowStep * i;
                        g.DrawLine(p, new PointF(0, y - 1), new PointF(thisWidth, y - 1));
                    }
                }
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            MouseButton btn = MouseButton.None;
            switch(e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    btn =  MouseButton.Left;
                    break;
                case System.Windows.Forms.MouseButtons.Middle:
                    btn =  MouseButton.Middle;
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    btn =  MouseButton.Right;
                    break;
                case System.Windows.Forms.MouseButtons.XButton1:
                    btn =  MouseButton.X1;
                    break;
                case System.Windows.Forms.MouseButtons.XButton2:
                    btn =  MouseButton.X1;
                    break;
            }
            Presenter.MouseDown(btn, e.X, e.Y);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Presenter.MouseMove(e.X, e.Y);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);

            MouseButton btn = MouseButton.None;
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    btn = MouseButton.Left;
                    break;
                case System.Windows.Forms.MouseButtons.Middle:
                    btn = MouseButton.Middle;
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    btn = MouseButton.Right;
                    break;
                case System.Windows.Forms.MouseButtons.XButton1:
                    btn = MouseButton.X1;
                    break;
                case System.Windows.Forms.MouseButtons.XButton2:
                    btn = MouseButton.X1;
                    break;
            }
            Presenter.MouseUp(btn, e.X, e.Y);
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);

            MouseButton btn = MouseButton.None;
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    btn = MouseButton.Left;
                    break;
                case System.Windows.Forms.MouseButtons.Middle:
                    btn = MouseButton.Middle;
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    btn = MouseButton.Right;
                    break;
                case System.Windows.Forms.MouseButtons.XButton1:
                    btn = MouseButton.X1;
                    break;
                case System.Windows.Forms.MouseButtons.XButton2:
                    btn = MouseButton.X1;
                    break;
            }
            Presenter.MouseClick(btn, e.X, e.Y);
        }
    }

    public class StageEditControlPresenter
    {
        public StageEditModule StageEditModule;
        public EditorService EditorService;
        public GameService GameService;

        public Point dragStartPoint = new Point();
        public bool dragging = false;
        public bool dragVisible = false;

        public SolidBrush dragTexture;
        public Color dragColor;
        public Rectangle dragRect;

        public RefGridSetting RefGridSetting;

        private ETransformType transType;

        public StageEditControlPresenter()
        {
            dragColor = Color.FromArgb(128, Color.Black);
            dragTexture = new SolidBrush(dragColor);
        }

        public void MouseDown(MouseButton button, int x, int y)
        {
            int mouseX = 0;
            int mouseY = 0;
            mouseX = GameService.Instance.QueryModule<InputModule>().MouseX;
            mouseY = GameService.Instance.QueryModule<InputModule>().MouseY;

            //if (EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Navigation ||
            //    EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Select ||
            //    EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Delete ||
            //    EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Create)
            //{
            //    dragging = true;
            //    dragStartPoint = new Point(mouseX, mouseY);
            //    // setSelectedItem(null);
            //}
            //else if (EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Transform &&
            //    EditorService.QueryModule<StageEditModule>(null).SelectedItem != null)
            //{
            //    Point p = new Point(mouseX, mouseY);
            //    transType = TransHelper.CheckTransformRect(
            //        EditorService.QueryModule<StageEditModule>(null).SelectedItem.Children.QueryComponent<Transform>().GetOrthoBox(),
            //        new System.Drawing.Point(p.X, p.Y));
            //    if (transType != ETransformType.None)
            //    {
            //        dragStartPoint = p;
            //        dragging = true;
            //    }
            //    else
            //    {
            //        EditorService.QueryModule<ToolBoxModule>(null).CurrentTool = EditorTool.Select;
            //    }
            //}
        }

        public void SetDrag(bool visible, Rectangle rect)
        {
            dragVisible = visible;
            dragRect = rect;
        }


        public void MouseMove(int mouseX, int mouseY)
        {
            //if (!dragging) return;
            //if (EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Navigation)
            //{
            //    Vector2 delta = new Vector2(mouseX - dragStartPoint.X, mouseY - dragStartPoint.Y);
            //    Camera c = GameService.QueryModule<StageModule>().CurCamera;
            //    c.SetAbsFocus(new Vector2(c.Focus.X - delta.X, c.Focus.Y - delta.Y));
            //    dragStartPoint = new Point(mouseX, mouseY);
            //}
            //else if (EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Create)
            //{
            //    Vector2 delta = new Vector2(mouseX - dragStartPoint.X, mouseY - dragStartPoint.Y);
            //    if (EditorService.QueryModule<StageEditModule>(null).SelectedItem == null && delta.X != 0 && delta.Y != 0)
            //    {
            //        // UNDONE [完成创建模式] 主编辑器的鼠标移动事件在激活创建工具时已经不执行任何代码了，等待创建模式提供相关event

            //        // AbstractComponent gc = ComponentFactory.CreateComponent(
            //        //    EditorManager.Instance.ToolBoxMgr.PenType, 
            //        //    EditorManager.Instance.ToolBoxMgr.TexRefData);

            //        // NOTE 创建对象时不需要名字

            //        // Add to scene
            //        // gameMgr.QueryModule<StageModule>().AddItem(editMgr.QueryModule<StageEditModule>(null).SelectedGroup, gc);

            //        // Change to Transform tool immediately
            //        // editMgr.QueryModule<ToolBoxModule>(null).SetAction(EAction.Transform);
            //        // transType = ETransformType.BottomRight;
            //        // Set current item to transform it
            //        // ComponentList il = new ComponentList();
            //        // il.Add(gc);
            //        // editMgr.QueryModule<StageEditModule>(null).setSelectedItem(il);
            //    }
            //}
            //else if (EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Select || EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Delete)
            //{
            //    Rectangle rect = new Rectangle(
            //        (int)dragStartPoint.X, (int)dragStartPoint.Y, (int)(mouseX - dragStartPoint.X), (int)(mouseY - dragStartPoint.Y));

            //    SetDrag(true, rect);
            //}
            //else if (EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Transform && EditorService.QueryModule<StageEditModule>(null).SelectedItem != null)
            //{
            //    Vector2 pDelta = new Vector2(mouseX - dragStartPoint.X, mouseY - dragStartPoint.Y);
            //    TransHelper.Transform(transType, pDelta, (Transform)EditorService.QueryModule<StageEditModule>(null).SelectedItem.Children.QueryComponent<Transform>());
            //    dragStartPoint = new Point(mouseX, mouseY);
            //}
        }


        public void MouseUp(MouseButton button, int x, int y)
        {

            //dragging = false;
            //int mouseX = GameService.Instance.QueryModule<InputModule>().MouseX;
            //int mouseY = GameService.Instance.QueryModule<InputModule>().MouseY;

            //if (EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Select)
            //{
            //    Microsoft.Xna.Framework.Rectangle r = new Microsoft.Xna.Framework.Rectangle(
            //        (int)dragStartPoint.X, (int)dragStartPoint.Y, (int)(mouseX - dragStartPoint.X), (int)(mouseY - dragStartPoint.Y));
            //    GameService.QueryModule<StageModule>().SelectItem(r, true);
            //    SetDrag(false, Rectangle.Empty);
            //}
            //else if (EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Delete)
            //{
            //    Microsoft.Xna.Framework.Rectangle r = new Microsoft.Xna.Framework.Rectangle(
            //        (int)dragStartPoint.X, (int)dragStartPoint.Y, (int)(mouseX - dragStartPoint.X), (int)(mouseY - dragStartPoint.Y));
            //    GameComponentCollection items = GameService.QueryModule<StageModule>().SelectItem(r, true);
            //    foreach (GameComponent item in items)
            //    {
            //        GameService.QueryModule<StageModule>().DeleteItem(item);
            //    }
            //    EditorService.QueryModule<StageEditModule>(null).SelecteItem(SelectMode.Clear, null);

            //    SetDrag(false, Rectangle.Empty);
            //}
        }

        public void MouseClick(MouseButton button, int x, int y)
        {
            //if (GameService.QueryModule<StageModule>().CurScene == null)
            //    return;
            //Vector2 mousePos = new Vector2(GameService.QueryModule<InputModule>().MouseX, GameService.QueryModule<InputModule>().MouseY);
            //if (EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Select)
            //{
            //    IGameComponent[] items = GameService.QueryModule<StageModule>().PickItem(mousePos);
            //    EditorService.QueryModule<StageEditModule>(null).SelecteItem(SelectMode.Clear, items);
            //    if (items.Count() != 0)
            //    {
            //        EditorService.QueryModule<ToolBoxModule>(null).CurrentTool = EditorTool.Transform;
            //    }
            //}
            //else if (EditorService.QueryModule<ToolBoxModule>(null).CurrentTool == EditorTool.Delete)
            //{
            //    IGameComponent[] items = GameService.QueryModule<StageModule>().PickItem(mousePos);
            //    if (items.Count() != 0)
            //    {
            //        GameService.QueryModule<StageModule>().DeleteItem(items[0]);
            //        EditorService.QueryModule<StageEditModule>(null).SelecteItem(SelectMode.Clear, null);
            //    }
            //}
        }
    }
}
