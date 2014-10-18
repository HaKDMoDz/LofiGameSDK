using System;
using System.Collections.Generic;
using System.IO;
using Lofinil.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace Lofinil.GameSDK.Engine
{
    public class ContentModule : BaseModule
    {
        public List<ContentSet> ContentSetList; // 命名资源集

        public bool AllowMissLoad;              // 在发现资源未预加载时，是否单独加载

        public ContentModule()
        {
            ContentSetList = new List<ContentSet>();
            AllowMissLoad = true;
        }

        public override void Initialize(IService service)
        {
            base.Initialize(service);

            foreach (ContentSet cs in ContentSetList)
            {
                cs.Initialize(GameService);
            }
        }

        #region 文件操作

        // 设计时 打开项目/场景时，加载资源导入集中的资源
        // 运行时 执行游戏时，加载资源导入集中的资源
        public void ReadContentSet(String filePath)
        {
            ContentSetData data = (ContentSetData)XmlSerialize.Deserialize(filePath, typeof(ContentSetData));
            AddContentSet(data);
        }

        #endregion 文件操作

        #region 一级子项 ContentSet

        public void AddContentSet(ContentSetData data)
        {
            // 若有同名资源集，则先将其卸载
            ContentSet existed = ContentSetList.Find(s => s.Id == data.Id);
            if (existed != null)
            {
                return;
            }

            ContentSet newSet = new ContentSet(data);
            newSet.ContentMgr = new Microsoft.Xna.Framework.Content.ContentManager(GameService.Instance.Services);

            ContentSetList.Add(newSet);
        }

        public void LoadCombra(int contentSetId)
        {
            ContentSet cs = GetContentSet(contentSetId);
            cs.Load();
        }

        public ContentSet GetContentSet(int contentSetId)
        {
            ContentSet set = ContentSetList.Find(s => s.Id == contentSetId);
            if (set != null)
                return set;
            return NullContentSet.Instance;
        }

        #endregion 一级子项 ContentSet

        #region 二级子项 Content
        public void AddContent(int id, ContentData data)
        {
            ContentSet cs = ContentSetList.Find(s => s.Id == id);
            cs.Add(data);
        }

        // NOTE 从已有资源中搜索的最终运行时API函数
        public Object GetContent(ContentType type, String key)
        {
            foreach (ContentSet cs in ContentSetList)
            {
                Object data = cs.Get(type, key);
                if (data != null)
                    return data;
            }
            return null;
        }

        public Object GetContent(ContentType type, int id)
        {
            foreach (ContentSet cs in ContentSetList)
            {
                Object data = cs.Get(type, id);
                if (data != null)
                    return data;
            }
            return null;
        }
        #endregion 二级子项 Content

        #region Combra

        public void LoadContentSet(int contentSetId)
        {
            ContentSetList.Find(s => s.Id == contentSetId).Load();
        }

        public void UnloadContentSet(int contentSetId)
        {
            ContentSetList.Find(s => s.Id == contentSetId).Unload();
        }

        #endregion Combra
    }
}