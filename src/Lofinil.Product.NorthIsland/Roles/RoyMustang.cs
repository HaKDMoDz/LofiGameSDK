using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Scenes;
using Microsoft.Xna.Framework;
using LofiEngine.Games;
using LofiEngine.Inputs;
using Microsoft.Xna.Framework.Input;
using Keyboard = LofiEngine.Inputs.Keyboard;

namespace BreakOutMario.Roles
{
    /// <summary>
    /// RoyMustang类
    /// </summary>
    public class RoyMustang : Role
    {
        #region Variables
        /// <summary>
        /// Roy状态枚举
        /// </summary>
        public enum ERoyState
        {
            /// <summary>
            /// 推
            /// </summary>
            Pushing,
            /// <summary>
            /// 获得补给
            /// </summary>
            GettingSupply,
            /// <summary>
            /// 使用钩子
            /// </summary>
            UsingHook,
            /// <summary>
            /// 使用枪
            /// </summary>
            UsingGun,
            /// <summary>
            /// 使用补给
            /// </summary>
            UsingSupply,
            /// <summary>
            /// 在空中使用枪
            /// </summary>
            UsingGunInAir,
            /// <summary>
            /// 改变重力
            /// </summary>
            ChangingGravity,
        }
        /// <summary>
        /// Roy状态
        /// </summary>
        public ERoyState RoyState;

        #endregion

        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public RoyMustang()
        {
            PhysicsBody.Body.FixedRotation = true;  // 固定角度

            // 注册事件处理

        }
        #endregion 

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        public override bool Update()
        {
            #region 基类更新动画
            // 更新动画
            if (!base.Update())
                return false;
            #endregion

            #region 测试用 -- 启动重力转换
            // edit tankid 
            if (Keyboard.isKeyJustPress(Keys.G))
            {
                // TODO 需更新
                //if (SceneMgr.Instance.ActiveGTM())
                //{
                    // 身体浮空...
                //}
            }
            #endregion

            #region Rotation Fix & GTM
            if (SceneManager.GTMActive)
            {
                // 获取GTM运行时间对身体旋转进行平滑处理
                float percent = SceneManager.CurrentGTMTime / SceneManager.MaxGTMTime;

                //* UpRotation 的范围是[0,2Pi)
                if (Rotation < RightRotation)
                {
                    if (RightRotation - Rotation >= Math.PI)
                    {
                        // R 减
                        Rotation -= ((float)Math.PI * 2 - (RightRotation - Rotation)) * percent;
                    }
                    else
                    {
                        // R 增
                        Rotation += (RightRotation - Rotation) * percent;
                    }
                }
                else if (Rotation > RightRotation)
                {
                    if (RightRotation - Rotation < -Math.PI)
                    {
                        // R 增
                        Rotation += (float)(((float)Math.PI * 2 - (Rotation - RightRotation)) * percent);
                    }
                    else
                    {
                        // R 减
                        Rotation -= (float)((Rotation - RightRotation) * percent);
                    }
                }

                // 范围限制
                if (Rotation < 0)
                {
                    Rotation += (float)Math.PI * 2;
                }
                if (Rotation >= Math.PI * 2)
                {
                    Rotation -= (float)Math.PI * 2;
                }
            }
            else
            {
                // 构造函数中尝试使用新的方法锁定角度
                // 锁定角度
                // Rotation = RightRotation;
                // fixture.Body.ClearTorque();
            }
            #endregion

            #region FSM
            switch (RoyState)
            {
                case ERoyState.Pushing:
                    #region Physics State Check
                    // 如果不和可推物体分离或者没有指向物体的合力，则转换为Free/Running
                    //if ((Math.Abs(InnerForce.X - body.Force.X)) <= 1000)
                    //{
                    //    roleState = RState.Free;
                    //    PlaySeq("Free");
                    //}
                    #endregion

                    #region World Influence
                    // 如果GettingItem开关打开，则转换为GettingItem
                    #endregion
                    break;
                case ERoyState.GettingSupply:
                    #region Anime Check
                    if (AnimTexture.CurrentSeq.Name != "GettingItem")
                    {
                        RoleState = ERoleState.Free;
                        AnimTexture.PlaySeq("Free");
                    }
                    #endregion
                    break;

                case ERoyState.UsingHook:
                    #region Anime Check
                    if (AnimTexture.CurrentSeq.Name != "UsingHook")
                    {
                        RoleState = ERoleState.Free;
                        AnimTexture.PlaySeq("Free");
                    }
                    #endregion
                    break;

                case ERoyState.UsingSupply:
                    #region Anime Check
                    if (AnimTexture.CurrentSeq.Name != "UsingItem")
                    {
                        RoleState = ERoleState.Free;
                        AnimTexture.PlaySeq("Free");
                    }
                    #endregion
                    break;

                case ERoyState.UsingGun:
                    #region Anime Check
                    if (AnimTexture.CurrentSeq.Name != "UsingGun")
                    {
                        RoleState = ERoleState.Free;
                        AnimTexture.PlaySeq("Free");
                    }
                    #endregion
                    break;

                case ERoyState.UsingGunInAir:
                    #region Anime Check
                    if (AnimTexture.CurrentSeq.Name != "UsingGunInAir")
                    {
                        RoleState = ERoleState.Free;
                        AnimTexture.PlaySeq("Free");
                    }
                    #endregion
                    break;
            }
            #endregion

            return true;
        }
        #endregion

        #region Event Handler
        /// <summary>
        /// 游戏键按下事件处理
        /// </summary>
        /// <param name="gameKey"></param>
        public void onGameKeyPressing(Keyboard.EGameKey gameKey)
        { 
            // TODO 考虑是否要把相关逻辑从Role移动到这里 ...
        }
        #endregion
    }
}
