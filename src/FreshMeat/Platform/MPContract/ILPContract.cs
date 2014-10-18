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
    public interface ILPContract : IContract
    {
        void OnStart(object sender, EventArgs e);
        void OnUpdate(object sender, EventArgs e);
        void OnDraw(object sender, EventArgs e);
        void OnStop(object sender, EventArgs e);
    }

}
