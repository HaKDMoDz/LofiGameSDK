using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LofiXUtil.Helpers;

namespace LofiXUtil.Graphics
{
    public static class GraphicsManager
    {
        #region Initialize
        public static void Initialize(GraphicsDevice device)
        {
            GraphicsDevice = device;
            mSpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO 需改进
            // mSpriteFont = LoadHelper.LoadSpriteFont("Default");
            // mDialogFont = LoadHelper.LoadSpriteFont("Dialog");
        }
        #endregion

        #region Variables
        static public GraphicsDevice GraphicsDevice;
        static private SpriteBatch mSpriteBatch;
        static private SpriteFont mSpriteFont;
        static private SpriteFont mDialogFont;
        #endregion

        #region Draw
        static public void DrawBegin()
        {
            mSpriteBatch.Begin(SpriteSortMode.Immediate,BlendState.AlphaBlend);
        }
        static public void DrawEnd()
        { 
            mSpriteBatch.End();
        }

        /// <summary>
        /// 元DrawT方法 - 1
        /// </summary>
        static public void DrawT(Texture2D texture, Vector2 position,Color color,Rectangle srcRect,float rotation,Vector2 origin,Vector2 scale)
        {
            mSpriteBatch.Draw(texture, position, srcRect, color, rotation, origin, scale,SpriteEffects.None,0);
        }

        /// <summary>
        /// 特点： 指定向量scale，指定目标点
        /// 暂记： 被ItemBase调用
        /// </summary>
        static public void DrawT(Texture2D texture, Vector2 position,Vector2 origin,Vector2 scale, float rotation)
        {
            mSpriteBatch.Draw(texture, position, null, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
        static public void DrawT(Texture2D texture, Vector2 position, Vector2 origin, Vector2 scale, float rotation,Color color)
        {
                mSpriteBatch.Draw(texture, position, null, color, rotation, origin, scale, SpriteEffects.None, 0);
        }

        // 使用向量scale的情况下，指定目标矩形没有太大意义

        /// 特点： 指定向量scale，指定源矩形，指定绘制位置
        static public void DrawT(Texture2D texture, Rectangle? srcRectangle,Color color, Vector2 origin, Vector2 position, Vector2 scale, float rotation)
        {
            mSpriteBatch.Draw(texture, position, srcRectangle, color, rotation, origin, scale, SpriteEffects.None, 0);
        }
        // 增加SpriteEffects
        static public void DrawT(Texture2D texture, Rectangle? srcRectangle,Color color, Vector2 origin, Vector2 position, Vector2 scale, float rotation, SpriteEffects spriteEffect)
        {
            mSpriteBatch.Draw(texture, position, srcRectangle, color, rotation, origin, scale, spriteEffect, 0);
        }
        //一下均为 demo所用，到时候要重写

        //按大小位置绘制一张texture2D矩形
        static public void DrawT(Texture2D texture, Vector2 position, float rotation, float scale)
        {
            mSpriteBatch.Draw(texture, position, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);
        }

        static public void DrawT(Texture2D texture, Rectangle srcRect, Vector2 position, Vector2 origin,float rotation, float scale)
        {
            mSpriteBatch.Draw(texture, position, srcRect, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        }
        static public void DrawT(Texture2D texture, Rectangle srcRect, Vector2 position, float rotation, float scale)
        {
            mSpriteBatch.Draw(texture, position, srcRect, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);
        }
        static public void DrawT(Texture2D texture, Vector2 position, Color color)
        {
            mSpriteBatch.Draw(texture,position,color);
        }
        static public void DrawT(Texture2D texture, Vector2 position)
        {
            mSpriteBatch.Draw(texture, position, Color.White);
        }
        static public void DrawT(Texture2D texture, Rectangle srcRect, Rectangle destRect)
        {
            mSpriteBatch.Draw(texture, srcRect, destRect,Color.White);
        }
        static public void DrawT(Texture2D texture, Rectangle srcRect, Rectangle destRect, Color color)
        {
            mSpriteBatch.Draw(texture, srcRect, destRect, color);
        }
        static public void DrawT(Texture2D texture, Rectangle destRect)
        {
            mSpriteBatch.Draw(texture, destRect,Color.White);
        }
        static public void DrawT(Texture2D texture, Rectangle destRect, Color color)
        {
            mSpriteBatch.Draw(texture, destRect, color);
        }
        #endregion

        #region Draw Text
        public static void DrawLine(string str,Vector2 position)
        {
            mSpriteBatch.DrawString(mSpriteFont, str, position, Color.White);
        }
        #endregion

        #region Draw Text (by CKH)
        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="fontname">字体名</param>
        static public void setFont(string fontname)
        {
            // 载入字体
            mSpriteFont = LoadHelper.Content.Load<SpriteFont>("Fonts//" + fontname);
        }

        static public void WriteText(int x, int y, string s, Color c)
        {
            mSpriteBatch.DrawString(mSpriteFont, s, new Vector2(x, y), c);
        }
        //根据容器大小、文字排版类型输出文字
        //输出类型
        public enum StringType { Left, Right, Middle };

        /// <summary>
        /// 按容器输出
        /// </summary>按容器输出
        /// <param name="sf"></param>
        /// <param name="x">容器x</param>
        /// <param name="y">容器y</param>
        /// <param name="width">容器宽</param>
        /// <param name="height">容器高</param>
        /// <param name="st">输出类型</param>
        /// <param name="s">字符串</param>
        /// <param name="c">颜色</param>
        static public void WriteText(SpriteFont sf, int x, int y, int width, int height, StringType st, string s, Color c)
        {
            Vector2 size = getTextSize(s, sf);
            int tx = x, ty = y;//实际输出的位置
            switch (st)
            {
                case StringType.Middle:
                    tx = (int)(x + (float)width / 2 - (float)size.X / 2);
                    ty = (int)(y + (float)height / 2 - (float)size.Y / 2);
                    break;
                case StringType.Right:
                    tx = (int)(x + (float)width - (float)size.X);
                    ty = (int)(y + (float)height / 2 - (float)size.Y / 2);
                    break;
                case StringType.Left:
                    ty = (int)(y + (float)height / 2 - (float)size.Y / 2);
                    break;
                default:
                    break;
            }
            mSpriteBatch.DrawString(sf, s, new Vector2(tx, ty), c);
        }
        static public void WriteText(int x, int y, int width, int height, StringType st, string s, Color c)
        {
            WriteText(mSpriteFont, x, y, width, height, st, s, c);
        }

        //获得字符串像素尺寸
        static public Vector2 getTextSize(string s, SpriteFont sf)
        {
            return sf.MeasureString(s);
        }
        static public Vector2 getTextSize(string s)
        {
            return mSpriteFont.MeasureString(s);
        }

        #endregion

        public static void DrawLineOnDialog(String line)
        {
            GraphicsManager.WriteText(mDialogFont, 380, 520, 0, 0, StringType.Middle, line, Color.White);
        }
    }
}
