using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Lofinil.GameSDK.Engine
{
    public class ContentSet
    {
        public Microsoft.Xna.Framework.Content.ContentManager ContentMgr;

        private GameService game;

        public int Id;

        public String Name;

        public List<Content> ContentList;

        public bool Loaded { get; protected set; }

        public ContentSet()
        {
            ContentList = new List<Content>();
        }

        public ContentSet(ContentSetData data)
        {
            this.Id = data.Id;
            this.Name = data.Name;

            ContentList = new List<Content>();
            foreach (ContentData ri in data.ContentDataList)
            {
                Content c = new Content(ri);
                ContentList.Add(c);
            }
        }

        public void Initialize(GameService game)
        {
            this.game = game;
            ContentMgr = new Microsoft.Xna.Framework.Content.ContentManager(game.Services);
        }

        public Object Load(ContentData data)
        {
            Content c = new Content(data);
            c.Load(ContentMgr);
            ContentList.Add(c);
            return c.Combra;
        }

        #region Combra

        public void Load()
        {
            foreach (Content c in ContentList)
                c.Load(ContentMgr);

            Loaded = true;
        }

        public void Unload()
        {
            foreach (Content c in ContentList)
                c.Unload();

            ContentMgr.Unload();

            Loaded = false;
        }

        #endregion Combra

        // NOTE Add方法自动判断是否马上加载，而Load只能在运行时使用，要立即加载
        public void Add(ContentData data)
        {
            Content c = new Content(data);
            if (Loaded)
                c.Load(ContentMgr);
            ContentList.Add(c);
        }

        public Object Get(ContentType type, String key)
        {
            Content content = ContentList.Find(c => c.Type == type && c.Key == key);
            return content.Combra;
        }

        public Object Get(ContentType type, int id)
        {
            Content content = ContentList.Find(c => c.Type == type && c.Id == id);
            return content.Combra;
        }

        public void Remove(ContentType type, int id)
        {
            Content content = ContentList.Find(c => c.Type == type && c.Id == id);
            ContentList.Remove(content);
        }
    }


    public class NullContentSet : ContentSet
    {
        public static NullContentSet Instance { get { if (instance == null) instance = new NullContentSet(); return instance; } }
        private static NullContentSet instance;
        private NullContentSet()
        {
            ContentMgr = null;
            Id = -1;
            Name = "";
            ContentList = new List<Content>();
            Loaded = false;

        }

        public new void Load()
        {

        }

        public new void Load(ContentData data) { }

        public new void Add(ContentData data) { }

        public new Content Get(ContentType type, String key) { return NullContent.Instance; }

        public new Content Get(ContentType type, int id) { return NullContent.Instance; }

        public new void Remove(ContentType type, int id) { }

        public new void Unload() { }

    }
}
