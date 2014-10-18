using System.Collections.Generic;
using LofiEngine.APIWrap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Game;
using LofiEngine.Enum;

namespace LofiEngine.GUI.Componsite
{
    /// <summary>
    ///UI-Button
    /// 基本按钮，具有点击事件
    /// </summary>
    public class Panel : Control
    {
        #region Variables

        //图片
        Texture2D titleTexture;

        Texture2D mainTexture;

        //title文字
        protected string text;

        public string Text { get { return text; } set { text = value; } }

        //状态
        bool isDarging = false;

        //标题栏和主体分别的长度
        int titleheight;

        int mainheight;

        //抓住点
        Point dragPoint;

        // 容器内部的控件
        private List<Control> children = new List<Control>();

        #endregion Variables

        #region Constructor

        public Panel(Texture2D t, Texture2D m, string text,
                                  int x, int y, int width, int titleheight, int mainheight)
            : base(x, y, width, mainheight + titleheight)
        {
            titleTexture = t;
            mainTexture = m;
            this.text = text;
            this.titleheight = titleheight;
            this.mainheight = mainheight;
        }

        #endregion Constructor

        #region Update

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            if (!Visible) return;
            if (isDarging == false && GameManager.Instance.InputMgr.IsButtonClicked(MouseButton.Left)&& isMouseInTitle())
            {
                isDarging = true;
                dragPoint = new Point(GameManager.Instance.InputMgr.MouseX - Left, GameManager.Instance.InputMgr.MouseY - Top);
            }
            if (isDarging == true && GameManager.Instance.InputMgr.IsButtonPressed(MouseButton.Left))
            {
                Left = GameManager.Instance.InputMgr.MouseX - dragPoint.X;
                Top = GameManager.Instance.InputMgr.MouseY - dragPoint.Y;
            }
            if (isDarging == true && GameManager.Instance.InputMgr.IsButtonReleased(MouseButton.Left))
            {
                isDarging = false;
            }

            for (int i = 0; i < children.Count; i++)
            {
                children[i].Update();
            }

            base.Update();
        }

        protected bool isMouseInTitle()
        {
            Rectangle rect = new Rectangle(Left, Top, Width, titleheight);
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
            if (!Visible)
            {
                return;
            }
            uiMgr.GraphicsMgr.Draw(titleTexture, new Rectangle(Left, Top, Width, titleheight));
            uiMgr.GraphicsMgr.Draw(mainTexture, new Rectangle(Left, Top + titleheight, Width, mainheight));
            uiMgr.GraphicsMgr.WriteText(Font, Left, Top, Width, titleheight, AlignMode.Middle, text, Color.Black);
            base.Draw();

            for (int i = 0; i < children.Count; i++)
            {
                children[i].Draw();
            }
        }

        #endregion Draw

        #region Children Control

        public void AddChild(Control ui)
        {
            children.Add(ui);
        }

        public void RemoveChild(Control ui)
        {
            int uiId = children.IndexOf(ui);
            if (uiId != -1)
                children.RemoveAt(uiId);
        }

        #endregion Children Control

        #region UnitTest

        //public static void UnitTest()
        //{
        //    Panel panel = null;
        //    Button subbutton = null;
        //    Label label = null;
        //    TextBox textboxA = null, textboxB = null;
        //    Texture2D background=null;
        //    TestGame.StartTest(
        //        "Panel Test",
        //        null,
        //        delegate
        //        {
        //            GraphicsManager.setFont("Kootenay");
        //            background = LoadHelper.Content.Load<Texture2D>("Textures/bg");
        //            Console.WriteLine("Panel Test start!");
        //            Texture2D m = LoadHelper.Content.Load<Texture2D>("UITexture/Panel/PanelMain");
        //            Texture2D t = LoadHelper.Content.Load<Texture2D>("UITexture/Panel/PanelTitle");
        //            panel = new Panel(t, m, "test panel", 0, 0, 450, 30, 500);
        //            //subButton
        //            Texture2D n = LoadHelper.Content.Load<Texture2D>("UITexture/Button/ButtonNormal");
        //            Texture2D bm = LoadHelper.Content.Load<Texture2D>("UITexture/Button/ButtonMoveIn");
        //            Texture2D p = LoadHelper.Content.Load<Texture2D>("UITexture/Button/ButtonPress");
        //            subbutton = new Button(n, bm, p, "sub", delegate { Console.WriteLine("subButton click!"); label.Text = textboxA.Text; }, 100, 100, 120, 50, panel);
        //            //label
        //            Texture2D b = LoadHelper.Content.Load<Texture2D>("UITexture/Label/Label");
        //            label = new Label(b, "label", 100, 200, 120, 30,panel);
        //            //textbox
        //            Texture2D bg = LoadHelper.Content.Load<Texture2D>("UITexture/TextBox/TextBox");
        //            textboxA = new TextBox(bg, "test", 100, 250, 150, 30,panel);
        //            textboxB = new TextBox(bg, "", 100, 100, 300, 30,panel);
        //        },
        //        delegate
        //        {
        //            panel.Update();
        //            subbutton.Update();
        //            label.Update();
        //            textboxA.Update();
        //            textboxB.Update();
        //        },
        //        delegate
        //        {
        //            GraphicsManager.DrawBegin();
        //            GraphicsManager.DrawT(background, new Rectangle(0, 0, BaseGame.Device.Viewport.Width, BaseGame.Device.Viewport.Height));
        //            panel.Draw();
        //            subbutton.Draw();
        //            label.Draw();
        //            textboxA.Draw();
        //            textboxB.Draw();
        //            GraphicsManager.DrawEnd();
        //        }
        //        );
        //}

        #endregion UnitTest
    }
}