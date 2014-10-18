using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Scenes;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using LofiEngine.Games;
using LofiEngine.Helpers;
using LofiEngine.Items;
using LofiEngine;

namespace BreakOutMario.Objects
{
    /// <summary>
    /// 门廊 场景之间的衔接点
    /// </summary>
    [Serializable]
    public class Proch : Item
    {
        #region Variable
        // 序列化字段
        /// <summary>
        /// 目标场景名称
        /// </summary>
        public string TargetSceneName;
        /// <summary>
        /// 目标Proch的Label
        /// </summary>
        public string TargetProchLabel;
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool ProchEnabled = true;

        /// <summary>
        /// 角色仍在内部
        /// </summary>
        [XmlIgnoreAttribute]
        public bool StillInside = false;
        #endregion

        #region Proch
        /// <summary>
        /// 构造函数
        /// </summary>
        public Proch()
        {
            PhysicsBody.Active = false;
        }
        #endregion

        #region Update
        /// <summary>
        /// 如果角色进入门廊，则切换场景
        /// </summary>
        public override bool Update()
        {
            if (!base.Update())
                return false;

            if (!ProchEnabled)
                return true;
            // 角色通过
            if (ModuleSharer.SceneMgr.GetItemByName("Role") == null || 
                StringHelper.IsNullOrEmpty(TargetSceneName) ||
                StringHelper.IsNullOrEmpty(TargetProchLabel))
                return true;
            if (ModuleSharer.SceneMgr.GetItemByName("Role").GetAABB().Intersects(GetAABB()))
            {
                if (!StillInside)
                {
                    ModuleSharer.SceneMgr.LoadScene(TargetSceneName);
                }
            }
            else
            {
                StillInside = false;
            }
            return true;
        }
        #endregion
    }
}
