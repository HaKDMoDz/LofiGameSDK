using System.Collections.Generic;

namespace Lofinil.GameSDK.Engine
{
    public class Trigger
    {
        public Event Event;

        public List<Condition> ConditionList;

        public List<Action> ActionList;

        public bool IsTriggered { get; set; }

        public Trigger()
        {
        }

        public void EventOccured(Event e)
        {
            GameService game = GameService.Instance;

            if (!Event.Occured)
                return;

            foreach (Condition c in ConditionList)
            {
                if (!c.Check(game))
                    return;
            }
            foreach (Action a in ActionList)
                a.Run(game);
        }
    }
}