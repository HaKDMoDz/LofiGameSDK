using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Lofinil.GameSDK.Engine
{
    // 空间变换组件
    [Component(new Type[0], true, true)]
    public class Transform : GameComponent
    {
        public Vector2 Origin 
        {
            get { return origin; }
            set { origin = value; if (OriginChanged != null) OriginChanged(this, new EA_Vector2(origin)); }
        }

        private Vector2 origin;

        public event EventHandler<EA_Vector2> OriginChanged;

        [Category("Both"), Description("Size of the Texture")]
        public float Rotation 
        {
            get { return rotation; }
            set { rotation = value; if (RotationChanged != null) RotationChanged(this, new EA_Float(rotation)); }
        }

        private float rotation;

        public event EventHandler<EA_Float> RotationChanged;

        [Category("Both"), Description("Show size of the item")]
        public Vector2 Position 
        { 
            get { return position; }
            set { position = value; if (PositionChanged != null) PositionChanged(this, new EA_Vector2(position)); }
        }

        private Vector2 position;

        public event EventHandler<EA_Vector2> PositionChanged;

        private Vector2 size;

        public Vector2 Size 
        {
            get { return size; }
            set { size = value; if (SizeChanged != null) SizeChanged(this, new EA_Vector2(size)); } 
        }

        public event EventHandler<EA_Vector2> SizeChanged;

        public Vector2 Scale 
        {
            get { return scale; }
            set { scale = value; if (ScaleChanged != null) ScaleChanged(this, new EA_Vector2(scale)); } 
        }

        private Vector2 scale;

        public event EventHandler<EA_Vector2> ScaleChanged;

        public Matrix GetMatrix()
        {
            Matrix result = Matrix.Identity;
            Matrix orgTrans = Matrix.CreateTranslation(new Vector3(Position, 0));
            Matrix matScale = Matrix.CreateScale(Size.X, Size.Y, 1);
            Matrix matRotate = Matrix.CreateRotationZ(Rotation);
            Matrix matTrans = Matrix.CreateTranslation(Position.X, Position.Y, 0);
            result = orgTrans * matScale * matRotate * matTrans;
            return result;
        }

        public Rectangle GetOrthoBox()
        {
            Rectangle r = new Rectangle((int)(Position.X - Origin.X), (int)(Position.Y - Origin.Y), (int)Size.X, (int)Size.Y);
            return r;
        }

        public virtual Rectangle GetAABB()
        {
            // Texture空间
            Rectangle orgRect = new Rectangle(0, 0, (int)Size.X, (int)Size.Y);
            // 矩形切块空间
            Vector2 rectOrigin = new Vector2(Origin.X - Size.X, Origin.Y - Size.Y);
            // 变换矩阵
            Matrix transMat = Matrix.Identity;
            // Item空间变换
            transMat *= Matrix.CreateTranslation(-rectOrigin.X, -rectOrigin.Y, 0); // Texture空间位置
            // 世界空间变换
            Vector2 scale = new Vector2(Size.X / Size.X, Size.Y / Size.Y);
            transMat *= Matrix.CreateScale(scale.X, scale.Y, 0); // Texture 尺寸映射到世界坐标尺寸
            transMat *= Matrix.CreateRotationZ(Rotation); // 世界空间旋转
            transMat *= Matrix.CreateTranslation(Position.X, Position.Y, 0); // Texture位置映射到世界位置

            // 获取包围区域最值
            Vector2 leftTop = new Vector2(orgRect.Left, orgRect.Top);
            Vector2 rightTop = new Vector2(orgRect.Right, orgRect.Top);
            Vector2 leftBottom = new Vector2(orgRect.Left, orgRect.Bottom);
            Vector2 rightBottom = new Vector2(orgRect.Right, orgRect.Bottom);

            Vector2.Transform(ref leftTop, ref transMat, out leftTop);
            Vector2.Transform(ref rightTop, ref transMat, out rightTop);
            Vector2.Transform(ref leftBottom, ref transMat, out leftBottom);
            Vector2.Transform(ref rightBottom, ref transMat, out rightBottom);

            Vector2 min = Vector2.Min(Vector2.Min(leftTop, rightTop),
                    Vector2.Min(leftBottom, rightBottom));
            Vector2 max = Vector2.Max(Vector2.Max(leftTop, rightTop),
                    Vector2.Max(leftBottom, rightBottom));

            // 返回包围矩形
            return new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }
    }
}
