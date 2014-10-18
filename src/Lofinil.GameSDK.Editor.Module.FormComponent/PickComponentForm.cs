using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor;

namespace Lofinil.GameSDK.Editor.App
{
    public partial class PickComponentForm : Form
    {
        // 选择数据
        public CompInfo SelComp;

        public PickComponentForm()
        {
            InitializeComponent();
        }

        private void PickCompForm_Load(object sender, EventArgs e)
        {
            // 加载程序集中的组件
            RefreshSource();

            lsvComps.LargeImageList = new ImageList();
            lsvComps.SmallImageList = new ImageList();
            lsvComps.LargeImageList.ImageSize = new Size(32, 32);
        }

        private void RefreshSource()
        {
            lsvSources.Items.Clear();

            foreach(AsmInfo ai in GameService.Instance.QueryModule<AssemblyModule>().AsmInfoList)
            {
                ListViewItem lvi = lsvSources.Items.Add(ai.Assembly.ManifestModule.Name);
                lvi.Tag = ai;
            }
        }

        private void RefreshComponent()
        {
            lsvComps.Items.Clear();

            lsvComps.LargeImageList.Images.Clear();
            lsvComps.SmallImageList.Images.Clear();

            if (lsvSources.SelectedItems.Count == 0)
                return;

            AsmInfo ai = (AsmInfo)lsvSources.SelectedItems[0].Tag;

            foreach(CompInfo ci in ai.CompInfoList)
            {
                if (ci.InEditor)
                {
                    ListViewItem lvi = lsvComps.Items.Add(ci.CompType.Name);
                    lvi.Tag = ci;
                    lvi.ImageKey = ci.CompType.Name;

                    // TODO [组件图标资源及扩展] 浏览和选择组件时使用图标表示比文字更加直观，考虑提供可扩展接口
                    // ACHACK [临时组件图标引入] 用一个字符串拼接获取编辑器某目录下预放置的图片文件
                    String file = "Resources/CompIcon/" + ci.CompType.Name + ".png";
                    if (File.Exists(file))
                    {
                        Bitmap bmp = new Bitmap(file);
                        lsvComps.LargeImageList.Images.Add(ci.CompType.Name, bmp);
                        lsvComps.SmallImageList.Images.Add(ci.CompType.Name, bmp);
                    }
                }
            }
        }

        private void lbSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshComponent();
        }

        private void lsvComps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvComps.SelectedItems.Count > 0)
                SelComp = (CompInfo)lsvComps.SelectedItems[0].Tag;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }
}
