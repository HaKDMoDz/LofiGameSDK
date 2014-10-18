using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Game;
using LofiEngine.Device;
using LofiEngine.Resource;

namespace LofiEngine.AVGModule
{
    public enum FacePos
    {
        Left,
        Middle,
        Right,
    }

    public class AVGManager : Manager
    {
        private GameManager game;

        private ResourceManager resMgr;

        private ACGPanel acgPanel;

        // TODO 迁移ACGPanel
        public ACGPanel ACGScreen;

        public AVGManager(GameManager game)
        {
            this.game = game;
            resMgr = (ResourceManager)game.GetManager("ResMgr");

        }

        public override void Initialize()
        {
            // UNDONE 这里因为AVGPanel是依赖于UIMgr的，应当确认UIMgr是否已经加载
        }

        public void Update()
        {}

        public void Draw()
        {
            // NOTE acgPanel虽然使用了UI的核心对象，但是并不为UI管理器所引用，因此在这里单独Draw
            // 这样一来acgPanel也无法采用UIMgr所施加的特殊效果
            // 究竟如何设计一个模块还是根据需要，只要保证结果可预知就可以了。
            if (acgPanel != null)
                acgPanel.Draw();
        }

        public void Dialog(String roleName, String line)
        {
            acgPanel.ShowDialog();
            SetDialogLine(line);
            SetRole(roleName);
        }

        public void ShowPicture(bool isShow, String picPath)
        {
            if (isShow)
                ShowPicture(picPath);
            else
                HidePicture();
        }

        public void ShowFace( bool isShow, FacePos facePos, String facePath)
        {
            if (isShow)
            {
                acgPanel.ShowFace(facePath, facePos);
            }
            else
                acgPanel.HideFace(facePos);
        }

        public void Aside()
        {

        }

        public void Flicker()
        {

        }

        public void SetRole(String roleName)
        {

        }


        // ACGPanel 相关
        public void ShowDialog() { acgPanel.ShowDialog(); }

        public void SetDialogLine(String line) { acgPanel.dialogStr = line; }

        public void SetDialogRole(int roleId) { acgPanel.speakingRole = roleId; }

        public void ShowPicture(String path) { acgPanel.showPicture = resMgr.LoadTexture2D(path); }

        public void HidePicture() { acgPanel.showPicture = null; }

        public void ShowFace(String path, FacePos pos) { acgPanel.ShowFace(path, pos); }

        public void HideFace(FacePos pos) { acgPanel.HideFace(pos); }

        public void Aside(String line) { acgPanel.Aside(line); }

    }
}
