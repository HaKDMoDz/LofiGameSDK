using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MenuItem = Lofinil.GameSDK.Editor.Module.Menu.MenuItem;

namespace Lofinil.GameSDK.Editor.Module.FormProject
{
    public class FormProjectItemImage : FormProjectItem
    {
        public override void BuildUpContextMenu()
        {
            base.BuildUpContextMenu();

            FormProjectModule projMod = EditorService.Instance.QueryModule<FormProjectModule>();

            List<MenuItem> items = new List<MenuItem>();
            MenuItem item = new MenuItem();
            item.Name = "作为精灵置入场景";
            item.Command = addToStageAsSprite;

        }

        private void addToStageAsSprite()
        {
            

        }
    }
}
