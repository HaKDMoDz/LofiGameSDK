using System;
using System.Collections.Generic;
using LofiEngine;
using LofiEngine.Items;
using LofiEngine.Scenes;
using LofiEngine.Graphics;
using LofiEngine.Helpers;
using LofiEngine.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Point = System.Drawing.Point;
using LofiEngine.Players;
using LofiEngine.Screens;
using LofiEngine.Dramas;
using XMediaService;
using System.Windows.Forms;

namespace LofiEditor.Controls
{
    class EditMainControl : GraphicsDeviceControl
    {
        #region Variable
        public GraphicsManager GraphicsManager;
        public IScreenManager ScreenManager;
        public SceneManager SceneManager;

        public enum EAction
        {
            Select,
            Create,
            Move,
            Transform,
            Delete,
            FreeCamera,
            Copy,
            GetTexture,
        }
        EAction action = EAction.Select;

        Point dragStartPoint = new Point();
        bool dragging = false;

        bool dragVisible = false;
        Texture2D dragTexture;
        Color dragColor;
        Rectangle dragRect;

        private String penTexturePath;
        private String penClass;
        private Item drawingItem;           // the item currently drawing, not put in engine yet

        private List<Item> selecedItems = new List<Item>();
        ETransformType transType;

        public bool ShowAABB = false;
        private Texture2D boundTexture;
        private Texture2D bodyTexture;
		
        public bool showBound = false;
        public bool showBody = false;


        public bool ShowCornerCoordinate = true;
        #endregion


        #region Event
        public delegate void OnSelectItem_Handler(Object sender, List<Item> items);
        public event OnSelectItem_Handler OnSelectItem;
        #endregion

        #region Properties
        public Item SelectedItem 
        { 
            get 
            {
                if (selecedItems.Count == 0)
                    return null;
                else
                    return selecedItems[0];
            } 
        }
        public List<Item> SelectedItems { get { return selecedItems; } }
        public String SelectedGroup = "";
        public EAction Action { get { return action; } }
        #endregion

        #region Constructor
        public EditMainControl()
        {
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            TimeHelper.Initialize();
            LoadHelper.Initialize(ContentMgr);

            SceneManager = new LofiEngine.Scenes.SceneManager();
            if(!DesignMode)
                GraphicsManager = new GraphicsManager(GraphicsDevice);

            dragTexture = LoadHelper.LoadTexture2D("Common/Black");
            dragColor = Color.White;
            dragColor.A = 128;
            boundTexture = LoadHelper.LoadTexture2D("Common/Bound");
            bodyTexture = LoadHelper.LoadTexture2D("Common/Body");
        }
        #endregion

        protected override void Update()
        {
            base.Update();

            SceneManager.Update();

            LofiXUtilManager.Instance.Update();
        }

        protected override void Draw()
        {
            base.Draw();

            GraphicsManager.DrawBegin();

            SceneManager.Draw();

            if (Action == EAction.Transform && selecedItems.Count > 0)
            {
                Rectangle worldAABB = SelectedItem.GetAABB();
                Rectangle camAABB = ModuleSharer.SceneMgr.Camera.RectangleToScreen(worldAABB);
                if (ShowAABB)
                {
                    GraphicsManager.Draw(bodyTexture, camAABB);
                }
                TransHelper.DrawRectTransControl(camAABB);
            }

            // Draw draging rectangle
            if (dragVisible)
                GraphicsManager.Draw(
                    dragTexture, null, dragColor, Vector2.Zero, 
                    new Vector2(dragRect.X, dragRect.Y),
                    new Vector2(dragRect.Width / dragTexture.Width, dragRect.Height / dragTexture.Height),
                    0, SpriteEffects.None);
			
            // 显示FPS
            GraphicsManager.DrawString("FPS:" + TimeHelper.FrameRate, new Vector2(5, 15));
            // Show Corner Coordinate
            if (ShowCornerCoordinate)
                showCornerCoordinate();

            // 显示角色状态
            //if(SceneMgr.Instance.role != null)
            //{
            //    GraphicsManager.DrawLine("RS: " + SceneMgr.Instance.role.RoleState.ToString(), new Vector2(5, 20));
            //    // Console.WriteLine(SceneMgr.Instance.role.RoleState.ToString());
            //}
            GraphicsManager.DrawEnd();
        }

        private void showCornerCoordinate()
        {
            Vector2 pos;
            String coorStr;
            Vector2 strVec;
            // Left-Up
            coorStr = ModuleSharer.SceneMgr.Camera.TopLeft.X + "," + ModuleSharer.SceneMgr.Camera.TopLeft.Y;
            pos = new Vector2(5, 5);
            GraphicsManager.DrawString(coorStr, pos);

            // Left-Down
            coorStr = ModuleSharer.SceneMgr.Camera.TopLeft.X + "," + ModuleSharer.SceneMgr.Camera.BottomRight.Y;
            pos = new Vector2(5, Height - 15);
            GraphicsManager.DrawString(coorStr, pos);

            // Right-Up
            coorStr = ModuleSharer.SceneMgr.Camera.BottomRight.X + "," + ModuleSharer.SceneMgr.Camera.TopLeft.Y;
            strVec = GraphicsManager.MeasureString(coorStr);
            pos = new Vector2(Width - 5 - strVec.X, 5);
            GraphicsManager.DrawString(coorStr, pos);

            // Right-Down
            coorStr = ModuleSharer.SceneMgr.Camera.BottomRight.X + "," + ModuleSharer.SceneMgr.Camera.BottomRight.Y;
            strVec = GraphicsManager.MeasureString(coorStr);
            pos = new Vector2(Width - 5 - strVec.X, Height - 15);
            GraphicsManager.DrawString(coorStr, pos);
        }

        public void SetAction(EAction action)
        {
            this.action = action;
            if (Action == EAction.Create)
            {
                SetSelectedItem(null);
            }
        }

        public void SetSelectedItem(List<Item> items)
        {
            if (items == null)
                items = new List<Item>();
            selecedItems = items;
            if (OnSelectItem != null)
                OnSelectItem(this, selecedItems);
        }

        // Set texture of pen
        public void SetPenTexture(String texturePath)
        {
            penTexturePath = texturePath;
        }

        // Set class for pen to create item
        public void SetPenClass(String className)
        {
            penClass = className;
        }

        public void GetTextureOnPoint(Point p)
        {
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (Action == EAction.FreeCamera || Action == EAction.Select || Action == EAction.Delete || Action == EAction.Create)
            {
                dragging = true;
                dragStartPoint = new Point(Mouse.X, Mouse.Y);
                // setSelectedItem(null);
            }
            else if (Action == EAction.Transform && SelectedItem != null)
            {
                Rectangle worldAABB = SelectedItem.GetAABB();
                Rectangle camAABB = ModuleSharer.SceneMgr.Camera.RectangleToScreen(worldAABB);
                Point p = new Point(Mouse.X, Mouse.Y);
                transType = TransHelper.CheckTransformRect(camAABB, new System.Drawing.Point(p.X, p.Y));
                if (transType != ETransformType.None)
                {
                    dragStartPoint = p;
                    dragging = true;
                }
                else
                {
                    action = EAction.Select;
                }
            }
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (!dragging) return;
            if (Action == EAction.FreeCamera)
            {
                Vector2 screenDelta = new Vector2(Mouse.X - dragStartPoint.X, Mouse.Y - dragStartPoint.Y);
                Vector2 worldDelta = ModuleSharer.SceneMgr.Camera.VectorToWorld(screenDelta);
                Camera c = SceneManager.Camera;
                c.SetAbsFocus(new Vector2(c.Focus.X - worldDelta.X, c.Focus.Y - worldDelta.Y));
                dragStartPoint = new Point(Mouse.X, Mouse.Y);
            }
            else if (Action == EAction.Create)
            {
                Vector2 camDelta = new Vector2(Mouse.X - dragStartPoint.X, Mouse.Y - dragStartPoint.Y);
                Vector2 worldDelta = ModuleSharer.SceneMgr.Camera.VectorToScreen(camDelta);
                if (SelectedItem == null && worldDelta.X != 0 && worldDelta.Y != 0)
                {
					// Create an instance
                    Item item = new Item(penTexturePath);
                    if (item == null)
                    {
                        Console.WriteLine("错误：Item创建失败");
                        return;
                    }
					
					// Set an unique name 
                    NameHelper.RestartNameInc(0);
                    String name = "";
                    bool occupied = true;
                    List<Item> allItems = SceneManager.GetAllItems();
                    while(occupied)
                    {
                        name = NameHelper.GetNextName("Item");
                        occupied = false;
                        foreach (Item i in allItems)
                        {
                            if (i.Name == name)
                                occupied = true;
                        }
                    }
                    item.Name = name;
					
					// Resize to drag rectangle
                    item.Size = new Vector2(worldDelta.X, worldDelta.Y);
					// Set initial position
                    Vector2 camDragPoint =
                        new Vector2(dragStartPoint.X, dragStartPoint.Y);
                    Vector2 worldDragPoint =  ModuleSharer.SceneMgr.Camera.PositionToWorld(camDragPoint);
                    Vector2 worldCreatePoint = new Vector2(worldDragPoint.X + item.Size.X / 2, worldDragPoint.Y + item.Size.Y / 2);

                    item.Position = worldCreatePoint;	
                    // Add to scene
                    SceneManager.AddItem(SelectedGroup, item);
					
					// Change to Transform tool immediately
                    action = EAction.Transform;
                    transType = ETransformType.BottomRight;
                    dragStartPoint = new Point(Mouse.X, Mouse.Y);
					// Set current item to transform it
                    List<Item> il = new List<Item>();
                    il.Add(item);
                    SetSelectedItem(il);

                }
            }
            else if (Action == EAction.Select || Action == EAction.Delete)
            {
                Microsoft.Xna.Framework.Rectangle rect = new Microsoft.Xna.Framework.Rectangle(
                    (int)dragStartPoint.X, (int)dragStartPoint.Y, (int)(Mouse.X - dragStartPoint.X), (int)(Mouse.Y - dragStartPoint.Y));

                SetDrag(true, rect);
            }
            else if (Action == EAction.Transform && SelectedItem != null)
            {
                Vector2 screenDelta = new Vector2(Mouse.X - dragStartPoint.X, Mouse.Y - dragStartPoint.Y);
                Vector2 worldDelta = ModuleSharer.SceneMgr.Camera.VectorToWorld(screenDelta) ;
                SelectedItem.Transform(transType, worldDelta);
                dragStartPoint = new Point(Mouse.X, Mouse.Y);
            }
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            dragging = false;
            if (Action == EAction.Select)
            {
                Rectangle camRect = 
                    new Microsoft.Xna.Framework.Rectangle(
                        (int)dragStartPoint.X, 
                        (int)dragStartPoint.Y, 
                        (int)(Mouse.X - dragStartPoint.X), 
                        (int)(Mouse.Y - dragStartPoint.Y));
                Rectangle worldRect = ModuleSharer.SceneMgr.Camera.RectangleToWorld(camRect);
                List<Item> items = SceneManager.SelectItem(worldRect, true);
                SetSelectedItem(items);
                SetDrag(false, new Microsoft.Xna.Framework.Rectangle());
            }
            else if (Action == EAction.Delete)
            {
                Rectangle camRect = new Microsoft.Xna.Framework.Rectangle(
                    (int)dragStartPoint.X, 
                    (int)dragStartPoint.Y, 
                    (int)(Mouse.X - dragStartPoint.X), 
                    (int)(Mouse.Y - dragStartPoint.Y));
                Rectangle worldRect = ModuleSharer.SceneMgr.Camera.RectangleToWorld(camRect);
                List<Item> items = SceneManager.SelectItem(worldRect, true);
                foreach (Item item in items)
                {
                    SceneManager.DeleteItem(item);
                }
                SetSelectedItem(null);

                SetDrag(false, new Microsoft.Xna.Framework.Rectangle());
            }

            base.OnMouseUp(e);
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            if (Action == EAction.Select)
            {
                Vector2 camPos = new Vector2(Mouse.X, Mouse.Y);
                Vector2 worldPos = ModuleSharer.SceneMgr.Camera.PositionToWorld(camPos);
                List<Item> items = SceneManager.SelectItem(worldPos);
                SetSelectedItem(items);
                if (items.Count != 0)
                {
                    action = EAction.Transform;
                }
            }
            else if (Action == EAction.Delete)
            {
                Vector2 camPos = new Vector2(Mouse.X, Mouse.Y);
                Vector2 worldPos = ModuleSharer.SceneMgr.Camera.PositionToWorld(camPos);
                List<Item> items = SceneManager.SelectItem(worldPos);
                if (items.Count != 0)
                {
                    SceneManager.DeleteItem(items[0]);
                    SetSelectedItem(null);
                }
            }

            base.OnMouseClick(e);
        }

        public void SelectItem(Item item)
        {
            this.selecedItems.Clear();
            if (item != null)
                this.selecedItems.Add(item);
            if (OnSelectItem != null)
                OnSelectItem(this, selecedItems);
        }

        #region Layer Manage
        public void LayerUp()
        {
            if (SelectedItem != null)
                SceneManager.MoveToUpperLayer(SelectedItem);
        }

        public void LayerDown()
        {
            if (SelectedItem != null)
                SceneManager.MoveToLowerLayer(SelectedItem);
        }

        public void LayerTop()
        {
            if (SelectedItem != null)
                SceneManager.MoveToTop(SelectedItem);
        }

        public void LayerBottom()
        {
            if(SelectedItem != null)
                SceneManager.MoveToBottom(SelectedItem);
        }
        #endregion


        public void SetDrag(bool visible, Rectangle rect)
        {
            dragVisible = visible;
            dragRect = rect;
        }
    }
}
