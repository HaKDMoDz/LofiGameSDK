using System;
using System.Windows.Forms;
using LofiEngine.Games;
using LofiEngine.Screens;
using Screen = LofiEngine.Screens.Screen;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Helpers;
using Label = LofiEngine.Interfaces.Texts.Label;
using Button = LofiEngine.Interfaces.Buttons.Button;
using LofiEngine;

namespace BreakOutMario.Screens
{
    class OptionScreen
    {
        public static void Add()
        {
            Screen option = new Screen();
            option.Load += Option_Load;
            option.KeyPress += Option_KeyPress;
            ModuleSharer.ScreenMgr.Screens.Add("Option", option);
        }

        private static void Option_Load(Object sender, EventArgs e)
        {
            Screen screen = (Screen)sender;
            Texture2D optionBackground = LoadHelper.LoadTexture2D("GameUI/Backgrounds/OptionBg");
            Texture2D n = LoadHelper.LoadTexture2D("GameUI/Buttons/MenuItem0");
            Texture2D bm = LoadHelper.LoadTexture2D("GameUI/Buttons/MenuItem");
            Texture2D p = LoadHelper.LoadTexture2D("GameUI/Buttons/MenuItem");

            Label lbl_background = new Label(optionBackground, "", 0, 0, GameConsts.Width, GameConsts.Height);
            screen.UIMgr.Add(lbl_background);
            Button btn;
            btn = new Button(
                LoadHelper.LoadTexture2D("GameUI/Buttons/Back0"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/Back"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/Back"),
                "", delegate { ModuleSharer.ScreenMgr.ChangeGameScreen("MainMenu"); }, 40, 350, 200, 60);
            screen.UIMgr.Add(btn);   // 返回
        }
        private static void Option_KeyPress(Object sender, KeyPressEventArgs e)
        {
            ModuleSharer.ScreenMgr.ChangeGameScreen("MainMenu");
        }

    }
}
