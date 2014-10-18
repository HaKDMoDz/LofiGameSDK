using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Point = System.Drawing.Point;
using Lofinil.GameSDK.Engine;

namespace Lofinil.GameSDK.Editor
{
    public enum ETransformType
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Top,
        Bottom,
        Left,
        Right,
        Middle,
        Center,
        None,
    }
    public class TransHelper
    {
        public static Texture2D resizeControlTexture = null;// GameManager.Instance.ResMgr.GetTexture("Transform/ResizeControl");
        public static Texture2D resizeHLineTexture = null;// GameManager.Instance.ResMgr.GetTexture("Transform/ResizeHLine");
        public static Texture2D resizeVLineTexture = null;// GameManager.Instance.ResMgr.GetTexture("Transform/ResizeVLine");

        public static void DrawRectTransControl(Rectangle r)
        {
            // Draw Resize Lines
            SamplerState ss = new SamplerState();
            ss.AddressU = TextureAddressMode.Clamp;
            ss.AddressV = TextureAddressMode.Clamp;
            GameService.Instance.Device.SamplerStates[0] = ss;
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeHLineTexture, GetTransformRect(r, ETransformType.Top));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeHLineTexture, GetTransformRect(r, ETransformType.Bottom));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeVLineTexture, GetTransformRect(r, ETransformType.Left));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeVLineTexture, GetTransformRect(r, ETransformType.Right));
            //ss = new SamplerState();
            //ss.AddressU = TextureAddressMode.Clamp;
            //ss.AddressV = TextureAddressMode.Clamp;
            //GameManager.Instance.GraphicsMgr.GraphicsDevice.SamplerStates[0] = ss;

            // Draw Resize Controls
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeControlTexture, GetTransformRect(r, ETransformType.TopLeft));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeControlTexture, GetTransformRect(r, ETransformType.TopRight));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeControlTexture, GetTransformRect(r, ETransformType.BottomLeft));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeControlTexture, GetTransformRect(r, ETransformType.BottomRight));
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
                    return new Rectangle(r.X + 4, r.Y + 4, r.Width-8, r.Height-8);
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

        public void DrawTransformControl(Rectangle r)
        {
            // Draw Resize Lines
            SamplerState ss = new SamplerState();
            ss.AddressU = TextureAddressMode.Mirror;
            ss.AddressV = TextureAddressMode.Mirror;
            GameService.Instance.Device.SamplerStates[0] = ss;
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeHLineTexture, GetTransformRect(r, ETransformType.Top));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeHLineTexture, GetTransformRect(r, ETransformType.Bottom));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeVLineTexture, GetTransformRect(r, ETransformType.Left));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeVLineTexture, GetTransformRect(r, ETransformType.Right));
            //ss = new SamplerState();
            //ss.AddressU = TextureAddressMode.Clamp;
            //ss.AddressV = TextureAddressMode.Clamp;
            //GameManager.Instance.GraphicsMgr.GraphicsDevice.SamplerStates[0] = ss;

            // Draw Resize Controls
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeControlTexture, GetTransformRect(r, ETransformType.TopLeft));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeControlTexture, GetTransformRect(r, ETransformType.TopRight));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeControlTexture, GetTransformRect(r, ETransformType.BottomLeft));
            GameService.Instance.QueryModule<GraphicsModule>().Draw(resizeControlTexture, GetTransformRect(r, ETransformType.BottomRight));

        }

        public static void Transform(ETransformType ett, Vector2 pDelta, Transform trans)
        {
            switch (ett)
            {
                case ETransformType.TopLeft:
                    trans.Size = new Vector2((float)Math.Max(trans.Size.X - pDelta.X, 1.0f), (float)Math.Max(trans.Size.Y - pDelta.Y, 1.0f));
                    // Keep the position of the Bottom Right corner
                    trans.Position = new Vector2(trans.Position.X + pDelta.X / 2f, trans.Position.Y + pDelta.Y / 2f);
                    break;
                case ETransformType.TopRight:
                    trans.Size = new Vector2((float)Math.Max(trans.Size.X + pDelta.X, 1.0f), (float)Math.Max(trans.Size.Y - pDelta.Y, 1));
                    trans.Position = new Vector2(trans.Position.X + pDelta.X / 2f, trans.Position.Y + pDelta.Y / 2);
                    break;
                case ETransformType.BottomLeft:
                    trans.Size = new Vector2((float)Math.Max(trans.Size.X - pDelta.X, 1.0f), (float)Math.Max(trans.Size.Y + pDelta.Y, 1.0f));
                    trans.Position = new Vector2(trans.Position.X + pDelta.X / 2f, trans.Position.Y + pDelta.Y / 2f);
                    break;
                case ETransformType.BottomRight:
                    trans.Size = new Vector2((float)Math.Max(trans.Size.X + pDelta.X, 1f), (float)Math.Max(trans.Size.Y + pDelta.Y, 1f));
                    trans.Position = new Vector2(trans.Position.X + pDelta.X / 2f, trans.Position.Y + pDelta.Y / 2f);
                    break;

                case ETransformType.Top:
                    trans.Size = new Vector2(trans.Size.X, trans.Size.Y - pDelta.Y);
                    trans.Position = new Vector2(trans.Position.X, trans.Position.Y + pDelta.Y / 2);
                    break;
                case ETransformType.Bottom:
                    trans.Size = new Vector2(trans.Size.X, trans.Size.Y + pDelta.Y);
                    trans.Position = new Vector2(trans.Position.X, trans.Position.Y + pDelta.Y / 2);
                    break;
                case ETransformType.Left:
                    trans.Size = new Vector2(trans.Size.X - pDelta.X, trans.Size.Y);
                    trans.Position = new Vector2(trans.Position.X + pDelta.X / 2, trans.Position.Y);
                    break;
                case ETransformType.Right:
                    trans.Size = new Vector2(trans.Size.X + pDelta.X, trans.Size.Y);
                    trans.Position = new Vector2(trans.Position.X + pDelta.X / 2, trans.Position.Y);
                    break;

                case ETransformType.Middle:
                    trans.Position = new Vector2(trans.Position.X + pDelta.X, trans.Position.Y + pDelta.Y);
                    break;
            }
        }
    }
}
