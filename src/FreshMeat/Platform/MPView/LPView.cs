using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LPView
{
    public abstract class LPView
    {
        public abstract void OnStart(object sender, EventArgs e);
        public abstract void OnUpdate(object sender, EventArgs e);
        public abstract void OnDraw(object sender, EventArgs e);
        public abstract void OnStop(object sender, EventArgs e);
    }
}
