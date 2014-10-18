using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;

namespace LPGView
{
    [AddInBase]
    public abstract class LPGView
    {
        public abstract void OnStart(object sender, EventArgs e);
        public abstract void OnUpdate(object sender, EventArgs e);
        public abstract void OnDraw(object sender, EventArgs e);
        public abstract void OnStop(object sender, EventArgs e);
    }
}
