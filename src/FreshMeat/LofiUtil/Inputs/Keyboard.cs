using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace LofiUtil.Inputs
{
    /// <summary>
    /// 键盘输入
    /// </summary>
    public static class Keyboard
    {
        #region Variables
        /// <summary>
        /// 前一次键盘状态
        /// </summary>
        private static KeyboardState mLastKeyState;

        /// <summary>
        /// 当前键盘状态
        /// </summary>
        private static KeyboardState mCurrentKeyState;
        #endregion

        #region Update
        /// <summary>
        /// 更新键盘状态
        /// </summary>
        static public void Update()
        {
            // 保存上次键盘状态
            mLastKeyState = mCurrentKeyState;
            mCurrentKeyState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }
        #endregion

        #region 按键映射
        /// <summary>
        /// 游戏键枚举
        /// </summary>
        public enum EGameKey
        {
            /// <summary>
            /// 上
            /// </summary>
            Up,
            /// <summary>
            /// 右
            /// </summary>
            Right,
            /// <summary>
            /// 左
            /// </summary>
            Left,
        }
        /// <summary>
        /// 游戏键字典
        /// </summary>
        static public Dictionary<EGameKey, Keys> keyMapping = new Dictionary<EGameKey, Keys> {};

        /// <summary>
        /// 游戏键刚按下
        /// </summary>
        /// <param name="gk"></param>
        /// <returns></returns>
        static public bool isGameKeyJustPressed(EGameKey gk)
        {
            if (isKeyJustPress(keyMapping[gk]))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 游戏键按下
        /// </summary>
        /// <param name="gk"></param>
        /// <returns></returns>
        public static bool isGameKeyPress(EGameKey gk)
        {
            if (isKeyPress(keyMapping[gk]))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 游戏键释放
        /// </summary>
        /// <param name="gk"></param>
        /// <returns></returns>
        public static bool isGameKeyJustRelease(EGameKey gk)
        {
            if(isKeyJustRelease(keyMapping[gk]))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 键盘处理方法组
        static public bool hasKeyPressed()
        {
            if (mCurrentKeyState.GetPressedKeys().Length > 0)
                return true;
            else
                return false;
        }

        static public Keys[] KeyPressed()
        {
            return mCurrentKeyState.GetPressedKeys();
        }

        /// <summary>
        /// 键盘键按下
        /// </summary>
        /// <param name="k">a key</param>
        /// <returns></returns>
        static public bool isKeyPress(Keys k)
        {
            return mCurrentKeyState.IsKeyDown(k);
        }

        /// <summary>
        /// 键盘键刚按下
        /// </summary>
        /// <param name="k">a key</param>
        /// <returns></returns>
        public static bool isKeyJustPress(Keys k)
        {
            return mCurrentKeyState.IsKeyDown(k) && !mLastKeyState.IsKeyDown(k);
        }
        /// <summary>
        /// 游戏键刚释放
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool isKeyJustRelease(Keys k)
        {
            if (mCurrentKeyState.IsKeyUp(k) && mLastKeyState.IsKeyDown(k))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取刚被按下的键盘键字符串
        /// </summary>
        /// <returns></returns>
        static public string getJustKeytoString()
        {
            string rstr = "";
            Keys[] ks = mCurrentKeyState.GetPressedKeys();
            foreach (Keys k in ks)
            {
                //键盘过滤
                if ((k >= Keys.D0 && k <= Keys.Z || k == Keys.Space || k == Keys.OemPeriod || k == Keys.OemQuestion || k == Keys.OemOpenBrackets || k == Keys.OemCloseBrackets || k == Keys.OemMinus || k == Keys.OemSemicolon) && isKeyJustPress(k))
                {
                    if (k == Keys.OemPeriod) rstr += '.';
                    else if (k == Keys.OemQuestion) rstr += '/';
                    else if (k == Keys.OemOpenBrackets)
                    {
                        if(isKeyPress(Keys.LeftShift)||isKeyPress(Keys.RightShift))
                            rstr += "{";
                        else
                            rstr += "[";
                    }
                    else if (k == Keys.OemCloseBrackets)
                    {
                        if(isKeyPress(Keys.LeftShift)||isKeyPress(Keys.RightShift))
                            rstr += "}";
                        else
                            rstr += "]";
                    }
                    else if (k == Keys.OemSemicolon)
                    {
                        if(isKeyPress(Keys.LeftShift)||isKeyPress(Keys.RightShift))
                            rstr += ":";
                        else
                            rstr += ";";
                    }
                    else if (k == Keys.OemMinus)
                    {
                        if(isKeyPress(Keys.LeftShift)||isKeyPress(Keys.RightShift))
                            rstr += "_";
                        else
                            rstr += "-";
                    }
                    else
                    {
                        rstr += Convert.ToChar(k.GetHashCode());
                        if (!isKeyPress(Keys.LeftShift) && !isKeyPress(Keys.RightShift))
                            rstr = rstr.ToLower();//若没按shift则转换成小写,暂时无视 caplock
                    }
                }
            }
            return rstr;
        }
        #endregion

    }
}
