using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Color = Microsoft.Xna.Framework.Color;
using ContentManager = Lofinil.GameSDK.Engine.ContentModule;
using Microsoft.Xna.Framework.Content.Pipeline.Tasks;
using Microsoft.Build.Framework;
using Microsoft.Xna.Framework.Content;
using Lofinil.GameSDK.Engine;

namespace EngineTest
{
    public partial class TestForm1 : Form
    {
        Vector2 speed;
        Vector2 pos;
        Vector2 textSize;

        GraphicsModule Graphics;

        public TestForm1()
        {
            InitializeComponent();
        }

        private void TestForm1_Load(object sender, EventArgs e)
        {
            GameService.Instance.Initialize(ExecuteMode.RunTime, xnaControl1.GraphicsDevice);
            Graphics = GameService.Instance.QueryModule<GraphicsModule>();

            ContentSetData csInfo = new ContentSetData();
            csInfo.Id = GameService.Instance.QueryModule<UIDStackModule>().Take(typeof(ContentSetData));
            csInfo.Name = "Default";
            GameService.Instance.QueryModule<ContentManager>().AddContentSet(csInfo);

            ContentData fontInfo = new ContentData();
            fontInfo.Id = -1;
            fontInfo.Key = "Content/Font/Default";
            fontInfo.Type = ContentType.Font;
            GameService.Instance.QueryModule<ContentManager>().AddContent(csInfo.Id, fontInfo);

            ContentData texInfo = new ContentData();
            texInfo.Id = -1;
            texInfo.Key = "Content/Texture/Char";
            texInfo.Type = ContentType.Texture;
            GameService.Instance.QueryModule<ContentManager>().AddContent(csInfo.Id, texInfo);

            GameService.Instance.QueryModule<ContentManager>().LoadCombra(csInfo.Id);

            pos = Vector2.Zero;
            speed = new Vector2(80f, 60f);
            textSize = new Vector2(30, 150);// GameManager.Instance.GraphicsMgr.MeasureString("Default", "Hello World");
        }

        private void xnaControl1_Update(object sender, EventArgs e)
        {
            GameService.Instance.Update();

            pos += speed * GameService.Instance.FrameTimeInS;

            if (speed.X > 0 && pos.X + textSize.X >= 184)
                speed.X = -Math.Abs(speed.X);

            if (speed.Y > 0 && pos.Y + textSize.Y >= 162)
                speed.Y = -Math.Abs(speed.Y);

            if (speed.X < 0 && pos.X <= 0)
                speed.X = Math.Abs(speed.X);

            if (speed.Y < 0 && pos.Y <= 0)
                speed.Y = Math.Abs(speed.Y);
                

        }

        private void xnaControl1_Draw(object sender, EventArgs e)
        {
            GameService.Instance.QueryModule<GraphicsModule>().DrawBegin();
            int x = 0;
            //while (x < 1000)
            {
                //GameManager.Instance.GraphicsMgr.DrawString("Default", "Hello World", pos);
                // Graphics.DrawString("Default", GameManager.Instance.TimeMgr.FrameRate.ToString(), Vector2.Zero);
                Graphics.Draw("Content/Texture/Char", new Rectangle(0, 0, 100, 100));
                Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y, (int)textSize.X, (int)textSize.Y);
                Graphics.DrawLine(new Vector2(rect.Left, rect.Top), new Vector2(rect.Right, rect.Top), Color.White);
                Graphics.DrawLine(new Vector2(rect.Left, rect.Top), new Vector2(rect.Left, rect.Bottom), Color.White);
                Graphics.DrawLine(new Vector2(rect.Right, rect.Top), new Vector2(rect.Right, rect.Bottom), Color.White);
                Graphics.DrawLine(new Vector2(rect.Left, rect.Bottom), new Vector2(rect.Right, rect.Bottom), Color.White);
                x++;
            }
            GameService.Instance.QueryModule<GraphicsModule>().DrawEnd();
        }
    }
}
