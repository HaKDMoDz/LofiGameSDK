using System;
using System.Collections.Generic;

namespace Lofinil.GameSDK.Engine
{
    public class GameConfig
    {
        public int Width;
        public int Height;

        public String ContentPath = "Content";

        public string ProfileDir = "Profile";


        public String SceneExt = ".xml";
        public String TriggerExt = ".xml";

        public List<String> AsmPathList;

        public GameConfig()
        {
            AsmPathList = new List<string>();
        }
    }
}