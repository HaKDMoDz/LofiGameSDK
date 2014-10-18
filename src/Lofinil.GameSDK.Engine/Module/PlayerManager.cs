using System;
using System.IO;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Lofinil.GameSDK.Engine
{
    public class PlayerModule : BaseModule
    {
        #region Constructor

        public PlayerModule()
        {
        }

        #endregion Constructor

        #region Variables

        // NOTE 目前只支持单玩家存档
        public PlayerData playerData;

        #endregion Variables

        #region Save & Load

        // 重建档案
        public void NewPlayerData()
        {
            playerData = new PlayerData();
            // TODO [玩家名称支持输入或隐藏] 这里仅把新玩家名字设为随机数字，可能重复
            playerData.PlayerName = GameService.GetRandomInt(0, 9999).ToString(); 
        }

        public void ReadProfile(String userName)
        {
            StorageContainer sContainer = LE_File.GetStorageContainer();
            Stream fStream = sContainer.OpenFile(userName + ".sav", FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerialize.Deserialize(fStream, typeof(PlayerData));
        }

        public void WriteProfile()
        {
            // TODO [完善存档系统] 应从场景变更更新Profile，并且将Role类整体序列化进来
            playerData.Position = GameService.RolePosition;
            playerData.SceneName = GameService.SceneName;

            StorageContainer sContainer = LE_File.GetStorageContainer();
            Stream fStream = sContainer.CreateFile(playerData.PlayerName + ".sav");
            XmlSerialize.Serialize(fStream, typeof(PlayerData), playerData);
        }

        // TODO [场景变脏记录] 用于支持存档优化
        public bool SceneInfluenced(String sceneName)
        {
            return true;
        }

        #endregion Save & Load

        public void AddSceneSaveEntry(String sceneName, PlayerData.SceneChange.ItemPropertyChange itemPropertyChange)
        {
            PlayerData.SceneChange sceneChange = null;

            foreach (PlayerData.SceneChange sc in playerData.SceneChangeList)
            {
                if (sc.SceneName == sceneName)
                {
                    sceneChange = sc;
                }
            }
            if (sceneChange == null)
            {
                sceneChange = new PlayerData.SceneChange();
                sceneChange.SceneName = sceneName;
                playerData.SceneChangeList.Add(sceneChange);
            }

            bool findItemParamChange = false;
            // 修改
            foreach (PlayerData.SceneChange.ItemPropertyChange ipc in sceneChange.ItemChangeList)
            {
                if (itemPropertyChange.ItemLabel == ipc.ItemLabel && itemPropertyChange.PropertyName == ipc.PropertyName)
                {
                    findItemParamChange = true;
                    ipc.Value = itemPropertyChange.Value;
                }
            }
            // 不存在则添加
            if (!findItemParamChange)
            {
                sceneChange.ItemChangeList.Add(itemPropertyChange);
            }
        }

        public bool CheckEventTriggered(String sceneName)
        {
            bool dramaTriggered = false;
            foreach (PlayerData.SceneChange sc in playerData.SceneChangeList)
            {
                if (sc.SceneName == sceneName && sc.DramaTriggered)
                    dramaTriggered = true;
            }
            return dramaTriggered;
        }

        public void TriggerEvent(String sceneName)
        {
            foreach (PlayerData.SceneChange sc in playerData.SceneChangeList)
            {
                if (sc.SceneName == sceneName)
                    sc.DramaTriggered = true;
            }
        }

        public void VisitScene(String sceneName)
        {
            PlayerData.SceneChange findSceneChange = null;
            foreach (PlayerData.SceneChange sc in playerData.SceneChangeList)
            {
                if (sceneName == sc.SceneName)
                {
                    findSceneChange = sc;
                    break;
                }
            }
            if (findSceneChange == null)
            {
                Console.WriteLine("信息：首次进入场景" + sceneName);
                PlayerData.SceneChange sceneChange = new PlayerData.SceneChange();
                sceneChange.SceneName = sceneName;
                playerData.SceneChangeList.Add(sceneChange);
            }
            else
            {
                // 覆盖场景档案信息

                #region TODO 待更新

                //foreach (PlayerData.SceneChange.ItemParamChange ipc in findSceneChange.ItemChangeList)
                //{
                //    switch (ipc.ItemType)
                //    {
                //        case GlobalItemName.Obstacle:
                //            foreach (Obstacle item in SceneMgr.Instance.obstacleMgr.Items)
                //            {
                //                if (item.Label == ipc.ItemLabel)
                //                {
                //                    // item.SetValueByGlobalName(ipc.ParamName, ipc.Value);
                //                }
                //            }
                //            break;
                //        default:
                //            Console.WriteLine("警告：Item属性修改信息的Case不存在,TypeName:"+ipc.ItemType.ToString());
                //            break;
                //    }
                //}

                #endregion TODO 待更新
            }
        }


        // TODO [属客户代码功能|过时] 获取目录中的存档文件列表函数不应放在资源中
        public List<String> GetPlayerNames()
        {
            List<string> nameList = new List<string>();

            StorageDevice sDevice = Storage.GetStorageDevice();
            if ((sDevice != null) && sDevice.IsConnected)
            {
                // Wait for the WaitHandle to become signaled. ???
                IAsyncResult result =
                    sDevice.BeginOpenContainer("SDF", null, null);

                result.AsyncWaitHandle.WaitOne();

                using (StorageContainer sContainter = sDevice.EndOpenContainer(result))
                {
                    foreach (String item in sContainter.GetFileNames())
                    {
                        FileInfo fi = new FileInfo(item);
                        if (fi.Extension == ".sav")
                        {
                            nameList.Add(fi.Name.Split('.')[0]);
                        }
                    }
                }
            }
            return nameList;
        }

        #region Unit Test

        //public static void UnitTest()
        //{
        //    TestGame.StartTest("存档测试：F1-存档 F2-读档 门连接两个Scene",
        //        null,
        //        delegate
        //        {
        //            PlayerMgr.Instance.LoadProfile("TestUser");
        //        },
        //        delegate
        //        {
        //            if (Keyboard.isKeyJustPress(Keys.F1))
        //            {
        //                PlayerMgr.Instance.SaveProfile();
        //            }
        //            if (Keyboard.isKeyJustPress(Keys.F2))
        //            {
        //                PlayerMgr.Instance.LoadProfile("TestUser");
        //            }
        //        },
        //        delegate
        //        {
        //        }
        //    );
        //}

        #endregion Unit Test
    }
}