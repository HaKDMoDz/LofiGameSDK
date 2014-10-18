using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LofiEditor.SupportForms;
using Lofinil.GameSDK.Editor.Module.FormStage;
using System.IO;
using Lofinil.GameSDK.Editor.Module.Project;
using Lofinil.GameSDK.Engine;

namespace Lofinil.GameSDK.Editor.Module.FormResource
{
    public partial class ImagePicker : PictureBox
    {
        public String TexKey;
        public ReferTextureData TexRefData;

        public ImagePicker()
        {
            InitializeComponent();

            TexRefData = new ReferTextureData();
            TexKey = "";
        }

        private void ImagePicker_Click(object sender, EventArgs e)
        {
            PickImageForm ptf = new PickImageForm();
            DialogResult dr = ptf.ShowDialog();
            if (dr == DialogResult.OK)
            {
                TexRefData = ptf.TexRefData;

                Bitmap srcImg = getSourceImage(ptf.TexRefData.UID);
                Bitmap ssrImg = new Bitmap(ptf.TexRefData.SrcRect.Width, ptf.TexRefData.SrcRect.Height);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(ssrImg);
                g.DrawImage(srcImg, ptf.TexRefData.SrcRect);
                this.Image = ssrImg;
                TexKey = ptf.TexRefData.Key;
            }
        }

        public Bitmap getSourceImage(int id)
        {
            ResourceData info = EditorService.Instance.QueryModule<ResourceSetModule>().GetResourceData(Engine.ContentType.Texture, id);

            Bitmap bmp = null;
            if (info != null)
            {
                // ACHACK 缩略图硬编码
                bmp = new Bitmap(Path.Combine(EditorService.Instance.QueryModule<ProjectModule>(null).CurProjDir, EditorService.Instance.QueryModule<ProjectModule>(null).CurProject.ResourcePath, info.ResourceKey));
            }
            return bmp;
        }

    }
}
