using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor.Interception.ModuleInterface
{
    public interface IResourceSetModule
    {
        int Read(String path);

        void Active(int id);
    }
}
