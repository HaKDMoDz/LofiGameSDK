using System;
using System.Windows.Forms;
using LofiEngine.Device;
using LofiEngine.Games;

namespace LofiEngine.Screen
{
    public class Screen
    {
        public GameManager Game;

        public event EventHandler Load;

        public event KeyPressEventHandler KeyPress;

        public Screen(GameManager game)
        {
            Game = game;
        }

        public void Show()
        {
            if (Load != null)
                Load(this, null);
        }

        public void Update()
        {
            if (KeyPress != null && Keyboard.hasKeyPressed())
            {
                KeyPressEventArgs args = new KeyPressEventArgs((char)Keyboard.KeyPressed()[0]);
                KeyPress(this, args);
            }
        }

        public void Draw()
        {
        }
    }
}