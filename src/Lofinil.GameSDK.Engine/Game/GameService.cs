using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Lofinil.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Keyboard = Lofinil.GameSDK.Engine.Keyboard;
using Mouse = Lofinil.GameSDK.Engine.Mouse;

namespace Lofinil.GameSDK.Engine
{
    // wiki:///E:/CodeDir/LofiGameSDK/Wiki/LofiGameSDK/Lofinil%20Game%20SDK.wiki?page=ExecuteMode%20Enum
    public enum ExecuteMode
    {
        DesignTime,     // 嵌入编辑器中
        TestTime,       // 编辑器调试
        RunTime,        // 实际运行
    }

    // wiki:///E:/CodeDir/LofiGameSDK/Wiki/LofiGameSDK/Lofinil%20Game%20SDK.wiki?page=GameManager%20Class
    public class GameService : IService
    {
        public static GameService Instance { get { if (instance == null) instance = new GameService(); return instance; } }
        private static GameService instance;

        public ExecuteMode ExecuteMode { get; private set; }

        public IServiceProvider Services { get; private set; }

        public GraphicsDevice Device{ get; private set;}

        public bool Initialized{get; private set;}

        public GameConfig GameConfig;

        public Dictionary<String, IGameModule> ManagerDic = new Dictionary<string, IGameModule>();

        public List<IGameModule> GameModuleList;

        public event EventHandler<EventArgs> GameInitialized;

        public GameService()
        {
            GameModuleList = new List<IGameModule>();
        }

        // 建议重载
        public void Initialize(ExecuteMode exeMode, GraphicsDevice device)
        {
            ServiceContainer sc = new ServiceContainer();
            // NOTE 必须写成IGraphicsDeviceService类型
            sc.AddService(typeof(IGraphicsDeviceService), GraphicsDeviceService.instance);
            Initialize(exeMode, device, sc);
        }

        public void SetDevice(GraphicsDevice device)
        {
            // 设置图形设备时，与此设备相关的模块可能要重新初始化

            // HACK...
            if (Initialized)
                return;
            ExecuteMode = ExecuteMode.DesignTime;
            Device = device;

            foreach (IModule mod in GameModuleList)
            {
                mod.Initialize(this);
            }

            Initialized = true;

            if (GameInitialized != null)
                GameInitialized(this, null);
        }

        // 过时的
        public void Initialize(ExecuteMode exeMode, GraphicsDevice device, IServiceProvider services)
        {
            if (Initialized)
                return;
            ExecuteMode = exeMode;
            Device = device;
            Services = services;

            foreach (IModule mod in GameModuleList)
            {
                mod.Initialize(this);
            }

            Initialized = true;

            if (GameInitialized != null)
                GameInitialized(this, null);
        }

        public void Uninitialize()
        {
            // 清空设备和服务
            Device = null;
            Services = null;

            // 清空模块
            foreach (IModule mod in GameModuleList)
            {
                mod.Uninitialize();
            }
            GameModuleList.Clear();

            // 清空消息处理函数
            GameInitialized = null;

            // 标记为未初始化
            Initialized = false;
        }

        // 加载配置和公共资源
        public void LoadGameConfig(String configFile)
        {
            GameConfig = (GameConfig)XmlSerialize.Deserialize(configFile, typeof(GameConfig));
        }

        public void Update()
        {
            foreach(IModule mod in GameModuleList)
            {
                // TODO 按模块关系排序的Update
                if (mod is IGameModule)
                    ((IGameModule)mod).Update();
            }
        }

        public void Draw()
        {
            QueryModule<GraphicsModule>().Clear(Microsoft.Xna.Framework.Color.Gray);
            QueryModule<GraphicsModule>().DrawBegin();
            foreach (IModule mod in GameModuleList)
            {
                // TODO 按模块关系排序的Draw
                if (mod is IGameModule)
                    ((IGameModule)mod).Draw();
            }
            QueryModule<GraphicsModule>().DrawEnd();
        }

        public void Quit()
        {
            // TODO [清理] 引擎关闭前的清理
        }

        [Category("Game"), Description("将所有的游戏内容绘制到图片文件上")]
        public void RenderGameToFile(String path)
        {
            QueryModule<GraphicsModule>().RenderToFile(this.Draw, path);
        }

        public Bitmap RenderCallToBitmap(System.Action call)
        {
            Texture2D t = QueryModule<GraphicsModule>().RenderToTexture(call);
            byte[] data = new byte[4 * t.Width * t.Height];
            t.GetData<byte>(data);

            Bitmap bmp = new Bitmap(t.Width, t.Height);
            BitmapData dat = bmp.LockBits(
                new System.Drawing.Rectangle(0, 0, t.Width, t.Height),
                System.Drawing.Imaging.ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(data, 0, dat.Scan0, 4 * t.Width * t.Height);
            bmp.UnlockBits(dat);

            Console.WriteLine(bmp.GetPixel(100, 100));
            return bmp;
        }

        public Bitmap RenderGameToBitmap()
        {
            return RenderCallToBitmap(this.Draw);
        }

        [Category("Game"), Description("游戏窗口宽度")]
        [InteractAttribute("游戏窗口宽度")]
        public int Width { get { return GameConfig.Width; } }

        [Category("Game"), Description("游戏窗口高度")]
        public int Height { get { return GameConfig.Height; } }

        [Category("Scene"), Description("玩家角色位置")]
        public Vector2 RolePosition { get { return QueryModule<StageModule>().CurRole.Children.QueryComponent<Transform>().Position; } }

        [Category("Scene"), Description("场景的名称")]
        public String SceneName { get { return QueryModule<StageModule>().CurStageName; } }

        // NOTE 要调用这个顶级ChangeScene方法，而不要直接调用StageManager的ChangeScene
        // 使用ActionStack能够避免资源引用的冲突
        [Category("Scene"), Description("切换场景")]
        public void ChangeScene(String sceneName)
        {
            ActionFunction csAction = new ActionFunction();
            csAction.FuncName = "ChangeScene";
            csAction.Caller = new TopAccessor("StageManager");
            csAction.Params = new List<Accessor>();
            csAction.Params.Add(new VariableAccessor(sceneName));
            this.QueryModule<ActionStack>().Push(csAction);
        }

        // 时间
        [Category("Game"), Description("当前帧所耗毫秒")]
        public long FrameTimeInMs { get { return QueryModule<TimeModule>().FrameTimeInMs; } }
        public float FrameTimeInS { get { return QueryModule<TimeModule>().FrameTimeInS; } }
        [Category("Game"), Description("游戏总时间秒")]
        public double TotalTimeInS { get { return QueryModule<TimeModule>().TotalTimeInS; } }
        [Category("Game"), Description("游戏总时间毫秒")]
        public long TotalTimeInMs { get { return QueryModule<TimeModule>().TotalTimeInMs; } }

        // 按键
        [Category("Input"), Description("检查映射键按下")]
        public bool IsGameKeyPressed(String kName) { return QueryModule<InputModule>().IsGameKeyPressed(kName); }

        [Category("Input"), Description("检查映射键一次按下")]
        public bool IsGameKeyJustPressed(String kName) { return QueryModule<InputModule>().IsGameKeyJustPressed(kName); }
        [Category("Input"), Description("检查映射键一次放开")]
        public bool IsGameKeyJustReleased(String kName) { return QueryModule<InputModule>().IsGameKeyJustReleased(kName); }

        [Category("Game"), Description("获取范围内的随机整数")]
        public int GetRandomInt(int min, int max) { return QueryModule<LE_Random>().GetRandomInt(min, max); }


        void IService.RegistModule(IModule mod)
        {
            RegistModule((IGameModule)mod);
        }

        public void RegistModule(IGameModule mod)
        {
            GameModuleList.Add(mod);
        }

        public void RegistModule(IModule mod, object[] args)
        {
            RegistModule((IGameModule)mod, args);
        }

        public void RegistModule(IGameModule mod, object[] args)
        {
            GameModuleList.Add(mod);
        }

        public T QueryModule<T>(object[] args)
        {
            foreach (IModule mod in GameModuleList)
            {
                if (mod is T)
                    return (T)mod;
            }
            return default(T);
        }

        public T QueryModule<T>()
        {
            foreach (IModule mod in GameModuleList)
            {
                if (mod is T)
                    return (T)mod;
            }
            return default(T);
        }
    }
}