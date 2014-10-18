using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using LPContract;

namespace LPAdapter
{
    [HostAdapter]
    internal class ContractToLPViewAdapter : LPView.LPView
    {
        private ILPContract contract;
        private ContractHandle handle;

        public ContractToLPViewAdapter(ILPContract contract)
        {
            this.contract = contract;
            handle = new ContractHandle(contract);
        }

        public override void OnStart(object sender, EventArgs e)
        {
            contract.OnStart(sender, e);
        }

        public override void OnUpdate(object sender, EventArgs e)
        {
            contract.OnUpdate(sender, e);
        }

        public override void OnDraw(object sender, EventArgs e)
        {
            contract.OnDraw(sender, e);
        }

        public override void OnStop(object sender, EventArgs e)
        {
            contract.OnStop(sender, e);
        }
    }
}
