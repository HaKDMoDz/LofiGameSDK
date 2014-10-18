using System.Collections.Generic;
using LofiEngine.APIWrap;
using LofiEngine.Game;
using LofiEngine.Resource;
using Microsoft.Xna.Framework.Graphics;
using LofiEngine.Module;
using LofiEngine.GUI.Componsite;

namespace LofiEngine.GUI.Module
{
    public class GUIManager : BaseModule
    {
        #region Variables

        Cursor cursor;
        public List<Control> ControlList;
        public GraphicsModule GraphicsMgr;

        private ResourceManager resMgr;

        #endregion Variables

        #region Constructor

        public GUIManager()
        {
            resMgr = Game.ResMgr;
            ControlList = new List<Control>();
        }

        #endregion Constructor

        #region Update

        public override void Update()
        {
            for (int i = 0; i < ControlList.Count; i++)
            {
                ControlList[i].Update();
            }

            cursor.Update();
        }

        #endregion Update

        #region Draw

        public override void Draw()
        {
            //绘制ui列表
            //if (!DramaMgr.Instance.IsDramaOn && !GameMgr.Instance.InEditorMode)
            {
                foreach (Control ui in ControlList)
                    ui.Draw();
            }

            cursor.Draw();
        }

        #endregion Draw

        #region UI Control

        /// <summary>
        /// 添加普通的ui
        /// </summary>
        /// <param name="ui"></param>
        public void Add(Control ui)
        {
            ui.uiMgr = this;
            ControlList.Add(ui);
        }

        #endregion UI Control

        public void SetCursor(string texturePath)
        {
            Texture2D texture = resMgr.LoadTexture2D(texturePath);
            cursor = new Cursor(texture, NullControl.Instance);
        }

        public void Clear()
        {
            ControlList.Clear();
        }

        public override void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public override void Load()
        {
            throw new System.NotImplementedException();
        }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}