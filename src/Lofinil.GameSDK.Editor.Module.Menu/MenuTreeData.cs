using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor.Module.Menu
{
    public class MenuTreeData
    {
        public List<MenuItem> ItemList = new List<MenuItem>();
    }

    public class MenuItem
    {
        public String Name;
        public int Index;
        public List<MenuItem> ItemList = new List<MenuItem>();
        public Object Tag;
        public Action Command;
        public Action<bool> StateChanged;
    }
}
