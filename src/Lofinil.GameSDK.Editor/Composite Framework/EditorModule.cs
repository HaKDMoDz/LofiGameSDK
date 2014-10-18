using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.Architecture;

namespace Lofinil.GameSDK.Editor
{
    public class EditorModule : IModule
    {
        IService IModule.Service{get { return Service; }}

        public EditorService Service { get; set; }

        public bool Enabled { get; set; }

        public bool Initialized { get; protected set; }

        public bool Loaded { get; protected set; }

        void IModule.Initialize(IService service)
        {
            if(service is EditorService)
                Initialize((EditorService)service);
        }

        public virtual void Initialize(EditorService service)
        {
            Service = service;
            Initialized = true;
        }

        public virtual void Load()
        {
            Loaded = true;
        }

        public virtual void Unload()
        {
            Loaded = false;
        }

        public void Uninitialize()
        {
            Initialized = true;
        }
    }
}
