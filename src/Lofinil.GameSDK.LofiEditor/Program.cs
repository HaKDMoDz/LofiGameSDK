using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lofinil.GameSDK.Editor.Shell
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LofiGameEditorBootstrapper boot = new LofiGameEditorBootstrapper();
            boot.LoadModules();
            boot.Startup();
            boot.Initialize();
        }
    }
}
