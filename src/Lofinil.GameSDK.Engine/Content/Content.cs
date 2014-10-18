using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ContentManager = Microsoft.Xna.Framework.Content.ContentManager;

namespace Lofinil.GameSDK.Engine
{
    public class Content
    {
        public int Id;
        public String Key;
        public ContentType Type;

        public Object Combra;

        public Content() { }

        public Content(ContentData data)
        {
            Id = data.Id;
            Key = data.Key;
            Type = data.Type;

            Combra = null;
        }

        public Object Load(Microsoft.Xna.Framework.Content.ContentManager cm)
        {
            Combra = XNAContent.LoadContent(cm, Type, Key);
            return Combra;
        }

        public void Unload()
        {
            // NOTE XNA不支持单个资源的卸载
            // Cannot do anything here...
        }

        public ContentData CreateData()
        {
            ContentData data = new ContentData();
            data.Id = this.Id;
            data.Key = this.Key;
            data.Type = this.Type;
            return data;
        }

    }

    public class NullContent : Content
    {
        public static NullContent Instance
        {
            get { if (instance == null)instance = new NullContent(); return instance; }
        }
        private static NullContent instance;
        private NullContent() { }

        public new int Id { get { return -1; } set { } }
        public new String Key { get { return ""; } set { } }
        public new ContentType Type { get { return ContentType.None; } set { } }

        public new Object Load(Microsoft.Xna.Framework.Content.ContentManager cm) { return null; }

        public new void Unload() { }

        public new ContentData CreateData() { return null; }
    }
}
