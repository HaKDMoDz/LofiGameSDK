using System;

namespace Lofinil.GameSDK.Engine
{
    public delegate void ObjectEventHandler(object publisher, object eventArgs);

    // TODO [Event和event] 建立好触发器事件和代码事件的运行时联系
    public class Event
    {
        // 编辑结构
        public Accessor Publisher;              // 事件发布者

        public String EventName;                // 事件名称 

        // 运行结构
        [NonSerialized]
        public bool Occured;                    // 事件已发生 - 用于多事件并发检查

        [NonSerialized]
        public Trigger Trigger;                 // 所属触发器

        [NonSerialized]
        public object EventArgs;                // 事件参数

        public Event()
        { }

        public Event(Accessor publisher, String eventName)
        {
            Publisher = publisher;
            EventName = eventName;
        }

        // 万能的EventHandler
        public void EventHandler(object publisher, object eventArgs)
        {
            Occured = true;
            EventArgs = eventArgs;
            Trigger.EventOccured(this);
        }

        // 由Trigger调用来开启这个事件
        public void Enable(GameService game, bool enabled)
        {
            if (enabled)
            {
                Occured = false;        // 事件真正发生时才为true
                Object pub = Publisher.Access(game);
                pub.GetType().GetEvent(EventName).AddEventHandler(pub, new ObjectEventHandler(EventHandler));
            }
            else
            {
                Occured = true;         // 取消检查始终为true
                Object pub = Publisher.Access(game);
                pub.GetType().GetEvent(EventName).RemoveEventHandler(pub, new ObjectEventHandler(EventHandler));
            }
        }
    }
}