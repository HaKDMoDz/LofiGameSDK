using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Lofinil.GameSDK.Engine;
using Lofinil.Architecture;
using Lofinil.GameSDK.Editor.App;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor.Interception;
using Lofinil.GameSDK.Editor.Interception.ModuleInterface;
using Lofinil.GameSDK.Editor.Module.Menu;
using Lofinil.GameSDK.Editor.Module.Project;

namespace Lofinil.GameSDK.Editor
{
    // 导入资源管理工具
    [ModuleDependency("FormViewModule")]
    public class ResourceSetModule : EditorModule, ITextureSetModule, IResourceSetModule
    {
        public ResourceSetData CurResDataSet;
        public List<ResourceSetData> ActiveResDataSet;

        public List<ResourceSetData> ResInfoSetList;

        public ResourceSetModule()
        {
            ResInfoSetList = new List<ResourceSetData>();
            ActiveResDataSet = new List<ResourceSetData>();
        }

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            EditorService.Instance.QueryModule<ProjectModule>(null).ProjectLoaded += OnProjectLoaded;

            EditorService.Instance.QueryModule<ProjectModule>().ProjectSaved += OnProjectSaved;

        }

        #region 文件操作

        public void New(String path)
        {
            ResourceSetData set = new ResourceSetData();
            set.Id = GameService.Instance.QueryModule<UIDStackModule>().Take(typeof(ResourceSetData));
            XmlSerialize.Serialize(path, set);
        }

        public int Read(string path)
        {
            ResourceSetData set = (ResourceSetData)XmlSerialize.Deserialize(path, typeof(ResourceSetData));
            if (GetResourceSetData(set.Id) != null)
            {
                return -1;
            }
            ResInfoSetList.Add(set);

            GameService.Instance.QueryModule<ContentModule>().AddContentSet(set.CreateContentSetData());

            return set.Id;
        }

        public void Write(String path)
        {
            throw new NotImplementedException();
        }

        public void Delete(String path)
        {
            ResourceSetData set = 
                (ResourceSetData)XmlSerialize.Deserialize(path, typeof(ResourceSetData));
            GameService.Instance.QueryModule<UIDStackModule>().Recycle(typeof(ResourceSetData), set.Id);

            File.Delete(path);
        }

        #endregion 文件操作

        #region 项目消息处理

        public void OnProjectLoaded()
        {
            String comResImpCfg = Path.Combine(
                EditorService.Instance.QueryModule<ProjectModule>(null).CurProjDir,
                EditorService.Instance.QueryModule<ProjectModule>(null).CurProject.CommonResConfig);
        }

        public void OnProjectSaved()
        {
            foreach (ResourceSetData set in ResInfoSetList)
            {
                XmlSerialize.Serialize(set.Path, set);
            }
        }

        public void OnProjectUnloaded()
        {
            foreach (ResourceSetData set in ResInfoSetList)
            {
                GameService.Instance.QueryModule<ContentModule>().UnloadContentSet(set.Id);
            }
        }

        #endregion 项目消息处理

        #region 一级子项 ResourceSet

        public ResourceSetData GetResourceSetData(int id)
        {
            return ResInfoSetList.Find(s => s.Id == id);
        }

        public ResourceSetData GetResourceSetData(String name)
        {
            return ResInfoSetList.Find(s => s.Name == name);
        }

        public void CreateResourceSetData(string name)
        {
            ResourceSetData data = new ResourceSetData();
            data.Name = name;
            data.Id = GameService.Instance.QueryModule<UIDStackModule>().Take(typeof(ResourceSetData));
            ResInfoSetList.Add(data);
        }

        #endregion 一级子项 ResourceSet

        #region 二级子项 Resource

        public void AddResourceData(int setId, ResourceData data)
        {
            GetResourceSetData(setId).Add(data);
        }

        public ResourceData GetResourceData(ContentType type, int id)
        {
            foreach (ResourceSetData set in ResInfoSetList)
            {
                ResourceData data = set.ResourceDataList.Find(s => s.ContentId == id && s.ContentType == type);
                if (data != null)
                    return data;
            }
            return null;
        }
        #endregion 二级子项 Resource

        #region Combra操作

        public void Load(int id)
        {
            throw new NotImplementedException();
        }

        public void Unload(int id)
        {
            throw new NotImplementedException();
        }

        #endregion Combra操作

        #region 场景消息处理

        public void OnStageChanging(Stage oldStage, Stage newStage)
        {
            // 卸载无效的资源集
            foreach (int setId in oldStage.ContentSetIdList)
            {
                if (!newStage.ContentSetIdList.Contains(setId))
                    Unload(setId);
            }

            // 仅加载新增的资源集
            foreach (int setId in newStage.ContentSetIdList)
            {
                if (!oldStage.ContentSetIdList.Contains(setId))
                    GameService.Instance.QueryModule<ContentModule>().LoadCombra(setId);
                    Load(setId);
            }
        }
        #endregion

        #region Active & Unaction

        public void Active(int id)
        {
            ResourceSetData set = ResInfoSetList.Find(s => s.Id == id);
            ActiveResDataSet.Add(set);
        }

        #endregion Active & Unaction

    }
}
