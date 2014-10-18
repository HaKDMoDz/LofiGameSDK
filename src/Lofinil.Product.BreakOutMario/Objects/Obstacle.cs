using System;
using LofiEngine.Items;
using LofiEngine.Modifiers;
using LofiEngine.Players;
using LofiEngine.Scenes;
using Microsoft.Xna.Framework;
using LofiEngine;

namespace BreakOutMario.Objects
{
    /// <summary>
    /// 障碍物类
    /// </summary>
    public class Obstacle : Item
    {
        #region Variables
        // 序列化
        /// <summary>
        /// 障碍状态
        /// </summary>
        public int ObstacleState = 0;
        private int obstacleState = 0;
        /// <summary>
        /// 开关标签
        /// </summary>
        public String TriggerLabel;
        /// <summary>
        /// 障碍预设枚举
        /// </summary>
        public enum EObstaclePreset
        {
            /// <summary>
            /// 无
            /// </summary>
            None,
            /// <summary>
            /// 上下运动
            /// </summary>
            UpDown,
            /// <summary>
            /// 左右运动
            /// </summary>
            LeftRight,
        }
        /// <summary>
        /// 障碍预设
        /// </summary>
        public EObstaclePreset ObstaclePreset
        {
            get{return obstaclePreset;}
            set
            {
                LoadPreset(value);
                obstaclePreset = value;
            }
        }

        // 不需序列化
        private int nextStateId = 0;
        private bool firstLoad = true;
        private EObstaclePreset obstaclePreset = EObstaclePreset.None;
        #endregion

        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public Obstacle()
        {
            PhysicsBody.IsStatic = true;
            PhysicsBody.Active = true;
        }
        #endregion

        #region Obstacle Preset
        private void LoadPreset(EObstaclePreset oType)
        {
            paramTweenList.Clear();
            RelaPosModifier mod = null;
            switch(oType)
            {
                case EObstaclePreset.LeftRight:
                    mod = new RelaPosModifier("MoveRight", "Position");
                    mod.TotalTimeMS = 1000;
                    mod.OnStart += MoveRight_OnStart;

                    mod = new RelaPosModifier("MoveLeft", "Position");
                    mod.TotalTimeMS = 1000;
                    mod.OnStart += MoveLeft_OnStart;
                    break;

                case EObstaclePreset.UpDown:
                    mod = new RelaPosModifier("MoveDown", "Position");
                    mod.TotalTimeMS = 1000;
                    mod.OnStart += MoveDown_OnStart;

                    mod = new RelaPosModifier("MoveUp", "Position");
                    mod.TotalTimeMS = 1000;
                    mod.OnStart += MoveUp_OnStart;
                    break;
            }
        }

        public void MoveRight_OnStart(Object sender, EventArgs e)
        {
            FixPosModifier mod = (FixPosModifier)sender;
            Vector2 rightPos = new Vector2(Position.X + Size.X, Position.Y);
            mod.StartValue = this.Position;
            mod.EndValue = rightPos;
        }

        public void MoveLeft_OnStart(Object sender, EventArgs e)
        {
            FixPosModifier mod = (FixPosModifier)sender;
            Vector2 leftPos = new Vector2(Position.X - Size.X, Position.Y);
            mod.StartValue = this.Position;
            mod.EndValue = leftPos;
        }

        public void MoveUp_OnStart(Object sender, EventArgs e)
        {
            FixPosModifier mod = (FixPosModifier)sender;
            Vector2 upPos = new Vector2(Position.X, Position.Y + Size.Y);
            mod.StartValue = this.Position;
            mod.EndValue = upPos;
        }

        public void MoveDown_OnStart(Object sender, EventArgs e)
        {
            FixPosModifier mod = (FixPosModifier)sender;
            Vector2 downPos = new Vector2(Position.X, Position.Y + Size.Y);
            mod.StartValue = this.Position;
            mod.EndValue = downPos;
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

            // 如果是首次载入场景，则直接设置为补间终点状态
            if (firstLoad)
            {
                if (paramTweenList.Count > ObstacleState)
                {
                    paramTweenList[ObstacleState].SetToFinal();
                }
                firstLoad = false;
            }
            return true;
        }
        #endregion

        #region ChangeState
        /// <summary>
        /// 改变状态
        /// </summary>
        /// <param name="stateId"></param>
        public void ChangeState(int stateId)
        {
            if (stateId < paramTweenList.Count)
            {
                paramTweenList[stateId].StartModify();
                paramTweenList[stateId].OnFinish += onTweenFinishedHandler;
                nextStateId = stateId;
            }
            else
            {
                Console.WriteLine("转换状态id:{0}超出ParamTween列表长度{1}",stateId,paramTweenList.Count);
            }
        }
        #endregion

        #region Tween
        private void onTweenFinishedHandler(Object sender, EventArgs e)
        {
            ObstacleState = nextStateId;
            SaveObstacleChange();
        }
        #endregion

        #region Player
        private void SaveObstacleChange()
        {
            if (Name == "")
                return;
            // TODO 需更新
            Player.SceneChange.ItemPropertyChange itemParamChange  = new Player.SceneChange.ItemPropertyChange();
            itemParamChange.ItemName = "Obstacle";
            itemParamChange.ItemLabel = "Name";
            itemParamChange.PropertyName = "ObstacleState";
            itemParamChange.Value = ObstacleState.ToString();
            ModuleSharer.PlayerMgr.AddSceneSaveEntry(ModuleSharer.SceneMgr.SceneName, itemParamChange);
        }
        #endregion
    }
}
