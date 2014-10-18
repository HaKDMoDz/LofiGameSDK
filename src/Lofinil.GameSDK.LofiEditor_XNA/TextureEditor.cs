using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using Lofinil.GameSDK.Engine;

namespace Lofinil.GameSDK.LofiEditor
{
    class TextureEditor : TextureBox
    {
        #region Variables
        public enum EEditMode
        {
            None,
            SourceRectangle,
            Origin,
        }
        public EEditMode EditMode = EEditMode.None;
        public Rectangle SourceRect = new Rectangle();
        public Vector2 Origin = Vector2.Zero;

        public override String TexturePath
        {
            set
            {
                base.TexturePath = value;
                if (Texture != null)
                {
                    Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
                    SourceRect = new Rectangle(0, 0, Texture.Width, Texture.Height);
                }
            }
        }
        #endregion

        public TextureEditor()
        {
            dragging = false;
        }

        #region Update & Draw
        protected override void XNAControl_Update(object sender, EventArgs e)
        {
            base.XNAControl_Update(sender, e);
        }
        protected override void XNAControl_Draw(object sender, EventArgs e)
        {
            base.XNAControl_Draw(sender, e);

            GameManager.Instance.GraphicsMgr.DrawBegin();
            if (EditMode == EEditMode.SourceRectangle)
            {
                Texture2D t = null;// GameManager.Instance.ResMgr.GetTexture("Common/Black");
                GameManager.Instance.GraphicsMgr.Draw(t, SourceRect, new Color(255, 255, 255, 128));
            }
            else if (EditMode == EEditMode.Origin)
            {
                Texture2D t = null;// GameManager.Instance.ResMgr.GetTexture("Transform/Origin");
                GameManager.Instance.GraphicsMgr.Draw(t, new Rectangle((int)Origin.X - 4, (int)Origin.Y - 4, 8, 8));
            }
            GameManager.Instance.GraphicsMgr.DrawEnd();
        }
        #endregion

        
        public void SetTexture(String path)
        {
            TexturePath = path;
        }

        private System.Drawing.Point dragStartPoint;
        private bool dragging;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (EditMode == EEditMode.SourceRectangle)
                {
                    dragStartPoint = e.Location;
                    dragging = true;
                }
            }
            base.OnMouseDown(e);
        }

        protected override void  OnMouseMove(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && dragging)
            {
                if (EditMode == EEditMode.SourceRectangle)
                {
                    SourceRect = new Rectangle(dragStartPoint.X, dragStartPoint.Y, e.X - dragStartPoint.X, e.Y - dragStartPoint.Y);
                }
            }
 	        base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (EditMode == EEditMode.SourceRectangle)
                {
                    dragging = false;
                }
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (EditMode == EEditMode.Origin)
                {
                    Origin = new Vector2(e.X, e.Y);
                }
            }
            base.OnMouseClick(e);
        }
    }
}
