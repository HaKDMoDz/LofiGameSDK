using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Graphics;
using LofiEngine.Helpers;
using LofiEngine.Items;
using Point = System.Drawing.Point;
using LofiEngine;

namespace LofiEditor
{
    public class TransHelper
    {
        public static Texture2D resizeControlTexture = LoadHelper.LoadTexture2D("Transform/ResizeControl");
        public static Texture2D resizeHLineTexture = LoadHelper.LoadTexture2D("Transform/ResizeHLine");
        public static Texture2D resizeVLineTexture = LoadHelper.LoadTexture2D("Transform/ResizeVLine");

        public static void DrawRectTransControl(Rectangle r)
        {
            // Draw Resize Lines
            SamplerState ss = new SamplerState();
            ss.AddressU = TextureAddressMode.Wrap;
            ss.AddressV = TextureAddressMode.Wrap;
            ModuleSharer.GraphicsMgr.GraphicsDevice.SamplerStates[0] = ss;
            Rectangle transRect;

            transRect = GetTransformRect(r, ETransformType.Top);
            ModuleSharer.GraphicsMgr.Draw(
                resizeHLineTexture, null, Color.White,
                Vector2.Zero,
                new Vector2(transRect.X, transRect.Y),
                new Vector2(transRect.Width / resizeHLineTexture.Width, transRect.Height / resizeHLineTexture.Height),
                0, SpriteEffects.None);
            transRect = GetTransformRect(r, ETransformType.Bottom);
            ModuleSharer.GraphicsMgr.Draw(
                resizeHLineTexture, null, Color.White,
                Vector2.Zero,
                new Vector2(transRect.X, transRect.Y),
                new Vector2(transRect.Width / resizeHLineTexture.Width, transRect.Height / resizeHLineTexture.Height),
                0, SpriteEffects.None);

            transRect = GetTransformRect(r, ETransformType.Left);
            ModuleSharer.GraphicsMgr.Draw(
                resizeVLineTexture, null, Color.White,
                Vector2.Zero,
                new Vector2(transRect.X, transRect.Y),
                new Vector2(transRect.Width / resizeVLineTexture.Width, transRect.Height / resizeVLineTexture.Height),
                0, SpriteEffects.None);

            transRect = GetTransformRect(r, ETransformType.Right);
            ModuleSharer.GraphicsMgr.Draw(
                resizeVLineTexture, null, Color.White,
                Vector2.Zero,
                new Vector2(transRect.X, transRect.Y),
                new Vector2(transRect.Width / resizeVLineTexture.Width, transRect.Height / resizeVLineTexture.Height),
                0, SpriteEffects.None);

            ss = new SamplerState();
            ss.AddressU = TextureAddressMode.Clamp;
            ss.AddressV = TextureAddressMode.Clamp;
            ModuleSharer.GraphicsMgr.GraphicsDevice.SamplerStates[0] = ss;

            // Draw Resize Controls
            ModuleSharer.GraphicsMgr.Draw(resizeControlTexture, GetTransformRect(r, ETransformType.TopLeft));
            ModuleSharer.GraphicsMgr.Draw(resizeControlTexture, GetTransformRect(r, ETransformType.TopRight));
            ModuleSharer.GraphicsMgr.Draw(resizeControlTexture, GetTransformRect(r, ETransformType.BottomLeft));
            ModuleSharer.GraphicsMgr.Draw(resizeControlTexture, GetTransformRect(r, ETransformType.BottomRight));

        }


        public static Rectangle GetTransformRect(Rectangle r, ETransformType errt)
        {
            switch (errt)
            {
                case ETransformType.TopLeft:
                    return new Rectangle(r.X - 4, r.Y - 4, 8, 8);
                case ETransformType.TopRight:
                    return new Rectangle(r.X + r.Width - 4, r.Y - 4, 8, 8);
                case ETransformType.BottomLeft:
                    return new Rectangle(r.X - 4, r.Y + r.Height - 4, 8, 8);
                case ETransformType.BottomRight:
                    return new Rectangle(r.X + r.Width - 4, r.Y + r.Height - 4, 8, 8);

                case ETransformType.Top:
                    if (r.Width < 8)
                        return new Rectangle();
                    else
                        return new Rectangle(r.X + 4, r.Y - 1, r.Width - 8, 3);
                case ETransformType.Bottom:
                    if (r.Width < 8)
                        return new Rectangle();
                    else
                        return new Rectangle(r.X + 4, r.Y + r.Height - 1, r.Width - 8, 3);
                case ETransformType.Left:
                    if (r.Height < 8)
                        return new Rectangle();
                    else
                        return new Rectangle(r.X - 1, r.Y + 4, 3, r.Height - 8);
                case ETransformType.Right:
                    if (r.Height < 8)
                        return new Rectangle();
                    else
                        return new Rectangle(r.X + r.Width - 1, r.Y + 4, 3, r.Height - 8);
                case ETransformType.Middle:
                    if (r.Height < 8 || r.Width < 8)
                        return new Rectangle();
                    else
                        return new Rectangle(r.X + 4, r.Y + 4, r.Width - 8, r.Height - 8);
                case ETransformType.Center:
                    // TODO 
                    return new Rectangle();
            }
            return new Rectangle();
        }

        public static ETransformType CheckTransformRect(Rectangle r, Point point)
        {
            Microsoft.Xna.Framework.Point p = new Microsoft.Xna.Framework.Point(point.X, point.Y);
            Rectangle rectTL = GetTransformRect(r, ETransformType.TopLeft);
            if (rectTL.Contains(p)) return ETransformType.TopLeft;
            Rectangle rectTR = GetTransformRect(r, ETransformType.TopRight);
            if (rectTR.Contains(p)) return ETransformType.TopRight;
            Rectangle rectBL = GetTransformRect(r, ETransformType.BottomLeft);
            if (rectBL.Contains(p)) return ETransformType.BottomLeft;
            Rectangle rectBR = GetTransformRect(r, ETransformType.BottomRight);
            if (rectBR.Contains(p)) return ETransformType.BottomRight;

            Rectangle rectT = GetTransformRect(r, ETransformType.Top);
            if (rectT.Contains(p)) return ETransformType.Top;
            Rectangle rectB = GetTransformRect(r, ETransformType.Bottom);
            if (rectB.Contains(p)) return ETransformType.Bottom;
            Rectangle rectL = GetTransformRect(r, ETransformType.Left);
            if (rectL.Contains(p)) return ETransformType.Left;
            Rectangle rectR = GetTransformRect(r, ETransformType.Right);
            if (rectR.Contains(p)) return ETransformType.Right;

            Rectangle rectM = GetTransformRect(r, ETransformType.Middle);
            if (rectM.Contains(p)) return ETransformType.Middle;
            Rectangle rectC = GetTransformRect(r, ETransformType.Center);
            if (rectC.Contains(p)) return ETransformType.Center;

            return ETransformType.None;
        }
    }
}
