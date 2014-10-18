using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Editor
{
    // 表示可以控制绘制的画布视图
    public interface ICanvasView : IView
    {
        // NOTE [ICanvas为何是空接口？] 对于一个抽象的画布可以做太多的操作，进而抽象图片、画笔、刷子... 没完没了了。
        // 因此调度层（MVC的C或MVP的P或我自己的模式...）对ICanvas制作共享（客户代码可用QueryView获取），而不做控制（不会视图绘制任何东西，绘制行为作为扩展由客户代码实现）
        // NOTE [客户代码必须自行确定ICanvas的类型] 客户代码依赖于Canvas实体的类型，在请求到ICanvas之后要自行强制转换为实体类型再使用

        // abstract void AddDrawCallback(EventArgs);

        // abstract void RemoveDrawCallback();
    }
}
