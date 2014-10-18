using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Action = System.Action;
using Lofinil.Architecture;

namespace Lofinil.GameSDK.Engine
{
    // NOTE 依赖模块：无
    // NOTE 可选模块：无
    public class GraphicsModule : BaseModule
    {
        protected Graphics graphics;

        protected ContentModule resMod;

        public override void Initialize(IService service)
        {
            base.Initialize(service);

            graphics = new Graphics();
            graphics.Initialize(GameService.Device);
            this.resMod = GameService.QueryModule<ContentModule>();

        }

        // 不要再任何Draw函数中调用这个
        public Texture2D RenderToTexture(System.Action drawCall)
        {
            return graphics.RenderToTexture(drawCall);
        }

        public void RenderToFile(System.Action drawCall, String path)
        {
            graphics.RenderToFile(drawCall, path);
        }

        public void DrawBegin()
        {
            graphics.DrawBegin();
        }

        public void DrawEnd()
        {
            graphics.DrawEnd();
        }

        public void Draw(Texture2D texture, Rectangle? srcRectangle, Color color, Vector2 origin, Vector2 position, Vector2 scale, float rotation, SpriteEffects spriteEffect)
        {
            graphics.Draw(texture, srcRectangle, color, origin, position, scale, rotation, spriteEffect);
        }

        public void DrawLine(Vector2 s, Vector2 e, Color color)
        {
            graphics.DrawLine(s, e, color);
        }

        public void DrawRectangle(Rectangle rect, Color color)
        {
            graphics.DrawRectangle(rect, color);
        }

        public void Draw(int id, Rectangle destRect)
        {
            Texture2D t = (Texture2D)resMod.GetContent(ContentType.Texture, id);
            Draw(t, destRect);
        }

        public void Draw(String path, Rectangle destRect)
        {
            Texture2D t = (Texture2D)resMod.GetContent(ContentType.Texture, path);
            Draw(t, destRect);
        }

        public void Draw(Texture2D texture, Rectangle destRect)
        {
            graphics.Draw(texture, destRect);
        }

        public void Draw(Texture2D texture, Rectangle destRect, Color color)
        {
            graphics.Draw(texture, destRect, color);
        }

        public void DrawString(String font, String text, Vector2 pos)
        {
            SpriteFont sf = (SpriteFont)resMod.GetContent(ContentType.Font, font);
            graphics.DrawString(sf, text, pos);
        }

        public Vector2 MeasureString(String font, String text)
        {
            SpriteFont sf = (SpriteFont)resMod.GetContent(ContentType.Font, font);
            return graphics.MeasureString(sf, text);
        }

        public void WriteText(String font, int x, int y, int width, int height, AlignMode st, String s, Color c)
        {
            SpriteFont sf = (SpriteFont)resMod.GetContent(ContentType.Font, font);
            graphics.WriteText(sf, x, y, width, height, st, s, c);
        }

        internal void Clear(Microsoft.Xna.Framework.Color color)
        {
            graphics.Device.Clear(color);
        }
    }
}
