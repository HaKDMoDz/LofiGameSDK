using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor.Module.ResourceSet
{
    public class ProjectItemResource : ProjectItem
    {
        public String Pipeline;
        public String ProcessParams;
    }

    public class ProjectItemResourceSet : ProjectItem
    {
    }

    public class ProjectItemImageResource : ProjectItemResource
    {
    }

    public class ProjectItemSoundResource : ProjectItemResource
    {
    }
}
