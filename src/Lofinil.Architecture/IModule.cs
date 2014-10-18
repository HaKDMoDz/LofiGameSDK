using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.Architecture
{
    public interface IModule
    {
        // 模块必须包含在一个服务中才能够被共享
        IService Service { get; }

        // 标识已存在的模块是否启用
        bool Enabled { get; set; }

        // 标识模块是否初始化
        bool Initialized { get; }

        // 标识模块资源是否加载
        bool Loaded { get; }

        // 初始化模块
        void Initialize(IService service);

        // 加载模块资源
        void Load();

        // 卸载模块资源
        void Unload();

        // 取消初始化
        void Uninitialize();
    }
}
