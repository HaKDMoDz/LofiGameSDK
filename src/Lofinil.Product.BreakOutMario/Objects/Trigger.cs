using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using LofiEngine.Scenes;
using LofiEngine.Games;
using Microsoft.Xna.Framework;
using LofiEngine.Inputs;

namespace BreakOutMario.Objects
{
    // TODO 需迁移
    /*
    /// <summary>
    /// 开关类
    /// </summary>
    public class Trigger:AnimItem
    {
        #region Variables
        /// <summary>
        /// 开关状态
        /// </summary>
        private int triggerState = 0;
        /// <summary>
        /// 开关状态
        /// </summary>
        public int TriggerState
        {
            get { return triggerState; }
            set 
            {
                triggerState = value;
                if (OnTriggerStateChanged != null)
                {
                    OnTriggerStateChanged(this, value);
                }
                if (GameMgr.Instance.InEditorMode && GameMgr.Instance.SceneEditor.Item != null && GameMgr.Instance.SceneEditor.Item == this)
                {
                    // 过时
                    //GameMgr.Instance.SceneEditor.LoadItemInfo("开关状态");
                }
            }
        }
        /// <summary>
        /// 障碍标签
        /// </summary>
        public String ObstacleLabel = "";
        /// <summary>
        /// 开关预设枚举
        /// </summary>
        public enum ETriggerPreset
        {
            /// <summary>
            /// 无
            /// </summary>
            None,
            /// <summary>
            /// 单击触发单帧开关
            /// </summary>
            COOSF, //ClickOnOffSingleFrame,
            /// <summary>
            /// 物体压制单帧开关
            /// </summary>
            BPOOSF, //BodyPressOnOffSingleFrame,
        }
        /// <summary>
        /// 开关预设
        /// </summary>
        public ETriggerPreset TriggerPreset
        {
            get { return triggerPreset; }
            set
            {
                LoadTirggerPreset(value);
                triggerPreset = value;
            }
        }

        private ETriggerPreset triggerPreset = ETriggerPreset.None;

        /// <summary>
        /// 点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void OnClickHandler(Object sender, EventArgs e);
        /// <summary>
        /// 点击事件
        /// </summary>
        public event OnClickHandler OnClick;
        /// <summary>
        /// Body压制事件处理
        /// TODO 需修改 需要在这个函数内部进行按压检测，因此这个命名并不合适
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void OnBodyPressHandler(Object sender, EventArgs e);
        /// <summary>
        /// Body压制事件
        /// </summary>
        public event OnBodyPressHandler OnBodyPress;
        /// <summary>
        /// 开关状态改变事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="triggerState"></param>
        public delegate void OnTriggerStateChangedHandler(Object sender, int triggerState);
        /// <summary>
        /// 开关状态改变事件
        /// </summary>
        public event OnTriggerStateChangedHandler OnTriggerStateChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public Trigger()
        {
            Body.Active = false;

            OnTriggerStateChanged += onTriggerStateChanged_NorifyObstacle;
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

            // 点击触发
            if(OnClick != null &&
               Mouse.isLeftMouseClick() &&
               GetAABB().Contains(Mouse.X, Mouse.Y))
            {
                OnClick(this, null);
            }

            // 按压触发
            if (OnBodyPress != null)
                OnBodyPress(this, null);

            return true;
        }
        #endregion

        #region Trigger Preset 待更新
        //private void LoadTirggerPreset(ETriggerPreset preset)
        //{
        //    switch (preset)
        //    {
        //        case ETriggerPreset.None:
        //            EnableAnim = false;
        //            AnimSeqList.Clear();
        //            OnClick = null;
        //            OnBodyPress = null;
        //            break;
        //        case ETriggerPreset.COOSF:
        //            EnableAnim = true;
        //            AnimSeqList.Clear();
        //            AnimSeqList.Add(new AnimSequence("On", 0, 1, 1, true, true));
        //            AnimSeqList.Add(new AnimSequence("Off", 1, 1, 1, true, true));

        //            OnClick += onClick_RoleEnter_Handler;
        //            OnTriggerStateChanged += onTriggerStateChangeSingleFrameAnimHandler;
        //            break;
        //        case ETriggerPreset.BPOOSF:
        //            EnableAnim = true;
        //            AnimSeqList.Clear();
        //            AnimSeqList.Add(new AnimSequence("On", 0, 1, 1, true, true));
        //            AnimSeqList.Add(new AnimSequence("Off", 1, 1, 1, true, true));

        //            OnBodyPress += onBodyPress_Case_Role_Handler;
        //            OnTriggerStateChanged += onTriggerStateChangeSingleFrameAnimHandler;
        //            break;
        //        default:
        //            Console.WriteLine("警告：指定TriggerPreset不存在，名称：" + preset.ToString());
        //            break;
        //    }
        //}
        //private void onClick_RoleEnter_Handler(Object sender, EventArgs e)
        //{
        //    Rectangle orthoBound = GetAABB();
        //    if (SceneMgr.Instance.role != null && orthoBound.Intersects(SceneMgr.Instance.role.GetAABB()))
        //    {
        //        switch (TriggerState)
        //        {
        //            case 0:
        //                TriggerState = 1;
        //                break;
        //            case 1:
        //                TriggerState = 0;
        //                break;
        //        }
        //    }
        //}
        //private void onBodyPress_Case_Role_Handler(Object sender, EventArgs e)
        //{
        //    // 取消碰撞
        //    Body.Active = false;

        //    Rectangle orthoBound = GetAABB();
        //    bool isPressed = false;
        //    foreach (Case item in SceneMgr.Instance.caseMgr.Items)
        //    {
        //        if (orthoBound.Intersects(item.GetAABB()))
        //        {
        //            isPressed = true;
        //        }
        //    }
        //    if (!isPressed && SceneMgr.Instance.role != null && orthoBound.Intersects(SceneMgr.Instance.role.GetAABB()))
        //    {
        //        isPressed = true;
        //    }
        //    if (isPressed)
        //    {
        //        if (TriggerState == 1)    // 避免重置补间
        //            return;
        //        TriggerState = 1;
        //    }
        //    else
        //    {
        //        if (TriggerState == 0) // 避免重置补间
        //            return;
        //        TriggerState = 0;
        //    }
        //}
        //private void onTriggerStateChangeSingleFrameAnimHandler(Object sender, int triggerState)
        //{
        //    if (triggerState == 1)
        //    {
        //        PlaySeq("Off");
        //    }
        //    else if (triggerState == 0)
        //    {
        //        PlaySeq("On");
        //    }
        //}
        //private void onTriggerStateChanged_NorifyObstacle(Object sender, int triggerState)
        //{
        //    foreach (Obstacle item in SceneMgr.Instance.obstacleMgr.Items)
        //    {
        //        if (item.Label == ObstacleLabel)
        //        {
        //            item.ChangeState(triggerState);
        //            return;
        //        }
        //    }
        //    Console.WriteLine("未找到标签为'{0}的障碍物'", ObstacleLabel);
        //}
        #endregion
    }
    */
}
