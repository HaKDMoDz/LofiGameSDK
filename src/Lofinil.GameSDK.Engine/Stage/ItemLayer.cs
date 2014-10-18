using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lofinil.GameSDK.Engine
{
    public class ItemLayerData
    {
        public String Name;

        public GameComponentCollection ItemList;
    }

    // 该类虽然有Update和Draw等，但是依存于Scene，功能已特化，不能成为独立接口组件
    public class ItemLayer
    {
        public String Name;

        public GameComponentCollection ItemList;

        private GameComponentCollection deleteItems = new GameComponentCollection();
        
        public ItemLayer()
        {
            ItemList = new GameComponentCollection();
        }

        public void SetData(ItemLayerData data)
        {
            this.Name = data.Name;
            this.ItemList = data.ItemList;
        }

        public void Update()
        {
            foreach (GameComponent i in ItemList)
            {
                i.Update();
            }

            foreach (GameComponent item in deleteItems)
            {
                item.Unload();
                ItemList.Remove(item);
            }
            deleteItems.Clear();
        }


        public void Draw()
        {
            foreach (GameComponent item in ItemList)
            {
                item.Draw();
                    //GameManager.Instance.SceneMgr.CurrentCamera, 0, null,
                    //null, null);
            }
        }

        // NOTE 因为ItemGroup实际上只负责层次，颜色叠加不属其职责范围，这个函数应属编辑器函数
        public void Draw(Color color)
        {
            foreach (GameComponent item in ItemList)
            {
                item.Draw();
                   // GameManager.Instance.SceneMgr.CurrentCamera, 0, null,
                   // null, color);
            }
        }

        public virtual void Add(GameComponent item)
        {
            ItemList.Add(item);
        }

        public virtual void Remove(GameComponent item)
        {
            ItemList.Remove(item);
        }

        public virtual void Delete(GameComponent item)
        {
            deleteItems.Add(item);
        }

        public virtual void Dispose()
        {

        }
    }
}
