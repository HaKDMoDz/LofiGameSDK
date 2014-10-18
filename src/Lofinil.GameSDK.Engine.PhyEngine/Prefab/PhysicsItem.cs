using System;
using System.Collections.Generic;
using System.ComponentModel;
using LofiEngine.Core;
using LofiEngine.Game;
using LofiEngine.Modifiers;
using LofiEngine.Stage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Core.Events;
using LofiEngine.Componsite;
using LofiEngine.DesignTime.Attributes;

namespace LofiEngine.Module
{
    [Prefab(new Type[] { typeof(FrameAnimator), typeof(PhysicsBody), typeof(Transform) })]
    public class PhysicsItem : BaseComponent
    {
        // 组件
        public FrameAnimator FAnimator { get; set; }

        public PhysicsBody PhysicsBody { get; set; }

        private Vector2 position;

        public bool Visible { get; set; }

        public PhysicsItem()
        {
            Visible = true;

            Transform trans = GetCompByType(typeof(Transform)) as Transform;
            trans.OriginChanged += new EventHandler<EA_Vector2>(OnSetOrigin);
            trans.PositionChanged += new EventHandler<EA_Vector2>(OnSetPosition);
            trans.RotationChanged += new EventHandler<EA_Float>(OnSetRotation);
        }

        public override void Initialize()
        {
            base.Initialize();

            FAnimator.Initialize();
            PhysicsBody.Initialize();
        }

        public override AbstractComponent Clone()
        {
            PhysicsItem item = (PhysicsItem)this.MemberwiseClone();
            item.PhysicsBody = PhysicsBody.Clone() as PhysicsBody;
            return item;
        }

        public override void Update()
        {
        }

        // Transform 事件处理
        public void OnSetOrigin(Object sender, EA_Vector2 origin)
        {
            // TODO 关联物理系统的原点
        }

        public void OnSetRotation(Object sender, EA_Float rot)
        {
            PhysicsBody.Rotation = rot.Value;
        }

        public void OnSetPosition(Object sender, EA_Vector2 pos)
        {
            PhysicsBody.Position = pos.Value;
            position = pos.Value;
        }

        public void OnSetScale(Object sender, EA_Vector2 scale)
        {

        }

        #region Draw

        public virtual void Draw(
            Camera camera, float rotation, Vector2? pos,
            Vector2? addScale, Color? color)
        {
        }
        #endregion Draw

        public override void Dispose()
        {
            FAnimator.Dispose();
            PhysicsBody.Dispose();

            base.Dispose();
        }

        public bool CheckSelect(Vector2 point)
        {
            Rectangle r = PhysicsBody.GetAABB();
            r.X += (int)position.X;
            r.Y += (int)position.Y;
            if (r.Contains(new Point((int)point.X, (int)point.Y)))
                return true;
            return false;
        }

        public bool CheckSelect(Rectangle rect, bool isFull)
        {
            Rectangle r = GetAABB();
            if (isFull && rect.Contains(r))
                return true;
            else if (!isFull && rect.Intersects(r))
                return true;
            return false;
        }

        public Rectangle GetAABB()
        {
            throw new NotImplementedException();
        }
    }
}