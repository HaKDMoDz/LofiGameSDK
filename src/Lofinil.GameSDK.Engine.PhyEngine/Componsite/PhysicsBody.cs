using System;
using System.ComponentModel;
using FarseerPhysics.Collision;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using LofiEngine.Game;
using Microsoft.Xna.Framework;
using LofiEngine.Core;
using LofiEngine.Module;
using LofiEngine.Componsite;

namespace LofiEngine.Module
{
    // The physics part of Item
    // based on Farseer Physics 3.1 library
    // NOTE 依赖组件：TopLevel::PhysicsManager
    public class PhysicsBody : BaseComponent
    {
        #region Variables

        protected Body body;
        protected Fixture fixture;
        protected Rectangle orthoAABBRect;
        public PhysicsItem Item;

        #endregion Variables

        #region Properties

        [Category("Physics"), Description("Show size of the item"), BrowsableAttribute(false)]
        public Body Body
        {
            get { return body; }
        }

        [Category("Physics"), Description("Show size of the item")]
        public Fixture Fixture
        {
            get { return fixture; }
        }

        [Category("Physics"), Description("Shape")]
        public PolygonShape Shape
        {
            get
            {
                PolygonShape shape = (PolygonShape)fixture.Shape;
                return shape;
            }
        }

        [Category("Physics"), Description("Show size of the item")]
        public bool Active
        {
            get { return body.Active; }
            set { body.Active = value; }
        }

        [Category("Physics"), Description("Show size of the item")]
        public bool IsStatic
        {
            get { return body.IsStatic; }
            set { body.IsStatic = value; }
        }

        [Category("Physics"), Description("Show size of the item")]
        public float Mass
        {
            get { return body.Mass; }
            set { body.Mass = value; }
        }

        [Category("Physics"), Description("Show size of the item")]
        public float Restitution
        {
            get { return Fixture.Restitution; }
            set { Fixture.Restitution = value; }
        }

        [Category("Physics"), Description("Show size of the item")]
        public float Friction
        {
            get { return Fixture.Friction; }
            set { Fixture.Friction = value; }
        }

        [Category("Physics"), Description("Size of the body shape")]
        public Vector2 Size
        {
            get
            {
                return new Vector2(orthoAABBRect.Width, orthoAABBRect.Height);
            }
            set
            {
                resizeBody(value);
                // Save the orthogonal AABB
                orthoAABBRect = GetAABB();
            }
        }

        [Category("Physics"), Description("Size of the body shape")]
        public float Rotation
        {
            get
            {
                return body.Rotation;
            }
            set
            {
                body.Rotation = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return body.Position;
            }
            set
            {
                body.Position = value;
            }
        }

        #endregion Properties

        #region Constructor

        // 运行时
        public PhysicsBody()
        {

        }

        // 设计时
        public PhysicsBody(Vector2 size)
        {
        }

        public override void Initialize()
        {
            fixture = FixtureFactory.CreateRectangle(((PhysicsManager)GameManager.Instance.ManagerDic["PhysicsManager"]).World, /*size.X*/10, /*size.Y*/10, 1, Vector2.Zero);
            body = fixture.Body;
            body.SleepingAllowed = false;
            orthoAABBRect = GetAABB();
            Active = false;
            IsStatic = true;

            base.Initialize();
        }

        #endregion Constructor

        public Rectangle GetAABB()
        {
            // 注意！ 只支持矩形Shape缩放，编辑时不允许有旋转角度
            Vertices vers = Shape.Vertices;
            vers.GetCollisionBox();
            AABB aabb = vers.GetCollisionBox();
            Rectangle rect = new Rectangle(
                (int)aabb.LowerBound.X, (int)aabb.LowerBound.Y,
                (int)(aabb.UpperBound.X - aabb.LowerBound.X), (int)(aabb.UpperBound.Y - aabb.LowerBound.Y));
            return rect;
        }

        protected void resizeBody(Vector2 size)
        {
            // Rebuild Fixture
            float friction = Fixture.Friction;
            float restitution = Fixture.Restitution;
            float shapeDensity = Fixture.Shape.Density;

            Body.DestroyFixture(Fixture);
            // 注意：参数是Half-Width和Half-Height
            // TODO 需改进 辅助序列化
            if (size.X <= 0) size.X = 1;
            if (size.Y <= 0) size.Y = 1;
            Vertices rectVets = PolygonTools.CreateRectangle(size.X / 2, size.Y / 2);
            Shape shape = new PolygonShape(rectVets);
            fixture = Body.CreateFixture(shape, shapeDensity);

            Fixture.Friction = friction;
            Fixture.Restitution = restitution;
        }

        public override AbstractComponent Clone()
        {
            PhysicsBody pbody = (PhysicsBody)this.MemberwiseClone();
            // 克隆时是否会多创建一个Body -- 不会，需要自己加一个
            Body newBody = FixtureFactory.CreateRectangle(((PhysicsManager)GameManager.Instance.ManagerDic["PhysicsManager"]).World, Size.X, Size.Y, Fixture.Shape.Density, Position).Body;
            newBody.Active = body.Active;
            newBody.IsStatic = body.IsStatic;
            newBody.Mass = body.Mass;
            newBody.Rotation = body.Rotation;

            newBody.FixedRotation = body.FixedRotation;
            newBody.SleepingAllowed = body.SleepingAllowed;

            pbody.body = newBody;
            return pbody;
        }

        public override void Dispose()
        {
            Body bd = Body;
            bd.DestroyFixture(Fixture);
            ((PhysicsManager)GameManager.Instance.ManagerDic["PhysicsManager"]).World.RemoveBody(bd);

            base.Dispose();
        }
    }
}