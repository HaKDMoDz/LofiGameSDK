using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.Architecture
{
    // Component和Module有点像，Module是平行结构，Component是树形结构
    public interface IComponent
    {
        // 父级组件
        IComponent Parent { get; set; }

        // 子组件
        IComponentContainer Children { get; }

        // 是否启用
        bool Enabled { get; }

        bool Initialized { get; }

        bool Loaded { get; }

        void Initialize();

        // 加载相关资源
        void Load();

        // 卸载相关资源
        void Unload();

        // 取消初始化
        void Uninitialize();

        // 创建一个深层拷贝
        IComponent Clone();

        // 创建一个浅层拷贝
        IComponent ShallowCopy();

    }

    public interface IComponentContainer
    {
        // 添加子组件
        void Add(IComponent component);

        // 移除子组件
        void Remove(IComponent component);

       //  T QueryComponent<T>() where T:IComponent;
    }
}
