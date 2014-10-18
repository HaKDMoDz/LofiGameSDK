using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.App;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor.Module.Menu;

namespace Lofinil.GameSDK.Editor.Module.FormResource
{
    public class FormResourceModule : ResourceSetModule
    {
        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            MenuModule menuModule = EditorService.Instance.QueryModule<MenuModule>();
            Menu.MenuItem catalog = new Menu.MenuItem();
            catalog.Name = "资源";
            catalog.Index = 3;
            menuModule.AddMenuItem("", catalog);
            Menu.MenuItem item1 = new Menu.MenuItem();
            item1.Name = "图片";
            item1.Index = 0;
            item1.Command = menuCommand_Image;
            menuModule.AddMenuItem("资源", item1);
            Menu.MenuItem item2 = new Menu.MenuItem();
            item2.Name = "声音";
            item2.Index = 1;
            item2.Command = menuCommand_Sound;
            menuModule.AddMenuItem("资源", item2);
            Menu.MenuItem item3 = new Menu.MenuItem();
            item3.Name = "自动编译资源";
            item3.Index = 0;
            item3.StateChanged = menuState_ResAutoCompile;
            menuModule.AddMenuItem("资源", item3);
        }

        #region 菜单命令
        private void menuCommand_Image()
        {
            TextureForm tFrm = new TextureForm();
            tFrm.StartPosition = FormStartPosition.CenterParent;
            tFrm.ShowDialog();
        }

        private void menuCommand_Sound()
        {
        }

        private void menuState_ResAutoCompile(bool check)
        {
        }
        #endregion 菜单命令

    }
}
