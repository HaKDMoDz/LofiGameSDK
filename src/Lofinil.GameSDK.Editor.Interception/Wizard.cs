using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor;

namespace Lofinil.GameSDK.Editor.App
{
    public abstract class Wizard
    {
        public String Name;

        public int PageCount;

        public bool NeedSummary;

        public abstract void StartUp();

        public abstract void ShowPage(int pageNumber, IWizardView view);

        // 只有将ShowSummary设置为true时才有必要实现该函数
        public abstract void ShowSummary(IWizardView view);

        public abstract void Finish();

        public abstract void Cancel();
    }
}
