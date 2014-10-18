using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.Module.Menu;
using Lofinil.GameSDK.Editor.Module.FormView;
using Lofinil.GameSDK.Editor.Module.PropertyEditor;
using System.IO;

namespace Lofinil.GameSDK.Editor.Module.FormProject
{
    public class FormProjectItem
    {
        public Object Data;

        public virtual void BuildUpContextMenu()
        {
            FormProjectModule formProjMod =
                EditorService.Instance.QueryModule<FormProjectModule>();

            List<MenuItem> menuItems = new List<MenuItem>();
            MenuItem ci = new MenuItem();
            ci.Name = "在资源管理器中打开";
            ci.Command = null;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "属性";
            ci.Command = viewProperty;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "从项目中排除";
            ci.Command = null;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "打开";
            ci.Command = null;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "打开方式";
            ci.Command = null;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "剪切";
            ci.Command = null;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "删除";
            ci.Command = null;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "复制";
            ci.Command = null;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();
            ci.Name = "重命名";
            ci.Command = null;
            ci.Index = 0;
            menuItems.Add(ci);
            ci = new MenuItem();

            formProjMod.MenuBuilder.SetMenu(menuItems.ToArray());
        }

        public virtual void OnDoubleClicked()
        {
            // HACK
            if (Data is ProjectItem)
            {
                String fName = ((ProjectItem)Data).FileName;
                FileInfo fInfo = new FileInfo(fName);
                if (fInfo.Extension == EditorStatics.StageExt)
                {
                    EditorService.Instance.QueryModule<FormViewModule>().ShowRegion("Stage");
                    EditorService.Instance.QueryModule<StageEditModule>().ReadStage(fName);
                }
            }
        }

        private void viewProperty()
        {
            EditorService.Instance.QueryModule<FormViewModule>().ShowRegion("PropertyTab");
            EditorService.Instance.QueryModule<PropertyEditorModule>().SetTarget(Data);
        }
    }
}
