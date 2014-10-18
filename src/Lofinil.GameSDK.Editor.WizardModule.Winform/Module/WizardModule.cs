using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.Architecture;
using Lofinil.GameSDK.Editor;
using Lofinil.GameSDK.Editor.Interception.ModuleInterface;
using Lofinil.GameSDK.Editor.Module.FormView;
using Lofinil.GameSDK.Editor.Module.View;

namespace Lofinil.GameSDK.Editor.App
{
    [ModuleDependency("FormViewModule")]
    public class WizardModule : EditorModule, IWizardModule
    {
        public IWizardView WizardView;

        public Wizard Wizard;

        public int CurrentPageNumber
        {
            get { return currentPageNumber; }
        }

        public int PageCount { get { return Wizard.PageCount; } }

        private int currentPageNumber;

        public event Action<int, int, IWizardView> PageChanging;

        public WizardModule()
        {
            PageChanging += WizardManager_OnPageChanging;
        }

        public override void Load()
        {
            base.Load();
        }

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            EditorService.Instance.QueryModule<ViewModule>().RegisterView(new WizardForm(), true);
            
        }

        // 通常，Wizard视图是编辑器全局独占的视图，在Winform下以模态对话框的形式存在
        public void Start<T>() where T:Wizard, new()
        {
            Wizard = new T();
            FormViewModule viewMod = EditorService.Instance.QueryModule<FormViewModule>(null);
            WizardView = viewMod.QueryView<IWizardView>(null);

            Wizard.StartUp();

            currentPageNumber = -1;
            NextPage();

            WizardView.ShowView();
        }

        public void NextPage()
        {
            if (currentPageNumber == PageCount)
                Finish();

            PageChanging(currentPageNumber, currentPageNumber+1, WizardView);
            currentPageNumber++;
            Wizard.ShowPage(currentPageNumber, WizardView);
        }

        public void LastPage()
        {
            if (currentPageNumber == 0)
                return;

            PageChanging(currentPageNumber, currentPageNumber-1, WizardView);
            currentPageNumber--;
            Wizard.ShowPage(currentPageNumber, WizardView);
        }

        public void RefreshPage()
        {
            PageChanging(currentPageNumber, currentPageNumber, WizardView);
        }

        public void Cancel()
        {
            Wizard.Cancel();
            Wizard = null;
            currentPageNumber = -1;
        }

        // 向导结束，让所有设置发挥作用
        public void Finish()
        {
            Wizard.Finish();
        }


        public void WizardManager_OnPageChanging(int oldPageNum, int newPageNum, IWizardView view) { }

        public bool IsFirstPage(int pageNum)
        {
            if (pageNum == 0)
                return true;
            return false;
        }

        public bool IsLastPage(int pageNum)
        {
            if (pageNum == Wizard.PageCount + (Wizard.NeedSummary ? 1 : 0))
                return true;
            return false;
        }

    }
}
