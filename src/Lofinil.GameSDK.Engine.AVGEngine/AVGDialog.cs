using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.TriggerAction;

namespace LofiEngine.AVGModule
{
    // Adventure Game 分支对话系统
    public class AVGDialog
    {
        public int CurActionId;

        public void Update()
        {
            // TODO 完成AVG的阻断功能
            //if (!IsTriggered)
            //{
            //    foreach (Event e in EventList)
            //        if (e.Check(Game) == false)
            //            return;
            //    IsTriggered = true;
            //}

            //if (IsTriggered)
            //{
            //    bool isDone = ActionList[CurActionId].Run(Game);
            //    if (isDone) CurActionId++;
            //    if (CurActionId >= ActionList.Count)
            //        IsTriggered = false;
            //}
            //UpdateDrama();
        }

        /// <summary>
        /// 更新剧本
        /// </summary>
        public void UpdateDrama()
        {
            // UNDONE 废弃该方法
            // dialogStr = "";
            // asideStr = "";
            //CurActionId++;

            //if (CurActionId >= ActionList.Count)
            //{
            //    EndDrama();
            //}
            //else
            //{
            //    ActionList[CurActionId].Run(Game);
            //}
        }

        // 无条件启动该触发器的行为
        // NOTE 下次Update时执行
        public void StartAction()
        {
            //IsTriggered = true;
        }

        // 无条件结束触发器行为
        // UNDONE 清理事件、条件和的行为中间量
        public void EndAction()
        {
            //IsTriggered = false;
        }

        public void StartDrama(string dramaName)
        {
            // IsTriggered = true;
            // UNDONE 资源路径
           // Trigger trigger = (Trigger)XmlSerialize.Deserialize(ContentDir + "\\" + dramaName + "." + "Dra", typeof(TriggerData));
           // ActionList = trigger.ActionList;
            //UpdateDrama();
        }

        public void EndDrama()
        {
           // Game.ACGScreen.HideDialog();
           // Game.ACGScreen.roleLeft = null;
           // Game.ACGScreen.roleMiddle = null;
           // Game.ACGScreen.roleRight = null;

           // ActionList = null;
           // IsTriggered = false;
        }
    }
}
