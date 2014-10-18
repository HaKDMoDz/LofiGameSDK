using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using LPGView;
using System.AddIn.Contract;
using LPContract;

namespace LPGAdapter
{
    // ContractBase 提供了基本的生命周期管理方法
    [AddInAdapter]
    internal class LPGViewToContractAdapter : ContractBase, ILPContract
    {
        private LPGView.LPGView view;

        public LPGViewToContractAdapter(LPGView.LPGView view)
        {
            this.view = view;
        }

        #region IMPContract Members
        public void OnStart(object sender, EventArgs e)
        {
            view.OnStart(sender, e);
        }

        public void OnStop(object sender, EventArgs e)
        {
            view.OnStop(sender, e);
        }

        public void OnUpdate(object sender, EventArgs e)
        {
            view.OnUpdate(sender, e);
        }

        public void OnDraw(object sender, EventArgs e)
        {
            view.OnDraw(sender, e);
        }
        #endregion
    }
}
