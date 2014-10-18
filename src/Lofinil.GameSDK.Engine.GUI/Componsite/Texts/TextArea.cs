using System;
using System.Collections.Generic;
using LofiEngine.APIWrap;
using LofiEngine.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LofiEngine.GUI.Componsite
{
    /// <summary>
    /// 文本区域
    /// </summary>
    public class TextArea : Control
    {
        #region Variables

        /// <summary>
        /// 贴图
        /// </summary>
        public Texture2D Texture;

        /// <summary>
        /// 文字
        /// </summary>
        public String Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                if (OnTextModeChange != null)
                    OnTextModeChange(this, null);
            }
        }

        /// <summary>
        /// 左边距
        /// </summary>
        public int MarginLeft
        {
            get
            {
                return margins[0];
            }
            set
            {
                margins[0] = value;
                if (OnTextModeChange != null)
                    OnTextModeChange(this, null);
            }
        }

        /// <summary>
        /// 右边距
        /// </summary>
        public int MarginRight
        {
            get
            {
                return margins[1];
            }
            set
            {
                margins[1] = value;
                if (OnTextModeChange != null)
                    OnTextModeChange(this, null);
            }
        }

        /// <summary>
        /// 上边距
        /// </summary>
        public int MarginTop
        {
            get
            {
                return margins[2];
            }
            set
            {
                margins[2] = value;
                if (OnTextModeChange != null)
                    OnTextModeChange(this, null);
            }
        }

        /// <summary>
        /// 下边距
        /// </summary>
        public int MarginDown
        {
            get
            {
                return margins[3];
            }
            set
            {
                margins[3] = value;
                if (OnTextModeChange != null)
                    OnTextModeChange(this, null);
            }
        }

        /// <summary>
        /// 行距
        /// </summary>
        public int LineSpacing = 12;

        private String text = "";
        private int[] margins = new int[] { 5, 5, 5, 5 };
        private List<String> lines = new List<string>();

        /// <summary>
        /// 文字模式改变事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void OnTextModeChangeHandler(Object sender, EventArgs e);

        /// <summary>
        /// 文字模式改变事件
        /// </summary>
        public event OnTextModeChangeHandler OnTextModeChange;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="backTexture"></param>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="parent"></param>
        public TextArea(Texture2D backTexture, int _x, int _y, int width, int height, Control parent)
            : base(_x, _y, width, height, parent)
        {
            Texture = backTexture;
            OnTextModeChange += onTextModeChangeHandler;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="backTexture"></param>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public TextArea(Texture2D backTexture, int _x, int _y, int width, int height)
            : base(_x, _y, width, height)
        {
            Texture = backTexture;
            OnTextModeChange += onTextModeChangeHandler;
        }

        #endregion Constructor

        #region Draw

        /// <summary>
        /// 绘制
        /// </summary>
        public override void Draw()
        {
            GameManager.Instance.GraphicsMgr.Draw(Texture, new Rectangle(AbsLeft, AbsTop, Width, Height));

            int addY = 0;
            foreach (String line in lines)
            {
                GameManager.Instance.GraphicsMgr.DrawString(Font, line, new Vector2(AbsLeft + MarginLeft, AbsTop + addY));
                addY += LineSpacing;
            }
        }

        #endregion Draw

        #region OnTextModeChangeHandler

        private void onTextModeChangeHandler(Object sender, EventArgs e)
        {
            // TODO 效率低 需优化
            // 重新分割字符串
            lines.Clear();
            String t = text;
            int lineWidth = Width - MarginLeft - MarginRight;
            while (t.Length != 0)
            {
                int curLen = 1;
                while (Game.GraphicsMgr.MeasureString(Font, t.Substring(0, curLen)).X < lineWidth)
                {
                    curLen++;
                    if (curLen > t.Length) break;
                }
                curLen--;
                lines.Add(t.Substring(0, curLen));
                t = t.Substring(curLen);
            }
        }

        #endregion OnTextModeChangeHandler
    }
}