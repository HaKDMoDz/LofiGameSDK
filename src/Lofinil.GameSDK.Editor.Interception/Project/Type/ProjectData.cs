using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Engine;

namespace Lofinil.GameSDK.Editor
{
    public class ProjectData
    {
        public String GameName{get;set;}
        public String Author{get;set;}

        public int Width{get;set;}
        public int Height{get;set;}

        public String ResourcePath{get;set;}

        public String ContentPath{get;set;}

        public String CommonResConfig{get;set;}             // 公共资源配置文件

        public List<String> AsmPathList{get;set;}
        public String ConfigDir{get;set;}                   // 配置目录

        public String UIDStackPath{get;set;}                // ID堆栈文件

        public String Thumbnail{get;set;}                   // 图片文件的临时缩略图目录

        public List<ProjectItem> ItemList{get;set;}

        public ProjectData()
        {
            GameName = "A Game";
            Author = "Super Man";
            Width = 800;
            Height = 600;
            ResourcePath = "Resource";
            ContentPath = "Content";
            CommonResConfig = "Config\\Commonres.lfrs";
            AsmPathList = new List<string>();
            ConfigDir = "Config";
            UIDStackPath = "Misc\\UIDStack.xml";
            Thumbnail = "Thumbnail";
            ItemList = new List<ProjectItem>();
        }

        public GameConfig CreateGameConfig()
        {
            GameConfig gc = new GameConfig();
            gc.Width = this.Width;
            gc.Height = this.Height;
            gc.ContentPath = this.ContentPath;
            gc.AsmPathList = this.AsmPathList;
            return gc;
        }
    }

    public class ProjectItem
    {
        public String FileName { get; set; }
        public String Processor { get; set; }
    }
}
