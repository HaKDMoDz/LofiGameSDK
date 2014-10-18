using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lofinil.Architecture;
using Microsoft.Xna.Framework;

namespace Lofinil.GameSDK.Engine
{
    public class StageModule : BaseModule
    {
        public GameComponent CurRole { get; set; }

        public String CurStageName { get{return CurScene.Name;} set{ CurScene.Name = value;} }

        public String CurScenePath { get { return CurScene.Path; } }    // 场景文件路径

        public Camera CurCamera { get; set; }       // 当前摄像机

        public List<ItemLayer> Layers { get { return CurScene.Layers; } }    // 层组

        public Stage CurScene { get; private set;}  // 当前场景

        // Events
        public event System.Action<Stage, Stage> StageChanging;
        public event System.Action StageChanged;

        public StageModule()
        {
            CurCamera = new Camera(50);
            CurCamera.Focus = Vector2.Zero;
        }

        public override void Initialize(IService service)
        {
            base.Initialize(service);

            CurScene = new Stage();

            StageChanging += StageManager_OnStageChanging;
            StageChanged += StageManager_OnStageChanged;
            
        }

        public override void Update()
        {
            if (CurCamera != null)
            {
                CurCamera.Update();
            }

            foreach (ItemLayer layer in Layers)
            {
                layer.Update();
            }
        }

        public override void Draw()
        {
            foreach (ItemLayer layer in Layers)
            {
                layer.Draw();
            }
        }

        public void NewScene(String path, String name)
        {
            ResetStage();
            CurScene = new Stage(name);
            CurScene.Path = path;
        }

        public void ResetStage()
        {
            CurCamera = null;

            if(CurScene != null)
                CurScene.Dispose();

            foreach (ItemLayer im in Layers)
            {
                foreach (GameComponent i in im.ItemList)
                    i.Unload();
            }
            Layers.Clear();
        }

        public void ReadStage(String path)
        {
            ResetStage();
            this.CurScene.Path = path;

            // 读取文件
            // TODO [路径整理] 在程序适当的位置保存下启动路径，并修改所有类似下面的代码
            Stage stageData = (Stage)XmlSerialize.Deserialize(path, typeof(Stage));

            StageChanging(CurScene.CreateData(), stageData);

            this.CurScene.SetData(stageData);


            if (stageData == null)
            {
                Console.WriteLine("警告：场景'{0}'载入失败", path);
                return;
            }
            this.CurStageName = stageData.Name;

            StageChanged();
        }

        // 保存场景
        public void WriteStage()
        {
            Stage curData = new Stage();
            curData.Name = CurStageName;
            curData.Layers = Layers;

            // 保存文件
            String fullPath = Path.Combine(Directory.GetCurrentDirectory(), GameService.Instance.GameConfig.ContentPath, CurScenePath + GameService.Instance.GameConfig.SceneExt);
            XmlSerialize.Serialize(fullPath, typeof(Stage), curData);
        }

        public static void WriteStage(String targetFile, Stage data)
        {
            XmlSerialize.Serialize(targetFile, data);
        }

        // TODO [恢复角色状态功能实现] 切场等情况下，角色也许会被销毁，需要适当恢复
        //private void LoadRoleState()
        //{
        //    // 从存档信息中查找此Scene的开关数据是否存在...
        //    if (PlayerMgr.Instance.playerData != null)
        //    {
        //        // 如果存在则使用存档的设定覆盖默认设定...
        //    }

        //    // 将角色放置在指定的门廊处
        //    PutRoleToProch(targetProchLabel);
        //}

        public void DeleteScene()
        {
            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), GameService.Instance.GameConfig.ContentPath, CurScenePath, CurStageName + ".scn"));

        }

        #region Handle Item

        public GameComponent[] PickItem(Vector2 worldPos)
        {
            GameComponentCollection items = GetAllItems();
            GameComponentCollection selectedItems = new GameComponentCollection();
            foreach (GameComponent item in items)
            {
                Transform trans = item.Children.QueryComponent<Transform>();
                if (trans == null) continue;

                if (Collision.Check(worldPos, trans.GetOrthoBox()))
                {
                    selectedItems.Add(item);
                    break;
                }
            }
            return selectedItems.ToArray();
        }

        public GameComponentCollection SelectItem(Rectangle worldRect, bool isFull)
        {
            GameComponentCollection items = GetAllItems();
            GameComponentCollection selectedItems = new GameComponentCollection();
            foreach (GameComponent item in items)
            {
                Transform trans = item.Children.QueryComponent<Transform>();
                if (trans == null) continue;

                if (Collision.Check(worldRect, trans.GetOrthoBox(), isFull))
                {
                    selectedItems.Add(item);
                }
            }
            return selectedItems;
        }

        public GameComponentCollection GetAllItems()
        {
            GameComponentCollection items = new GameComponentCollection();
            foreach (ItemLayer im in Layers)
            {
                foreach (GameComponent item in im.ItemList)
                    items.Add(item);
            }
            return items;
        }

        public void AddItem(String layerName, GameComponent item)
        {
            ItemLayer layer = GetLayer(layerName);
            // TODO [Null模式实现] 优化请求层不存在情况处理
            if(layer == null)
            {
                layer = new ItemLayer();
                layer.Name = layerName;
                CurScene.Layers.Add(layer);
            }
            layer.Add(item);
        }

        public void AddItem(ItemLayer layer, GameComponent item)
        {
            layer.Add(item);
        }

        public ItemLayer GetLayer(String name)
        {
            return Layers.Find(layer => layer.Name == name);
        }

        public void DeleteItem(GameComponent item)
        {
            foreach (ItemLayer itemMgr in Layers)
            {
                foreach (GameComponent i in itemMgr.ItemList)
                {
                    int itemId = itemMgr.ItemList.IndexOf(item);
                    if (itemId == -1)
                    {
                        Console.WriteLine("错误：要删除的Item不存在于列表中！");
                        return;
                    }
                    itemMgr.ItemList[itemId].Unload();
                    itemMgr.ItemList.RemoveAt(itemId);
                    return;
                }
            }

            Console.WriteLine("警告：场景管理器中不存在对指定Item的引用！");
        }

        public GameComponent GetItemByName(String name)
        {
            foreach (ItemLayer ig in Layers)
            {
                GameComponent item = IdModule.GetCompByName(name, ig.ItemList);
                if (item == NullGameComponent.Instance)
                    continue;
            }
            return NullGameComponent.Instance;
        }

        #endregion Handle Item

        #region Handle Group

        // 找到Item应属的List 注意：无法返回List引用？？
        // 若要修改List，请配合使用SetTypeList
        public ItemLayer GetGroupByName(String groupName)
        {
            foreach (ItemLayer itemGroup in Layers)
            {
                if (itemGroup.Name == groupName)
                    return itemGroup;
            }
            return null;
        }

        public ItemLayer GetContainLayer(GameComponent item)
        {
            foreach (ItemLayer layer in Layers)
                if (layer.ItemList.Contains(item))
                    return layer;
            return null;
        }

        public void DeleteGroup(String groupName)
        {
            ItemLayer itemGrp = GetGroupByName(groupName);
            if (itemGrp != null)
            {
                foreach (GameComponent item in itemGrp.ItemList)
                {
                    item.Unload();
                }
                Layers.Remove(itemGrp);
            }
        }

        public void MoveGroup(int srcId, int movement)
        {
            int step = movement > 0 ? 1 : -1;
            ItemLayer curGroup = Layers[srcId];
            for (int i = srcId + step; i != srcId + movement + step; i += step)
            {
                Layers[i - step] = Layers[i];
            }
            Layers[srcId + movement] = curGroup;
        }

        public bool GroupNameTaken(string name)
        {
            foreach (ItemLayer itemGrp in Layers)
            {
                if (itemGrp.Name == name)
                    return true;
            }
            return false;
        }

        #endregion Handle Group

        #region Layer Sort

        public void MoveToUpperLayer(GameComponent item) { MoveToUpperLayer(item, GetContainLayer(item).ItemList); }

        public void MoveToLowerLayer(GameComponent item) { MoveToLowerLayer(item, GetContainLayer(item).ItemList); }

        public void MoveToTop(GameComponent item) { MoveToTop(item, GetContainLayer(item).ItemList); }

        public void MoveToBottom(GameComponent item) { MoveToBottom(item, GetContainLayer(item).ItemList); }

        private void MoveToUpperLayer(GameComponent item, GameComponentCollection itemList)
        {
            int layer = itemList.IndexOf(item);
            int MaxLayer = itemList.Count - 1;
            if (layer == MaxLayer)
            {
                Console.WriteLine("信息：该Item已经处于顶层");
                return;
            }

            // 寻找最近一个覆盖它的Item
            GameComponent curItem = itemList[layer];

            Transform curTrans = curItem.Children.QueryComponent<Transform>();
            if ( curTrans == null)
                return;
            Rectangle curRect = curTrans.GetOrthoBox();

            GameComponent upperItem = null;
            int upLayer = -1;
            for (int i = layer + 1; i <= MaxLayer; i++)
            {
                GameComponent compItem = itemList[i];
                Transform compTrans = compItem.Children.QueryComponent<Transform>();
                if (compItem == null)
                    continue;
                Rectangle compRect = compTrans.GetOrthoBox();


                if (curRect.Intersects(compRect))
                {
                    upperItem = compItem;
                    upLayer = i;
                    break;
                }
            }

            if (upperItem == null)
            {
                Console.WriteLine("信息：该Item未被任Item覆盖");
                return;
            }

            // 移动
            MoveTo(layer, upLayer, itemList);

            //SetTypeList(itemList);
        }

        private void MoveToLowerLayer(GameComponent item, GameComponentCollection itemList)
        {
            int layer = itemList.IndexOf(item);
            if (layer == 0)
            {
                Console.WriteLine("信息：该Item已经处于底层");
                return;
            }

            // 寻找最近一个被覆盖的Item
            GameComponent curItem = itemList[layer];
            Transform curTrans = curItem.Children.QueryComponent<Transform>();
            if (curTrans == null)
                return;
            Rectangle curRect = curTrans.GetOrthoBox();

            GameComponent lowerItem = null;
            int lowerLayer = -1;
            for (int i = layer - 1; i >= 0; i--)
            {
                GameComponent compItem = itemList[i];
                Transform compTrans = item.Children.QueryComponent<Transform>();
                if (compItem == null)
                    continue;
                Rectangle compRect = compTrans.GetOrthoBox();


                if (curRect.Intersects(compRect))
                {
                    lowerItem = compItem;
                    lowerLayer = i;
                    break;
                }
            }

            if (lowerItem == null)
            {
                Console.WriteLine("信息：该Item未覆盖任何其他Item");
                return;
            }

            // 移动
            MoveTo(layer, lowerLayer, itemList);

            //SetTypeList(itemList);
        }

        private void MoveTo(int srcLayer, int destLayer, GameComponentCollection itemList)
        {
            int MaxLayer = itemList.Count - 1;
            if (srcLayer > MaxLayer || destLayer > MaxLayer)
            {
                Console.WriteLine("错误：指定层级不存在于itemList当中！");
                return;
            }

            // 层级和Id是对应的 layer0 -- id0
            int srcId = srcLayer;
            int destId = destLayer;
            // sort
            GameComponent srcItem = itemList[srcId];
            if (srcLayer < destLayer)
            {
                for (int i = srcId + 1; i <= destId; i++)
                {
                    itemList[i - 1] = itemList[i];
                }
            }
            else if (srcLayer > destLayer)
            {
                for (int i = srcId - 1; i >= destId; i--)
                {
                    itemList[i + 1] = itemList[i];
                }
            }
            itemList[destId] = srcItem;
        }

        private void MoveToTop(GameComponent item, GameComponentCollection itemList)
        {
            int layer = itemList.IndexOf(item);
            int MaxLayer = itemList.Count - 1;
            if (layer > MaxLayer)
            {
                Console.WriteLine("错误：指定层级不存在于itemList当中！");
                return;
            }

            GameComponent srcItem = itemList[layer];
            for (int i = layer + 1; i <= itemList.Count - 1; i++)
            {
                itemList[i - 1] = itemList[i];
            }
            itemList[MaxLayer] = srcItem;

            //SetTypeList(itemList);
        }

        private void MoveToBottom(GameComponent item, GameComponentCollection itemList)
        {
            int layer = itemList.IndexOf(item);
            int MaxLayer = itemList.Count - 1;
            if (layer > MaxLayer)
            {
                Console.WriteLine("错误：指定层级不存在于itemList当中！");
                return;
            }

            GameComponent srcItem = itemList[layer];
            for (int i = layer - 1; i >= 0; i--)
            {
                itemList[i + 1] = itemList[i];
            }
            itemList[0] = srcItem;

            //SetTypeList(itemList);
        }

        #endregion Layer Sort

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public void StageManager_OnStageChanging(Stage oldData, Stage newData)
        {

        }

        public void StageManager_OnStageChanged()
        {

        }
    }
}