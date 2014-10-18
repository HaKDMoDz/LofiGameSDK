using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Lofinil.GameSDK.Editor;
using Lofinil.GameSDK.Editor.Interception.ModuleInterface;
using Lofinil.GameSDK.Editor.Module.Project;

namespace Lofinil.GameSDK.Editor.App
{
    public partial class ImageSetControl : UserControl
    {
        public ImageSetControl()
        {
            InitializeComponent();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lsvTexture.View != View.List && lsvTexture.View != View.Details)
                return;

            if (e.KeyChar == (char)Keys.Enter)
            {
                ListViewItem foundItem = lsvTexture.FindItemWithText(tbFilter.Text.Trim(), false, 0, true);
                if (foundItem != null)
                {
                    lsvTexture.TopItem = foundItem;
                }
            }
        }


        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == rbDetail)
            {
                lsvTexture.View = View.Details;
            }
            else if (sender == rbTile)
            {
                lsvTexture.View = View.Tile;
            }
        }

        private void TexViewControl_Load(object sender, EventArgs e)
        {
            lsvTexture.View = View.Details;
            //lsvTexture.TileSize = new Size(256, 128);
            lsvTexture.GridLines = true;
            lsvTexture.Scrollable = true;

            lsvTexture.LargeImageList = new ImageList();
            lsvTexture.LargeImageList.ImageSize = new Size(64, 64);
            lsvTexture.SmallImageList = new ImageList();
            lsvTexture.SmallImageList.ImageSize = new Size(64, 64);

            // NOTE 该顺序不应随意改变
            lsvTexture.Columns.Add("名称");       // 0 (这里即输入资源Key) - 特定于Winform控件选择Resource为图片来源
            lsvTexture.Columns.Add("ID");         // 1 ID
            lsvTexture.Columns.Add("内容");       // 2 输出内容Key
            lsvTexture.Columns.Add("资源");       // 3 输入资源Key
            lsvTexture.Columns.Add("管线");       // 4 处理管线
            lsvTexture.Columns.Add("参数");       // 5 处理管线参数
        }

        public void AddItem(ResourceData tRes, bool froceRegenThumb)
        {
            // 添加缩略图
            // ACHACK [图片资源缩略图创建时机] 在项目文件夹中搜索缩略图，如果没有则创建一个
            String nailFile = Path.Combine(EditorService.Instance.QueryModule<ProjectModule>(null).CurProjDir, "Thumbnail", tRes.ContentId.ToString() + ".ico");
            Image nail = null;
            if (froceRegenThumb || !File.Exists(nailFile))
            {
                Bitmap bmp = new Bitmap(Path.Combine(EditorService.Instance.QueryModule<ProjectModule>(null).CurProjDir, EditorService.Instance.QueryModule<ProjectModule>(null).CurProject.ResourcePath, tRes.ResourceKey));
                nail = bmp.GetThumbnailImage(64, 64, null, new IntPtr());
                nail.Save(nailFile, System.Drawing.Imaging.ImageFormat.Icon);
            }
            else
            {
                nail = new Bitmap(nailFile);
            }
            lsvTexture.LargeImageList.Images.Add(tRes.ContentId.ToString(), nail);
            lsvTexture.SmallImageList.Images.Add(tRes.ContentId.ToString(), nail);

            // 添加到列表
            ListViewItem item = lsvTexture.Items.Add(tRes.ResourceKey);     // NOTE 在此视图中，显示的图片取自Resource
            item.ImageKey = tRes.ContentId.ToString();
            item.SubItems.Add(tRes.ContentId.ToString());
            item.SubItems.Add(tRes.ContentKey);
            item.SubItems.Add(tRes.ResourceKey);
            item.SubItems.Add(tRes.Processor);
            item.SubItems.Add(tRes.Argument);
        }
    }
}
