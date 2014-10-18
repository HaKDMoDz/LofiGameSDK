using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using LofiEngine.Items;

namespace LPGView
{
    [AddInBase]
    public abstract class CEGView
    {
        public abstract void AddItem(Item item);
    }
}
