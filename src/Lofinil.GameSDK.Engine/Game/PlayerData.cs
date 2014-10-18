using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Lofinil.GameSDK.Engine
{
    public class PlayerData
    {
        public String PlayerName;

        public String SceneName = "";

        public int Health = 3;

        public List<String> ItemList = new List<string>();

        // TODO [角色初始位置交由编辑器设定]
        public Vector2 Position = new Vector2(100, 100);        

        public class SceneChange
        {
            public String SceneName;

            public bool DramaTriggered = false;

            public class ItemPropertyChange
            {
                public String ItemName;

                public String ItemLabel;

                public String PropertyName;

                public String Value;
            }

            public List<ItemPropertyChange> ItemChangeList = new List<ItemPropertyChange>();
        }

        public List<SceneChange> SceneChangeList = new List<SceneChange>();
    }
}