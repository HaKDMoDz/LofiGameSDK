using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using LofiUtil.Helpers;

namespace LofiUI.Manager
{
    public class UIManager
    {
        #region Variables
        Cursor cursor;
        public List<Control> ControlList;
        #endregion

        #region Constructor
        public UIManager()
        {            
            ControlList = new List<Control>();
        }
        #endregion

        #region Update
        public void Update()
        {
            //更新ui列表
            for (int i = 0; i < ControlList.Count; i++)
            {
                ControlList[i].Update();
            }

            cursor.Update();
        }
        #endregion

        #region Draw
        public void Draw()
        {
            //绘制ui列表
            //if (!DramaMgr.Instance.IsDramaOn && !GameMgr.Instance.InEditorMode)
            {
                foreach (Control ui in ControlList)
                    ui.Draw();
            }

            cursor.Draw();
        }
        #endregion

        #region UI Control
        /// <summary>
        /// 添加普通的ui
        /// </summary>
        /// <param name="ui"></param>
        public void Add(Control ui)
        {
            ControlList.Add(ui);
        }
        #endregion

        public void SetCursor(string texturePath)
        { 
            Texture2D texture = LoadHelper.LoadTexture2D(texturePath);
            cursor = new Cursor(texture, NullControl.Instance);
        }

        public void Clear()
        {
            ControlList.Clear();
        }
    }
}
