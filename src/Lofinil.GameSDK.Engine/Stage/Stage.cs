using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Lofinil.GameSDK.Engine
{
    // 场景数据类
    public class Stage    // 和预计不同的是，因为Scene包含了自己的资源管理器，必须自行初始化，所以成为组件
    {
        public int Id;

        public List<int> ContentSetIdList;

        public String Name = "DefaultName";

        public String Path = ""; // 文件路径

        public List<ItemLayer> Layers = new List<ItemLayer>();

        // 运行时 反序列化
        public Stage()
        {
            ContentSetIdList = new List<int>();
        }

        // 设计时 
        public Stage(String name)
        {
            Name = name;

            Initialize();
        }

        public void Initialize()
        {
        }

        // 运行时 预载资源
        public void Load()
        {

        }

        public void Dispose()
        {
            foreach (ItemLayer layer in Layers)
                layer.Dispose();
        }

        public void Update()
        {
        }

        public void Draw()
        {
        }

        public void SetData(Stage stageData)
        {
            this.Id = stageData.Id;
            this.Name = stageData.Name;
            this.Layers = stageData.Layers;
            this.ContentSetIdList = stageData.ContentSetIdList;
        }

        public Stage CreateData()
        {
            Stage data = new Stage();
            data.Id = Id;
            data.ContentSetIdList = ContentSetIdList;
            data.Layers = Layers;
            return data;
        }

        public Stage GetData()
        {
            return CreateData();
        }
    }
}