using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lofinil.GameSDK.Engine
{
    public static class Collision
    {
        public static bool Check(Point point, Rectangle rectangle)
        {
            return rectangle.Contains(point);
        }

        public static bool Check(Vector2 pos, Rectangle rectangle)
        {
            return rectangle.Contains((int)pos.X, (int)pos.Y);
        }

        public static bool Check(Point point, Transform trans)
        {
            Vector2 p = new Vector2(point.X, point.Y);
            return Check(p, trans);
        }

        public static bool Check(Vector2 point, Transform trans)
        {
            Matrix matPoint = Matrix.CreateTranslation(point.X, point.Y, 0);
            Matrix matTrans = trans.GetMatrix();
            Matrix convert = matPoint * Matrix.Invert(matTrans);
            Vector2 convertPoint = Vector2.Transform(point, convert);
            return Check(convertPoint, new Rectangle(0, 0, (int)trans.Size.X, (int)trans.Size.Y));
        }

        public static bool Check(Rectangle rect1, Rectangle rect2, bool full)
        {
            if (full)
                return rect1.Contains(rect2);
            else
                return rect1.Intersects(rect2);
        }

        public static bool Check(Point point, Transform trans, Texture2D texture)
        {
            Vector2 p = new Vector2(point.X, point.Y);
            return Check(p, trans, texture);
        }

        public static bool Check(Vector2 point, Transform trans, Texture2D texture)
        {
            Matrix matPoint = Matrix.CreateTranslation(point.X, point.Y, 0);
            Matrix matTrans = trans.GetMatrix();
            Matrix convert = matPoint * Matrix.Invert(matTrans);
            Vector2 convertPoint = Vector2.Transform(point, convert);
            if (Check(convertPoint, new Rectangle(0, 0, (int)trans.Size.X, (int)trans.Size.Y)))
            {
                Color[] data =  new Color[texture.Width * texture.Height];
                texture.GetData(data);
                Point p = new Point((int)convertPoint.X, (int)convertPoint.Y);
                if (data[p.X + p.Y * texture.Width].A != 0)
                    return true;
                return false;
            }
            return false;
        }
    }
}
