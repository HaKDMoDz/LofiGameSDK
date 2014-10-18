using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Scenes;
using Microsoft.Xna.Framework;
using LofiEngine.Items;
using LofiEngine.Graphics;
using LofiEngine;
using BreakOutMario.Roles;
using LofiEngine.Interfaces;

namespace BreakOutMario.UI
{
    /// <summary>
    /// 补给图标条
    /// </summary>
    public class SupplyBar : Control 
    {
        Dictionary<String, Texture2D> supplyIcons;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="supplyIcons"></param>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="parent"></param>
        public SupplyBar(Dictionary<String, Texture2D> supplyIcons, int _x, int _y, int width, int height, Control parent)
            : base(_x, _y, width, height, parent)
        {
            this.supplyIcons = supplyIcons;
        }
        /// <summary>
        /// 绘制
        /// </summary>
        public override void Draw()
        {
            base.Draw();

            if (ModuleSharer.SceneMgr.GetItemByName("Role") != null)
            {
                // 计算补给品图标尺寸
                Vector2 supplyIconSize = new Vector2((Width - 80) / Role.MaxSupplyNumber, Height - 20);
                for (int i = 0; i < ((Role)ModuleSharer.SceneMgr.GetItemByName("Role")).supplyNameList.Count; i++)
                {
                    String spName = ((Role)ModuleSharer.SceneMgr.GetItemByName("Role")).supplyNameList[i];
                    ModuleSharer.GraphicsMgr.Draw(supplyIcons[spName], new Rectangle(Left + 20 + (int)supplyIconSize.X * i, Top + 10, (int)supplyIconSize.X, (int)supplyIconSize.Y));
                }
            }
        }
    }
}
