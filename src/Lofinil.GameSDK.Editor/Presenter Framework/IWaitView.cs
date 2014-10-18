using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Lofinil.GameSDK.Editor
{
    // 等待视图 - 在等待某项任务完成时呈现的视图。通常是一个模态等待窗口，也可能是让整个界面变暗的遮罩控件等，也可能仅冻结客户视图的一部分甚至不冻结任何东西仅仅是一个存在并行任务执行的信息显示。
    // 实际应用中，发生旁支任务的需要一般另开了Thread或者Process。使用回调的方式进行操作让等待视图无需知道到底是什么类型的任务，另外呈现器也可以将必要的信息另行通知该视图来呈现
    public interface IWaitView : IView
    {
        // StartTask时等待也就开始了，在StartTask之前必须注册任务回调，在StartTask中调用该回调
        void StartTask();

        // 该视图要接受启动任务的回调，在视图内部调用该回调真正启动任务
        void SetTaskBeginCallback(Action p);

        // 在呈现器层，可以在任务产生文本信息时经过这个回调通知视图，视图可做任意呈现
        void TextInfoCallback(String info);

        void TaskEndCallback(int code);
    }
}
