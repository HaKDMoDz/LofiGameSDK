using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.Module.ToolBox;
using Lofinil.GameSDK.Editor.SharedRes;
using Lofinil.GameSDK.Editor.App;
using Lofinil.GameSDK.Editor.Module.FormView;
using System.Windows.Forms;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor.Interception;
using Lofinil.GameSDK.Editor.Module.Component;
using Lofinil.GameSDK.Editor.Module.Menu;
using MenuItem = Lofinil.GameSDK.Editor.Module.Menu.MenuItem;

namespace Lofinil.GameSDK.Editor.Module.FormStage
{
    public class FormStageModule : StageEditModule
    {
        public StageEditControl EditMainControl1;

        public String CurStageEditToolName;

        public FormStageModule()
        { }

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            EditMainControl1 = new StageEditControl();
            EditorService.Instance.QueryModule<FormViewModule>().RegisterView(EditMainControl1, "Stage");
            EditorService.Instance.QueryModule<FormViewModule>().RegisterView(new ItemControl(), "StageTab");

            CurStageEditToolName = "Move";

            MenuModule menuModule = EditorService.Instance.QueryModule<MenuModule>();
            Menu.MenuItem catalog = new MenuItem();
            catalog.Name = "视图";
            catalog.Index = 1;
            menuModule.AddMenuItem("",catalog);
            MenuItem item = new MenuItem();
            item.Name = "场景配置";
            item.Index = 0;
            item.Command = menuCommand_StageConfig;
            menuModule.AddMenuItem("视图", item);
            MenuItem item2 = new MenuItem();
            item2.Name = "显示参考网格";
            item2.Index = 0;
            item2.StateChanged = menuState_ShowRefGrid;
            menuModule.AddMenuItem("视图", item2);
            item = new MenuItem();
            item.Name = "参考网格设置";
            item.Index = 1;
            item.Command = menuCommand_RefGridSet;
            menuModule.AddMenuItem("视图", item);

            ToolBoxModule toolBoxModule = 
                EditorService.Instance.QueryModule<ToolBoxModule>();
            ToolItem toolItem = new ToolItem();
            toolItem.Name = "选择";
            toolItem.Image = (Object)Resources._22_Select;
            toolItem.TurnOn = toolCommand_Select;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "创建";
            toolItem.Image = (Object)Resources._22_Create;
            toolItem.TurnOn = toolCommand_Create;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "创建精灵";
            toolItem.Image = (Object)Resources._22_Wizard;
            toolItem.TurnOn = toolCommand_CreateSprite;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "变换";
            toolItem.Image = (Object)Resources._22_Move;
            toolItem.TurnOn = toolCommand_Transform;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "删除";
            toolItem.Image = (Object)Resources._22_Delete;
            toolItem.TurnOn = toolCommand_Delete;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "漫游";
            toolItem.Image = (Object)Resources._22_FreeCamera;
            toolItem.TurnOn = toolCommand_Navigate;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "复制";
            toolItem.Image = (Object)Resources._22_Copy;
            toolItem.TurnOn = toolCommand_Copy;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "提取";
            toolItem.Image = (Object)Resources._22_Picker;
            toolItem.TurnOn = toolCommand_Picker;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "编辑动画";
            toolItem.Image = (Object)Resources._22_Anim;
            toolItem.TurnOn = toolCommand_Anim;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "移到顶部";
            toolItem.Image = (Object)Resources._22_Top;
            toolItem.TurnOn = toolCommand_Top;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "上移一层";
            toolItem.Image = (Object)Resources._22_Up;
            toolItem.TurnOn = toolCommand_Up;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "下移一层";
            toolItem.Image = (Object)Resources._22_Down;
            toolItem.TurnOn = toolCommand_Down;
            toolBoxModule.RegistToolItem(toolItem);
            toolItem = new ToolItem();
            toolItem.Name = "移到底部";
            toolItem.Image = (Object)Resources._22_Bottom;
            toolItem.TurnOn = toolCommand_Bottom;
            toolBoxModule.RegistToolItem(toolItem);
        }


        private void menuCommand_StageConfig()
        {

        }

        private void menuCommand_RefGridSet()
        {
            // HACK
            // EditorService.Instance.QueryModule<IStageModule>().ShowGridConfig();
        }

        private void menuState_ShowRefGrid(bool check)
        {
        }


        public void ShowGridConfig()
        {
            RefGridSettingForm setForm = new RefGridSettingForm();
            setForm.RefGridSetting =
                this.EditMainControl1.Presenter.RefGridSetting.ShallowCopy();
            DialogResult dr = setForm.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                this.EditMainControl1.Presenter.RefGridSetting =
                    setForm.RefGridSetting;
            }
        }

        #region 工具命令
        private void toolCommand_Delete()
        {
            CurStageEditToolName = "Delete";
        }

        private void toolCommand_Select()
        {
            CurStageEditToolName = "Select";
        }

        private void toolCommand_Create()
        {
            CurStageEditToolName = "Create";

            SelectItem(SelectMode.Clear, null);
            CompInfo cInfo = EditorService.Instance.QueryModule<ComponentModule>().PenType;
            EditorService.Instance.QueryModule<IOperatePatternModule>().StartPattern(cInfo.CompType);
        }

        private void toolCommand_CreateSprite()
        {
            CurStageEditToolName = "CreateSprite";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
        }

        private void toolCommand_Transform()
        {
            CurStageEditToolName = "Trans";
        }

        private void toolCommand_Picker()
        {
            CurStageEditToolName = "Picker";
        }

        private void toolCommand_Copy()
        {
            CloneSelectedItem();
        }

        private void toolCommand_Navigate()
        {
            CurStageEditToolName = "Navigate";
        }

        private void toolCommand_Anim()
        {
            throw new NotImplementedException();
        }

        private void toolCommand_Bottom()
        {
            MoveSelectionToBottom();
        }

        private void toolCommand_Down()
        {
            MoveSelectionToLower();
        }

        private void toolCommand_Up()
        {
            MoveSelectionToUpper();
        }

        private void toolCommand_Top()
        {
            MoveSelectionToTop();
        }

        #endregion 工具命令
    }
}
