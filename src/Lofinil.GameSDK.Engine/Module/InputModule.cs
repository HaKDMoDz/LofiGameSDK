using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Keyboard = Lofinil.GameSDK.Engine.Keyboard;
using Mouse = Lofinil.GameSDK.Engine.Mouse;
using System.ComponentModel;

namespace Lofinil.GameSDK.Engine
{
    // TODO [按键映射和按键序列支持] 需对输入设备API进行功能加强
    public class InputModule : BaseModule
    {
        protected Keyboard Keyboard;

        protected Mouse Mouse;

        protected KeyMap KeyMap;

        public InputModule()
        {
            Mouse = new Mouse();
            Keyboard = new Keyboard();
        }

        public override void Update()
        {
            base.Update();

            Keyboard.Update();
            Mouse.Update();
        }

        [Interact("确认游戏键按过")]
        public bool IsGameKeyJustPressed(String kName)
        {
            GameKey key = KeyMap.GetGameKey(kName);

            GameMouseKey mKey = key as GameMouseKey;
            if (mKey != null)
               return Mouse.IsButtonClicked(mKey.Button);

            GameKeyboardKey kKey = key as GameKeyboardKey;
            if (kKey != null)
                return Keyboard.IsKeyJustPressed(kKey.Key);

            return false;
        }

        [Interact("确认游戏键按下")]
        public bool IsGameKeyPressed(String kName)
        {
            GameKey key = KeyMap.GetGameKey(kName);

            GameMouseKey mKey = key as GameMouseKey;
            if (mKey != null)
                return Mouse.IsButtonPressed(mKey.Button);

            GameKeyboardKey kKey = key as GameKeyboardKey;
            if (kKey != null)
                return Keyboard.IsKeyJustPressed(kKey.Key);

            return false;
        }

        [Interact("确认游戏键释放")]
        public bool IsGameKeyJustReleased(String kName)
        {
            GameKey key = KeyMap.GetGameKey(kName);

            GameMouseKey mKey = key as GameMouseKey;
            if (mKey != null)
                return Mouse.IsButtonReleased(mKey.Button);

            GameKeyboardKey kKey = key as GameKeyboardKey;
            if (kKey != null)
                return Keyboard.IsKeyJustReleased(kKey.Key);

            return false;
        }

        [Category("Input"), Description("检查键按下")]
        public bool IsKeyPressed(Keys key) { return Keyboard.IsKeyPressed(key); }
        [Category("Input"), Description("检查键一次按下")]
        public bool IsKeyJustPressed(Keys key) { return Keyboard.IsKeyJustPressed(key); }


        public int MouseX { get { return Mouse.X; } }

        public int MouseY { get { return Mouse.Y; } }

        [Interact("输入", "检查鼠标键是否释放")]
        public bool IsButtonReleased(MouseButton button)
        {
            return Mouse.IsButtonReleased(button);
        }

        [Interact("输入", "检查鼠标键是否按下")]
        public bool IsButtonPressed(MouseButton button)
        {
            return Mouse.IsButtonReleased(button);
        }

        [Interact("输入", "检查鼠标键是否完成点击")]
        public bool IsButtonClicked(MouseButton button)
        {
            return Mouse.IsButtonClicked(button);
        }
    }

    public class GameKey
    {
        public String Name{get; set;}

        public GameKey(String name) { Name = name; }

        public virtual void Empty()
        {}

        public virtual bool IsPressed()
        {
            return false;
        }

        public virtual bool IsDown()
        {
            return false;
        }

        public virtual bool IsUp()
        {
            return false;
        }
    }

    public class GameKeyNull : GameKey
    {
        public GameKeyNull Instance 
        { 
            get{
                if(ins == null)
                    ins = new GameKeyNull();
                return ins;
            }
        }
        private GameKeyNull ins;

        private GameKeyNull() : base("")
        {}

        public new String Name { get { return ""; } set { } }
    }

    public class GameMouseKey : GameKey
    {
        public MouseButton Button{get; set;}

        public GameMouseKey(String name, MouseButton button) : base(name)
        {
            Button = button;
        }

        public override void Empty()
        {
            Button = MouseButton.None;
        }
    }

    public class GameMouseKeyNull : GameMouseKey
    {
        public GameMouseKeyNull Instance
        {
            get
            {
                if (ins == null)
                    ins = new GameMouseKeyNull();
                return ins;
            }
        }
        private GameMouseKeyNull ins;

        public GameMouseKeyNull()
            : base("", MouseButton.None)
        { }

        public new String Name { get { return ""; } set { } }

        public new MouseButton Button { get { return MouseButton.None; } set { } }
    }

    public class GameKeyboardKey : GameKey
    {
        public Keys Key;

        public GameKeyboardKey(String name, Keys key) : base(name)
        {
            Key = key;
        }

        public override void Empty()
        {
            Key = Keys.None;
        }
    }

    public class GameKeyboardKeyNull : GameKeyboardKey
    {
        public GameKeyboardKeyNull Instance
        {
            get
            {
                if (ins == null)
                    ins = new GameKeyboardKeyNull();
                return ins;
            }
        }
        private GameKeyboardKeyNull ins;

        public GameKeyboardKeyNull()
            : base("", Keys.None)
        { }

        public new String Name { get { return ""; } set { } }

        public new Keys Key { get { return Keys.None; } set { } }
    }

    public class KeyMap
    {
        public List<GameKey> GameKeys = new List<GameKey>();

        public GameKey GetGameKey(String name)
        {
            return GameKeys.Find(k => k.Name == name);
        }

        public bool IsGKeyExist(String name)
        {
            return GameKeys.Exists(k => k.Name == name);
        }

        public void SetGameKey(String name, Keys key)
        {
            GameKeyboardKey gKey = GameKeys.Find(k => k.Name == name) as GameKeyboardKey;
            if (gKey != null)
                gKey.Key = key;
        }

        public void SetGameKey(String name, MouseButton button)
        {
            GameMouseKey gKey = GameKeys.Find(k => k.Name == name) as GameMouseKey;
            if (gKey != null)
                gKey.Button = button;
        }

        public void AddGameKey(GameKey gameKey)
        {
            if (IsGKeyExist(gameKey.Name))
                return;
            GameKeys.Add(gameKey);
        }

        public void AddGameKey(String name, Keys key)
        {
            if (IsGKeyExist(name))
                return;
            GameKeys.Add(new GameKeyboardKey(name, key));
        }

        public void AddGameKey(String name, MouseButton button)
        {
            if (IsGKeyExist(name))
                return;
            GameKeys.Add(new GameMouseKey(name, button));
        }

        public void EmptyGKey(String name)
        {
            GameKey key = GetGameKey(name);
            key.Empty();
        }

        public void EmptyAll()
        {
            foreach (GameKey k in GameKeys)
                k.Empty();
        }

        public void ClearGKey(String name)
        {
            GameKeys.RemoveAll(k => k.Name == name);
        }

        public void ClearAll()
        {
            GameKeys.Clear();
        }

        #region Load & Save

        public static KeyMap LoadKeyMap(String path)
        {
            KeyMap keyMap =
                (KeyMap)XmlSerialize.Deserialize(path, typeof(KeyMap));
            return keyMap;
        }

        public static void SaveKeyMap(KeyMap keyMap, String path)
        {
            XmlSerialize.Serialize(path, typeof(KeyMap), keyMap);
        }

        #endregion Load & Save
    }
}
