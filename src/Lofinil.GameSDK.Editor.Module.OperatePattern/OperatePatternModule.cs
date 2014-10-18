using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Lofinil.GameSDK.Engine;
using Lofinil.Architecture;
using Lofinil.GameSDK.Editor.Interception;

namespace Lofinil.GameSDK.Editor
{
    // wiki:///E:/CodeDir/LofiGameSDK/Wiki/LofiGameSDK/Lofinil%20Game%20SDK.wiki?page=FrameAnimator%20Class
    [ModuleDependency("FormViewModule")]
    public class OperatePatternModule : EditorModule, IOperatePatternModule
    {
        private OperatePattern CurPattern;

        private List<OperatePattern> OperatePatternList;

        public OperatePatternModule()
        {
            CurPattern = null;
            OperatePatternList = new List<OperatePattern>();
        }

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            GameService.Instance.QueryModule<AssemblyModule>().AssemblyLoaded += new Action<Assembly>(OnAssemblyLoaded);
        }
        
        // KEY 一个组件
        public void BindPattern()
        {
            // NOTE 已经完成CreatePattern的绑定
        }

        public void StartPattern(String name)
        {
            foreach (OperatePattern cp in OperatePatternList)
            {
                if (cp.Name == name)
                {
                    CurPattern = cp;
                    break;
                }
            }

            CurPattern.Startup();
        }

        public void StartPattern(Type type)
        {
            // ACHACK [创建模式的选择] 选择遍历到的第一个相关创建模式
            foreach (OperatePattern op in OperatePatternList)
            {
                // HACK
                CurPattern = op;
                break;
            }
        }

        public void StartPattern<T>()
        {
            throw new NotImplementedException();
        }

        public void StartPattern<T>(object[] args)
        {
            throw new NotImplementedException();
        }

        public void EndPattern()
        {
             //CurCreatePattern.
            CurPattern.End();
        }

        public void OnAssemblyLoaded(Assembly asm)
        {
            Type[] cps = NETFramework.GetAllChildren(asm, typeof(OperatePattern));
            foreach (Type t in cps)
            {
                OperatePattern c = (OperatePattern)t.GetConstructor(Type.EmptyTypes).Invoke(null);
                OperatePatternList.Add(c);
            }
        }
    }
}
