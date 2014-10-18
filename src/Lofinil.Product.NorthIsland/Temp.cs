using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    class Temp
    {
        public void INit()
        {
            PhysicsManager.GDKeyMap(PhysicsManager.GravityDirection.Down);
        }


        #region TODO 需迁移 Handle Role
        /// <summary>
        /// 将角色放置在门廊处
        /// </summary>
        /// <param name="prochLabel"></param>
        //public void PutRoleToProch(String prochLabel)
        //{
        //    if (role == null)
        //        CreateRole();

        //    // 如果prochLabel为空
        //    // 1. 场景制作失误
        //    // 2. 这个场景中不需要出现人物，或者角色并不一开始就出现，有其他事件控制
        //    foreach (Proch proch in prochMgr.Items)
        //    {
        //        if (proch.Label == prochLabel)
        //        {
        //            proch.StillInside = true;
        //            role.Position = proch.Position;
        //            role.Body.ResetDynamics();
        //            role.RoleState = Role.ERoleState.Free;
        //            break;
        //        }
        //    }
        //}

        //public void CreateRole()
        //{
        //    // 创建新角色
        //    Vector2 itemSize = new Vector2(32, 55);
        //    float runForce = 40000.0f;
        //    float jumpForce = 300000.0f;
        //    float maxRunSpeed = 0;
        //    role = new RoyMustang();
        //    role.Texture = "Roles/Roy";
        //    role.Size = itemSize;
        //    role.Position = new Vector2(400, 100);
        //    role.Origin = new Vector2(16, 24);

        //    role.EnableAnim = true;
        //    role.FrameSize = new Vector2(36, 64);
        //    role.FrameNumber = 17;
        //    role.AnimSeqList.Add(new AnimSequence("Free", 7, 1, 8, true, true));
        //    role.AnimSeqList.Add(new AnimSequence("Running", 0, 8, 8, true, true));
        //    role.AnimSeqList.Add(new AnimSequence("Jumping", 8, 3, 4, true, false));
        //    role.AnimSeqList.Add(new AnimSequence("Falling",10, 1, 4, true, true));
        //    role.PlaySeq("Free");

        //    role.IsStatic = false;
        //    role.Mass = 100;
        //    role.Friction = 0.1f;

        //    role.RunForce = runForce;
        //    role.JumpForce = jumpForce;
        //    role.MaxRunSpeed = maxRunSpeed;

        //    role.supplyNameList.Add("Thorn");
        //    role.supplyNameList.Add("Thorn");

        //    if (PlayerMgr.Instance.playerData != null)
        //    {
        //        role.Position = PlayerMgr.Instance.playerData.Position;
        //        role.Health = PlayerMgr.Instance.playerData.Health;
        //    }
        //}
        //public void CreateAskia()
        //{
        //    Vector2 itemSize = new Vector2(125, 125);
        //    float runforce = 10000.0f;
        //    float jumpforce = 500000.0f;
        //    float maxRunSpeed = 200;
        //    askia = new Askia();
        //    askia.Texture ="Roles/Askia";

        //    askia.EnableAnim = true;
        //    askia.FrameSize = new Vector2(125,125);
        //    askia.FrameNumber = 30;
        //    askia.AnimSeqList.Add(new AnimSequence("Wondering", 0, 7, 8, true, true));
        //    askia.AnimSeqList.Add(new AnimSequence("Dashing", 7, 3, 8, true, false));
        //    askia.AnimSeqList.Add(new AnimSequence("LostControl", 10, 1, 4, true, true));
        //    askia.AnimSeqList.Add(new AnimSequence("Stop", 11, 5, 7, true, true));
        //    askia.AnimSeqList.Add(new AnimSequence("ShootingThorn", 16, 5, 12, true, false));
        //    askia.AnimSeqList.Add(new AnimSequence("TakingOff", 21, 2, 2, true, true));
        //    askia.AnimSeqList.Add(new AnimSequence("Dying", 23, 7, 8, true, false));
        //    askia.AnimSeqList.Add(new AnimSequence("GetHurt", 29, 1, 8, true, true));
        //    askia.PlaySeq("Stop");


        //    askia.Size = itemSize;
        //    askia.Position = new Vector2(400, 100);
        //    askia.Origin = new Vector2(75, 75);

        //    askia.Mass = 50;
        //    askia.Friction = 300;

        //    askia.RunForce = runforce;
        //    askia.JumpForce = jumpforce;
        //    askia.MaxRunSpeed = maxRunSpeed;
        //}
        //public void RespawnRole(Vector2 pos)
        //{
        //    if (role != null)
        //        role.Dispose();
        //    CreateRole();
        //    role.Position = pos;
        //}
        //public void RespawnAskia(Vector2 pos)
        //{
        //    if(askia != null)
        //        askia.Dispose();
        //    CreateAskia();
        //    askia.Position = pos;
        //}
        #endregion

        public void ChangeScene(string targetSceneName, string targetProchLabel)
        {
            if (StringHelper.IsNullOrEmpty(targetSceneName) ||
                StringHelper.IsNullOrEmpty(targetProchLabel))
            {
                Console.WriteLine("警告 切换场景名称:'{0}'，目标Proch标签：'{1}'禁止为空，场景切换失败",
                    targetSceneName, targetProchLabel);
                return;
            }
            nextSceneName = targetSceneName;
            this.targetProchLabel = targetProchLabel;
        }
    }
}
