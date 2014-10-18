using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Items;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Helpers;
using LofiEngine.Graphics;
using Microsoft.Xna.Framework;
using XMediaService;
using System.Windows.Forms;
using LofiEditor.Controls;
using LofiEngine;

namespace LofiEditor.Controls
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

        #region Update & Draw
        protected override void Update()
        {
        }
        protected override void Draw()
        {
            base.Draw();

            ModuleSharer.GraphicsMgr.DrawBegin();
            if (EditMode == EEditMode.SourceRectangle)
            {
                Texture2D t = LoadHelper.LoadTexture2D("Common/Black");
                ModuleSharer.GraphicsMgr.Draw(
                    t, null, new Color(255, 255, 255, 128), Vector2.Zero,
                    new Vector2(SourceRect.X, SourceRect.Y),
                    new Vector2(SourceRect.Width / t.Width, SourceRect.Height / t.Height),
                    0, SpriteEffects.None);
            }
            else if (EditMode == EEditMode.Origin)
            {
                Texture2D t = LoadHelper.LoadTexture2D("Transform/Origin");
                ModuleSharer.GraphicsMgr.Draw(t, new Rectangle((int)Origin.X - 4, (int)Origin.Y - 4, 8, 8));
            }
            ModuleSharer.GraphicsMgr.DrawEnd();
        }
        #endregion

        
        public void SetTexture(String path)
        {
            TexturePath = path;
        }

        private System.Drawing.Point dragStartPoint;
        private bool dragging = false;
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
            if(e.Button == MouseButtons.Left)
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
