
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using LofiEngine.Inputs;

namespace Game1
{
    class GTM
    {
        #region TODO 需迁移 GTM
        public void ActiveGTM(GravityDirection gd)
        {
            // 保存重力值 重力置零
            float gValue = mWorld.Gravity.Length();
            mWorld.Gravity = Vector2.Zero;

            // 增大空气摩擦...


            // 储备下一个重力 & SetRoleUp & 按键映射
            switch (gd)
            {
                case GravityDirection.Up:
                    NextGravity = new Vector2(0, -gValue);
                    SetRoleRight((float)Math.PI);
                    break;
                case GravityDirection.Down:
                    NextGravity = new Vector2(0, gValue);
                    SetRoleRight(0);
                    break;
                case GravityDirection.Left:
                    NextGravity = new Vector2(-gValue, 0);
                    SetRoleRight((float)Math.PI / 2);
                    break;
                case GravityDirection.Right:
                    NextGravity = new Vector2(gValue, 0);
                    SetRoleRight((float)Math.PI * 3 / 2);
                    break;
            }
        }
        /// <summary>
        /// GTM转换完成
        /// </summary>
        public void GravityReady()
        {
            // 清除空气摩擦...

            // 将储备重力设置为当前重力
            mWorld.Gravity = NextGravity;
        }
        private static void SetRoleRight(float angle)
        {
            if (SceneMgr.Instance.role == null)
            {
                throw new Exception("场景中不存在Role，无法设定方向");
            }
            // 向右方向
            SceneMgr.Instance.role.RightRotation = angle;
            // 向上方向 -- 规定为向右方向逆时针旋转90°（-90°）
            SceneMgr.Instance.role.UpRotation = angle - 3.14f / 2;
        }
        #endregion

        /// <summary>
        /// 根据重力方向载入按键映射
        /// </summary>
        /// <param name="gd"></param>
        public void GDKeyMap(GravityDirection gd)
        {
            switch (gd)
            {
                case GravityDirection.Down:
                    Keyboard.keyMapping = new Dictionary<Keyboard.EGameKey, Keys> { { Keyboard.EGameKey.Up, Keys.Up }, { Keyboard.EGameKey.Left, Keys.Left }, { Keyboard.EGameKey.Right, Keys.Right } };
                    break;
                case GravityDirection.Up:
                    Keyboard.keyMapping = new Dictionary<Keyboard.EGameKey, Keys> { { Keyboard.EGameKey.Up, Keys.Down }, { Keyboard.EGameKey.Left, Keys.Right }, { Keyboard.EGameKey.Right, Keys.Left } };
                    break;
                case GravityDirection.Left:
                    Keyboard.keyMapping = new Dictionary<Keyboard.EGameKey, Keys> { { Keyboard.EGameKey.Up, Keys.Right }, { Keyboard.EGameKey.Left, Keys.Up }, { Keyboard.EGameKey.Right, Keys.Down } };
                    break;
                case GravityDirection.Right:
                    Keyboard.keyMapping = new Dictionary<Keyboard.EGameKey, Keys> { { Keyboard.EGameKey.Up, Keys.Left }, { Keyboard.EGameKey.Left, Keys.Down }, { Keyboard.EGameKey.Right, Keys.Up } };
                    break;
            }
        }

        public void Update()
        {
            #region TODO 需迁移 GTM
            //if (GTMActive)
            //{
            //    if (CurrentGTMTime >= MaxGTMTime)
            //    {
            //        GTMActive = false;
            //        CurrentGTMTime = 0;
            //        PhysicsManager.GravityReady();
            //    }
            //    else
            //    {
            //        CurrentGTMTime += TimeHelper.ElapsedTimeThisFrameInMilliseconds;
            //    }
            //}
            #endregion

            #region TODO 需迁移 GTM
            //public bool ActiveGTM()
            //{
            //    if (role == null)
            //    {
            //        throw new Exception("角色不存在不能启动GTM！");
            //    }
            //    foreach (GTMPower gp in gtmPowerMgr.Items)
            //    {
            //        if (role.GetAABB().Intersects(gp.GetAABB()))
            //        {
            //            GTMActive = true;
            //            PhysicsManager.GravityDirection gd = (PhysicsManager.GravityDirection)Enum.Parse(typeof(PhysicsManager.GravityDirection), gp.GravityDirection.ToString());
            //            PhysicsManager.ActiveGTM(gd);
            //            PhysicsManager.GDKeyMap(gd);
            //            return true;
            //        }
            //    }
            //    return false;
            //}
            #endregion

        }
    }
}
