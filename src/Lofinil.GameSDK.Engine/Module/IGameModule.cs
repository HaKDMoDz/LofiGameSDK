using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.Architecture;

namespace Lofinil.GameSDK.Engine
{
    public interface IGameModule : IModule, IDisposable
    {
        void Update();

        void Draw();
    }
}
