using System;
using System.Windows.Forms;
using LofiEngine.Games;
using LofiEngine.Screens;
using Screen = LofiEngine.Screens.Screen;
using LofiEngine;
namespace BreakOutMario.Screens
{
    class SceneScreen
    {
        public static void Add()
        {
            Screen scene = new Screen();
            scene.Load += Scene_Load;
            scene.KeyPress += Scene_KeyPress;
            ModuleSharer.ScreenMgr.Screens.Add("Scene", scene);

        }
        private static void Scene_Load(Object sender, EventArgs e)
        {
            Screen screen = (Screen)sender;
            // TODO 临时不显示 需要提供显示开关
            //Texture2D rolePanelBg = LoadHelper.LoadTexture2D("GameUI/RolePanel/FaceBack");
            //Texture2D supplyBg = LoadHelper.LoadTexture2D("GameUI/RolePanel/Supplies");
            //Texture2D roleFace = LoadHelper.LoadTexture2D("Faces/RoyFace");
            //Texture2D lifeIcon = LoadHelper.LoadTexture2D("GameUI/RolePanel/LifeIcon");

            //Panel pnl_rolePanel = new Panel(rolePanelBg, rolePanelBg, "", 0, 0, 150, 0, 150);
            //Label lbl_roleFace = new Label(roleFace, "", 25, 15, 100, 100, pnl_rolePanel);
            //HealthBar htb_roleHealth = new HealthBar(lifeIcon, 10, 120, 150, 24, pnl_rolePanel);

            //pnl_rolePanel.AddChild(lbl_roleFace);
            //pnl_rolePanel.AddChild(htb_roleHealth);

            //Panel pnl_supplies = new Panel(supplyBg, supplyBg, "", 500, 550, 400, 0, 50);
            //Dictionary<String, Texture2D> supplyDic = new Dictionary<string, Texture2D>();
            //supplyDic.Add("Thorn", LoadHelper.LoadTexture2D("Icons/Thorn"));
            //SupplyBar spb_roleSupplies = new SupplyBar(supplyDic, 0, 0, 300, 50, pnl_supplies);
            //pnl_supplies.AddChild(spb_roleSupplies);


            //screen.UIMgr.Add_N(pnl_rolePanel);
            //screen.UIMgr.Add_N(pnl_supplies);
        }
        private static void Scene_KeyPress(Object sender, KeyPressEventArgs e)
        {
            ModuleSharer.ScreenMgr.ChangeGameScreen("MainMenu");
        }

    }
}
