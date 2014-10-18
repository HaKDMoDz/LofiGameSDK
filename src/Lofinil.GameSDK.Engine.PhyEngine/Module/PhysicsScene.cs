using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Componsite;
using LofiEngine.Game;

namespace LofiEngine.Module
{
    // 物理类游戏场景
    public class PhysicsScene
    {
        private String targetProchLabel = "";           // 待迁移 用于需要场景切换，事件卸载时缓存角色出现的门廊

        public void MoveToProch()
        {
            AbstractComponent proch = GameManager.Instance.StageMgr.GetItemByName(targetProchLabel);

            AbstractComponent role = GameManager.Instance.StageMgr.CurRole;

            Transform roleTrans = role.GetCompByType(typeof(Transform)) as Transform;
            Transform prochTrans = proch.GetCompByType(typeof(Transform)) as Transform;
            roleTrans.Position = prochTrans.Position;
        }
    }
}
