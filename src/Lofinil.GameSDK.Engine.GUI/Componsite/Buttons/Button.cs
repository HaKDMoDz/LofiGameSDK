using System;
using LofiEngine.APIWrap;
using LofiEngine.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Enum;

namespace LofiEngine.GUI.Componsite
{
    /// <summary>
    ///UI-Button
    /// 基本按钮，具有点击事件
    /// </summary>
    public class Button : Control
    {
        #region Variables

        //按钮图片
        protected Texture2D NormalTexture;

        protected Texture2D MoveInTexture;
        protected Texture2D PressTexture;
        protected Texture2D CurrentTexture;

        //按钮文字
        protected string text;

        public string Text { get { return text; } set { text = value; } }

        //状态枚举
        public enum ButtonState { Normal, MoveIn, Pressed };

        protected ButtonState buttonstate;

        public ButtonState buttonState { get { return buttonstate; } }

        // 点击委托
        public delegate void OnClickHandler(Object sender, EventArgs e);

        public event OnClickHandler OnClick;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// button构造函数
        /// </summary>
        /// <param name="nt">普通状态下材质</param>
        /// <param name="mt">鼠标移入时图片</param>
        /// <param name="pt">鼠标按下时图片</param>
        /// <param name="text">文字</param>
        /// <param name="bc">点击委托</param>
        /// <param name="x">绝对位置X</param>
        /// <param name="y">绝对位置Y</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public Button(Texture2D nt, Texture2D mt, Texture2D pt, string text, OnClickHandler bc,
                                  int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            NormalTexture = nt;
            CurrentTexture = NormalTexture;
            MoveInTexture = mt;
            PressTexture = pt;
            OnClick += new OnClickHandler(bc);
            this.text = text;
        }

        /// <summary>
        /// button构造函数
        /// </summary>
        /// <param name="nt">普通状态下材质</param>
        /// <param name="mt">鼠标移入时图片</param>
        /// <param name="pt">鼠标按下时图片</param>
        /// <param name="text">文字</param>
        /// <param name="bc">点击委托</param>
        /// <param name="x">绝对位置X</param>
        /// <param name="y">绝对位置Y</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="parent">容器</param>
        public Button(Texture2D nt, Texture2D mt, Texture2D pt, string text, OnClickHandler bc,
                          int x, int y, int width, int height, Control parent)
            : base(x, y, width, height, parent)
        {
            NormalTexture = nt;
            CurrentTexture = NormalTexture;
            MoveInTexture = mt;
            PressTexture = pt;
            if (bc != null)
                OnClick += new OnClickHandler(bc);
            this.text = text;
        }

        #endregion Constructor

        #region Update

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            if (isMouseMoveIn())
            {
                if (GameManager.Instance.InputMgr.IsButtonPressed(MouseButton.Left))
                {
                    buttonstate = ButtonState.Pressed;
                    CurrentTexture = PressTexture;
                }
                if (GameManager.Instance.InputMgr.IsButtonReleased(MouseButton.Left))
                {
                    buttonstate = ButtonState.MoveIn;
                    CurrentTexture = MoveInTexture;
                }
                if (GameManager.Instance.InputMgr.IsButtonClicked(MouseButton.Left))
                {
                    GameManager.Instance.InputMgr.CaptureLeftMouseClick();
                    if (OnClick != null)
                        OnClick(this, null);
                }
            }
            else
            {
                buttonstate = ButtonState.Normal;
                CurrentTexture = NormalTexture;
            }
            base.Update();
        }

        /// <summary>
        /// 判断鼠标是否进入
        /// </summary>
        /// <returns></returns>
        public bool isMouseMoveIn()
        {
            Rectangle rect = new Rectangle(AbsLeft, AbsTop, Width, Height);
            Point mvec = new Point(GameManager.Instance.InputMgr.MouseX, GameManager.Instance.InputMgr.MouseY);
            return rect.Contains(mvec);
        }

        #endregion Update

        #region Draw

        /// <summary>
        /// 绘制
        /// </summary>
        public override void Draw()
        {
            if (!Visible) return;
            GameManager.Instance.GraphicsMgr.Draw(CurrentTexture, new Rectangle(AbsLeft, AbsTop, Width, Height));
            GameManager.Instance.GraphicsMgr.WriteText(Font, AbsLeft, AbsTop, Width, Height, AlignMode.Middle, text, Color.Black);
            base.Draw();
        }

        #endregion Draw

        #region UnitTest

        //public static void UnitTest()
        //{
        //    Button buttonA = null,buttonB=null;
        //    TestGame.StartTest(
        //        "Button Test",
        //        null,
        //        delegate
        //        {
        //            GraphicsManager.setFont("Kootenay");
        //            Console.WriteLine("Button Test start!");
        //            Texture2D n=LoadHelper.Content.Load<Texture2D>("UITexture/Button/ButtonNormal");
        //            Texture2D m=LoadHelper.Content.Load<Texture2D>("UITexture/Button/ButtonMoveIn");
        //            Texture2D p=LoadHelper.Content.Load<Texture2D>("UITexture/Button/ButtonPress");
        //            buttonA = new Button(n, m, p, "ButtonA",delegate { Console.WriteLine("Button A Click!"); }, 100, 100, 120, 50);
        //            buttonB = new Button(n, m, p, "ButtonB",delegate { Console.WriteLine("Button B Click!"); }, 400, 100, 120, 50);

        //        },
        //        delegate
        //        {
        //            buttonA.Update();
        //            buttonB.Update();
        //        },
        //        delegate
        //        {
        //            GraphicsManager.DrawBegin();
        //            buttonA.Draw();
        //            buttonB.Draw();
        //            GraphicsManager.DrawEnd();
        //        }
        //        );
        //}

        #endregion UnitTest
    }
}