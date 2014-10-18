using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using System.AddIn.Contract;
using LofiEngine.Items;

namespace LPContract
{
    [AddInContract]
    public interface ICEContract : IContract
    {
        // Child Class of Item?
        void AddItem(Item item);
    }
}
