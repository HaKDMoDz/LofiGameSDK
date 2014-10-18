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
    /// 健康条
    /// </summary>
    public class HealthBar : Control 
    {
        Texture2D lifeIcon;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="lifeIcon"></param>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="parent"></param>
        public HealthBar(Texture2D lifeIcon, int _x, int _y, int width,int height, Control parent)
            : base(_x, _y, width, height, parent)
        {
            this.lifeIcon = lifeIcon;
        }
        /// <summary>
        /// 绘制
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            if (ModuleSharer.SceneMgr.GetItemByName("Role") != null)
            {
                int roleHealth = ((Role)ModuleSharer.SceneMgr.GetItemByName("Role")).Health;
                for (int i = 0; i < Role.MaxHealth; i++)
                {
                    if (i < roleHealth)
                    {
                        ModuleSharer.GraphicsMgr.Draw(
                            lifeIcon, null, Color.White, Vector2.Zero, 
                            new Vector2(Top + lifeIcon.Width * i, Left), 
                            new Vector2(1, 1), 0, SpriteEffects.None);
                    }
                    else
                    {
                        ModuleSharer.GraphicsMgr.Draw(
                            lifeIcon, null, Color.Gray, Vector2.Zero, 
                            new Vector2(Top + lifeIcon.Width * i, Left), 
                            new Vector2(1, 1), 0, SpriteEffects.None);
                    }
                }
            }
        }
    }
}
