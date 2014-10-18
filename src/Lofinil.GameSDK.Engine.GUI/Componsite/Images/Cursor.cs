using LofiEngine.APIWrap;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Game;

namespace LofiEngine.GUI.Componsite
{
    internal class Cursor : Control
    {
        #region Variables

        public Texture2D Texture;
        public int FixX;
        public int FixY;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Cursor(Texture2D texture, Control parent)
            : base(0, 0, 0, 0, parent)
        {
            Texture = texture;
            this.Parent = parent;
            FixX = 0;
            FixY = 0;
        }

        #endregion Constructor

        #region Update

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            Left = GameManager.Instance.InputMgr.MouseX - FixX;
            Top = GameManager.Instance.InputMgr.MouseY - FixY;
        }

        #endregion Update

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

        #endregion Draw
    }
}