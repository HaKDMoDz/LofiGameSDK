using Microsoft.Xna.Framework;
using System.ComponentModel;
using System;

namespace LofiUI
{
    /// <summary>
    ///UI基类
    /// 储存UI类的共同属性
    /// </summary>
    public class Control
    {
        #region Variables
        /// <summary>
        /// Pixels from left
        /// </summary>
        public int Left;
        /// <summary>
        /// Pixels from top
        /// </summary>
        public int Top;

        /// <summary>
        /// 实际位置
        /// </summary>
        public int AbsLeft
        {
            // TODO 消除Parent Null判断
            get
            {
                if(Parent == null)
                {
                    return Left;
                }
                else
                {
                    return Left + Parent.AbsLeft;
                }
            }
            set
            {
                if(Parent == null)
                {
                    Left = value;
                }
                else
                {
                    Left = value - Parent.AbsLeft;
                }
            }
        }

        /// <summary>
        /// 绝对Y
        /// </summary>
        public int AbsTop
        {
            get
            {
                if (Parent == null)
                {
                    return Top;
                }
                else
                {
                    return Top + Parent.AbsTop;
                }
            }
            set
            {
                if (Parent == null)
                {
                    Top = value;
                }
                else
                {
                    Top = value - Parent.AbsTop;
                }
            }
        }
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width;
        /// <summary>
        /// 高度
        /// </summary>
        public int Height;
        /// <summary>
        /// 容器
        /// </summary>
        protected Control Parent=null;
        /// <summary>
        /// 可见性
        /// </summary>
        public bool Visible = true;

        #endregion

        #region Constructor
        /// <summary>
        /// UIbase构造（UI均为矩形）
        ///  注1：UI实际位置为Parent位置+相对位置
        ///  注2：parent需要手动单独设置
        /// </summary>
        /// <param name="left">当前ui的相对x</param>
        /// <param name="top">当前ui的相对y</param>
        /// <param name="width">宽</param>
        /// <param name="height">长</param>
        public Control(int left, int top, int width, int height)
        {
            Left = left;
            Top = top;
            this.Width = width;
            this.Height = height;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="parent"></param>
        public Control(int left, int top, int width, int height,Control parent)
        {
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
            this.Parent = parent;
        }
        #endregion

        #region virtualUpdate&Draw
        /// <summary>
        /// 更新
        /// </summary>
        public virtual void Update()
        {
        }
        /// <summary>
        /// 绘制
        /// </summary>
        public virtual void Draw()
        { 
            //Draw...
        }
        #endregion
    }

    internal class NullControl : Control
    {
        public int Left = 0;
        public int Top = 0;

        public int AbsLeft
        {
            get
            {
                return 0;
            }
            set
            {
                throw new Exception("NullControl的Abs属性禁止修改");
            }
        }

        public int AbsTop
        {
            get
            {
                return 0;
            }
            set
            {
                throw new Exception("NullControl的Abs属性禁止修改");
            }
        }

        public new int Width = 0;
        public new int Height = 0;
        protected new Control Parent = null;
        public new bool Visible = true;

        #region Instance
        private static NullControl instance;
        public static NullControl Instance
        {
            get
            {
                if(instance == null)
                    instance = new NullControl();
                return instance;
            }
        }
        private NullControl(): base(0,0,0,0)
        {
        }
        #endregion

        public virtual void Update()
        {
        }
        public virtual void Draw()
        { 
        }
    }
}
