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

namespace Lofinil.GameSDK.Editor
{
    public class EditorService : IService
    {
        public static EditorService Instance 
        { 
            get { if (instance == null) instance = new EditorService(); return instance; } 
        }

        private static EditorService instance;

        public List<IModule> ModuleList;

        public bool Initialized{get; private set;}

        public String EditorDir;

        public EditorService()
        {
            ModuleList = new List<IModule>();

        }

        public void Initialize(GraphicsDevice gd)
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

                GameService.Instance.Initialize(ExecuteMode.DesignTime, gd);
                Application.Idle += delegate
                {
                    GameService.Instance.Update();
                };

                foreach (IModule mod in ModuleList)
                {
                    mod.Initialize(this);
                }

                EditorDir = Application.StartupPath;

                Initialized = true;
            }

        }

        public void RegistModule(IModule mod)
        {
            ModuleList.Add(mod);
        }

        public void RegistModule(IModule mod, object[] args)
        {
            ModuleList.Add(mod);
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
    }
}
