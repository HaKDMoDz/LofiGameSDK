using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor
{
    public interface IEditorModule
    {
        EditorService EditorMgr { get; }

        bool Enabled { get; set; }

        void Initialize();

        void Uninitialize();
    }
}
