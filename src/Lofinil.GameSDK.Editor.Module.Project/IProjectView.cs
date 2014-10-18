using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor
{
    public interface IProjectView : IView
    {
        void OnItemChanged();
    }
}
