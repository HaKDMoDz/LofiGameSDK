using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.Module.Menu;
using Lofinil.GameSDK.Editor.Module.FormView;
using System.Windows.Forms;

namespace Lofinil.GameSDK.Editor.Module.FormMenu
{
    public class FormMenuModule : MenuModule
    {
        MenuControl menuCtrl;

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            menuCtrl = new MenuControl();
            menuCtrl.menuStrip1.Items.Clear();

            EditorService.Instance.QueryModule<FormViewModule>().RegisterView(menuCtrl, "Menu");
            // base.MenuTreeChanged += onMenuTreeChanged;
            
            MenuData.Tag = menuCtrl.menuStrip1.Items;
        }

        public override void AddMenuItem(string menuPath, Menu.MenuItem item)
        {
            base.AddMenuItem(menuPath, item);
            Menu.MenuItem baseNode = findNode(menuPath, MenuData);
            //if(baseNode == null)
                
            ToolStripItemCollection coll = (ToolStripItemCollection)baseNode.Tag;
            ToolStripMenuItem tsItem = new ToolStripMenuItem();
            tsItem.Text = item.Name;
            tsItem.Click += delegate { if(item.Command!=null) item.Command(); };
            coll.Add(tsItem);
            item.Tag = tsItem.DropDownItems;
        }

        public void RegistMenuItem(String itemName, String level, String group, MenuItemType type, EventHandler command)
        {
            ToolStripItemCollection curLvlCol = menuCtrl.MainMenuStrip.Items;

            ToolStripDropDownItem item = (ToolStripDropDownItem)curLvlCol.Find(level, false).ElementAt(0);
            if (item == null)
                menuCtrl.MainMenuStrip.Items.Add(level);

            item.DropDownItems.Add(itemName, null, command);

            // TODO Group处理
        }

        #region Removed
        //private void onMenuTreeChanged(Lofinil.GameSDK.Editor.Module.Menu.MenuItem data)
        //{
        //    MenuStrip menuStrip = menuCtrl.menuStrip1;
        //    menuStrip.Items.Clear();
        //    foreach (Lofinil.GameSDK.Editor.Module.Menu.MenuItem catalog in data.ItemList)
        //    {
        //        addMenuItem(menuStrip, catalog);
        //    }
        //}

        //private void addChoiceItem(ToolStripMenuItem menuItem, ChoiceItemMenuItem choiceItem)
        //{
        //    ToolStripMenuItem item = new ToolStripMenuItem(choiceItem.Name, null, delegate { choiceItem.ChoiceChanged(); });
        //    menuItem.DropDownItems.Add(item);
        //}

        //private void addMenuCatalog(MenuStrip menuStrip, MenuCatalog catalog)
        //{
        //    ToolStripMenuItem menuItem = new ToolStripMenuItem();
        //    menuItem.Text = catalog.Name;
        //    menuStrip.Items.Add(menuItem);
        //    foreach (MenuGroup group in catalog.MenuGroupList)
        //    {
        //        addMenuGroup(menuItem, group);
        //    }
        //}

        //private void addMenuGroup(ToolStripMenuItem menuItem, MenuGroup group)
        //{
        //    if (menuItem.DropDownItems.Count != 0)
        //    {
        //        ToolStripItem separator = new ToolStripSeparator();
        //        menuItem.DropDownItems.Add(separator);
        //    }
        //    foreach (Lofinil.GameSDK.Editor.Module.Menu.MenuItem item in group.MenuItemList)
        //    {
        //        addMenuItem(menuItem, item);
        //    }
        //}

        //private void addMenuItem(ToolStripMenuItem menuItem, Lofinil.GameSDK.Editor.Module.Menu.MenuItem item)
        //{
        //    if (item is MenuItem)
        //    {
        //        MenuItem command = (MenuItem)item;
        //        ToolStripMenuItem button = new ToolStripMenuItem(command.Name, null, delegate { command.Command(); });
        //        menuItem.DropDownItems.Add(button);
        //    }
        //    else if (item is StateMenuItem)
        //    {
        //        StateMenuItem state = (StateMenuItem)item;
        //        ToolStripMenuItem stateItem = new ToolStripMenuItem(state.Name, null, delegate { state.StateChanged(true); }); // HACK
        //        menuItem.DropDownItems.Add(stateItem);
        //    }
        //    else if (item is ChoiceMenuItem)
        //    {
        //        ChoiceMenuItem choice = (ChoiceMenuItem)item;
        //        ToolStripMenuItem choiceItem = new ToolStripMenuItem(choice.Name);
        //        menuItem.DropDownItems.Add(choiceItem);
        //        foreach (ChoiceItemMenuItem i in choice.ChoiceItemList)
        //            addChoiceItem(choiceItem, i);
        //    }
        //}

        #endregion Removed
    }
}
