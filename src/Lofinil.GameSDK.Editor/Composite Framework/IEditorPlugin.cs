using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor.Composite_Framework
{
    public interface IEditorPlugin
    {
        bool Enabled { get; set; }

        void Initialize();

        void Uninitialize();
    }
}
