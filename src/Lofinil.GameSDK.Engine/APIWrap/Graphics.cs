using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Lofinil.GameSDK.Engine
{
    public class Graphics
    {
        public GraphicsDevice Device;

        private SpriteBatch spriteBatch;

        private BasicEffect basicEffect;

        public bool IsDrawBegin;

        public Graphics()
        {
            IsDrawBegin = false;
        }

        public void Initialize(GraphicsDevice device)
        {
            Device = device;
            spriteBatch = new SpriteBatch(Device);
            basicEffect = new BasicEffect(Device);
            basicEffect.VertexColorEnabled = true;

            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0, Device.Viewport.Width, Device.Viewport.Height, 0, 0, 1);
        }

        // 不要在任何的Draw函数里面调用这个函数
        public Texture2D RenderToTexture(System.Action drawCall )
        {
            RenderTarget2D rt = new RenderTarget2D(
                Device, Device.Viewport.Width, Device.Viewport.Height);//, true, SurfaceFormat.Color, DepthFormat.Depth16);

            Device.SetRenderTarget(rt);
            bool oldDrawBegin = IsDrawBegin;
            if (!oldDrawBegin)
                DrawBegin();
            drawCall();
            if (!oldDrawBegin)
                DrawEnd();

            Device.SetRenderTarget(null);

            Color[] c = new Color[1];
            rt.GetData(0, new Rectangle(100, 100, 1, 1), c, 0, 1);
            Console.WriteLine(c[0].ToString());

            return rt;
        }

        public void RenderToFile(System.Action drawCall, String path)
        {
            Texture2D texture = RenderToTexture(drawCall);
            Stream stream = new FileStream( path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            texture.SaveAsPng(stream, texture.Width, texture.Height);
        }

        public void DrawBegin()
        {
            if (!IsDrawBegin)
            {
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                IsDrawBegin = true;
            }
        }

        public void DrawEnd()
        {
            if (IsDrawBegin)
            {
                spriteBatch.End();
                IsDrawBegin = false;
            }
        }

        public void Draw(Texture2D texture, Rectangle? srcRectangle, Color color, Vector2 origin, Vector2 position, Vector2 scale, float rotation, SpriteEffects spriteEffect)
        {
            spriteBatch.Draw(texture, position, srcRectangle, color, rotation, origin, scale, spriteEffect, 0);
        }

        public void DrawLine(Vector2 s, Vector2 e, Color color)
        {
            VertexPositionColor[] vertices = new VertexPositionColor[2];

            vertices[0].Color = color;
            vertices[0].Position = new Vector3(s, 0);

            vertices[1].Color = color;
            vertices[1].Position = new Vector3(e, 0);

            basicEffect.CurrentTechnique.Passes[0].Apply();

            Device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, vertices, 0, 1);
        }

        public void DrawRectangle(Rectangle rect, Color color)
        {
            VertexPositionColor[] vertices = new VertexPositionColor[5];

            vertices[0].Color = color;
            vertices[0].Position = new Vector3(rect.Left, rect.Top, 0);

            vertices[1].Color = color;
            vertices[1].Position = new Vector3(rect.Right, rect.Top, 0);

            vertices[2].Color = color;
            vertices[2].Position = new Vector3(rect.Right, rect.Bottom, 0);

            vertices[3].Color = color;
            vertices[3].Position = new Vector3(rect.Left, rect.Bottom, 0);

            vertices[4] = vertices[0];
        }

        public void Draw(Texture2D texture, Rectangle destRect)
        {
            spriteBatch.Draw(texture, destRect, Color.White);
        }

        public void Draw(Texture2D texture, Rectangle destRect, Color color)
        {
            spriteBatch.Draw(texture, destRect, color);
        }

        public void DrawString(SpriteFont sf, String text, Vector2 pos)
        {
            spriteBatch.DrawString(sf, text, pos, Color.White);
        }

        public Vector2 MeasureString(SpriteFont sf, String text)
        {
            return sf.MeasureString(text);
        }

        // TODO [由UI自己缓存文本位置] 文本位置应该由UI自己负责计算和缓存，而不是每次绘制时计算
        public void WriteText(SpriteFont sf, int x, int y, int width, int height, AlignMode st, string s, Color c)
        {
            Vector2 size = sf.MeasureString(s);
            int tx = x, ty = y;//实际输出的位置
            switch (st)
            {
                case AlignMode.Middle:
                    tx = (int)(x + (float)width / 2 - (float)size.X / 2);
                    ty = (int)(y + (float)height / 2 - (float)size.Y / 2);
                    break;
                case AlignMode.Right:
                    tx = (int)(x + (float)width - (float)size.X);
                    ty = (int)(y + (float)height / 2 - (float)size.Y / 2);
                    break;
                case AlignMode.Left:
                    ty = (int)(y + (float)height / 2 - (float)size.Y / 2);
                    break;
                default:
                    break;
            }
            spriteBatch.DrawString(sf, s, new Vector2(tx, ty), c);
        }
    }
}