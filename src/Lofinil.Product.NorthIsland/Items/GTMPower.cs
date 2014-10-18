using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Games;
using LofiEngine.Items;

namespace BreakOutMario.Objects
{
    /// <summary>
    /// GTMPower 类
    /// 重力转换器能源
    /// 角色携带重力转换器并处于该能源中，可以进行重力转换
    /// </summary>
    public class GTMPower:Item
    {
        #region Variables
        // 序列化字段
        /// <summary>
        /// 重力方向
        /// </summary>
        public ModuleSharer.SceneManager.GravityDirection GravityDirection;
        #endregion

        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public GTMPower()
        {
        }
        #endregion
    }
}
