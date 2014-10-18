using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;
using Lofinil.GameSDK.Editor;
using Lofinil.GameSDK.Engine;
using Lofinil.GameSDK.Editor.Interception.ModuleInterface;
using Lofinil.GameSDK.Editor.Module.Project;

namespace Lofinil.GameSDK.Editor.App
{

    public partial class TextureForm : Form
    {
        ResourceSetModule resSetMod;

        public TextureForm()
        {
            InitializeComponent();
        }

        private void TextureForm_Load(object sender, EventArgs e)
        {
            // Test2();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "位图(*.bmp;*.jpg;*.png)|*.bmp; *.jpg;*.png";

            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // NOTE 引用方案 - 直接取文件绝对路径相对当前资源目录的相对路径 - 该方法通常要求先将资源拷入子目录中
                // NOTE 导入方案 - 若指定文件不在资源目录或其子目录中，则拷贝入指定子目录，然后取相对路径 - 该方法更人性化
                // 这里使用引用方案
                String curProjDir_Abs = EditorService.Instance.QueryModule<ProjectModule>(null).CurProjDir;
                String curResDir_Rel = EditorService.Instance.QueryModule<ProjectModule>(null).CurProject.ResourcePath;
                String curResDir_Abs = Path.Combine(curProjDir_Abs, curResDir_Rel);

                String curCntDir_Rel = EditorService.Instance.QueryModule<ProjectModule>(null).CurProject.ContentPath;

                // 拷贝&转换路径
                String refPath_Abs = ofd.FileName;
                String refPath_Rel = PathHelper.MakeRelative(refPath_Abs, curResDir_Abs);

                FileInfo fInfo = new FileInfo(refPath_Abs);
                String srcName = refPath_Rel;
                String xnbFileName_Rel = refPath_Rel.Replace(fInfo.Extension, "");
                String xnbKey = refPath_Rel.Replace(fInfo.Extension, "");

                // 使用引用方案，暂不用下面代码
                // 拷贝路径相同，则认为需要重新加载，不拷贝继续后续操作
                // ACHACK 写这段代码是因为“\\”总是被转换为“/”，无法直接匹配字串
                // String dstPath = Path.Combine(curProjDir_Abs, curResDir_Rel, srcName);
                //if(new FileInfo(refPath_Abs).FullName != new FileInfo(dstPath).FullName)
                //    File.Copy(refPath_Abs, dstPath, true);

                // 编译XNAContent
                // ACHACK ***.xnb
                String outFile = Path.Combine(EditorService.Instance.QueryModule<ProjectModule>(null).CurProjDir, EditorService.Instance.QueryModule<ProjectModule>(null).CurProject.ContentPath, xnbFileName_Rel+".xnb");
                XNAContentMaker.BuildSingleContent(ContentType.Texture, refPath_Abs, outFile);

                String hackCpyPath = Path.Combine(Application.StartupPath, curCntDir_Rel, xnbKey + ".xnb");
                FileInfo fi = new FileInfo(hackCpyPath);
                if (!fi.Directory.Exists)
                    Directory.CreateDirectory(fi.Directory.FullName);
                File.Copy(outFile, hackCpyPath, true);

                // 数据
                ResourceData resData = new ResourceData();
                resData.ResourceKey = srcName;
                resData.Processor = "XNATexture";
                resData.Argument = "";
                resData.ContentKey = xnbKey;      // ACHACK [ContentKey硬编码] 这里按照XNA的方案，不带后缀名
                resData.ContentId = GameService.Instance.QueryModule<UIDStackModule>().Take(typeof(Texture2D));

                String resSetName = cbSet.Text;
                ResourceSetData setData = EditorService.Instance.QueryModule<ResourceSetModule>().GetResourceSetData(resSetName);
                int curResDataSetId = setData.Id;

                // 添加到资源列表配置(引擎也会加载这个资源)
                EditorService.Instance.QueryModule<ResourceSetModule>().AddResourceData(curResDataSetId, resData);

                GameService.Instance.QueryModule<ContentModule>().AddContent(curResDataSetId, resData.CreateContentData());

                // 添加列表项
                texViewControl1.AddItem(resData, true);
            }
        }

        private void TextureForm_Shown(object sender, EventArgs e)
        {
            // TODO [实现编辑器各部分按编辑状态刷新] 避免很多空对象异常，例如在项目未加载时，公共资源集就是空

            String setName = cbSet.Text;
            ResourceSetData setData = EditorService.Instance.QueryModule<ResourceSetModule>().GetResourceSetData(setName);
            if (setData == null)
                return;

            foreach (ResourceData res in setData.ResourceDataList)
            {
                if(res.ContentType == ContentType.Texture)
                    texViewControl1.AddItem(res, false);
            }
        }

        private void btnAddSet_Click(object sender, EventArgs e)
        {
            String name = cbSet.Text.Trim();
            if (String.IsNullOrEmpty(name))
                return;

            resSetMod = EditorService.Instance.QueryModule<ResourceSetModule>();
            ResourceSetData rsd = resSetMod.GetResourceSetData(name);
            if (rsd == null)
            {
                resSetMod.CreateResourceSetData(name);
                refreshSetNames();
                cbSet.Text = name;
            }
        }

        private void refreshSetNames()
        {
            cbSet.Items.Clear();
            resSetMod = EditorService.Instance.QueryModule<ResourceSetModule>();
            foreach (ResourceSetData data in resSetMod.ResInfoSetList)
            {
                cbSet.Items.Add(data.Name);
            }
        }
    }
}
