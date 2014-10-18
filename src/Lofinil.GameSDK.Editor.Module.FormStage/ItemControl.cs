using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor.Interception;

namespace Lofinil.GameSDK.Editor.App
{
    public partial class ItemControl : UserControl, IView
    {
        public ItemControl()
        {
            InitializeComponent();
        }

        private void updateItemCollection()
        {
            trv_itemCollection.BeginUpdate();
            trv_itemCollection.Nodes.Clear();
            for (int i = 0; i < GameService.Instance.QueryModule<StageModule>().Layers.Count; i++)
            {
                TreeNode tn = new TreeNode(GameService.Instance.QueryModule<StageModule>().Layers[i].Name);
                foreach (GameComponent item in GameService.Instance.QueryModule<StageModule>().Layers[i].ItemList)
                {
                    // NOTE 无名对象是不显示在这里的
                    Identifier id = item.Children.QueryComponent<Identifier>();
                    if(id != null)
                        tn.Nodes.Add(id.Name);
                }
                trv_itemCollection.Nodes.Add(tn);
            }
            trv_itemCollection.EndUpdate();
        }


        private void trv_itemCollection_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Is an Item node
            if (e.Node.Parent != null)
            {
                GameComponent i = GameService.Instance.QueryModule<StageModule>().GetItemByName(e.Node.Text);
                EditorService.Instance.QueryModule<IStageModule>().SelectItem(SelectMode.Clear, i);
            }
        }


        #region Item Panel
        private void btn_deleteGroup_Click(object sender, EventArgs e)
        {

        }

        private void btn_loadItems_Click(object sender, EventArgs e)
        {
            updateItemCollection();
        }


        private void btn_addGroup_Click(object sender, EventArgs e)
        {
            bool occupied = true;
            NameUtil.RestartNameInc(0);
            String groupName = "";
            while (occupied)
            {
                groupName = NameUtil.GetNextName("Group");
                if (GameService.Instance.QueryModule<StageModule>().GetGroupByName(groupName) != null)
                {
                    occupied = false;
                    break;
                }
            }

            ItemLayer layer = new ItemLayer();
            layer.Name = groupName;
            GameService.Instance.QueryModule<StageModule>().Layers.Add(layer);
            updateItemCollection();
        }

        bool itemCollDragging = false;
        TreeNode itemCollDragNode = null;

        private void trv_itemCollection_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode n = (TreeNode)e.Item;
            //if (n.Parent != null)
            {
                itemCollDragging = true;
                DoDragDrop(n, DragDropEffects.Move);
                itemCollDragNode = n;
            }
        }

        private void trv_itemCollection_DragEnter(object sender, DragEventArgs e)
        {
            if (!itemCollDragging) return;
            //if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode n = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
                if (n.Parent == null)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void trv_itemCollection_DragDrop(object sender, DragEventArgs e)
        {
            if (!itemCollDragging) return;
            itemCollDragging = false;
            System.Drawing.Point p = new System.Drawing.Point(e.X, e.Y);
            p = trv_itemCollection.PointToClient(p);
            TreeNode dropNode = trv_itemCollection.GetNodeAt(p);
            //if (dropNode.Parent == null)
            {
                TreeNode n = itemCollDragNode;
                itemCollDragNode.Remove();
                dropNode.Nodes.Add(n);
            }
        }
        #endregion

    }
}
