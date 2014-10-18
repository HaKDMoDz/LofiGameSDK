using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Engine
{
    // 组件标识和搜索模块
    public class IdModule
    {
        public static GameComponent GetCompByName(String name, GameComponentCollection compList)
        {
            foreach (GameComponent comp in compList)
            {
                foreach (GameComponent c in comp.Children)
                {
                    Identifier idComp = c as Identifier;
                    if (idComp != null && idComp.Name == name)
                        return comp;
                }
            }
            return NullGameComponent.Instance;
        }

    }
}
