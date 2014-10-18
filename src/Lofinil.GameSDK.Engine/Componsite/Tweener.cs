using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Engine.Componsite
{
    public class Tweener
    {
        public List<PropertyModifier> paramTweenList { get; set; }

        public void StartModify(String tweenName)
        {
            for (int i = 0; i < paramTweenList.Count; i++)
            {
                if (paramTweenList[i].Name == tweenName)
                {
                    paramTweenList[i].StartModify();
                }
            }
        }

        public void StopModify(String tweenName)
        {
            for (int i = 0; i < paramTweenList.Count; i++)
            {
                if (paramTweenList[i].Name == tweenName)
                {
                    paramTweenList[i].StopModify();
                }
            }
        }

        public PropertyModifier GetModifier(String modName)
        {
            foreach (PropertyModifier pm in paramTweenList)
            {
                if (pm.Name == modName)
                    return pm;
            }
            return null;
        }
    }
}
