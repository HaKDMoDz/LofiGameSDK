using System;
using System.Collections.Generic;
using LofiEngine.Games;

namespace LofiEngine.Screen
{
    public class ScreenManager
    {
        #region Variables

        public Dictionary<String, Screen> Screens = new Dictionary<string, Screen>();

        public GameManager Game;

        #endregion Variables

        #region Constructor

        public ScreenManager(GameManager game)
        {
            Game = game;
        }

        #endregion Constructor

        #region Handle Screen

        public void ChangeGameScreen(String screenName)
        {
            if (Screens.ContainsKey(screenName))
                Screens[screenName].Show();
        }

        #endregion Handle Screen
    }
}