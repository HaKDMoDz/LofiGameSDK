using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Engine
{
    public class ContentData
    {
        public int Id;
        public String Key;
        public ContentType Type;           // NOTE [这只是一个XNA的引擎！]
    }

    public class ContentSetData
    {
        public int Id;

        public String Name;

        public List<ContentData> ContentDataList;

        public ContentSetData()
        {
            Name = "";
            ContentDataList = new List<ContentData>();
        }
    }
}
