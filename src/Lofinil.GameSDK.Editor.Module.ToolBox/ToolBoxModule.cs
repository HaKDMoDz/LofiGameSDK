using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Engine;
using Lofinil.Architecture;
using Lofinil.GameSDK.Editor.Interception;
using Lofinil.GameSDK.Editor.Module.FormView;
using Lofinil.GameSDK.Editor.App;
using Lofinil.GameSDK.Editor.Module.ToolBox;

namespace Lofinil.GameSDK.Editor
{
    [ModuleDependency("FormViewModule")]
    public class ToolBoxModule:EditorModule
    {
        public List<ToolItem> ToolItemList;

        public Action<List<ToolItem>> ToolListChanged;

        public ToolBoxModule()
        {
            ToolItemList = new List<ToolItem>();
        }

        public void RegistToolItem(ToolItem item)
        {
            ToolItemList.Add(item);
            if (ToolListChanged != null)
                ToolListChanged(ToolItemList);
        }
    }
}
