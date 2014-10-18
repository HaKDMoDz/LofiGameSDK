using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using LofiEngine.Device;
using Microsoft.Xna.Framework.Input;
using LofiEngine.Game;
using LofiEngine.Scene;
using LofiEngine.GameObjects;

// NOTE Gravity 支持组件依赖性设计
//      因依赖于NorthIsland的Role类，将其移出引擎
//      时间：2012-07-04 周三
namespace LofiEngine.Module_Physics
{
    public enum GravityDirection
    {
        Up,
        Down,
        Left,
        Right,
    }

    // 可变重力控制
    // NOTE 依赖组件：PhysicsManager Role
    // NOTE 可选组件：Role（RightRotation）
    public class Gravity
    {
        private GameManager game;

        // 依赖组件
        private PhysicsManager physicsMgr;

        private Vector2 NextGravity;

        private Role role;

        // 启动GTM
        public void ActiveGTM(GravityDirection gd)
        {
            // 保存重力值 重力置零
            float gValue = physicsMgr.World.Gravity.Length();
            physicsMgr.World.Gravity = Vector2.Zero;

            // 增大空气摩擦...

            // 储备下一个重力 & SetRoleUp & 按键映射
            switch (gd)
            {
                case GravityDirection.Up:
                    NextGravity = new Vector2(0,-gValue);
                    SetRoleRight((float)Math.PI);
                    break;
                case GravityDirection.Down:
                    NextGravity = new Vector2(0,gValue);
                    SetRoleRight(0);
                    break;
                case GravityDirection.Left:
                    NextGravity = new Vector2(-gValue,0);
                    SetRoleRight((float)Math.PI / 2);
                    break;
                case GravityDirection.Right:
                    NextGravity = new Vector2(gValue,0);
                    SetRoleRight((float)Math.PI * 3 / 2);
                    break;
            }
        }

        // GTM转换完成
        public void GravityReady()
        {
            // 清除空气摩擦...

            // 将储备重力设置为当前重力
            physicsMgr.World.Gravity = NextGravity;
        }
        private void SetRoleRight(float angle)
        {
            if (role == null)
                return;

            // 向右方向
            role.RightRotation = angle;
            // 向上方向 -- 规定为向右方向逆时针旋转90°（-90°）
            role.UpRotation = angle - 3.14f/2;
        }

        // 根据重力方向载入按键映射
        public void GDKeyMap(GravityDirection gd)
        {
            switch (gd)
            {
                case GravityDirection.Down:
                    game.SetKeyMap(new Dictionary<EGameKey, Keys> { { EGameKey.Up, Keys.Up }, { EGameKey.Left, Keys.Left }, { EGameKey.Right, Keys.Right } });

                    break;
                case GravityDirection.Up:
                    game.SetKeyMap(new Dictionary<EGameKey, Keys> { { EGameKey.Up, Keys.Down }, { EGameKey.Left, Keys.Right }, { EGameKey.Right, Keys.Left } });
                    break;
                case GravityDirection.Left:
                    game.SetKeyMap(new Dictionary<EGameKey, Keys> { { EGameKey.Up, Keys.Right }, { EGameKey.Left, Keys.Up }, { EGameKey.Right, Keys.Down } });
                    break;
                case GravityDirection.Right:
                    game.SetKeyMap(new Dictionary<EGameKey, Keys> { { EGameKey.Up, Keys.Left }, { EGameKey.Left, Keys.Down }, { EGameKey.Right, Keys.Up } });
                    break;
            }
        }
    }
}
