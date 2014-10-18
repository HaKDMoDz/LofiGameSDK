using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor;
using Lofinil.GameSDK.Editor.Module.FormView;

namespace Lofinil.GameSDK.Editor.Shell
{
    class LofiGameEditorBootstrapper : Bootstrapper
    {
        private MainForm mfrn;

        public override void LoadModules()
        {
            // NOTE 下面是手工处理模块的加载顺序
            EditorService.Instance.RegistModule("Module.FormView");             // 通用模块 - 视图
            EditorService.Instance.RegistModule("Module.Process");              // 通用模块 - 任务
            EditorService.Instance.RegistModule("Module.PropertyEditor");       // 呈现模块 - 属性格
            EditorService.Instance.RegistModule("Module.FormMenu");             // 呈现模块 - 菜单
            EditorService.Instance.RegistModule("Module.StatusBar");            // 呈现模块 - 状态条
            EditorService.Instance.RegistModule("Module.FormToolBox");          // 呈现模块 - 工具箱
            EditorService.Instance.RegistModule("Module.Wizard");               // 定制模块 - 向导
            EditorService.Instance.RegistModule("Module.OperatePattern");       // 定制模块 - 操作模式
            EditorService.Instance.RegistModule("Module.FormComponent");        // 组构模块 - 组件
            EditorService.Instance.RegistModule("Module.FormProject");          // 组构模块 - 项目
            EditorService.Instance.RegistModule("Module.ContentPipeline");      // 组构模块 - 资源管线
            EditorService.Instance.RegistModule("Module.FormStage");            // 组构模块 - 场景
            EditorService.Instance.RegistModule("Module.Trigger");              // 组构模块 - 触发器
            EditorService.Instance.RegistModule("Module.FormResource");         // 组构模块 - 资源
            EditorService.Instance.LoadAllPlugin();
        }

        public override void Startup()
        {
            base.Startup();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mfrn = new MainForm();
            FormViewModule viewModule = EditorService.Instance.QueryModule<FormViewModule>();
            viewModule.RegisterRegine(new FormRegion("Menu", mfrn.pnlMenu));
            viewModule.RegisterRegine(new FormRegion("Status", mfrn.pnlStatus));
            viewModule.RegisterRegine(new FormRegion("Tools", mfrn.pnlTools));
            viewModule.RegisterRegine(new FormRegion("Stage", mfrn.pnlStage));
            viewModule.RegisterRegine(new FormRegion("ProjectTab", mfrn.tpgProject));
            viewModule.RegisterRegine(new FormRegion("StageTab", mfrn.tpgStage));
            viewModule.RegisterRegine(new FormRegion("PropertyTab", mfrn.tpgProperty));
            // EditorService.Instance.Initialize(editMainControl1.GraphicsDevice);
        }

        public override void Initialize()
        {
            EditorService.Instance.Initialize();
            Application.Run(mfrn);
        }
    }
}
