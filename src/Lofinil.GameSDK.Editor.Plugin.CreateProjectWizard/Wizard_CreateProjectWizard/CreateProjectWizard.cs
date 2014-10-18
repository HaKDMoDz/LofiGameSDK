using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor;

namespace Lofinil.GameSDK.Editor.App
{
    class CreateProjectWizard : Wizard
    {
        String GameName;
        String ProjectDir;
        bool CreateDir;
        String Author;
        String IconPath;


        public CreateProjectWizard()
        {
            this.PageCount = 2;
            this.NeedSummary = true;
        }

        public override void StartUp()
        {
            WizardModule wizMod = EditorService.Instance.QueryModule<WizardModule>(null);
            wizMod.PageChanging += OnPageChanging;
        }

        public override void ShowPage(int pageNumber, IWizardView view)
        {
            switch(pageNumber)
            {
                case 0:
                    view.Clear();
                    view.SetTitle("创建项目向导 - Page1_路径设置");
                    view.AddInput("游戏名称", "游戏名称：", "新游戏");
                    view.AddPathInput("项目路径", "项目路径：", "");
                    view.AddYesNoChooser("是否建立目录", "是否建立项目文件夹", true);
                    break;
                case 1:
                    view.Clear();
                    view.SetTitle("创建项目向导 - Page2_作者信息");
                    view.AddInput("作者", "作者：", "");
                    view.AddFileInput("图标", "图标", "", "图标文件|*.ico");
                    break;
            }
        }

        public void OnPageChanging(int oldPageNum, int newPageNum, IWizardView view)
        {
            switch(oldPageNum)
            {
                case 0:
                    GameName = view.GetInput("游戏名称");
                    ProjectDir = view.GetPathInput("项目路径");
                    CreateDir = view.GetYesOrNo("是否建立目录");
                    break;
                case 1:
                    Author = view.GetInput("作者");
                    IconPath = view.GetFileInput("图标");
                    break;
            }
        }

        public void OnPageChanged(int pageNum, IWizardView view)
        {
            // ACHACK 下面这东西到底放那一层呢？
        }

        public override void ShowSummary(IWizardView view)
        {
            view.Clear();
            view.SetTitle("创建项目向导 - 信息确认页");
            StringBuilder strBldr = new StringBuilder();
            strBldr.AppendLine("1. 路径设置");
            strBldr.AppendLine("   游戏名称：" + GameName);
            strBldr.AppendLine("   项目路径：" + ProjectDir);
            strBldr.AppendLine("   是否建立项目文件夹：" + CreateDir);
            strBldr.AppendLine("2. 作者信息");
            strBldr.AppendLine("   作者：" + Author);
            strBldr.AppendLine("   图标：" + IconPath);

        }

        public override void Finish()
        {
            WizardModule wizMod = EditorService.Instance.QueryModule<WizardModule>(null);
            wizMod.PageChanging -= OnPageChanging;
            wizMod.WizardView.HideView();
        }

        public override void Cancel()
        {
            EditorService.Instance.QueryModule<WizardModule>(null).PageChanging -= OnPageChanging;
            EditorService.Instance.QueryModule<WizardModule>(null).WizardView.HideView();
        }
    }
}
