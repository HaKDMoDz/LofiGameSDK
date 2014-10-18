using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.Architecture;

namespace Lofinil.GameSDK.Engine
{
    public class BaseModule : IGameModule
    {
        public GameService GameService{get; protected set;}

        public IService Service { get { return GameService; } }

        public bool Enabled { get; set; }

        public bool Initialized { get; protected set; }

        public bool Loaded { get; protected set; }

        public virtual void Initialize(IService service)
        {
            GameService = GameService.Instance;
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

        public virtual void Uninitialize()
        {
            GameService = null;
            Initialized = false;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
        }

        public virtual void Dispose()
        {
        }

    }
}
