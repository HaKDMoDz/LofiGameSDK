using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMediaService;
using LofiEngine.Items;
using LofiEngine.Graphics;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using LofiEngine;

namespace LofiEditor.Controls
{
    class AnimViewer : GraphicsDeviceControl
    {
        #region Variables
        public AnimTexture AnimTexture = null;
        #endregion

        protected override void Update()
        {
            if (AnimTexture != null)
                AnimTexture.Update();
        }

        protected override void Draw()
        {
            if (AnimTexture == null)
                return;

            ModuleSharer.GraphicsMgr.DrawBegin();
            AnimTexture.Draw(null, 0, null, null, null);
            ModuleSharer.GraphicsMgr.DrawEnd();
        }
    }
}
