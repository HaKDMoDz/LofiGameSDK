using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using LofiUtil.Inputs;
using Microsoft.Xna.Framework.Graphics;

namespace LofiUI
{
    class Cursor : Control
    {
        #region Variables
        public Texture2D Texture;
        public int FixX;
        public int FixY;
        #endregion

        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public Cursor(Texture2D texture, Control parent)
            : base(0, 0, 0, 0, parent)
        {
            Texture = texture;
            this.Parent = parent;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            Left = Mouse.X - FixX;
            Top = Mouse.Y - FixY;
        }
        #endregion 

        #region Draw
        /// <summary>
        /// 绘制
        /// </summary>
        public override void Draw()
        {
            if (Visible)
            {
                // TODO 需更新
                // 绘制
                //GraphicsManager.DrawT(Texture, new Vector2(Left, Top), new Vector2(0, 0), new Vector2(1,1), 0, Color.White);
            }
        }
        #endregion
    }
}
