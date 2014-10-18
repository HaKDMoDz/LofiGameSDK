using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LPGView;
using System.AddIn;
using BreakOutMario.Screens;
using LofiEngine.Scenes;
using LofiEngine.Items;
using Microsoft.Xna.Framework;
using LofiEngine;

namespace BreakOutMario
{
    [AddIn("BreakOutMario", Publisher = "Lofi", Version = "1.0.0.0", Description = "Mario is breaking out!")]
    public class Class1 : LPGView.LPGView
    {
        public override void OnStart(object sender, EventArgs e)
        {
           // MainMenuScreen.Add();
           // LoadProfileScreen.Add();
           // OptionScreen.Add();
           // SceneScreen.Add();
        }

        public override void OnUpdate(object sender, EventArgs e)
        {
        }

        public override void OnDraw(object sender, EventArgs e)
        {
            Item i = new Item();
            i.Position = new Vector2(100, 100);
            ModuleSharer.SceneMgr.AddItem(null, i);
        }

        public override void OnStop(object sender, EventArgs e)
        {
        }
    }
}
