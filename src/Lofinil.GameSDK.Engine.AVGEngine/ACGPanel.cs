using System;
using LofiEngine.Game;
using LofiEngine.Resource;
using LofiEngine.TriggerAction;
using LofiEngine.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LofiEngine.AVGModule
{
    public class ACGPanel
    {
        public GameManager Game;
        private ResourceManager resMgr;

        private readonly static Rectangle
            DialogLeftGfxRect = new Rectangle(0, 0, 59, 168),
            DialogMiddleGfxRect = new Rectangle(59, 0, 53, 168),
            DialogRightGfxRect = new Rectangle(112, 0, 141, 168),
            NextButtonGfxRect = new Rectangle(226, 169, 17, 17);

        private const String PicturePath = "Pictures";
        private const String FacePath = "Faces";

        /// <summary>
        /// 剧本界面图片
        /// </summary>
        public Texture2D dramaUI;

        // HACK 临时Public
        /// <summary>
        /// 当前讲话内容
        /// </summary>
        public String dialogStr = "";

        public String asideStr = "";

        /// <summary>
        /// 在讲话的角色Id
        /// </summary>
        public int speakingRole = 0;

        /// <summary>
        /// 图片显示
        /// </summary>
        public Texture2D showPicture;

        /// <summary>
        /// 左侧人物
        /// </summary>
        public Texture2D roleLeft;

        /// <summary>
        /// 中间人物
        /// </summary>
        public Texture2D roleMiddle;

        /// <summary>
        /// 右侧人物
        /// </summary>
        public Texture2D roleRight;

        public ACGPanel(GameManager game)
        {
            Game = game;
            resMgr = Game.ResMgr;
            dramaUI = resMgr.LoadTexture2D("GameUI/Dialog");
        }

        public void Dispose()
        {
            if (showPicture != null)
            {
                showPicture.Dispose();
            }
            if (roleLeft != null)
            {
                roleLeft.Dispose();
            }
            if (roleMiddle != null)
            {
                roleMiddle.Dispose();
            }
            if (roleRight != null)
            {
                roleRight.Dispose();
            }
            if (dramaUI != null)
            {
                dramaUI.Dispose();
            }
        }

        public void Initialize()
        {
            speakingRole = -1;
        }

        #region Draw

        /// <summary>
        /// Draw
        /// </summary>
        public void Draw()
        {
            if (showPicture != null)
            {
                RenderShowPicture();
            }
            // 绘制角色头像
            RenderGameRole();
            // 绘制界面
            RenderGameUI();
            if (!String.IsNullOrEmpty(dialogStr))
            {
                Game.GraphicsMgr.DrawLineOnDialog(dialogStr);
            }
            if (!String.IsNullOrEmpty(asideStr))
            {
                Game.GraphicsMgr.DrawLineOnDialog(asideStr);
            }
        }

        #endregion Draw

        #region DramaUI

        /// <summary>
        /// 绘制角色
        /// </summary>
        public void RenderGameRole()
        {
            int xPos, yPos;
            xPos = yPos = 0;
            if (roleLeft != null)
            {
                Color color;
                if (speakingRole == -1 || speakingRole == 0)
                {
                    color = Color.White;
                }
                else if (speakingRole == 1)
                {
                    color = Color.Gray;
                }
                else
                {
                    // 意外情况
                    color = Color.Red;
                }
                yPos = Game.Height - roleLeft.Height;
                Game.GraphicsMgr.Draw(roleLeft, null, color, Vector2.Zero, new Vector2(xPos, yPos), new Vector2(1, 1), 0, SpriteEffects.None);
            }
            if (roleRight != null)
            {
                Color color;
                if (speakingRole == -1 || speakingRole == 1)
                {
                    color = Color.White;
                }
                else if (speakingRole == 0)
                {
                    color = Color.Gray;
                }
                else
                {
                    // 意外情况
                    color = Color.Red;
                }
                xPos = Game.Width - roleRight.Width;
                yPos = Game.Height - roleRight.Height;
                Game.GraphicsMgr.Draw(roleRight, null, color, Vector2.Zero, new Vector2(xPos, yPos), new Vector2(1, 1), 0, SpriteEffects.None);
            }
        }

        private bool showDialog = false;

        /// <summary>
        /// 绘制游戏UI
        /// </summary>
        public void RenderGameUI()
        {
            int xPos, yPos;
            xPos = yPos = 0;
            // 绘制用户界面
            if (showDialog)
            {
                yPos = Game.Height - DialogLeftGfxRect.Height;
                int blandWidth = Game.Width - DialogLeftGfxRect.Width - DialogRightGfxRect.Width;
                Game.GraphicsMgr.Draw(
                    dramaUI, new Rectangle(0, yPos, DialogLeftGfxRect.Width, DialogLeftGfxRect.Height),
                    Color.White, Vector2.Zero, new Vector2(DialogLeftGfxRect.Left, DialogLeftGfxRect.Top),
                    new Vector2(1, 1), 0, SpriteEffects.None);
                Game.GraphicsMgr.Draw(
                    dramaUI, new Rectangle(DialogLeftGfxRect.Width, yPos, blandWidth, DialogMiddleGfxRect.Height),
                    Color.White, Vector2.Zero, new Vector2(DialogMiddleGfxRect.Left, DialogMiddleGfxRect.Top),
                    new Vector2(1, 1), 0, SpriteEffects.None);
                Game.GraphicsMgr.Draw(
                    dramaUI, new Rectangle(DialogLeftGfxRect.Width + blandWidth, yPos, DialogRightGfxRect.Width, DialogRightGfxRect.Height),
                    Color.White, Vector2.Zero, new Vector2(DialogRightGfxRect.Left, DialogRightGfxRect.Top),
                    new Vector2(1, 1), 0, SpriteEffects.None);
                // 绘制闪烁NextButton
                xPos = Game.Width - 67;
                yPos = Game.Height - 53;
                float alphaValue = 0;
                float t = Game.TotalTimeInMs % 2000;
                alphaValue = t < 1000 ? (t / 1000.0f) : 2 - t / 1000;
                Game.GraphicsMgr.Draw(
                    dramaUI, NextButtonGfxRect, new Color(1, 1, 1, alphaValue),
                    Vector2.Zero, new Vector2(xPos, yPos),
                    new Vector2(1, 1), 0, SpriteEffects.None);
            }
        }

        public void ShowDialog()
        {
            showDialog = true;
        }

        public void HideDialog()
        {
            showDialog = false;
        }

        /// <summary>
        /// 绘制显示图片
        /// </summary>
        public void RenderShowPicture()
        {
            int x = Game.Width / 2 - showPicture.Width / 2;
            int y = Game.Height / 2 - showPicture.Height / 2;
            Rectangle picRect = new Rectangle(x, y, showPicture.Width, showPicture.Height);
            Game.GraphicsMgr.Draw(showPicture, picRect);
        }

        #endregion DramaUI

        public void ShowFace(String path, FacePos pos)
        {
            switch (pos)
            {
                case FacePos.Left:
                    roleLeft = resMgr.LoadTexture2D(path);
                    break;
                case FacePos.Middle:
                    roleMiddle = resMgr.LoadTexture2D(path);
                    break;
                case FacePos.Right:
                    roleRight = resMgr.LoadTexture2D(path);
                    break;
            }
        }

        public void HideFace(FacePos pos)
        {
            switch (pos)
            {
                case FacePos.Left:
                    roleLeft = null;
                    break;
                case FacePos.Middle:
                    roleMiddle = null;
                    break;
                case FacePos.Right:
                    roleRight = null;
                    break;
            }
        }

        public void Aside(String line)
        {
            ShowDialog();
            asideStr = line;
        }
    }
}