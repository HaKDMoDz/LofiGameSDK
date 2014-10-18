using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor.Module.Menu
{
    [ModuleDependency("FormViewModule")]
    public class MenuModule : EditorModule
    {
        public MenuItem MenuData;

        public event Action<MenuItem> MenuTreeChanged;
        public event Action<String, MenuItem> MenuItemAdded;
        public event Action<String, String, String> MenuItemRemoved;

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            MenuData = new MenuItem();
        }

        public virtual void AddMenuItem(String menuPath, MenuItem item)
        {
            MenuItem parent = findNode(menuPath, MenuData);
            if (parent != null)
            {
                parent.ItemList.Insert(item.Index, item);
                if (MenuItemAdded != null)
                    MenuItemAdded(menuPath, item);
                if (MenuTreeChanged != null)
                    MenuTreeChanged(item);
            }
        }

        protected MenuItem findNode(String menuPath, MenuItem data)
        {
            List<String> pathNodes = new List<String>(menuPath.Split('/'));
            if (String.IsNullOrEmpty(menuPath) || pathNodes.Count() == 0)
                return data;
            else
            {
                MenuItem curItem = data;
                while (pathNodes.Count() != 0)
                {
                    String curName = pathNodes[0];
                    MenuItem findItem = curItem.ItemList.Find(i => i.Name == curName);
                    if (findItem == null)
                        return null;
                    curItem = findItem;
                    pathNodes.RemoveAt(0);
                }
                return curItem;
            }
        }

        //protected MenuItem createNode(String menuPath, MenuItem data)
        //{
        //    List<String> pathNodes = new List<string>(menuPath.Split('/'));
        //    if (String.IsNullOrEmpty(menuPath) || pathNodes.Count() == 0)
        //        return null;
        //    else
        //    {
        //        MenuItem curItem = data;
        //        while (pathNodes.Count() != 0)
        //        {
        //            String curName =
        //        }
        //    }
        //}

        #region Removed
        //private void AddCatalog(MenuCatalog catalog)
        //{
        //    MenuData.ItemList.Insert(catalog.Index, catalog);
        //    if(CatalogAdded!=null)
        //        CatalogAdded(catalog);
        //    if (MenuTreeChanged != null)
        //        MenuTreeChanged(MenuData);
        //}

        //private void RemoveCatalog(String name)
        //{
        //    MenuData.ItemList.Remove(MenuData.ItemList.Find(c => c.Name == name));
        //    if (CatalogRemoved != null)
        //        CatalogRemoved(name);
        //    if (MenuTreeChanged != null)
        //        MenuTreeChanged(MenuData);
        //}

        //private void AddGroup(String catalogName, MenuGroup group)
        //{
        //    MenuData.ItemList.Find(c => c.Name == catalogName).MenuGroupList.Insert(group.Index, group);
        //    if (GroupAdded != null)
        //        GroupAdded(catalogName, group);
        //    if (MenuTreeChanged != null)
        //        MenuTreeChanged(MenuData);
        //}

        //private void RemoveGroup(String catalogName, String groupName)
        //{
        //    MenuCatalog catalog = MenuData.ItemList.Find(c => c.Name == catalogName);
        //    MenuGroup group = catalog.MenuGroupList.Find(g => g.Name == groupName);
        //    catalog.MenuGroupList.Remove(group);
        //    if (GroupRemoved != null)
        //        GroupRemoved(catalogName, groupName);
        //    if (MenuTreeChanged != null)
        //        MenuTreeChanged(MenuData);
        //}

        //private void AddMenuItem(String catalogName, String groupName, MenuItem item)
        //{
        //    MenuData.ItemList.Find(c => c.Name == catalogName)
        //        .MenuGroupList.Find(g => g.Name == groupName)
        //        .MenuItemList.Insert(item.Index, item);
        //}

        //private void RemoveMenuItem(String catalogName, String groupName, String itemName)
        //{
        //    MenuGroup group = MenuData.ItemList.Find(c => c.Name == catalogName)
        //        .MenuGroupList.Find(g => g.Name == groupName);
        //    MenuItem item = group.MenuItemList.Find(i => i.Name == itemName);
        //    group.MenuItemList.Remove(item);
        //    if (MenuItemRemoved != null)
        //        MenuItemRemoved(catalogName, groupName, itemName);
        //    if (MenuTreeChanged != null)
        //        MenuTreeChanged(MenuData);
        //}

        //private void AddChoiceItem(String catalogName, String groupName, String itemName, ChoiceItemMenuItem item)
        //{
        //    ((ChoiceMenuItem)MenuData.ItemList
        //        .Find(c => c.Name == catalogName)
        //        .MenuGroupList.Find(g=>g.Name == groupName)
        //        .MenuItemList.Find(i=>i.Name == itemName))
        //        .ChoiceItemList.Insert(item.Index, item);
        //    if (ChoiceItemAdded != null)
        //        ChoiceItemAdded(catalogName, groupName, itemName, item);
        //    if (MenuTreeChanged != null)
        //        MenuTreeChanged(MenuData);
        //}

        //private void RemoveChoiceItem(String catalogName, String groupName, String itemName, String choiceItemName)
        //{
        //    ChoiceMenuItem choice = (ChoiceMenuItem)MenuData.ItemList
        //        .Find(c => c.Name == catalogName)
        //        .MenuGroupList.Find(g => g.Name == groupName)
        //        .MenuItemList.Find(i => i.Name == itemName);
        //    ChoiceItemMenuItem choiceItem = choice.ChoiceItemList.Find(ci=>ci.Name == choiceItemName);
        //    choice.ChoiceItemList.Remove(choiceItem);
        //    if (ChoiceItemRemoved != null)
        //        ChoiceItemRemoved(catalogName, groupName, itemName, choiceItemName);
        //    if (MenuTreeChanged != null)
        //        MenuTreeChanged(MenuData);
        //}
        #endregion Removed
    }
}
