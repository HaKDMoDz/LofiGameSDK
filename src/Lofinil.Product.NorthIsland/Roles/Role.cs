using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Games;
using LofiEngine.Scenes;
using LofiEngine.Helpers;
using LofiEngine.Inputs;
using LofiEngine.Graphics;
using LofiEngine.Items;
using LofiEngine;
using SceneManager = BreakOutMario.Scenes.SceneManager;

namespace BreakOutMario.Roles
{
    // 预设的Role类，扩展游戏项目可以继承或自行创建
    // TODO 需更新
    /// <summary>
    /// 角色类
    /// </summary>
    public class Role : Item
    {
        #region Constants
        /// <summary>
        /// 最小跑速
        /// </summary>
        public const float MinRunSpeed = 20.0f;
        /// <summary>
        /// 转向速度
        /// </summary>
        public const float RurnFaceSpeed = 40.0f;
        private const float lowDefine = 1;                  // 速度判断的低值
        private const float GInfluenceOnlyCheckTime = 100;  // 仅重力影响检测时间
        private const float JumpTotalTime = 100;            // 跳跃施力计时
        /// <summary>
        /// 最大生命值
        /// </summary>
        public const float MaxHealth = 5;
        /// <summary>
        /// 最大携带补给品数量
        /// </summary>
        public const int MaxSupplyNumber = 5;
        /// <summary>
        /// 受伤时间
        /// </summary>
        public const float HurtTime = 2000;
        #endregion

        #region Variables
        // 序列化字段
        /// <summary>
        /// 健康值
        /// </summary>
        public int Health = 5;
        /// <summary>
        /// 面向右
        /// </summary>
        public bool FaceRight = true;
        /// <summary>
        /// 跑动力量
        /// </summary>
        public float RunForce = 100;
        /// <summary>
        /// 跳跃力量
        /// </summary>
        public float JumpForce = 9000;
        /// <summary>
        /// 最大跑速
        /// </summary>
        public float MaxRunSpeed = 100;
        #region ERoleState Enum
        /// <summary>
        /// 标志角色的各种状态
        /// </summary>
        public enum ERoleState
        {
            /// <summary>
            /// 空闲
            /// </summary>
            Free,
            /// <summary>
            /// 思考
            /// </summary>
            Think,
            /// <summary>
            /// 跳跃
            /// </summary>
            Jumping,
            /// <summary>
            /// 跌落
            /// </summary>
            Falling,
            /// <summary>
            /// 跑动
            /// </summary>
            Running,
            /// <summary>
            /// 改变重力
            /// </summary>
            ChanggingGravity,
            /// <summary>
            /// 受伤
            /// </summary>
            Hurt,
            /// <summary>
            /// 死亡
            /// </summary>
            Dying,
            /// <summary>
            /// 需要清理
            /// </summary>
            NeedClear,
        }
        #endregion
        /// <summary>
        /// 角色状态
        /// </summary>
        public ERoleState RoleState
        {
            get { return roleState; }
            set
            {
                ERoleState oldState = RoleState;
                roleState = value;
                if (OnRoleStateChange != null)
                {
                    OnRoleStateChange(this, oldState);
                }
            }
        }
        /// <summary>
        /// 向上角度
        /// </summary>
        public float UpRotation = -(float)Math.PI / 2;
        /// <summary>
        /// 向右角度
        /// </summary>
        public float RightRotation = 0;

        /// <summary>
        /// 补给品
        /// </summary>
        public List<String> supplyNameList = new List<String>();


        private ERoleState roleState = ERoleState.Free;
        private Vector2 speedFromPhysics = Vector2.Zero;
        private int jumpState = 0;
        private double jumpTime = 0;
        private Vector2 runForce = Vector2.Zero;
        private Vector2 jumpForce = Vector2.Zero;
        private bool continueJump = true;
        private float lastGV = 0;

        private bool isLowGravityOrthoSpeed = true;
        private bool isLowGravitySpeed = true;
        private bool isGInfluenceOnlyOneFrame = false;

        // TODO 因为无法从物理系统中直接获取，暂时使用这个方法检测物体是否只受重力 需修改物理引擎...
        private bool isGInfluenceOnly = false;
        private double gCheckTime = 0;   // 重力向仅重力检测计时

        private bool isHurting = false;     // 受伤状态 
        private double hurtTime = 0;         // 受伤时间
        /// <summary>
        /// 角色状态改变事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="oldState"></param>
        public delegate void OnRoleStateChangedHandler(Object sender, ERoleState oldState);
        /// <summary>
        /// 角色状态改变事件
        /// </summary>
        public event OnRoleStateChangedHandler OnRoleStateChange;
        #endregion

        #region Properties
        /// <summary>
        /// 向右方向向量
        /// </summary>
        [XmlIgnoreAttribute]
        public Vector2 RightVector
        {
            get
            {
                return new Vector2((float)Math.Cos(RightRotation), (float)Math.Sin(RightRotation));
            }
        }
        /// <summary>
        /// 向上方向向量
        /// </summary>
        [XmlIgnoreAttribute]
        public Vector2 UpVector
        {
            get
            {
                return new Vector2((float)Math.Cos(UpRotation), (float)Math.Sin(UpRotation));
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public Role()
        {
            PhysicsBody.Active = true;
            OnRoleStateChange += new OnRoleStateChangedHandler(onRoleStateChanged);
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

            // 分析物理系统计算信息 -- ! 需要先保存起来，FSM更新和Input跟新都可能覆盖掉物理信息
            speedFromPhysics = PhysicsBody.Body.LinearVelocity;
            isLowGravityOrthoSpeed = IsLowGravityOrthoSpeed();
            isLowGravitySpeed = IsLowGravitySpeed();
            isGInfluenceOnlyOneFrame = IsGInfluenceOnlyOneFrame();
            if (isGInfluenceOnlyOneFrame)
            {
                // Console.WriteLine("当前帧仅受重力");
                gCheckTime += TimeHelper.ElapsedTimeThisFrameInMilliseconds;
                if (gCheckTime > GInfluenceOnlyCheckTime)
                {
                    isGInfluenceOnly = true;
                }
            }
            else
            {
                gCheckTime = 0;
                isGInfluenceOnly = false;
            }

            // TODO 迁移
            //if (SceneMgr.Instance.role == this)
            //{
                // 受伤检测 -- TODO 以后要将Hurt加入状态机中
                //if (!isHurting)
                //{
                //    if (HitByThorn() || (SceneMgr.Instance.askia != null && SceneMgr.Instance.askia.AskiaState== Askia.EAskiaState.Dashing && GetAABB().Intersects(SceneMgr.Instance.askia.GetAABB())))
                //    {
                //        isHurting = true;
                //        Health--;
                //        hurtTime = 0;
                //    }
                //}
                //else
                //{
                //    hurtTime += TimeHelper.ElapsedTimeThisFrameInMilliseconds;
                //    if (hurtTime > HurtTime)
                //    {
                //        isHurting = false;

                //    }
                //}
                
                //if(Health <= 0)
                //    gameOver()
            //}


            // FSM更新
            FSMUpdate();

            // Input更新
            if (ModuleSharer.SceneMgr.GetItemByName("Role") == this && !(SceneManager)ModuleSharer.SceneMgr.GTMActive) // TODO 需修改，将GTM融合进状态机 ...
                InputUpdate();

            return true;
        }
        #endregion

        #region Draw
        /// <summary>
        /// 绘制
        /// </summary>
        public override void Draw()
        {
            base.Draw();

            #region 过时
            //// 角色始终在显示列表中
            //inFilterList = true;
            //if (Visible)
            //{
            //    // 如果启用动画则绘制帧
            //    // 否则使用基类的绘制方式
            //    if (AnimSeqList.Count != 0)
            //    {
            //        // 计算帧对应的矩形区域
            //        Rectangle pixelRect;
            //        int posX, poxY;
            //        int rowId, columnId;
            //        rowId = currentFrameId / ColumnCount;
            //        columnId = currentFrameId % ColumnCount;
            //        posX = columnId * (int)FrameSize.X;
            //        poxY = rowId * (int)FrameSize.Y;
            //        pixelRect = new Rectangle(posX, poxY, (int)FrameSize.X, (int)FrameSize.Y);

            //        Vector2 inCamPos = SceneMgr.Instance.Camera.GetInCameraPos(Position);
            //        if (FaceRight)
            //        {
            //            GraphicsManager.DrawT(texture, pixelRect, GetEditorColor(), origin, inCamPos, scale, Rotation, SpriteEffects.FlipHorizontally);
            //        }
            //        else
            //        {
            //            GraphicsManager.DrawT(texture, pixelRect, GetEditorColor(), origin, inCamPos, scale, Rotation);
            //        }
            //    }
            //    DrawBound();
            //    DrawBody();
            //}
            #endregion
        }
        #endregion

        #region Self Check&Control
        private float GetHSpeed(Vector2 speed)
        {
            return Vector2.Dot(speed, RightVector);
        }
        private float GetVSpeed(Vector2 speed)
        {
            return Vector2.Dot(speed, UpVector);
        }
        /// <summary>
        /// 重力正交方向低速
        /// </summary>
        /// <returns></returns>
        private bool IsLowGravityOrthoSpeed()
        {
            if (Math.Abs(Vector2.Dot(PhysicsBody.Body.LinearVelocity, RightVector)) < lowDefine)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 重力向低速
        /// </summary>
        /// <returns></returns>
        private bool IsLowGravitySpeed()
        {
            if (Math.Abs(Vector2.Dot(PhysicsBody.Body.LinearVelocity, UpVector)) < lowDefine)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 重力方向上只受重力 -- 这是一个不太精确的检测，应当避免斜坡过陡
        /// </summary>
        /// <returns></returns>
        private bool IsGInfluenceOnlyOneFrame()
        {
            double predictGV = lastGV;
            Vector2 g = -PhysicsManager.World.Gravity;
            float garvityG = Vector2.Dot(g, UpVector);
            predictGV -= garvityG * TimeHelper.ElapsedTimeThisFrameInMilliseconds/1000;
            lastGV = Vector2.Dot(speedFromPhysics, UpVector);
            double abs = Math.Abs(predictGV - lastGV);
            //if (isGInfluenceOnly)
            //{
            //    Console.WriteLine("预测速度:{0} --- 实际速度:{1}", predictGV, lastGV);
            //    Console.WriteLine("差值:" + (predictGV - lastGV).ToString());
            //}
            // 理论相同，即使物理引擎算法很高级，如果没有画蛇添足的处理，误差应该不大！
            // 预测和实际差值大约20 而且 为什么角色是匀速下落的？ -- 重新整理代码！
            if (abs < 1)
                return true;
            else
                return false;
        }
        private void LimitRunSpeed()
        {
            // 提取垂直分量
            float vspeed = Vector2.Dot(PhysicsBody.Body.LinearVelocity, UpVector);
            // 限制水平分量
            float hspeed = Vector2.Dot(PhysicsBody.Body.LinearVelocity, RightVector);
            hspeed = MathHelper.Clamp(hspeed, -MaxRunSpeed, MaxRunSpeed);
            // 更新速度
            PhysicsBody.Body.LinearVelocity = Vector2.Zero +
                new Vector2((float)Math.Cos(UpRotation), (float)Math.Sin(UpRotation)) * vspeed +
                new Vector2((float)Math.Cos(RightRotation), (float)Math.Sin(RightRotation)) * hspeed;
        }
        
        // TODO 迁移
        //private bool HitByThorn()
        //{
        //    bool getHit = false;
        //    Rectangle rect = GetAABB();
        //    foreach (Thorn thorn in SceneMgr.Instance.thornMgr.Items)
        //    {
        //        if (rect.Intersects(thorn.GetAABB()))
        //        {
        //            getHit = true;
        //            thorn.HitRole();
        //        }
        //    }
        //    return getHit;
        //}
        private void FSMUpdate()
        {
            switch (RoleState)
            {
                case ERoleState.Free:
                    #region 基于Free的"活动"和"检测型转出"
                    FaceControl();
                    #region 转出Falling
                    if (isGInfluenceOnly)
                    {
                        ChangeStateAction(ERoleState.Falling);
                    }
                    #endregion
                    #region 转出Running
                    if (!isLowGravityOrthoSpeed && !isGInfluenceOnly)
                    {
                        ChangeStateAction(ERoleState.Running);
                    }
                    #endregion
                    break;
                    #endregion
                case ERoleState.Running:
                    #region 基于Running的"活动"和"检测型转出"
                    FaceControl();
                    #region 转出Free
                    if (speedFromPhysics.Length() < lowDefine)
                    {
                        ChangeStateAction(ERoleState.Free);
                    }
                    #endregion
                    #region 转出Falling
                    if (isGInfluenceOnly)
                    {
                        ChangeStateAction(ERoleState.Falling);
                    }
                    #endregion
                    break;
                    #endregion
                case ERoleState.Jumping:
                    #region 基于Jumping的"活动"和"检测型转出"
                    jumpTime += TimeHelper.ElapsedTimeThisFrameInMilliseconds;
                    if (jumpState == 0)
                    {
                        if (isGInfluenceOnly && !isLowGravitySpeed)
                        {
                            jumpState = 1;
                        }
                    }
                    if (jumpState == 1)
                    {
                        if (isGInfluenceOnly && isLowGravitySpeed)
                        {
                            jumpState = 2;
                        }
                    }
                    #region 转出Falling
                    if (jumpState == 2)
                    {
                        if (isGInfluenceOnly && !isLowGravitySpeed)
                        {
                            ChangeStateAction(ERoleState.Falling);
                        }
                    }
                    #endregion

                    #region 强制转出 Falling
                    if (jumpState != 0 && !isGInfluenceOnly)
                    {
                        ChangeStateAction(ERoleState.Falling);
                    }
                    #endregion
                    //#region 转出Free
                    //if(isLowGravitySpeed)
                    //{
                    //    if (jumpState == 1)
                    //    {
                    //        jumpState = 2;
                    //    }
                    //    fixJumpTime += BaseGame.ElapsedTimeThisFrameInMilliseconds;
                    //    if (fixJumpTime > 100)
                    //    {
                    //        fixJumpTime = 0;
                    //        jumpState = 0;
                    //        jumpTime = 0;
                    //        ChangeStateAction(ERoleState.Free);
                    //    }
                    //}
                    //#endregion
                    break;
                    #endregion
                case ERoleState.Falling:
                    #region 基于Falling的"活动"和"检测型转出"
                    #region 转出Free
                    if (!isGInfluenceOnly)
                    {
                        ChangeStateAction(ERoleState.Free);
                    }
                    #endregion
                    break;
                    #endregion
            }
        }
        private void ChangeStateAction(ERoleState state)
        {
            switch (state)
            {
                case ERoleState.Free:
                    RoleState = ERoleState.Free;
                    AnimTexture.PlaySeq("Free");
                    break;
                case ERoleState.Running:
                    RoleState = ERoleState.Running;
                    AnimTexture.PlaySeq("Running");
                    break;
                case ERoleState.Jumping:
                    RoleState = ERoleState.Jumping;
                    AnimTexture.PlaySeq("Jumping");
                    float hSpeed =  Vector2.Dot(speedFromPhysics, RightVector);
                    jumpForce = new Vector2((float)Math.Cos(UpRotation) * JumpForce, (float)Math.Sin(UpRotation) * JumpForce);
                    jumpTime = 0;
                    jumpState = 0;
                    continueJump = true;
                    break;
                case ERoleState.Falling:
                    RoleState = ERoleState.Falling;
                    AnimTexture.PlaySeq("Falling");
                    float hSpeed1 =  Vector2.Dot(speedFromPhysics, RightVector);
                    break;
            }
        }
        private void InputUpdate()
        {
            #region 基于Free的"控制"和"控制型转出"
            if (RoleState == ERoleState.Free)
            {
                // 按方向键，进行左右移动
                if (Keyboard.isGameKeyPress(Keyboard.EGameKey.Right))
                {
                    AddRunForce(Keyboard.EGameKey.Right);
                }
                else if (Keyboard.isGameKeyPress(Keyboard.EGameKey.Left))
                {
                    AddRunForce(Keyboard.EGameKey.Left);
                }
                #region 转出Jumping
                if (Keyboard.isGameKeyJustPressed(Keyboard.EGameKey.Up))
                {
                    ChangeStateAction(ERoleState.Jumping);
                }
                #endregion
            }
            #endregion
            #region 基于Running的"行为"和"控制型转出"
            if (RoleState == ERoleState.Running)
            {
                // 按方向键，进行左右移动
                if (Keyboard.isGameKeyPress(Keyboard.EGameKey.Right))
                {
                    AddRunForce(Keyboard.EGameKey.Right);
                }
                else if (Keyboard.isGameKeyPress(Keyboard.EGameKey.Left))
                {
                    AddRunForce(Keyboard.EGameKey.Left);
                }
                #region 转出Jumping
                if (Keyboard.isGameKeyJustPressed(Keyboard.EGameKey.Up))
                {
                    ChangeStateAction(ERoleState.Jumping);
                    continueJump = true;
                }
                #endregion
            }
            #endregion
            #region 基于Jumping的"行为"和"控制型转出"
            if (RoleState == ERoleState.Jumping)
            {
                if (jumpTime < JumpTotalTime && continueJump &&
                    Keyboard.isGameKeyPress(Keyboard.EGameKey.Up))
                {
                    PhysicsBody.Body.ApplyForce(jumpForce);
                }
                if (Keyboard.isGameKeyJustRelease(Keyboard.EGameKey.Up))
                {
                    continueJump = false;
                }
            }
            #endregion
        }
        private void AddRunForce(Keyboard.EGameKey key)
        {
            Vector2 addForce = new Vector2((float)Math.Cos(RightRotation),
                (float)Math.Sin(RightRotation)) * RunForce;
            if (key == Keyboard.EGameKey.Right)
            {
                PhysicsBody.Body.ApplyForce(addForce);
            }
            else if (key == Keyboard.EGameKey.Left)
            {
                PhysicsBody.Body.ApplyForce(-addForce);
            }
        }
        private void FaceControl()
        {
            // 检查脸的朝向
            if (Vector2.Dot(PhysicsBody.Body.LinearVelocity, RightVector) > RurnFaceSpeed)
            {
                FaceRight = true;
            }
            else if (Vector2.Dot(PhysicsBody.Body.LinearVelocity, RightVector) < -RurnFaceSpeed)
            {
                FaceRight = false;
            }
        }
        #endregion

        #region Supply
        /// <summary>
        /// 获取补给
        /// </summary>
        /// <param name="supplyName"></param>
        public void GetSupply(String supplyName)
        {
            // TODO Add Logic ...
        }
        /// <summary>
        /// 使用补给
        /// </summary>
        /// <param name="supplyName"></param>
        public void UseSupply(String supplyName)
        {
            // TODO Add Logic ...
        }
        /// <summary>
        /// 是否拥有补给
        /// </summary>
        /// <param name="supplyName"></param>
        /// <returns></returns>
        public bool HasSupply(String supplyName)
        {
            foreach (String sname in supplyNameList)
            {
                if (sname == supplyName)
                    return true;
            }
            return false;
        }
        #endregion

        private void onRoleStateChanged(Object sender, ERoleState oldState)
        {
            // 过时
            //if (GameMgr.Instance.InEditorMode &&
            //    GameMgr.Instance.SceneEditor.Item != null &&
            //    (GameMgr.Instance.SceneEditor.Item.GetType().Name == "Role" ||
            //    GameMgr.Instance.SceneEditor.Item.GetType().Name == "RoyMustang"))
            //    GameMgr.Instance.SceneEditor.LoadItemInfo("角色状态");
        }
    }
}