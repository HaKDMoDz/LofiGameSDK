using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Lofinil.Architecture;

namespace Lofinil.GameSDK.Engine
{
    public interface IGameComponent : IComponent
    {
    }

    // 通用的组件系统节点
    [Component(new Type[0], false, true)]
    public class GameComponent : IGameComponent
    {
        [XmlIgnore]
        public GameService Game { get; set; }

        [XmlIgnore]
        public IComponent Parent { get; set; }

        public GameComponentCollection Children { get; set; }

        IComponentContainer IComponent.Children
        {
            get { return Children; }
        }

        public bool Enabled { get; set; }

        public bool Initialized { get; set; }

        public bool Loaded { get; set; }

        public List<Trigger> Triggers;

        public GameComponent()
        {
            Children = new GameComponentCollection();
            Triggers = new List<Trigger>();
        }

        public virtual void Initialize()
        {
            foreach (GameComponent com in Children)
            {
                com.Initialize();
            }
        }

        public virtual void Load()
        {
            foreach (GameComponent com in Children)
            {
                com.Load();
            }
        }

        public virtual void Unload() { }

        public virtual void Uninitialize() { }

        IComponent IComponent.Clone()
        {
            return NullGameComponent.Instance;
        }

        public virtual GameComponent Clone()
        {
            // HACK
            return null;
        }

        public virtual IComponent ShallowCopy()
        {
            // HACK
            return null;
        }

        public virtual void Update()
        {
            foreach (GameComponent com in Children)
            {
                com.Update();
            }
        }

        public virtual void Draw()
        {
            foreach (GameComponent com in Children)
            {
                com.Draw();
            }
        }

        public virtual GameComponent GetCompByType(Type type)
        {
            foreach (GameComponent comp in Children)
            {
                if (comp.GetType() == type)
                    return comp;
            }
            return null;    // TODO [Null模式]
        }

        IComponent IComponent.Parent
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        bool IComponent.Enabled
        {
            get { throw new NotImplementedException(); }
        }

        bool IComponent.Initialized
        {
            get { throw new NotImplementedException(); }
        }

        bool IComponent.Loaded
        {
            get { throw new NotImplementedException(); }
        }

        void IComponent.Initialize()
        {
            throw new NotImplementedException();
        }

        void IComponent.Load()
        {
            throw new NotImplementedException();
        }

        void IComponent.Unload()
        {
            throw new NotImplementedException();
        }

        void IComponent.Uninitialize()
        {
            throw new NotImplementedException();
        }

        IComponent IComponent.ShallowCopy()
        {
            throw new NotImplementedException();
        }
    }


    [Component(new Type[0], false, false)]
    public class NullGameComponent : GameComponent
    {
        public static NullGameComponent Instance { get { if (inst == null) inst = new NullGameComponent(); return inst; } }

        private static NullGameComponent inst;

        public new GameService Game { get { return null; } set { } }

        public new GameComponentCollection Children { get; private set; }

        public new bool Enabled { get { return true; } set { } }

        private NullGameComponent()
        {
            Children = new GameComponentCollection();
        }

        public new void Initialize()
        {
        }

        public new void Load()
        {
        }

        public new void Update()
        {
        }

        public new void Draw()
        {
        }

        public new GameComponent GetCompByType(Type type)
        {
            return NullGameComponent.Instance;
        }


        public new GameComponent Parent { get { return NullGameComponent.Instance; } set { } }

        public new GameComponent Clone()
        {
            return NullGameComponent.Instance;
        }
    }
}