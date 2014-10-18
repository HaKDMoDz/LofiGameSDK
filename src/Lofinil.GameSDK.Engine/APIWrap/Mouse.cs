using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lofinil.GameSDK.Engine
{
    public class Mouse
    {
        protected MouseState lastMouseState;
        protected MouseState curMouseState;

        public int X { get { return curMouseState.X; } }

        public int Y { get { return curMouseState.Y; } }

        public Point Position{get { return new Point(X, Y); }}

        public bool MouseMoved { get; private set; }

        public void Update()
        {
            lastMouseState = curMouseState;
            curMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();

            if (lastMouseState.X == curMouseState.X && lastMouseState.Y == curMouseState.Y)
                MouseMoved = true;
            else
                MouseMoved = false;
        }

        public ButtonState GetButtonState(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return curMouseState.LeftButton;
                case MouseButton.Right:
                    return curMouseState.RightButton;
                case MouseButton.Middle:
                    return curMouseState.MiddleButton;
                case MouseButton.X1:
                    return curMouseState.XButton1;
                case MouseButton.X2:
                    return curMouseState.XButton2;
            }
            return ButtonState.Released;
        }

        public bool IsButtonPressed(MouseButton button)
        {
            switch(button)
            {
                case MouseButton.Left:
                    return curMouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return curMouseState.RightButton == ButtonState.Pressed;
                case MouseButton.Middle:
                    return curMouseState.MiddleButton == ButtonState.Pressed;
                case MouseButton.X1:
                    return curMouseState.XButton1 == ButtonState.Pressed;
                case MouseButton.X2:
                    return curMouseState.XButton2 == ButtonState.Pressed;
            }
            return false;
        }

        public bool IsButtonReleased(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return curMouseState.LeftButton == ButtonState.Released;
                case MouseButton.Right:
                    return curMouseState.RightButton == ButtonState.Released;
                case MouseButton.Middle:
                    return curMouseState.MiddleButton == ButtonState.Released;
                case MouseButton.X1:
                    return curMouseState.XButton1 == ButtonState.Released;
                case MouseButton.X2:
                    return curMouseState.XButton2 == ButtonState.Released;
            }
            return false;
        }

        public bool IsButtonClicked(MouseButton button)
        {
            ButtonState lastBtnStat = ButtonState.Released;
            ButtonState curBtnStat = ButtonState.Released;

            switch (button)
            {
                case MouseButton.Left:
                    lastBtnStat = lastMouseState.LeftButton;
                    curBtnStat = curMouseState.LeftButton;
                    break;
                case MouseButton.Right:
                    lastBtnStat = lastMouseState.RightButton;
                    curBtnStat = curMouseState.RightButton;
                    break;
                case MouseButton.Middle:
                    lastBtnStat = lastMouseState.MiddleButton;
                    curBtnStat = curMouseState.MiddleButton;
                    break;
                case MouseButton.X1:
                    lastBtnStat = lastMouseState.XButton1;
                    curBtnStat = curMouseState.XButton2;
                    break;
                case MouseButton.X2:
                    lastBtnStat = lastMouseState.XButton2;
                    curBtnStat = curMouseState.XButton2;
                    break;
            }

            if (lastBtnStat == ButtonState.Pressed && 
                curBtnStat == ButtonState.Released)
                return true;
            return false;
        }
    }
}