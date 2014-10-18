using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor;
using Lofinil.GameSDK.Engine;
using System.Drawing;
using System.IO;
using Lofinil.GameSDK.Editor.Module.FormView;
using Lofinil.GameSDK.Editor.Module.Project;
using Lofinil.GameSDK.Editor.Module.FormStage;

namespace Lofinil.GameSDK.Editor.App
{
    public class CreateSpritePattern : OperatePattern
    {
        private ICustomView customView;
        private ICanvasView canvas;

        // NOTE [Canvas实体已知] 这造成此操作模式依赖具体的视图实现，无法被其他视图实现共享
        private StageEditControl stageEditCtrl;

        public override void Regist()
        {
        }

        public override void Startup()
        {
            FormViewModule viewMod = EditorService.Instance.QueryModule<FormViewModule>(null);            

            // NOTE [操作模式参考] 如果操作模式需要用到视图，可以用QueryView从调度层请求过来
            customView = viewMod.QueryView<ICustomView>(null);
            canvas = (ICanvasView)viewMod.QueryView<ICustomView>(null);
            stageEditCtrl = (StageEditControl)canvas;

            // NOTE [操作模式参考] 以下代码也是控制ICustomView呈现的例子
            // customView.AddPickOneChooser2("rb3", new String[] { "图章", "自由" }, makeMode);
            // customView.AddCommander("在视图中心创建", delegate { createSpriteInMiddleOfView(); });
            // customView.AddYesNoChooser("cb1", "半透明", isHalfAlpha);
            // customView.AddPickOneChooser("cbb2", new String[] { "默认名称", "名称1", "名称2", "名称3" }, 0);
        }

        public override void End()
        {
            customView.Clear();
        }

        public override void Idle()
        {
            // 这里编写逻辑
        }

        private void createSpriteInMiddleOfView()
        {
            Sprite sp = new Sprite();
            sp.Position = GameService.Instance.QueryModule<StageModule>().CurCamera.Focus;
            sp.Texture = new ReferTexture("Background");
            GameService.Instance.QueryModule<StageModule>().AddItem("Default", sp);
        }
    }
}
