using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Scenes;
using Microsoft.Xna.Framework;
using LofiEngine.Games;
using LofiEngine.Helpers;
using LofiEngine.Items;
using LofiEngine.Modifiers;
using BreakOutMario.Objects;
using LofiEngine.Dramas;
using LofiEngine.Groups;

namespace BreakOutMario.Roles
{
    /// <summary>
    /// Askia类
    /// </summary>
    public class Askia : Role
    {
        #region Constants
        /// <summary>
        /// 徘徊左端
        /// </summary>
        public const int WonderLeft = 80;   
        /// <summary>
        /// 徘徊右端
        /// </summary>
        public const int WonderRight = 720;
        /// <summary>
        /// 徘徊高度
        /// </summary>
        public const int WonderHeight = 100;
        /// <summary>
        /// 徘徊右端
        /// </summary>
        public const int DashLow = 600;
        /// <summary>
        /// 冲刺速度
        /// </summary>
        public const int DashSpeed = 450;
        /// <summary>
        /// 冲刺最小水平距
        /// </summary>
        public const int MinDashDest = 200;
        /// <summary>
        /// 针刺倍数
        /// </summary>
        public const int ThornMultiple = 3;
        /// <summary>
        /// 变换形态血量
        /// </summary>
        public const int StageHP = 40;
        /// <summary>
        /// 停止时间 毫秒 - 变换形态后停止时间减半  
        /// </summary>
        public const int StopTime = 2000;
        /// <summary>
        /// 失控时间
        /// </summary>
        public const int LostControlTime = 2000;
        #endregion

        #region Variables
        /// <summary>
        /// Askia状态枚举
        /// </summary>
        public enum EAskiaState
        {
            /// <summary>
            /// 徘徊
            /// </summary>
            Wondering,
            /// <summary>
            /// 冲刺
            /// </summary>
            Dashing,
            /// <summary>
            /// 失控
            /// </summary>
            LostControl,
            /// <summary>
            /// 受伤
            /// </summary>
            GetHurt,
            /// <summary>
            /// 钢针射击
            /// </summary>
            ShootingThorn,
            /// <summary>
            /// 起飞
            /// </summary>
            TakingOff,
            /// <summary>
            /// 停止
            /// </summary>
            Stop,
            /// <summary>
            /// 死亡
            /// </summary>
            Dying
        }
        /// <summary>
        /// Askia状态
        /// </summary>
        public EAskiaState AskiaState
        {
            get
            {
                return askiaState;
            }
            set
            {
                askiaState = value;
                if (OnAskiaStateChanged != null)
                    OnAskiaStateChanged(this, askiaState);
            }
        }
        private EAskiaState askiaState = EAskiaState.Stop;

        /// <summary>
        /// Askia状态改变事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="askiaState"></param>
        public delegate void OnAskiaStateChangedHandler(Object sender, EAskiaState askiaState);
        /// <summary>
        /// Askia状态改变事件
        /// </summary>
        public event OnAskiaStateChangedHandler OnAskiaStateChanged;

        private double stopTime = 0;
        private float lostControlTime = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public Askia()
        {
            // Askia通常状态非物理控制
            PhysicsBody.Active = false;
            PhysicsBody.IsStatic = true;
            PhysicsBody.Body.FixedRotation = true;


            paramTweenList.Add(new RelaPosModifier("Wonder", "Position"));
            GetModifier("Wonder").OnStart += Wonder_OnStart;
            GetModifier("Wonder").OnFinish += Wonder_OnFinish;
            paramTweenList.Add(new RelaRateModifier("Dash", "Position"));
            GetModifier("Dash").OnStart += Dash_OnStart;
            GetModifier("Dash").OnFinish += Wonder_OnFinish;
            paramTweenList.Add(new RelaPosModifier("TakeOff", "Position"));
            GetModifier("TakeOff").OnStart += Dash_OnStart;
            GetModifier("TakeOff").OnFinish += Wonder_OnFinish;

            // TODO 更新状态机

            // 过时的
            // paramTweenList.Add(new PropertyModifier("Wonder", GlobalParamName.Position, PropertyModifier.ETweenType.AnyStart, "0", "100", 2500));
            // paramTweenList.Add(new PropertyModifier("Dash", GlobalParamName.Position, PropertyModifier.ETweenType.ChangeRate, "0", "100", 2000));
            // paramTweenList.Add(new PropertyModifier("TakeOff", GlobalParamName.Position, PropertyModifier.ETweenType.AnyStart, "0", "100", 1000));

            OnAskiaStateChanged += new OnAskiaStateChangedHandler(onAskiaStateChanged);

            Health = 3;
        }
        #endregion

        #region Preset Modifier
        public void Wonder_OnStart(Object sender, EventArgs e)
        {
            int rand = RandomHelper.GetRandomInt(0, 1);
            if (rand == 0)
                GetModifier("Wonder").EndValue = new Vector2(WonderLeft, WonderHeight).ToString();
            else
                GetModifier("Wonder").EndValue = new Vector2(WonderRight, WonderHeight).ToString();
        }
        public void Wonder_OnFinish(Object sender, EventArgs e)
        {
        }

        public void Dash_OnStart(Object sender, EventArgs e)
        {
            GetModifier("Dash").StartValue= Position.ToString();
            Vector2 speedVec = SceneManager.GetItemByName("Role").Position - Position;
            speedVec.Normalize();
            speedVec *= DashSpeed;
            GetModifier("Dash").EndValue = speedVec.ToString();
        }
        public void Dash_OnFinish(Object sender, EventArgs e)
        {
        }

        public void TakeOff_OnStart(Object sender, EventArgs e)
        {
            GetModifier("TakeOff").EndValue = new Vector2(Position.X, WonderHeight).ToString();
        }
        public void TakeOff_OnFinish(Object sender, EventArgs e)
        {
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        public override bool Update()
        {
            if (!base.Update())
                return false;

            // FSM更新
            if (SceneManager.GetItemByName("Role") != null)
            {
                FSMUpdate();
            }
            return true;
        }
        #endregion

        #region Self Control
        private void FaceControl()
        {
            if (SceneManager.GetItemByName("Role").Position.X < (Position.X - Size.X))
            {
                FaceRight = true;
            }
            if (SceneManager.GetItemByName("Role").Position.X > (Position.X + Size.X))
            {
                FaceRight = false;
            }
        }
        private void ChangeStateAction(EAskiaState state)
        {
            switch (state)
            {
                case EAskiaState.Wondering:
                    AskiaState = EAskiaState.Wondering;
                    AnimTexture.PlaySeq("Wondering");
                    StartModify("Wonder");
                    break;
                case EAskiaState.Dashing:
                    AskiaState = EAskiaState.Dashing;
                    AnimTexture.PlaySeq("Dashing");
                    StartModify("Dash");
                    break;
                case EAskiaState.LostControl:
                    AskiaState = EAskiaState.LostControl;
                    AnimTexture.PlaySeq("LostControl");
                    break;
                case EAskiaState.GetHurt:
                    AskiaState = EAskiaState.GetHurt;
                    AnimTexture.PlaySeq("GetHurt");
                    Health -= 1;
                    if (Health <= 0)
                    {
                        Visible = false;
                        DramaManager.Instance.StartDrama("End");
                    }
                    break;
                case EAskiaState.ShootingThorn:
                    AskiaState = EAskiaState.ShootingThorn;
                    AnimTexture.PlaySeq("ShootingThorn");
                    ThrowThorn();
                    break;
                case EAskiaState.TakingOff:
                    AskiaState = EAskiaState.TakingOff;
                    AnimTexture.PlaySeq("TakingOff");
                    StartModify("TakeOff");
                    break;
                case EAskiaState.Stop:
                    AskiaState = EAskiaState.Stop;
                    AnimTexture.PlaySeq("Stop");
                    stopTime = 0;
                    break;
                case EAskiaState.Dying:
                    AskiaState = EAskiaState.Dying;
                    AnimTexture.PlaySeq("Dying");
                    break;
            }
        }
        private void FSMUpdate()
        {
            switch (AskiaState)
            {
                case EAskiaState.Stop:
                    FaceControl();
                    stopTime += TimeHelper.ElapsedTimeThisFrameInMilliseconds;
                    #region 转出Dashing/ShootingThorn/Wondering
                    ChangeStateAction(ThinkNextAction());
                    #endregion
                    break;
                case EAskiaState.Dashing:
                    #region 转出Dashing
                    if (GetModifier("Dash").Tweening == false)
                    {
                        ChangeStateAction(EAskiaState.TakingOff);
                    }
                    #endregion
                    #region 转出LostControl
                    if (SceneManager.GTMActive)
                    {
                        StopModify("Dash");
                        ChangeStateAction(EAskiaState.LostControl);
                    }
                    #endregion
                    break;
                case EAskiaState.LostControl:
                    FaceControl();
                    #region 转出TakingOff
                    if (!SceneManager.GTMActive)
                    {
                        ChangeStateAction(EAskiaState.TakingOff);
                    }
                    #endregion
                    #region 转出GetHurt
                    foreach (Thorn t in SceneManager.GetItemManagerByName("Thorn").Items)
                    {
                        if (t.ThornState == Thorn.EThornState.Ice)
                        {
                            if (GetAABB().Intersects(t.GetAABB()))
                            {
                                ChangeStateAction(EAskiaState.GetHurt);
                            }
                        }
                    }
                    #endregion
                    break;
                case EAskiaState.GetHurt:
                    #region 转出Dying
                    if (Health <= 0)
                    {
                        ChangeStateAction(EAskiaState.Dying);
                    }
                    #endregion
                    break;
                case EAskiaState.ShootingThorn:
                    #region 转出ShootingThorn/Dashing/Wondering/Stop
                    if (AnimTexture.CurrentFrameId >= AnimTexture.CurrentSeq.EndFrameId)
                    {
                        ChangeStateAction(ThinkNextAction());
                    }
                    #endregion
                    break;
                case EAskiaState.Wondering:
                    FaceControl();
                    #region 转出ShootingThorn/Dashing/Wondering/Stop
                    if (GetModifier("Wonder").Tweening == false)
                    {
                        ChangeStateAction(ThinkNextAction());
                    }
                    #endregion
                    break;
                case EAskiaState.TakingOff:
                    FaceControl();
                    #region 转出ShootingThorn/Dashing/Wondering/Stop
                    if (GetModifier("TakeOff").Tweening == false)
                    {
                        ChangeStateAction(ThinkNextAction());
                    }
                    #endregion
                    break;
                case EAskiaState.Dying:
                    #region 目前无转出
                    #endregion
                    break;
            }
        }
        private EAskiaState ThinkNextAction()
        {
            EAskiaState thinkState = EAskiaState.Stop;
            int randomSeed = (int)TimeHelper.TotalTimeMilliseconds;
            bool thinkStateValid = false;
            while (!thinkStateValid)
            {
                thinkStateValid = true;
                randomSeed++;
                Random r = new Random(randomSeed);
                int rn = r.Next(4);
                if (rn == 0)
                {
                    // 是否可以冲刺
                    if (Math.Abs(SceneManager.GetItemByName("Role").Position.X - Position.X) > MinDashDest)
                    {
                        thinkState = EAskiaState.Dashing;
                    }
                    else
                    {
                        thinkStateValid = false;
                    }
                }
                else if (rn == 1)
                {
                    thinkState = EAskiaState.ShootingThorn;
                }
                else if (rn == 2)
                {
                    thinkState = EAskiaState.Wondering;
                }
                else if (rn == 3)
                {
                    if (AskiaState != EAskiaState.Stop)
                    {
                        thinkState = EAskiaState.Stop;
                    }
                    else
                    {
                        thinkStateValid = false;
                    }
                }
            }
            return thinkState;
        }
        private void ThrowThorn()
        {
            // TODO Make Thorn a Templete
            Item thorn = new Item();
            // TODO Set Properties for item

            if (!SceneManager.ItemManagers.ContainsKey("Thorn"))
                SceneManager.ItemManagers.Add("Thorn", new ItemManager());
            SceneManager.ItemManagers["Thorn"].Add(thorn);
        }
        #endregion


        private void onAskiaStateChanged(Object sender, EAskiaState askiaState)
        {
            // 过时
            //if (GameMgr.Instance.InEditorMode &&
            //    GameMgr.Instance.SceneEditor.Item == this)
            //{
            //    GameMgr.Instance.SceneEditor.LoadItemInfo("Askia状态");
            //}
        }
    }
}