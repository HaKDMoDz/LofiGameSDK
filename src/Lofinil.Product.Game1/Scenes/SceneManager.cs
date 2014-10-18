using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BreakOutMario.Scenes
{
    using Keyboard = LofiUtil.Inputs.Keyboard;
    using Microsoft.Xna.Framework.Input;
    class SceneManager : LofiEngine.Scenes.SceneManager
    {
        #region Variables
        public float CurrentGTMTime = 0;                        // 当前重力改变倒计时
        public bool GTMActive = false;                          // GTM激活开关
        public const float MaxGTMTime = 1000;   // 2s 重力改变倒计时
        // 下一个重力
        private Vector2 NextGravity;
        #endregion
    }
}
