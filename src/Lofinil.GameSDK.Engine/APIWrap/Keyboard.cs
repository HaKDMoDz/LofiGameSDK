using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;

namespace Lofinil.GameSDK.Engine
{
    public class Keyboard
    {
        private KeyboardState lastKeyState;
        private KeyboardState curKeyState;

        public void Update()
        {
            lastKeyState = curKeyState;
            curKeyState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }

        public Keys[] KeysPressed()
        {
            return curKeyState.GetPressedKeys();
        }

        public bool IsKeyPressed(Keys k)
        {
            return curKeyState.IsKeyDown(k);
        }

        public bool IsKeyJustPressed(Keys k)
        {
            return curKeyState.IsKeyDown(k) && !lastKeyState.IsKeyDown(k);
        }

        public bool IsKeyJustReleased(Keys k)
        {
            if (curKeyState.IsKeyUp(k) && lastKeyState.IsKeyDown(k))
            {
                return true;
            }
            return false;
        }
    }
}