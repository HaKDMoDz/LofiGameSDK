using System;
using System.Windows.Forms;
using LofiEngine.Games;
using LofiEngine.Screens;
using Screen = LofiEngine.Screens.Screen;
using Label = LofiEngine.Interfaces.Texts.Label;
using Button = LofiEngine.Interfaces.Buttons.Button;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Helpers;
using System.Collections.Generic;
using LofiEngine.Players;
using LofiEngine;

namespace BreakOutMario.Screens
{
    class LoadProfileScreen
    {
        public static void Add()
        {
            Screen loadProfile = new Screen();
            loadProfile.Load += LoadProfile_Load;
            loadProfile.KeyPress += LoadProfile_KeyPress;
            ModuleSharer.ScreenMgr.Screens.Add("LoadProfile", loadProfile);
        }
            
        private static void LoadProfile_Load(Object sender, EventArgs e)
        {
            Screen screen = (Screen)sender;
            Texture2D loadBackground = LoadHelper.LoadTexture2D("GameUI/Backgrounds/ProfileBg");

            Texture2D n = LoadHelper.LoadTexture2D("GameUI/Buttons/MenuItem0");
            Texture2D bm = LoadHelper.LoadTexture2D("GameUI/Buttons/MenuItem");
            Texture2D p = LoadHelper.LoadTexture2D("GameUI/Buttons/MenuItem");
            Button btn;

            Label lbl_background = new Label(loadBackground, "", 0, 0, GameConsts.Width, GameConsts.Height);
            screen.UIMgr.Add(lbl_background);

            // 获取玩家文件夹
            List<String> playerList = LoadHelper.GetPlayerNames();
            int ypos = 150;
            foreach (String playerName in playerList)
            {
                String pn = playerName;
                btn = new Button(n, bm, p, pn, delegate { ModuleSharer.ScreenMgr.ChangeGameScreen("Scene"); ModuleSharer.PlayerMgr.LoadProfile(playerName); ModuleSharer.SceneMgr.LoadScene(ModuleSharer.PlayerMgr.playerData.SceneName); /* LoadSavedGame(pn); */}, 240, ypos, 200, 40);
                screen.UIMgr.Add(btn);
                ypos += 50;
            }
            btn = new Button(
                LoadHelper.LoadTexture2D("GameUI/Buttons/Back0"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/Back"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/Back"),
                "", delegate { ModuleSharer.ScreenMgr.ChangeGameScreen("MainMenu"); }, 40, 350, 200, 60);
            screen.UIMgr.Add(btn);   // 返回
        }
        private static void LoadProfile_KeyPress(Object sender, KeyPressEventArgs e)
        {
            ModuleSharer.ScreenMgr.ChangeGameScreen("MainMenu");
        }
    }
}
