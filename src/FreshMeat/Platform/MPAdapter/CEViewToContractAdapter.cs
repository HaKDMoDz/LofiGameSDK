using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using LPView;
using LPContract;
using LofiEngine.Items;

namespace LPAdapter
{
    [HostAdapter]
    internal class CEViewToContractAdapter : ContractBase, ICEContract
    {
        private CEView view;

        public CEViewToContractAdapter(CEView view)
        {
            this.view = view;
        }

        public void AddItem(Item item)
        {
            view.AddItem(item);
        }
    }
}
