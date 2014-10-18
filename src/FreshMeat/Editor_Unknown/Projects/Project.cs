using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LofiEditor.Projects
{
    public class Project
    {
        public String Path = "";
        public String Name = "NoName";
        public String GameName = "NoName";
        public String Author = "Nobody";
        // public String icon;

        public String TexturePath = "Content/Textures";
        public String SongPath = "Content/Songs";
        public String FontPath = "Content/Fonts";
        public String DramaPath = "Content/Dramas";
        public String ScenePath = "Content/Scenes";

        public int PixelCount = 32;
        public String GameLenUnit = "米";
    }
}
