using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Scenes;
using LofiEngine.Games;
using LofiEngine.Inputs;
using LofiEngine.Items;
using LofiEngine;

namespace BreakOutMario.Objects
{
    /// <summary>
    /// 补给箱 武器、链条、生长素等可拾取物
    /// </summary>
    [Serializable]
    public class SupplyBox : Item
    {
        #region Variable
        /// <summary>
        /// 补给道具名称
        /// </summary>
        public string SupplyName = "";
        #endregion

        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public SupplyBox()
        {
            PhysicsBody.Active = false;
        }
        #endregion


        #region Update
        public override bool Update()
        {
            if(!base.Update())
                return false;

            if (Mouse.LeftMouseClicked())
            {
                if (this.CanGet())
                {
                    // TODO 需迁移
                    //SceneMgr.Instance.role.GetSupply(SupplyName);
                    //System.Console.Write("获得补给：" + SupplyName + "\n");
                    return false;
                }
            }

            return true;
        }
        #endregion
        /// <summary>
        /// 是否可以获得
        /// </summary>
        /// <returns></returns>
        public bool CanGet()
        {
            // 需迁移
            // 鼠标点击时，检测拾取
            //if (Mouse.GetMouseClickRect().Intersects(GetAABB()) &&
            //    SceneMgr.Instance.role.GetAABB().Intersects(GetAABB())) 
            //{
            //    return true;
            //}
            return false;
        }

    }
}
