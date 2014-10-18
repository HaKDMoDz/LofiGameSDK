using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Editor.App;

namespace Lofinil.GameSDK.Editor.Interception.ModuleInterface
{
    public interface IWizardModule
    {
        void Start<T>() where T : Wizard, new();
    }
}
