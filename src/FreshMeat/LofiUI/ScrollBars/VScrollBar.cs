using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LofiUtil.Inputs;
using LofiUtil.Helpers;
using LofiUI.Buttons;

namespace LofiUI.ScrollBars
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
        public float ScrollValue { get { return scrollValue; } }

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
        public delegate void OnScrollValueChangeHandler(Object sender, EventArgs e);
        /// <summary>
        /// 滚动值改变事件
        /// </summary>
        public event OnScrollValueChangeHandler OnScrollValueChange;
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
        #endregion

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
        public VScrollBar(Texture2D barTexture ,float buttonHeightPercent, int x, int y, int width, int height)
            : base(x,y,width,height)
        {
            this.barTexture = barTexture;

            int btnHeight = (int)(height * buttonHeightPercent);
            btnYMin = 0;
            btnYMax = height - btnHeight;
            if (btnYMax <= btnYMin) btnYMax = btnYMin + 1;

            Texture2D nt, mt, pt;
            nt = LoadHelper.LoadTexture2D("EditorUI/Button/ButtonNormal");
            mt = LoadHelper.LoadTexture2D("EditorUI/Button/ButtonMoveIn");
            pt = LoadHelper.LoadTexture2D("EditorUI/Button/ButtonPress");
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
            nt = LoadHelper.LoadTexture2D("EditorUI/VSCrollBar/VSBN");
            mt = LoadHelper.LoadTexture2D("EditorUI/VSCrollBar/VSBM");
            pt = LoadHelper.LoadTexture2D("EditorUI/VSCrollBar/VSBP");
            dragButton = new Button(nt, mt, pt, "", null, 0, btnYMin, width, btnHeight, this);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            dragButton.Update();

            // 检查拖拽
            Rectangle btnRect = new Rectangle(dragButton.AbsLeft,dragButton.AbsTop,dragButton.Width,dragButton.Height);
            Point mousePoint = new Point(Mouse.X, Mouse.Y);
            if (btnRect.Contains(mousePoint))
            {
                if (Mouse.LeftMousePressed() && !isDragging)
                {
                    isDragging = true;
                    dragOffsetY = Mouse.Y - (int)dragButton.AbsTop;
                    Mouse.CaptureLeftMouseClick();
                }
                else if (Mouse.LeftMouseReleased() && isDragging)
                {
                    isDragging = false;
                }
            }
            if (Mouse.LeftMousePressed() && isDragging)
            {
                // 范围限定
                int buttonY = Mouse.Y - dragOffsetY;
                dragButton.AbsTop = buttonY;
                dragButton.Top = (int)MathHelper.Clamp((float)dragButton.Top, (float)btnYMin, (float)btnYMax);
                scrollValue = dragButton.Top / (float)(btnYMax - btnYMin);
                if (OnDrag != null)
                    OnDrag(this, null);
                Mouse.CaptureLeftMousePress();
            }
        }
        #endregion

        #region Draw
        /// <summary>
        /// 绘制
        /// </summary>
        public override void Draw()
        {
            if (Visible)
            {
                GraphicsManager.DrawT(barTexture, new Rectangle(AbsLeft, AbsTop, Width, Height));
                dragButton.Draw();
            }
        }
        #endregion
    }
}
