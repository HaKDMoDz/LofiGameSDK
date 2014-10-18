using System;
using LofiEngine.Items;
using LofiEngine.Scenes;
using Microsoft.Xna.Framework;
using LofiEngine.Modifiers;

namespace BreakOutMario.Objects
{
    /// <summary>
    /// 针刺类
    /// </summary>
    public class Thorn : Item
    {
        #region Constants
        float speed = 600;
        float CoolDownTime = 3000;
        float IceTime = 10000;
        #endregion

        #region Variables
        /// <summary>
        /// 针刺状态枚举
        /// </summary>
        public enum EThornState
        {
            /// <summary>
            /// 灼热
            /// </summary>
            Hot,
            /// <summary>
            /// 冷却
            /// </summary>
            CoolDown,
            /// <summary>
            /// 冰冷
            /// </summary>
            Ice,
            /// <summary>
            /// 销毁
            /// </summary>
            Destroy,
        }
        /// <summary>
        /// 针刺状态
        /// </summary>
        public EThornState ThornState = EThornState.Hot;

        private double coolDownTime = 0;
        private double iceTime = 0;
        private Vector2 vSpeed;
        #endregion

        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public Thorn()
        {
            PhysicsBody.Active = false;
            AnimTexture.TexturePath = "Items/Thorn";
            Size = new Vector2(11, 34);
            // Origin = new Vector2(12.5f, 12.5f);
            AnimTexture.SourceRect = new Rectangle(0, 0, 11, 34);
            AnimTexture.AnimSeqList.Add(new AnimSequence("Hot", 0, 1, 1, true, true));
            AnimTexture.AnimSeqList.Add(new AnimSequence("Normal", 1, 1, 1, true, true));
            AnimTexture.AnimSeqList.Add(new AnimSequence("Ice", 2, 1, 1, true, true));
            AnimTexture.PlaySeq("Hot");

            RelaRateModifier mod = new RelaRateModifier("Shoot", "Position");
            mod.OnStart += Shoot_OnStart;
            StartModify("Shoot");

            // 计算速度
            vSpeed = SceneManager.GetItemByName("Role").Position - SceneManager.GetItemByName("Askia").Position;
            vSpeed.Normalize();
            vSpeed *= speed;
            // 设置角度
            if (vSpeed.X == 0)
                vSpeed.X += 0.00001f;
            Rotation = -(float)Math.Acos(vSpeed.Y / vSpeed.X);
        }
        #endregion

        private void Shoot_OnStart(Object sender, EventArgs e)
        {
            RelaRateModifier mod = (RelaRateModifier)sender;
            mod.StartValue = this.Position;

            mod.Speed = vSpeed;

            mod.TotalTimeMS = 20000;
        }

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        public override bool Update()
        {
            if (!base.Update())
                return false;

            #region 待移动
            // FSM
            //switch (ThornState)
            //{
            //    case EThornState.Hot:
            //        // 如果碰到非角色非Boss障碍物，则转换为静止状态
            //        // 障碍物现在仅包括地板
            //        Rectangle rect = GetAABB();
            //        foreach (Terrain tt in SceneMgr.Instance.terrainMgr.Items)
            //        {
            //            // TODO 目前无像素碰撞检测，因此不要旋转地板
            //            if(rect.Intersects(tt.GetAABB()))
            //            {
            //                ChangeStateAction(EThornState.CoolDown);
            //            }
            //        }
            //        break;

            //    case EThornState.CoolDown:
            //        // 可以被角色拾起
            //        coolDownTime += TimeHelper.ElapsedTimeThisFrameInMilliseconds;
            //        if(coolDownTime > CoolDownTime)
            //            return false;
            //        if (Mouse.isLeftMouseClick())
            //        {
            //            Rectangle r = GetAABB();
            //            if (r.Contains(Mouse.X, Mouse.Y))
            //            {
            //                if (SceneMgr.Instance.role.supplyNameList.Count < 5)
            //                {
            //                    SceneMgr.Instance.role.supplyNameList.Add("Thorn");
            //                    return false;
            //                }
            //            }
            //        }
            //        break;

            //    case EThornState.Ice:
            //        // 能够伤害Askia
            //        iceTime += TimeHelper.ElapsedTimeThisFrameInMilliseconds;
            //        if (iceTime > IceTime)
            //            return false;
            //        if (SceneMgr.Instance.askia != null &&
            //            SceneMgr.Instance.askia.AskiaState == Askia.EAskiaState.GetHurt)
            //        {
            //            if(GetAABB().Intersects(SceneMgr.Instance.askia.GetAABB()))
            //            {
            //                SceneMgr.Instance.askia.Health--;
            //                return false;
            //            }
            //        }
            //        break;
            //    case EThornState.Destroy:
            //        return false;
            //}
            #endregion

            return true;
        }
        #endregion

        private void ChangeStateAction(EThornState thornState)
        {
            switch (thornState)
            {
                case EThornState.Hot:
                    ThornState = thornState;
                    coolDownTime = 0;
                    AnimTexture.PlaySeq("Normal");
                    break;
                case EThornState.CoolDown:
                    ThornState = thornState;
                    StopModify("Shoot");
                    coolDownTime = 0;
                    AnimTexture.PlaySeq("Normal");
                    break;
                case EThornState.Ice:
                    ThornState = thornState;
                    iceTime = 0;
                    AnimTexture.PlaySeq("Ice");
                    break;
                case EThornState.Destroy:
                    ThornState = thornState;
                    break;
            }
        }

        #region Hit Role
        public void HitRole()
        {
            ThornState = EThornState.Destroy;
        }
        #endregion

        #region Collect & Setup
        /// <summary>
        /// 激活 - 能够伤害到Askia
        /// </summary>
        /// <param name="setPos"></param>
        public void Active(Vector2 setPos)
        {
            ThornState = EThornState.Ice;
            Position = setPos;
            Rotation = 0; //... 水平插入墙体
            Visible = true;
        }
        #endregion
    }
}
