using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.Module.Project;
using Lofinil.GameSDK.Editor.Module.FormView;
using Lofinil.GameSDK.Editor.Module.Menu;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor.Interception.ModuleInterface;
using Lofinil.GameSDK.Engine;
using System.Diagnostics;
using Lofinil.GameSDK.Editor.Module.StatusBar;
using MenuItem = Lofinil.GameSDK.Editor.Module.Menu.MenuItem;

namespace Lofinil.GameSDK.Editor.Module.FormProject
{
    public class FormProjectModule : ProjectModule
    {
        private ProjectControl projectCtrl;

        public ProjectItemContextMenuBuilder MenuBuilder;

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);


            projectCtrl = new ProjectControl();

            MenuBuilder = new ProjectItemContextMenuBuilder();
            MenuBuilder.Menu = projectCtrl.contextMenuStrip1;

            EditorService.Instance.QueryModule<FormViewModule>(null).RegisterView(projectCtrl, "ProjectTab");

            MenuModule menuModule = EditorService.Instance.QueryModule<MenuModule>();
            MenuItem fileItem = new MenuItem();
            fileItem.Name = "文件";
            fileItem.Index = 0;
            menuModule.AddMenuItem("", fileItem);
            MenuItem item = new MenuItem();
            item.Name = "新建";
            item.Index = 0;
            item.Command = menuCommand_New;
            menuModule.AddMenuItem("文件", item);
            item = new MenuItem();
            item.Name = "打开";
            item.Index = 1;
            item.Command = menuCommand_Open;
            menuModule.AddMenuItem("文件", item);
            item = new MenuItem();
            item.Name = "保存";
            item.Index = 2;
            item.Command = menuCommand_Save;
            menuModule.AddMenuItem("文件", item);
            item = new MenuItem();
            item.Name = "关闭";
            item.Index = 3;
            item.Command = menuCommand_Close;
            menuModule.AddMenuItem("文件", item);
            item = new MenuItem();
            item.Name = "新建场景";
            item.Index = 0;
            item.Command = menuCommand_NewStage;
            menuModule.AddMenuItem("文件", item);
            item = new MenuItem();
            item.Name = "保存场景";
            item.Index = 0;
            item.Command = menuCommand_SaveStage;
            menuModule.AddMenuItem("文件", item);
            item = new MenuItem();
            item.Name = "退出";
            item.Index = 4;
            item.Command = menuCommandQuit;
            menuModule.AddMenuItem("文件", item);
            fileItem = new Lofinil.GameSDK.Editor.Module.Menu.MenuItem();
            fileItem.Name = "项目";
            fileItem.Index = 1;
            menuModule.AddMenuItem("", fileItem);
            item = new MenuItem();
            item.Name = "项目配置";
            item.Index = 0;
            item.Command = menuCommand_ProjConf;
            menuModule.AddMenuItem("项目", item);
            item = new MenuItem();
            item.Name = "管线预设配置";
            item.Index = 1;
            item.Command = menuCommand_PipelineConf;
            menuModule.AddMenuItem("项目", item);

            StatusBarModule statusModule = EditorService.Instance.QueryModule<StatusBarModule>();
            statusModule.AddIndicator("项目状态");
            statusModule.SetIndicator("项目状态", "项目状态:未加载");
        }

        #region 菜单命令
        private void menuCommand_Open()
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "游戏项目文件|*.lfp";
            DialogResult dr = ofDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Read(ofDialog.FileName);

                StatusBarModule statusModule = EditorService.Instance.QueryModule<StatusBarModule>();
                statusModule.SetIndicator("项目状态", "项目状态:已加载" + CurProject.GameName);
            }
        }

        private void menuCommand_New()
        {
            CreateProjectForm cpFrom = new CreateProjectForm();
            cpFrom.StartPosition = FormStartPosition.CenterParent;
            DialogResult dr = cpFrom.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // 关闭当前已保存项目
                // if(EditorManager.Instance.CurProject != null)
                // ...

                // 打开新项目
                String projFile = cpFrom.ProjFile;
                EditorService.Instance.QueryModule<ProjectModule>(null).Read(projFile);

            }
        }

        private void menuCommand_Save()
        {
            Save();
        }

        private void menuCommand_Close()
        {
        }

        private void menuCommandQuit()
        {
            Application.Exit();
        }

        private void menuCommand_NewStage()
        {
            CreateStageForm csf = new CreateStageForm();
            csf.StartPosition = FormStartPosition.CenterParent;
            DialogResult dr = csf.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                RefreshProjectTree();
            }
        }

        private void menuCommand_SaveStage()
        {
            GameService.Instance.QueryModule<StageModule>().WriteStage();
        }

        public void menuCommand_ProjConf()
        {
            ProjectConfigForm pcFrm = new ProjectConfigForm();
            DialogResult dr = pcFrm.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                EditorService.Instance.QueryModule<ProjectModule>(null).CurProject = pcFrm.Project;
            }
        }

        private void menuCommand_PipelineConf()
        {

        }

        #endregion 菜单命令

        public void RefreshProjectTree()
        {
            projectCtrl.BuildTree(CurProject);
        }
    }
}
