using System;
using System.Windows.Forms;
using LofiEngine.Games;
using LofiEngine.Screens;
using Screen = LofiEngine.Screens.Screen;
using Microsoft.Xna.Framework.Graphics;
using Label = LofiEngine.Interfaces.Texts.Label;
using Button = LofiEngine.Interfaces.Buttons.Button;
using LofiEngine.Sounds;
using LofiEngine.Helpers;
using LofiEngine.Scenes;
using LofiEngine.Players;
using LofiEngine;

namespace BreakOutMario.Screens
{
    class MainMenuScreen
    {
        public static void Add()
        {
            Screen mainMenu = new Screen();
            mainMenu.Load += MainMenu_Load;
            mainMenu.KeyPress += MainMenu_KeyPress;
            ModuleSharer.ScreenMgr.Screens.Add("MainMenu", mainMenu);
        }
        private static void MainMenu_Load(Object sender, EventArgs e)
        {
            SoundMgr.Instance.PlaySong(LoadHelper.LoadSong("ForTheRed"));

            Screen screen = (Screen)sender;
            screen.UIMgr.Clear();

            Texture2D menuBackground = LoadHelper.LoadTexture2D("GameUI/Backgrounds/MainMenuBg");

            Texture2D n = LoadHelper.LoadTexture2D("GameUI/Buttons/MenuItem0");
            Texture2D bm = LoadHelper.LoadTexture2D("GameUI/Buttons/MenuItem");
            Texture2D p = LoadHelper.LoadTexture2D("GameUI/Buttons/MenuItem");

            Label lbl_background = new Label(menuBackground, "", 0, 0, GameConsts.Width, GameConsts.Height);
            screen.UIMgr.Add(lbl_background);

            Button btn;
            btn = new Button(
                LoadHelper.LoadTexture2D("GameUI/Buttons/NewGame0"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/NewGame"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/NewGame")
                , "", delegate
                {
                    ModuleSharer.ScreenMgr.ChangeGameScreen("Scene");
                    ModuleSharer.SceneMgr.LoadScene("Default");
                    ModuleSharer.PlayerMgr.NewPlayer();
                }
                , 300, 200, 200, 40); // 40 150
            screen.UIMgr.Add(btn);  // 新游戏
            btn = new Button(
                LoadHelper.LoadTexture2D("GameUI/Buttons/LoadGame0"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/LoadGame"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/LoadGame"),
                "", delegate { ModuleSharer.ScreenMgr.ChangeGameScreen("LoadProfile"); }, 300, 250, 200, 40);
            screen.UIMgr.Add(btn);  // 载入游戏
            btn = new Button(
                LoadHelper.LoadTexture2D("GameUI/Buttons/Option0"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/Option"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/Option"),
                "", delegate { ModuleSharer.ScreenMgr.ChangeGameScreen("Option"); }, 300, 300, 200, 40);
            screen.UIMgr.Add(btn);  // 选项
            btn = new Button(
                LoadHelper.LoadTexture2D("GameUI/Buttons/EditScene0"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/EditScene"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/EditScene"),
                "", delegate { ModuleSharer.ScreenMgr.ChangeGameScreen("EditScene"); }, 300, 350, 200, 40);
            screen.UIMgr.Add(btn);  // 编辑场景
            btn = new Button(
                LoadHelper.LoadTexture2D("GameUI/Buttons/Exit0"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/Exit"),
                LoadHelper.LoadTexture2D("GameUI/Buttons/Exit"),
                "", delegate { ModuleSharer.GameMgr.Quit(); }, 300, 400, 200, 40);
            screen.UIMgr.Add(btn);  // 退出
        }
        private static void MainMenu_KeyPress(Object sender, KeyPressEventArgs e)
        {
            ModuleSharer.GameMgr.Quit();
        }

    }
}
