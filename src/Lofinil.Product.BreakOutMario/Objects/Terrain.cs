 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Physics;
using LofiEngine.Games;
using LofiEngine.Scenes;
using LofiXUtil.Graphics;
using LofiXUtil.Helpers;
using LofiEngine.Items;
using LofiEngine;

namespace BreakOutMario.Objects
{
    /// <summary>
    /// 地板
    /// </summary>
    public class Terrain : Item
    {
        #region Variables & Properties
        // 序列化字段
        #region ETiledType Enum
        /// <summary>
        /// 平铺类型枚举
        /// </summary>
        public enum ETiledType
        {
            /// <summary>
            /// 水平竖直
            /// </summary>
            Both,
            /// <summary>
            /// 仅水平
            /// </summary>
            Horizontal,
            /// <summary>
            /// 仅竖直
            /// </summary>
            Vertical,
        }
        #endregion
        /// <summary>
        /// 平铺类型
        /// </summary>
        public ETiledType TiledType = ETiledType.Both;

        //private Vector2 tiledScale = new Vector2(1,1);
        // 序列化字段
        //public Vector2 TiledSize            // 每个平铺单元的绝对显示尺寸
        //{
        //    get
        //    {
        //        return new Vector2(tiledScale.X * TextureSize.X, tiledScale.Y * TextureSize.Y);
        //    }
        //    set
        //    {
        //        tiledScale = new Vector2(value.X / TextureSize.X, value.Y / TextureSize.Y);
        //    }
        //}
        #endregion

        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public Terrain()
        {
            PhysicsBody.IsStatic = true;
            PhysicsBody.Active = true;
        }
        #endregion
        /// <summary>
        /// 更新
        /// </summary>
        public override bool Update()
        {
            return base.Update();
        }

        #region Draw
        /// <summary>
        /// 绘制
        /// </summary>
        public override void Draw()
        {
            if (Visible)
            {
                SamplerState ss = new SamplerState();
                if (TiledType == ETiledType.Both)
                {
                    ss.AddressU = TextureAddressMode.Wrap;
                    ss.AddressV = TextureAddressMode.Wrap;
                    GraphicsManager.GraphicsDevice.SamplerStates[0] = ss;
                    Rectangle srcRect = new Rectangle(0, 0, (int)Math.Ceiling(Size.X /* * tiledScale.X */), (int)Math.Ceiling(Size.Y /* * tiledScale.Y */));
                    Vector2 Origin = new Vector2(srcRect.Width / 2, srcRect.Height / 2);
                    Vector2 inCamPos = SceneManager.Instance.Camera.GetInCameraPos(Position);
                    // 需迁移
                    //  EditorManager.DrawTiledTerrain(texture, inCamPos, srcRect, GetEditorColor(), Origin, new Vector2(1, 1), Rotation);
                }
                else if (TiledType == ETiledType.Horizontal)
                {
                    ss.AddressU = TextureAddressMode.Wrap;
                    ss.AddressV = TextureAddressMode.Clamp;
                    GraphicsManager.GraphicsDevice.SamplerStates[0] = ss;
                    Rectangle srcRect = new Rectangle(0, 0, (int)(Size.X /*  *tiledScale.X */), (int)AnimTexture.Texture.Height);
                    Vector2 Origin = new Vector2(srcRect.Width / 2, srcRect.Height / 2);
                    Vector2 inCamPos = SceneManager.Instance.Camera.GetInCameraPos(Position);
                    // 需迁移
                    //EditorManager.DrawTiledTerrain(texture, inCamPos, srcRect, GetEditorColor(), Origin, new Vector2(1, 1), Rotation);
                }
                else if (TiledType == ETiledType.Vertical)
                {
                    ss.AddressU = TextureAddressMode.Clamp;
                    ss.AddressV = TextureAddressMode.Wrap;
                    GraphicsManager.GraphicsDevice.SamplerStates[0] = ss;
                    Rectangle srcRect = new Rectangle(0, 0, (int)AnimTexture.Texture.Width, (int)(Size.Y /* * tiledScale.Y */));
                    Vector2 Origin = new Vector2(srcRect.Width / 2, srcRect.Height / 2);
                    Vector2 inCamPos = SceneManager.Instance.Camera.GetInCameraPos(Position);
                    // 需迁移
                    //EditorManager.DrawTiledTerrain(texture, inCamPos, srcRect, GetEditorColor(), Origin, new Vector2(1, 1), Rotation);
                }
                ss = new SamplerState();
                ss.AddressU = TextureAddressMode.Clamp;
                ss.AddressV = TextureAddressMode.Clamp;
                GraphicsManager.GraphicsDevice.SamplerStates[0] = ss;
            }
        }

        #endregion
    }
}
