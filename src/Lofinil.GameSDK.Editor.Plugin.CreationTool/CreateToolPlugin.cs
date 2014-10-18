using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.Module.FormToolBox;
using Lofinil.GameSDK.Editor.Module.ToolBox;
using Lofinil.GameSDK.Editor.App;
using Lofinil.GameSDK.Editor.SharedRes;
using Lofinil.GameSDK.Editor.Composite_Framework;
using Lofinil.GameSDK.Editor.Module.FormStage;
using System.Drawing;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor.Module.Project;
using System.IO;

namespace Lofinil.GameSDK.Editor.Plugin.CreationTool
{
    public class CreateToolPlugin : IEditorPlugin
    {
        // 该插件只注册一个位置：
        //  类型:工具箱项
        //  依赖文档: Stage
        public bool Enabled { get; set; }

        private FormToolBoxModule toolMod;
        private CreateContextControl contextCtrl;
        private StageEditControl stageEditCtrl;

        private bool created;           // 精灵是否已创建出
        private int mouseX;
        private int mouseY;
        private String curPicPath;
        private Bitmap picture;
        private int makeMode;           // 0-图章模式 1-自由模式
        private bool isHalfAlpha;       // 是否将叠加色设为半透明 [Demo]

        public void Initialize()
        {
            toolMod = EditorService.Instance.QueryModule<FormToolBoxModule>();
            ToolItem item = new ToolItem();
            // item.TurnOn = onTurnOn;
            // item.TurnOff = onTurnOff;
            item.Name = "创建";
            item.Image = Resources._22_Create;
            toolMod.RegistToolItem(item);

            contextCtrl = new CreateContextControl();

            created = false;
            mouseX = 0;
            mouseY = 0;
            curPicPath = "";
            picture = null;
            makeMode = 0;
            isHalfAlpha = false;

        }

        private void onTurnOn()
        {
            toolMod.SetToolContextControl(contextCtrl);

            stageEditCtrl = EditorService.Instance.QueryModule<FormStageModule>().EditMainControl1;
            stageEditCtrl.MouseMove += new System.Windows.Forms.MouseEventHandler(stageEditCtrl_MouseMove);
            stageEditCtrl.MouseClick += new System.Windows.Forms.MouseEventHandler(stageEditCtrl_MouseClick);
            stageEditCtrl.FormDrawAfter += new EventHandler<System.Windows.Forms.PaintEventArgs>(stageEditCtrl_FormDrawAfter);
        }

        private void onTurnOff()
        {
            stageEditCtrl = EditorService.Instance.QueryModule<FormStageModule>().EditMainControl1;
            stageEditCtrl.MouseMove -= new System.Windows.Forms.MouseEventHandler(stageEditCtrl_MouseMove);
            stageEditCtrl.MouseClick -= new System.Windows.Forms.MouseEventHandler(stageEditCtrl_MouseClick);
            stageEditCtrl.FormDrawAfter -= new EventHandler<System.Windows.Forms.PaintEventArgs>(stageEditCtrl_FormDrawAfter);
        }

        public void Uninitialize()
        {
        }

        void stageEditCtrl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        public void stageEditCtrl_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Sprite sp = new Sprite();
            sp.Position = new Microsoft.Xna.Framework.Vector2(e.X, e.Y);
            sp.Texture = new ReferTexture(contextCtrl.imagePicker1.TexRefData.Key);
            GameService.Instance.QueryModule<StageModule>().AddItem("Default", sp);
        }

        public void stageEditCtrl_FormDrawAfter(Object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (!created && makeMode == 0)
            {
                String picPath = contextCtrl.imagePicker1.TexRefData.Key;
                if (picPath != curPicPath)
                {
                    curPicPath = picPath;
                    // ACHACK 由于为记录后缀名，故无法找到文件 - 临时补上硬编码后缀
                    String realPath = Path.Combine(EditorService.Instance.QueryModule<ProjectModule>(null).CurProjDir, EditorService.Instance.QueryModule<ProjectModule>(null).CurProject.ResourcePath, curPicPath + ".png");
                    picture = new Bitmap(realPath);
                }

                if (picture != null)
                {
                    e.Graphics.DrawImage(picture, new Point(mouseX, mouseY));
                }
            }
        }
    }
}
