using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lofinil.GameSDK.Engine
{
    /// <summary>
    /// 摄像机类
    /// </summary>
    [Prefab(new Type[]{typeof(Transform)})]
    public class Camera : GameComponent
    {
        #region Variables

        private GameService game;

        public Vector2 Focus;

        // Up-Left Corner of viewport
        public Vector2 TopLeft
        {
            get
            {
                return new Vector2(Focus.X - WindowSize.X / (2 * Zoom), Focus.Y - WindowSize.Y / (2 * Zoom));
            }
            set
            {
                Focus.X = WindowSize.X / (2 * Zoom) + value.X;
                Focus.Y = WindowSize.Y / (2 * Zoom) + value.Y;
            }
        }

        // Botton-Right of view port
        public Vector2 BottomRight
        {
            get
            {
                return new Vector2(Focus.X + WindowSize.X / (2 * Zoom), Focus.Y + WindowSize.Y / (2 * Zoom));
            }
            set
            {
                Focus.X = WindowSize.X / (2 * Zoom) - value.X;
                Focus.Y = WindowSize.Y / (2 * Zoom) - value.Y;
            }
        }

        public Vector2 WindowSize { get { return windowSize; } set { windowSize = value; } }

        private Vector2 windowSize = new Vector2(800, 600);

        // Movement Speed
        public float Speed;

        /// <summary>
        /// 摄像机状态枚举
        /// </summary>
        public enum ECameraState
        {
            /// <summary>
            /// 锁定到玩家角色
            /// </summary>
            LockOnPlayer,
            /// <summary>
            /// 自由
            /// </summary>
            Free,
        }

        /// <summary>
        /// 摄像机状态
        /// </summary>
        public ECameraState cameraState;

        // 缩放
        public float Zoom = 1;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Camera(int cameraSpeed)
        {
            game = GameService.Instance;
            Speed = cameraSpeed;
        }

        #endregion Constructor

        #region Update

        public override void Update()
        {
            // 自由摄像机
            if (cameraState == ECameraState.Free)
            {
                // 自由移动
                float elapsedTime = game.FrameTimeInMs / 1000;
                if (game.QueryModule<InputModule>().IsKeyPressed(Keys.W))
                {
                    Focus.Y -= Speed * elapsedTime;
                }
                if (game.QueryModule<InputModule>().IsKeyPressed(Keys.S))
                {
                    Focus.Y += Speed * elapsedTime;
                }
                if (game.QueryModule<InputModule>().IsKeyPressed(Keys.A))
                {
                    Focus.X -= Speed * elapsedTime;
                }
                if (game.QueryModule<InputModule>().IsKeyPressed(Keys.D))
                {
                    Focus.X += Speed * elapsedTime;
                }
            }

            base.Update();
        }

        #endregion Update

        #region Control

        /// <summary>
        /// 设置绝对聚焦点
        /// </summary>
        public void SetAbsFocus(Vector2 focus)
        {
            Focus = focus;
        }

        #endregion Control

        #region Space Mapping

        // World position to screen position
        public Vector2 PositionToScreen(Vector2 worldPos)
        {
            Vector2 vecToFocus = new Vector2(worldPos.X - Focus.X, worldPos.Y - Focus.Y);
            Vector2 camPos = vecToFocus * Zoom;
            Vector2 screenPos = new Vector2(camPos.X + WindowSize.X / 2, camPos.Y + WindowSize.Y / 2);
            return screenPos;
        }

        // Screen position to world position
        public Vector2 PositionToWorld(Vector2 screenPos)
        {
            Vector2 camPos = new Vector2(screenPos.X - WindowSize.X / 2, screenPos.Y - WindowSize.Y / 2);
            Vector2 vecToFocus = camPos / Zoom;
            Vector2 worldPos = new Vector2(vecToFocus.X + Focus.X, vecToFocus.Y + Focus.Y);
            return worldPos;
        }

        // World rectangle to screen rectangle
        public Rectangle RectangleToScreen(Rectangle worldRect)
        {
            Vector2 worldPos = new Vector2(worldRect.X, worldRect.Y);
            Vector2 screenPos = PositionToScreen(worldPos);
            Rectangle screenRect = new Rectangle(
                (int)screenPos.X,
                (int)screenPos.Y,
                (int)(worldRect.Width * Zoom),
                (int)(worldRect.Height * Zoom));
            return screenRect;
        }

        // Screen rectangle to world rectangle
        public Rectangle RectangleToWorld(Rectangle screenRect)
        {
            Vector2 screenPos = new Vector2(screenRect.X, screenRect.Y);
            Vector2 worldPos = PositionToWorld(screenPos);
            Rectangle worldRect = new Rectangle(
                (int)worldPos.X,
                (int)worldPos.Y,
                (int)(screenRect.Width / Zoom),
                (int)(screenRect.Height / Zoom));
            return worldRect;
        }

        // Screen vector to world vector
        public Vector2 VectorToWorld(Vector2 screenVec)
        {
            return screenVec / Zoom;
        }

        // World vector to screen vector
        public Vector2 VectorToScreen(Vector2 worldVec)
        {
            return worldVec * Zoom;
        }

        public Vector2 ZoomScale
        {
            get { return VectorToScreen(new Vector2(Zoom, Zoom)); }
        }

        #endregion Space Mapping
    }
}