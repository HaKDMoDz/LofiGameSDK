using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using LPGView;
using LPContract;
using LofiEngine.Items;

namespace LPGAdapter
{
    [AddInAdapter]
    internal class ContractToCEGViewAdapter : CEGView
    {
        ICEContract contract;
        private ContractHandle handle;

        public void ContractToCEGViewAdapter(ICEContract contract)
        {
            this.contract = contract;
            handle = new ContractHandle(contract);
        }

        public override void AddItem(Item item)
        {
            contract.AddItem(item);
        }
    }
}
