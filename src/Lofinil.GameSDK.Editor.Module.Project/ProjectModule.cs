using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Lofinil.Architecture;
using Lofinil.GameSDK.Editor.App;
using Lofinil.GameSDK.Editor.Interception;
using Lofinil.GameSDK.Editor.Interception.ModuleInterface;
using Lofinil.GameSDK.Editor.Module.FormView;
using Lofinil.GameSDK.Editor.Module.Menu;
using Lofinil.GameSDK.Editor.Module.View;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor.Interception.Project.Type;

namespace Lofinil.GameSDK.Editor.Module.Project
{
    [ModuleDependency("FormViewModule")]
    public class ProjectModule : EditorModule, IProjectModule
    {
        public bool IsProjectLoaded;
        public String CurProjDir { get; set; }
        public ProjectData CurProject { get; set; }
        public IProjectView ProjectView;

        public event System.Action ProjectCreated;      // 项目创建\加载\卸载\保存消息处理
        public event System.Action ProjectLoaded;
        public event System.Action ProjectUnloaded;
        public event System.Action ProjectSaved;

        public event System.Action ItemListChanged;     // TODO 这里不应定义事件，而应侦听事件

        public List<Type> Processors;

        public ProjectModule()
        {
            IsProjectLoaded = false;
            ProjectView = null;
            CurProjDir = "";
            CurProjDir = null;
            Processors = new List<Type>();
        }

        #region 项目项注册
        public void RegistProjectItemType()
        {
        }
        #endregion 项目项注册

        #region MVC
        public void SetView(IProjectView projectView)
        {
            ProjectView = Service.QueryModule<ViewModule>().QueryView<IProjectView>();
            ItemListChanged += ProjectView.OnItemChanged;
        }
        #endregion

        #region 文件操作
        public void CreateProject(String path, String name, String author)
        {
            Directory.CreateDirectory(path);

            ProjectData proj = new ProjectData();
            proj.Author = author;
            proj.GameName = name;
            XmlSerialize.Serialize(
                Path.Combine(path, proj.GameName + EditorStatics.ProjectExt), typeof(ProjectData), proj);


            GameService.Instance.QueryModule<UIDStackModule>().New(proj.UIDStackPath);

            Directory.CreateDirectory(Path.Combine(path, proj.ResourcePath));
            // NOTE 下列目录是资源分类管理的建议目录，其实可以自由设置
            Directory.CreateDirectory(Path.Combine(path, Path.Combine(proj.ResourcePath, "Image")));
            Directory.CreateDirectory(Path.Combine(path, Path.Combine(proj.ResourcePath, "Song")));
            Directory.CreateDirectory(Path.Combine(path, Path.Combine(proj.ResourcePath, "Font")));
            Directory.CreateDirectory(Path.Combine(path, Path.Combine(proj.ResourcePath, "Trigger")));
            Directory.CreateDirectory(Path.Combine(path, Path.Combine(proj.ResourcePath, "Stage")));

            Directory.CreateDirectory(Path.Combine(path, proj.ContentPath));

            // NOTE 程序集建议目录
            Directory.CreateDirectory(Path.Combine(path, "Assembly"));
            Directory.CreateDirectory(Path.Combine(path, proj.ConfigDir));

            Directory.CreateDirectory(Path.Combine(path, proj.Thumbnail));


            // 保存IDStack
            GameService.Instance.QueryModule<UIDStackModule>().Write(Path.Combine(path, proj.UIDStackPath));

        }

        public void Read(String path)
        {
            FileInfo fi = new FileInfo(path);
            CurProjDir = fi.Directory.FullName;
            CurProject = (ProjectData)XmlSerialize.Deserialize(path, typeof(ProjectData));

            GameService.Instance.GameConfig = CurProject.CreateGameConfig();

            GameService.Instance.QueryModule<AssemblyModule>().RefreshAssembly(CurProject.AsmPathList.ToArray());

            Directory.SetCurrentDirectory(CurProjDir);

            // ACHACK 拷贝XNA的Content
            String srcDir = Path.Combine(CurProjDir, CurProject.ContentPath);
            String dstDir = Path.Combine(Application.StartupPath, CurProject.ContentPath);
            PathHelper.DirectoryCopy(srcDir, dstDir, true);

            // 载入IDStack
            GameService.Instance.QueryModule<UIDStackModule>().Read(CurProject.UIDStackPath);

            IsProjectLoaded = true;

            if(ProjectLoaded!=null)ProjectLoaded();
            if(ItemListChanged!=null)ItemListChanged();
        }

        public void Save()
        {
            write();
        }

        private void write()
        {
            GameService.Instance.QueryModule<UIDStackModule>().Write(CurProject.UIDStackPath);

            String projPath = Path.Combine(CurProjDir, CurProject.GameName + EditorStatics.ProjectExt);
            XmlSerialize.Serialize(projPath, CurProject);

            ProjectSaved();
        }

        public void UnloadProject()
        {
            // ACHACK 删除拷贝来的Content
            String tempCntDir = Path.Combine(Application.StartupPath, CurProject.ContentPath);
            Directory.Delete(tempCntDir);

            GameService.Instance.Uninitialize();

            ProjectUnloaded();
        }

        #endregion

        #region 项目项操作

        public bool IsItemIncluded(String path)
        {
            // HACK
            foreach (ProjectItem i in CurProject.ItemList)
            {
                if (i.FileName == path)
                    return true;
                if (i is ProjectItemFolder)
                {
                    foreach (ProjectItem ii in ((ProjectItemFolder)i).ItemList)
                        if (ii.FileName == path)
                            return true;
                }
            }
            return false;
        }

        public void NewStage(String path)
        {
            Stage sData = new Stage();
            sData.Id = GameService.Instance.QueryModule<UIDStackModule>().Take(typeof(Stage));
            sData.Name = Path.GetFileNameWithoutExtension(path);

            XmlSerialize.Serialize(path, sData);

            ItemListChanged();
        }

        public void ReadStage(String path)
        {
            EditorService.Instance.QueryModule<IStageModule>().ReadStage(path);
        }

        public void WriteStage(String path)
        {

        }

        #endregion 项目项操作

        #region 插件注册 [模块初始化-插件初始化->插件注册]
        public void RegistProcessor<Type>() where Type : Processor
        {
            Processors.Add(typeof(Type));
        }
        #endregion 插件注册

        // 插件处理
        public void Process(String processorName, String param, Object data)
        {
            foreach (Type t in Processors)
            {
                if (t.GetField("Name").GetValue(null).ToString() == processorName)
                {
                    t.GetMethod("Process").Invoke(null, new Object[] { data, param});
                    break;
                }
            }
        }
    }
}
