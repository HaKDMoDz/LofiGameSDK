using System;
using LofiEngine.APIWrap;
using LofiEngine.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Module;
using LofiEngine.Enum;

namespace LofiEngine.GUI.Componsite
{
    /// <summary>
    ///UI-CheckBox
    /// 框选按钮
    /// </summary>
    public class CheckBox : Control
    {
        #region Variables

        //框图片和选中标记图片（如钩子）
        Texture2D boxTexture;

        Texture2D checkedTexture;

        //文字
        protected string text;

        public string Text { get { return text; } set { text = value; } }

        //是否选中
        protected bool isChecked = false;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                if (OnCheckChange != null)
                    OnCheckChange(this, null);
            }
        }

        public delegate void OnCheckChangeHandler(Object sender, EventArgs e);

        public event OnCheckChangeHandler OnCheckChange;

        //算上文字后的图片实际x位置
        int boxX;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// checkbox构造函数
        /// </summary>
        /// <param name="b">选框</param>
        /// <param name="c">选中标记</param>
        /// <param name="text">左边显示的文字</param>
        /// <param name="onCheckChangeHandler">勾选状态改变事件处理</param>
        /// <param name="x">绝对位置X</param>
        /// <param name="y">绝对位置Y</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public CheckBox(Texture2D b, Texture2D c, string text, OnCheckChangeHandler onCheckChangeHandler,
                                  int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            boxTexture = b;
            checkedTexture = c;
            boxX = (int)Game.GraphicsMgr.MeasureString(Font, text).X;
            this.text = text;
            OnCheckChange += new OnCheckChangeHandler(onCheckChangeHandler);
        }

        public CheckBox(Texture2D b, Texture2D c, string text, OnCheckChangeHandler onCheckChangeHandler,
                          int x, int y, int width, int height, Control parent, bool isChecked)
            : base(x, y, width, height, parent)
        {
            boxTexture = b;
            checkedTexture = c;
            boxX = (int)Game.GraphicsMgr.MeasureString(Font, text).X;
            this.text = text;
            this.isChecked = isChecked;
            OnCheckChange += new OnCheckChangeHandler(onCheckChangeHandler);
        }

        #endregion Constructor

        #region Update

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            if (!Visible) return;
            if (isMouseInBox() && GameManager.Instance.InputMgr.IsButtonClicked(MouseButton.Left))
            {
                if (IsChecked) IsChecked = false;
                else IsChecked = true;
            }
            base.Update();
        }

        protected bool isMouseInBox()
        {
            Rectangle rect = new Rectangle(boxX + AbsLeft, AbsTop, boxTexture.Width, boxTexture.Height);
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
            GameManager.Instance.GraphicsMgr.WriteText(Font, AbsLeft, AbsTop, Width, Height, AlignMode.Left, text, Color.Black);
            GameManager.Instance.GraphicsMgr.Draw(boxTexture, new Rectangle(boxX + AbsLeft, AbsTop, boxTexture.Width, boxTexture.Height));
            if (isChecked) GameManager.Instance.GraphicsMgr.Draw(checkedTexture, new Rectangle(boxX + AbsLeft, AbsTop, boxTexture.Width, boxTexture.Height));
            base.Draw();
        }

        #endregion Draw

        #region UnitTest

        //public static void UnitTest()
        //{
        //    CheckBox checkbox=null;
        //    TestGame.StartTest(
        //        "CheckBox Test",
        //        null,
        //        delegate
        //        {
        //            GraphicsManager.setFont("Kootenay");
        //            Console.WriteLine("CheckBox Test start!");
        //            Texture2D b = LoadHelper.Content.Load<Texture2D>("UITexture/CheckBox/CheckBoxBox");
        //            Texture2D c = LoadHelper.Content.Load<Texture2D>("UITexture/CheckBox/CheckBoxCheck");
        //            checkbox = new CheckBox(b, c, "check",null, 100, 100, 30, 30);

        //        },
        //        delegate
        //        {
        //            checkbox.Update();
        //        },
        //        delegate
        //        {
        //            GraphicsManager.DrawBegin();
        //            checkbox.Draw();
        //            GraphicsManager.DrawEnd();
        //        }
        //        );
        //}

        #endregion UnitTest
    }
}