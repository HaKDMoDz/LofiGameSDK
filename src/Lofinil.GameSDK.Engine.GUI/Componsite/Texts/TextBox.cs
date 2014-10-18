using System;
using LofiEngine.APIWrap;
using LofiEngine.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mouse = LofiEngine.APIWrap.Mouse;
using LofiEngine.Game;
using LofiEngine.Enum;

namespace LofiEngine.GUI.Componsite
{
    /// <summary>
    ///UI-TextBox
    /// 输入框
    /// </summary>
    public class TextBox : Control
    {
        #region Variables

        //输入框底纹
        Texture2D backgroundTexture;

        //输入框文字
        public string Text;

        //是否光标
        bool isCursorBlink = false;

        // 点击委托
        public delegate void OnTextBoxClickHandler(Object sender, EventArgs e);

        public event OnTextBoxClickHandler OnTextBoxClick;

        public delegate void OnEnterPressedHandler(Object sender, EventArgs e);

        public event OnEnterPressedHandler OnEnterPressed;

        #endregion Variables

        #region Constructor

        public TextBox(Texture2D bt, string text,
                                  int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            backgroundTexture = bt;
            this.Text = text;
        }

        public TextBox(Texture2D bt, string text,
                          int x, int y, int width, int height, Control parent)
            : base(x, y, width, height, parent)
        {
            backgroundTexture = bt;
            this.Text = text;
        }

        #endregion Constructor

        #region Update

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            if (!Visible) return;
            //光标
            if (isMouseIn() && GameManager.Instance.InputMgr.IsButtonClicked(MouseButton.Left) && !isCursorBlink)
            {
                isCursorBlink = true;
                if (OnTextBoxClick != null)
                    OnTextBoxClick(this, null);
            }
            else if (!isMouseIn() && GameManager.Instance.InputMgr.IsButtonClicked(MouseButton.Left) && isCursorBlink)
                isCursorBlink = false;

            //输入
            if (isCursorBlink)
            {
                if ( Game.InputMgr.IsKeyJustPressed(Keys.Back) && Text.Length > 0)
                    Text = Text.Remove(Text.Length - 1);
                //如果长度未满继续输入
                //if (GraphicsManager.getTextSize(text + "|").X < Width)
                {
                    // TODO 现在不支持输入
                    // Text += Game.GetJustKeyToString();
                }

                if (Game.InputMgr.IsKeyJustPressed(Keys.Enter))
                {
                    if (OnEnterPressed != null)
                    {
                        OnEnterPressed(this, null);
                    }
                }
            }

            //限制长度
            base.Update();
        }

        /// <summary>
        /// 判断鼠标是否进入
        /// </summary>
        /// <returns></returns>
        public bool isMouseIn()
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
            string text_cursor = Text;
            if (isCursorBlink && (int)(Game.TotalTimeInS * 2) % 2 == 1)
                text_cursor += "|";
            uiMgr.GraphicsMgr.Draw(backgroundTexture, new Rectangle(AbsLeft, AbsTop, Width, Height));
            uiMgr.GraphicsMgr.WriteText(Font, AbsLeft, AbsTop, Width, Height, AlignMode.Left, text_cursor, Color.Black);

            base.Draw();
        }

        #endregion Draw

        #region UnitTest

        //public static void UnitTest()
        //{
        //    TextBox textboxA=null,textboxB=null;
        //    TestGame.StartTest(
        //        "TextBox Test",
        //        null,
        //        delegate
        //        {
        //            GraphicsManager.setFont("Kootenay");
        //            Console.WriteLine("TextBox Test start!");
        //            Texture2D b=LoadHelper.Content.Load<Texture2D>("UITexture/TextBox/TextBox");
        //            textboxA = new TextBox(b, "test", 100, 250, 150, 30);
        //            textboxB = new TextBox(b, "", 100, 100, 300, 30);
        //        },
        //        delegate
        //        {
        //            textboxA.Update();
        //            textboxB.Update();
        //        },
        //        delegate
        //        {
        //            GraphicsManager.DrawBegin();
        //            textboxA.Draw();
        //            textboxB.Draw();
        //            GraphicsManager.DrawEnd();
        //        }
        //        );
        //}

        #endregion UnitTest
    }
}