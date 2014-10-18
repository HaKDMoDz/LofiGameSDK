using LofiEngine.APIWrap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Enum;

namespace LofiEngine.GUI.Componsite
{
    /// <summary>
    ///UI-Button
    /// 基本按钮，具有点击事件
    /// </summary>
    public class Label : Control
    {
        #region Variables

        //底纹图片
        Texture2D backgroundTexture;

        // 文字
        protected string text;

        public string Text { get { return text; } set { text = value; } }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// label构造函数
        /// </summary>
        /// <param name="b">底纹图片(没有底纹则为null)</param>
        /// <param name="text">文字</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Label(Texture2D b, string text,
                                  int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            backgroundTexture = b;
            this.text = text;
        }

        public Label(Texture2D b, string text,
                          int x, int y, int width, int height, Control parent)
            : base(x, y, width, height, parent)
        {
            backgroundTexture = b;
            this.text = text;
        }

        #endregion Constructor

        #region Update

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            if (!Visible) return;
            base.Update();
        }

        #endregion Update

        #region Draw

        /// <summary>
        /// 绘制
        /// </summary>
        public override void Draw()
        {
            if (!Visible) return;
            if (backgroundTexture != null)
                uiMgr.GraphicsMgr.Draw(backgroundTexture, new Rectangle(AbsLeft, AbsTop, Width, Height));
            uiMgr.GraphicsMgr.WriteText(Font, AbsLeft, AbsTop, Width, Height, AlignMode.Left, text, Color.Black);
            base.Draw();
        }

        #endregion Draw

        #region UnitTest

        //public static void UnitTest()
        //{
        //    Label label=null;
        //    TestGame.StartTest(
        //        "Panel Test",
        //        null,
        //        delegate
        //        {
        //            Texture2D b = LoadHelper.Content.Load<Texture2D>("UITexture/Label/Label");
        //            label = new Label(b, "label", 100, 100, 120, 50);

        //        },
        //        delegate
        //        {
        //            label.Update();
        //        },
        //        delegate
        //        {
        //            GraphicsManager.DrawBegin();
        //            label.Draw();
        //            GraphicsManager.DrawEnd();
        //        }
        //        );
        //}

        #endregion UnitTest
    }
}