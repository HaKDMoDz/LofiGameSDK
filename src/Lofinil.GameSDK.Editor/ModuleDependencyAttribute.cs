using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor
{
    public class ModuleDependencyAttribute : Attribute
    {
        public String Name;

        public ModuleDependencyAttribute(String name)
        {
            Name = name;
        }
    }
}
