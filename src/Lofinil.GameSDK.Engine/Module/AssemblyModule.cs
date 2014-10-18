using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using Lofinil.Architecture;

namespace Lofinil.GameSDK.Engine
{
    // 模块数据
    public class ModuleInfo
    {
        public Type ModuleType;

        public List<Type> Depends;

        public ModuleInfo(Type type)
        {
            ModuleType = type;
            Depends = new List<Type>();
        }

        public void BuildDepends()
        {
            Depends.AddRange(NETFramework.GetModuleDepTypes(ModuleType));
        }
    }

    // 组件数据
    public class CompInfo
    {
        public Type CompType;

        public List<Type> Parents;

        public bool InEditor;

        public bool CanStore;

        public CompInfo(Type type)
        {
            CompType = type;
            ComponentAttribute compAttr = NETFramework.GetCompAttr(type);
            InEditor = compAttr.InEditor;
            CanStore = compAttr.CanStore;
            Parents = new List<Type>();
        }

        public void BuildDepends()
        {
            Parents.AddRange(NETFramework.GetCompParentTypes(CompType));
        }
    }

    // 程序集数据
    public class AsmInfo
    {
        public Assembly Assembly;

        public List<ModuleInfo> ModInfoList;

        public List<CompInfo> CompInfoList;

        public AsmInfo(Assembly asm)
        {
            if (asm == null)
                throw new ArgumentNullException("asm", "程序集参数不能为Null");
            Assembly = asm;

            ModInfoList = new List<ModuleInfo>();
            CompInfoList = new List<CompInfo>();
            filterType();
        }

        private void filterType()
        {
            Type[] types = Assembly.GetTypes();

            foreach (Type t in types)
            {
                if (NETFramework.IsComponent(t, true))
                {
                    CompInfoList.Add(new CompInfo(t));
                }
                else if (NETFramework.IsModule(t))
                {
                    ModInfoList.Add(new ModuleInfo(t));
                }
            }
        }

        public void BuildDepends()
        {
            foreach (ModuleInfo mi in ModInfoList)
            {
                mi.BuildDepends();
            }
            foreach (CompInfo ci in CompInfoList)
            {
                ci.BuildDepends();
            }
        }

        public CompInfo GetComponentInfo(Type t)
        {
            return CompInfoList.Find(i => i.CompType == t);
        }
    }

    // Phase-1 loadAssembly -> 完成类型筛选
    // Phase-2 依赖性分析 在已经筛选出的类型之间建立联系
    public class AssemblyModule : BaseModule
    {
        public List<AsmInfo> AsmInfoList;

        // 用于派生体系容器的序列化支持
        public XmlAttributeOverrides SharedXmlAttrOverrides;

        public event Action<Assembly> AssemblyLoaded;

        public AssemblyModule()
        {
            AsmInfoList = new List<AsmInfo>();
        }

        public override void Initialize(IService service)
        {
            base.Initialize(service);

            AssemblyLoaded += new Action<Assembly>(AssemblyModule_OnAssemblyLoaded);

            RefreshAssembly();
        }

        public void RefreshAssembly()
        {
            if (GameService.Instance.GameConfig != null)
            {
                String[] paths = GameService.Instance.GameConfig.AsmPathList.ToArray();

                RefreshAssembly(paths);
            }
        }

        public void RefreshAssembly(String[] asmPaths)
        {
            loadAssembly(asmPaths);
            buildDepend();
            serializeSupport();
        }

        private void loadAssembly(String[] asmPaths)
        {
            AsmInfoList.Clear();

            // 添加引擎程序集
            AsmInfo ai = new AsmInfo(Assembly.GetExecutingAssembly());
            AsmInfoList.Add(ai);

            // 添加导入程序集
            foreach (String path in asmPaths)
            {
                if (File.Exists(path))
                {
                    Assembly a = Assembly.LoadFrom(path);
                    ai = new AsmInfo(a);
                    AsmInfoList.Add(ai);
                    AssemblyLoaded(a);
                }
            }
        }

        private void buildDepend()
        {
            foreach (AsmInfo ai in AsmInfoList)
            {
                ai.BuildDepends();
            }
        }

        private void serializeSupport()
        {
            SharedXmlAttrOverrides = new XmlAttributeOverrides();

            // 组件派生体系容器
            XmlAttributes compAttrs = new XmlAttributes();

            foreach (AsmInfo ai in AsmInfoList)
            {
                foreach (CompInfo ci in ai.CompInfoList)
                {
                    if(ci.CanStore)
                        compAttrs.XmlElements.Add(new XmlElementAttribute(ci.CompType));
                }
            }

            SharedXmlAttrOverrides.Add(typeof(GameComponentCollection), "CompList", compAttrs);
        }

        public CompInfo GetComponentInfo(Type t)
        {
            foreach (AsmInfo ai in AsmInfoList)
            {
                CompInfo ci = ai.GetComponentInfo(t);
                if (ci != null)
                    return ci;
            }
            return null;
        }

        protected void AssemblyModule_OnAssemblyLoaded(Assembly asm)
        { 
        }
    }
}
