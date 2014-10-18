using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace LofiUtil.Inputs
{
    public static class Mouse
    {
        #region Constants
        // 点击有效范围
        public const int ClickSize = 2;
        #endregion

        #region Variables
        /// <summary>
        /// 前一次键盘状态
        /// </summary>
        private static MouseState mJustMouseState;

        /// <summary>
        /// 当前键盘状态
        /// </summary>
        private static MouseState mCurrentMouseState;

        private static bool leftMouseClickCaptured = false;
        private static bool leftMousePressCaptured = false;
        private static bool mouseMoved = false;
        #endregion

        #region Properties
        static public Point Position
        {
            get { return new Point(X, Y); }
        }
        static public int X
        {
            get
            {
                return mCurrentMouseState.X;
            }
        }
        static public int Y
        {
            get
            {
                return mCurrentMouseState.Y;
            }
        }
        static public int ScrollWheelValue
        {
            get
            {
                return mScrollWheelValue;
            }
        }

        /// <summary>
        /// 滚轮幅度
        /// </summary>
        private static int mScrollWheelValue;

        public static bool MouseMoved
        {
            get { return mouseMoved;  }
        }
        #endregion

        #region Update
        static public void Update()
        {
            // 清空消息截获
            leftMouseClickCaptured = false;
            leftMousePressCaptured = false;

            // 保存当前的鼠标状态
            mJustMouseState = mCurrentMouseState;
            // 保存当前的鼠标状态
            mCurrentMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            //滚轮幅度
            mScrollWheelValue = mCurrentMouseState.ScrollWheelValue - mJustMouseState.ScrollWheelValue;

            // Check Mouse Move
            if (mJustMouseState.X == mCurrentMouseState.X && mJustMouseState.Y == mCurrentMouseState.Y)
                mouseMoved = true;
            else
                mouseMoved = false;
        }
        #endregion

        #region 鼠标处理方法组
        //左键一直按、释放、单击
        static public bool LeftMousePressed()
        {
            if (leftMousePressCaptured)
                return false;
            if (mCurrentMouseState.LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }
        static public bool LeftMouseReleased()
        {
            if (mCurrentMouseState.LeftButton == ButtonState.Released)
                return true;
            return false;
        }
        static public bool LeftMouseClicked()
        {
            if (leftMouseClickCaptured)
                return false;
            if (mCurrentMouseState.LeftButton == ButtonState.Pressed &&
                mJustMouseState.LeftButton == ButtonState.Released)
                return true;
            return false;
        }

        //右键一直按、释放、单击
        static public bool RightMousePressed()
        {
            if (mCurrentMouseState.RightButton == ButtonState.Pressed)
                return true;
            return false;
        }
        static public bool RightMouseReleased()
        {
            if (mCurrentMouseState.RightButton == ButtonState.Released)
                return true;
            return false;
        }
        static public bool RightMouseClicked()
        {
            if (mCurrentMouseState.RightButton == ButtonState.Pressed &&
                 mJustMouseState .RightButton ==ButtonState.Released )
                return true;
            return false;
        }

        #endregion

        #region 模拟消息截获
        public static void CaptureLeftMouseClick()
        {
            leftMouseClickCaptured = true;
        }
        public static void CaptureLeftMousePress()
        {
            leftMousePressCaptured = true;
        }
        #endregion

        public static Rectangle GetMouseClickRect()
        {
            return new Rectangle(X - ClickSize, Y - ClickSize, ClickSize * 2 + 1, ClickSize * 2 + 1);
        }
    }
}
