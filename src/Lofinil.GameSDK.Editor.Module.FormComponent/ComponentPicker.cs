using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor.App;
using System.IO;
using Lofinil.GameSDK.Editor.Module.Component;

namespace Lofinil.GameSDK.Editor.Module.FormComponent
{
    public partial class ComponentPicker : PictureBox
    {
        public String ComponentName;

        public ComponentPicker()
        {
            InitializeComponent();
        }

        private void ComponentPicker_Click(object sender, EventArgs e)
        {
            PickComponentForm pcForm = new PickComponentForm();
            DialogResult dr = pcForm.ShowDialog();
            {
                if (dr == DialogResult.OK)
                {
                    // HACK
                    EditorService.Instance.QueryModule<ComponentModule>().PenType = pcForm.SelComp;

                    String compName = pcForm.SelComp.CompType.Name;
                    // ACHACK [临时组件图标引入] 用一个字符串拼接获取编辑器某目录下预放置的图片文件
                    String file = "Resources/CompIcon/" + compName + ".png";
                    if (File.Exists(file))
                    {
                        Bitmap bmp = new Bitmap(file);
                        this.Image = bmp;
                    }
                    ComponentName = compName;
                }
            }
        }
    }
}
