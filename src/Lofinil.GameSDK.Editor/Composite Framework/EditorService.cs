using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using Lofinil.GameSDK.Engine;
using Lofinil.Architecture;
using System.Reflection;
using Lofinil.GameSDK.Editor.Composite_Framework;

namespace Lofinil.GameSDK.Editor
{
    public class EditorService : IService
    {
        public static EditorService Instance 
        { 
            get { if (instance == null) instance = new EditorService(); return instance; } 
        }

        private static EditorService instance;

        public GraphicsModule graphics;
        public PlayerModule PlayerMgr;
        public StageModule SceneMgr;

        public List<EditorModule> ModuleList;
        public List<IEditorPlugin> PluginList;

        public bool Initialized{get; private set;}

        public String EditorDir;

        public EditorService()
        {
            ModuleList = new List<EditorModule>();
            PluginList = new List<IEditorPlugin>();
        }

        public virtual void Initialize()
        {
            if (!this.Initialized)
            {
                GameService.Instance.RegistModule(new ActionStack());
                GameService.Instance.RegistModule(new GraphicsModule());
                GameService.Instance.RegistModule(new SoundModule());
                GameService.Instance.RegistModule(new TimeModule());
                GameService.Instance.RegistModule(new ContentModule());
                GameService.Instance.RegistModule(new PlayerModule());
                GameService.Instance.RegistModule(new StageModule());
                GameService.Instance.RegistModule(new TriggerManager());
                GameService.Instance.RegistModule(new InputModule());
                GameService.Instance.RegistModule(new LE_Random());
                GameService.Instance.RegistModule(new AssemblyModule());
                GameService.Instance.RegistModule(new UIDStackModule());

                // GameService.Instance.Initialize(ExecuteMode.DesignTime, gd);
                Application.Idle += delegate
                {
                    //GameService.Instance.Update();
                };

                foreach (IModule mod in ModuleList)
                {
                    mod.Initialize(this);
                }

                Assembly[] ass = AppDomain.CurrentDomain.GetAssemblies();

                foreach (IEditorPlugin plugin in PluginList)
                    plugin.Initialize();

                EditorDir = Application.StartupPath;

                Initialized = true;
            }

        }

        public void RegistModule(IModule mod)
        {
            ModuleList.Add((EditorModule)mod);
        }

        public void RegistModule(IModule mod, object[] args)
        {
            ModuleList.Add((EditorModule)mod);
        }
        
        // UNDONE 从文件名加载模块
        public void RegistModule(String name)
        {
            // 在程序目录下搜索包含模块名称的动态库，并使用LoadFrom加载
            String[] files = Directory.GetFiles(Application.StartupPath, "*"+name+"*.dll", SearchOption.AllDirectories);
            if (files.Count() > 0)
            {
                Assembly asm = Assembly.LoadFrom(files[0]);
                Type[] types = asm.GetTypes();
                Type modType = types.FirstOrDefault(t=>t.IsSubclassOf(typeof(EditorModule)));
                if (modType != null)
                {
                    EditorModule mod = (EditorModule)modType.GetConstructor(Type.EmptyTypes).Invoke(null);
                    ModuleList.Add(mod);

                    mod.Load();

                    if (this.Initialized)
                        mod.Initialize(this);
                }
            }
        }

        public void LoadAllPlugin()
        {
            // 搜索Plugin目录
            // HACK
            String pluginPath = Path.Combine(Application.StartupPath, "Plugin");
            String[] files = Directory.GetFiles(pluginPath, "*Plugin*.dll", SearchOption.AllDirectories);
            foreach (String file in files)
            {
                Assembly asm = Assembly.LoadFrom(file);
                Type[] types = asm.GetTypes();
                foreach(Type type in types)
                {
                    if(type.GetInterface("IEditorPlugin", false) != null)   // HACK
                    {
                        IEditorPlugin plugin = (IEditorPlugin)type.GetConstructor(Type.EmptyTypes).Invoke(null);
                        PluginList.Add(plugin);

                        if(this.Initialized)
                            plugin.Initialize();
                    }
                }
            }
        }

        public T QueryModule<T>(object[] args)
        {
            foreach (IModule mod in ModuleList)
            {
                if (mod is T)
                    return (T)mod;
            }
            return default(T);
        }

        public T QueryModule<T>()
        {
            foreach (IModule mod in ModuleList)
            {
                if (mod is T)
                    return (T)mod;
            }
            return default(T);
        }

        public IModule QueryModule(String typeName)
        {
            return null;
        }

    }
}
