using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Engine;
using System.IO;
using Lofinil.Architecture;
using Lofinil.GameSDK.Editor.Interception;
using Lofinil.GameSDK.Editor.App;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor.Module.FormView;
using Lofinil.GameSDK.Editor.Module.View;
using Lofinil.GameSDK.Editor.Module.Menu;
using Lofinil.GameSDK.Editor.Module.ToolBox;

namespace Lofinil.GameSDK.Editor
{
    // 场景编辑器的绘制干涉、层级、选择管理等
    [ModuleDependency("FormViewModule")]
    public class StageEditModule : EditorModule, IStageModule
    {
        public bool StageLoaded;

        private StageModule stageMgr;

        public event System.Action StageChanged;

        public event EventHandler SelectionChanged;

        public StageEditModule()
        {
            StageLoaded = false;
            Item = null;
        }

        public override void Initialize(EditorService service)
        {
            base.Initialize(service);

            stageMgr = GameService.Instance.QueryModule<StageModule>();
            //StageChanging +=new Action<StageData,StageData>(StagePresenter_OnStageChanging);
            StageChanged += new System.Action(OnStageChanged);

        }

        #region 层级管理
        public void MoveSelectionToBottom()
        {
            if (SelectedItem != null)
                stageMgr.MoveToBottom(SelectedItem);
        }

        public void MoveSelectionToLower()
        {
            if (SelectedItem != null)
                stageMgr.MoveToLowerLayer(SelectedItem);
        }

        public void MoveSelectionToUpper()
        {
            if (SelectedItem != null)
                stageMgr.MoveToUpperLayer(SelectedItem);
        }

        public void MoveSelectionToTop()
        {
            if (SelectedItem != null)
                stageMgr.MoveToTop(SelectedItem);
        }
        #endregion 层级管理

        #region 选择管理
        public GameComponent Item;
        public GameComponent SelectedItem { get { return selectedItems.Count > 0 ? selectedItems[0] : null; } }
        public GameComponentCollection SelectedItems { get { return selectedItems; } }
        private GameComponentCollection selectedItems = new GameComponentCollection();

        public void SelecteItem(SelectMode selMode, GameComponent[] items)
        {
            switch(selMode)
            {
                case SelectMode.Clear:
                    selectedItems.Clear();
                    selectedItems.AddRange(items);
                    break;
                case SelectMode.Add:
                    selectedItems.AddRange(items);
                    break;
                case SelectMode.Remove:
                    foreach (GameComponent c in items)
                        selectedItems.Remove(c);
                    break;
            }

            if (SelectionChanged != null)
                SelectionChanged(this, null);
        }

        public void SelectItem(GameComponent item)
        {
            this.selectedItems.Clear();
            if (item != null)
                this.selectedItems.Add(item);
            if (SelectionChanged != null)
                SelectionChanged(this, null);
        }

        public void CloneSelectedItem()
        {
            if (Item != null)
            {
                ItemLayer layer = GameService.Instance.QueryModule<StageModule>().GetContainLayer(Item);

                GameService.Instance.QueryModule<StageModule>().AddItem(layer, Item.Clone());
            }
        }

        #endregion

        #region 文件操作
        public void ReadStage(String path)
        {
            GameService.Instance.QueryModule<StageModule>().ReadStage(path);
            StageLoaded = true;

            if (StageChanged != null)
                StageChanged();
        }
        #endregion 文件操作

        public virtual void OnStageChanging(Stage orgStage, Stage newStage)
        {
        }

        public virtual void OnStageChanged()
        {
        }

        public void DrawStage()
        {
            GameService.Instance.Draw();
        }

        public void SelectItem(SelectMode mode, GameComponent comp)
        {
            // UNDONE SelectItem
        }
    }
}
