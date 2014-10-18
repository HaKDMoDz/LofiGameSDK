using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Lofinil.GameSDK.Engine
{
    // wiki:///E:/CodeDir/LofiGameSDK/Wiki/LofiGameSDK/Lofinil%20Game%20SDK.wiki?page=TriggerManager%20Class
    public class TriggerManager : BaseModule
    {
        public List<Trigger> TriggerList;

        public TriggerManager()
        {
        }

        public override void Update()
        {
        }

        public void LoadTriggerList(String path)
        {
            TriggerList = (List<Trigger>)XmlSerialize.Deserialize(path, typeof(List<Trigger>));
        }

        public void SaveTriggerList(String path)
        {
            XmlSerialize.Serialize(path, typeof(List<Trigger>), TriggerList);
        }
    }
}