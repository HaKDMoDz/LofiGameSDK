using System;
using LofiEngine.APIWrap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Game;
using LofiEngine.Enum;

namespace LofiEngine.GUI.Componsite
{
    /// <summary>
    /// 垂直滚动条类
    /// </summary>
    public class VScrollBar : Control
    {
        #region Variables

        /// <summary>
        /// 滚动值
        /// </summary>
        public float ScrollValue 
        { 
            get { return scrollValue; }
            set { scrollValue = value; if (ScrollValueChanged != null) ScrollValueChanged(this); }
        }

        private float scrollValue = 0;          // 滚动值
        private Texture2D barTexture = null;    // 滚动条背景图案
        private Button dragButton = null;       // 拖拽按钮
        private bool isDragging = false;        // 拖拽状态
        private int dragOffsetY = 0;            // 鼠标拖拽Y轴偏移
        private int btnYMin = 0;                // 鼠标位置最小值
        private int btnYMax = 0;                // 鼠标位置最大值

        /// <summary>
        /// 滚动值改变事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void OnScrollValueChangeHandler(Object sender);

        /// <summary>
        /// 滚动值改变事件
        /// </summary>
        public event OnScrollValueChangeHandler ScrollValueChanged;

        /// <summary>
        /// 拖拽事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void OnDragHandler(Object sender, EventArgs e);

        /// <summary>
        /// 拖拽事件
        /// </summary>
        public event OnDragHandler OnDrag;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="barTexture"></param>
        /// <param name="buttonHeightPercent">拖动按钮高度百分比</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public VScrollBar(Texture2D barTexture, float buttonHeightPercent, int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.barTexture = barTexture;

            int btnHeight = (int)(height * buttonHeightPercent);
            btnYMin = 0;
            btnYMax = height - btnHeight;
            if (btnYMax <= btnYMin) btnYMax = btnYMin + 1;

            Texture2D nt, mt, pt;
            nt = resMgr.LoadTexture2D("EditorUI/Button/ButtonNormal");
            mt = resMgr.LoadTexture2D("EditorUI/Button/ButtonMoveIn");
            pt = resMgr.LoadTexture2D("EditorUI/Button/ButtonPress");
            dragButton = new Button(nt, mt, pt, "", null, 0, btnYMin, width, btnHeight, this);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="barTexture"></param>
        /// <param name="buttonHeightPercent"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="parent"></param>
        public VScrollBar(Texture2D barTexture, float buttonHeightPercent, int x, int y, int width, int height, Control parent)
            : base(x, y, width, height, parent)
        {
            this.barTexture = barTexture;

            int btnHeight = (int)(height * buttonHeightPercent);
            btnYMin = 0;
            btnYMax = height - btnHeight;
            if (btnYMax <= btnYMin) btnYMax = btnYMin + 1;

            Texture2D nt, mt, pt;
            nt = resMgr.LoadTexture2D("EditorUI/VSCrollBar/VSBN");
            mt = resMgr.LoadTexture2D("EditorUI/VSCrollBar/VSBM");
            pt = resMgr.LoadTexture2D("EditorUI/VSCrollBar/VSBP");
            dragButton = new Button(nt, mt, pt, "", null, 0, btnYMin, width, btnHeight, this);
        }

        #endregion Constructor

        #region Update

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            dragButton.Update();

            // 检查拖拽
            Rectangle btnRect = new Rectangle(dragButton.AbsLeft, dragButton.AbsTop, dragButton.Width, dragButton.Height);
            Point mousePoint = new Point(GameManager.Instance.InputMgr.MouseX, GameManager.Instance.InputMgr.MouseY);
            if (btnRect.Contains(mousePoint))
            {
                if (GameManager.Instance.InputMgr.IsButtonPressed(MouseButton.Left) && !isDragging)
                {
                    isDragging = true;
                    dragOffsetY = GameManager.Instance.InputMgr.MouseY - (int)dragButton.AbsTop;
                    GameManager.Instance.InputMgr.CaptureLeftMouseClick();
                }
                else if (GameManager.Instance.InputMgr.IsButtonReleased(MouseButton.Left) && isDragging)
                {
                    isDragging = false;
                }
            }
            if (GameManager.Instance.InputMgr.IsButtonPressed(MouseButton.Left) && isDragging)
            {
                // 范围限定
                int buttonY = GameManager.Instance.InputMgr.MouseY - dragOffsetY;
                dragButton.AbsTop = buttonY;
                dragButton.Top = (int)MathHelper.Clamp((float)dragButton.Top, (float)btnYMin, (float)btnYMax);
                scrollValue = dragButton.Top / (float)(btnYMax - btnYMin);
                if (OnDrag != null)
                    OnDrag(this, null);
                GameManager.Instance.InputMgr.CaptureLeftMousePress();
            }
        }

        #endregion Update

        #region Draw

        /// <summary>
        /// 绘制
        /// </summary>
        public override void Draw()
        {
            if (Visible)
            {
                uiMgr.GraphicsMgr.Draw(barTexture, new Rectangle(AbsLeft, AbsTop, Width, Height));
                dragButton.Draw();
            }
        }

        #endregion Draw
    }
}