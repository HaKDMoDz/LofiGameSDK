using System;
using LofiEngine.Componsite;
using LofiEngine.Game;
using LofiEngine.GUI.Module;
using LofiEngine.Resource;

namespace LofiEngine.GUI.Componsite
{
    public class Control : BaseComponent
    {
        protected ResourceManager resMgr;
        public GUIManager uiMgr;

        public int Left;
        public int Top;
        public int Width;
        public int Height;

        public bool Visible = true;

        public int AbsLeft
        {
            get
            {
                return Left + (Parent as Control).AbsLeft;
            }
            set
            {
                Left = value - (Parent as Control).AbsLeft;
            }
        }

        public int AbsTop
        {
            get
            {
                return Top + (Parent as Control).AbsTop;
            }
            set
            {
                Top = value - (Parent as Control).AbsTop;
            }
        }

        // UNDONE Font属性仅定义了，没有应用
        public String Font;

        /// UIbase构造（UI均为矩形）
        ///  注1：UI实际位置为Parent位置+相对位置
        ///  注2：parent需要手动单独设置
        public Control(int left, int top, int width, int height)
        {
            Left = left;
            Top = top;
            this.Width = width;
            this.Height = height;
        }

        public Control(int left, int top, int width, int height, Control parent)
        {
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
            this.Parent = parent;
        }
    }

    internal class NullControl : Control
    {
        protected new Control Parent = null;
        public new bool Visible = true;

        public new int Left { get { return 0; } }

        public new int Top { get { return 0; } }

        public new int Width { get { return 0; } }

        public new int Height { get { return 0; } }

        public new int AbsLeft { get { return 0; } }

        public new int AbsTop { get { return 0; } }

        private static NullControl instance;

        public static NullControl Instance
        {
            get
            {
                if (instance == null)
                    instance = new NullControl();
                return instance;
            }
        }

        private NullControl()
            : base(0, 0, 0, 0)
        {
        }
    }
}