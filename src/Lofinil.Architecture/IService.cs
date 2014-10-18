using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.Architecture
{
    // IModule的容器，在应用程序中作模块全局共享者存在
    public interface IService
    {
        // 标识服务是否初始化
        bool Initialized { get; }

        // 注册一个模块
        void RegistModule(IModule mod);
        void RegistModule(IModule mod, Object[] args);

        // 请求一个模块
        T QueryModule<T>();
        T QueryModule<T>(Object[] args);
    }
}
