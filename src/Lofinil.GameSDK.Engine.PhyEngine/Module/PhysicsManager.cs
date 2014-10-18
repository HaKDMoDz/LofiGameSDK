using System.Collections.Generic;
using FarseerPhysics.Dynamics;
using LofiEngine.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using LofiEngine.APIWrap;
using LofiEngine.Game;
using LofiEngine.Core;
using LofiEngine.Module;

namespace LofiEngine.Module
{
    /// <summary>
    /// 物理管理器类
    /// </summary>
    public class PhysicsManager : BaseModule
    {
        /// <summary>
        /// 物理世界
        /// </summary>
        public World World { get; set; }

        public Vector2 Gravity { get { return World.Gravity; } set { World.Gravity = value; } }

        public Vector2 DefalutGravity = new Vector2(0, 1000);

        private bool paused = false;

        public PhysicsManager(GameManager game)
        { 
            this.Game = game; 
        }

        public override void Initialize()
        {
            World = new World(DefalutGravity);
            World.BodyList.Clear();
            World.JointList.Clear();
            World.AutoClearForces = true;
        }

        public override void Update()
        {
            if (paused)return;

            //mWorld.Step(Math.Min((float)TimeHelper.ElapsedTimeThisFrameInMilliseconds * 0.001f,
            //                        (1f / 30f)));{
            World.Step((float)Game.FrameTimeInMs * 0.001f);
        }

        public void Pause(bool paused)
        {
            this.paused = paused;
        }

        // 检测两个Fixture之间是否碰撞
        public bool CheckCollision(Fixture fixtureA, Fixture fixtureB)
        {
            if (fixtureA.CollisionGroup == fixtureB.CollisionGroup && fixtureA.CollisionGroup != 0)
            {
                return fixtureA.CollisionGroup > 0;
            }

            bool collide = (fixtureA.CollidesWith & fixtureB.CollisionCategories) != 0 && (fixtureA.CollisionCategories & fixtureB.CollidesWith) != 0;

            if (collide)
            {
                if (fixtureA.IsFixtureIgnored(fixtureB) || fixtureB.IsFixtureIgnored(fixtureA))
                {
                    return false;
                }
            }
            return collide;
        }
    }
}