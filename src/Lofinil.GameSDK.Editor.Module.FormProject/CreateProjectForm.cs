using System;
using System.IO;
using System.Windows.Forms;
using Lofinil.GameSDK.Editor;

namespace Lofinil.GameSDK.Editor.Module.Project
{
    public partial class CreateProjectForm : Form
    {
        public String ProjFile;

        public CreateProjectForm()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            String projectDir = tb_projectPath.Text.Trim();
            String gameName = tb_gameName.Text.Trim();
            String author = tb_auther.Text.Trim();

            if(String.IsNullOrEmpty(projectDir) || !Directory.Exists(projectDir))
            {
                MessageBox.Show("项目路径非法或不存在");
                return;
            }

            if (chbCreateFolder.Checked)
                projectDir = Path.Combine(projectDir, tb_gameName.Text);
            
            if(Directory.Exists(projectDir))
            {
                MessageBox.Show("目录已存在，请另行选择");
                return;
            }

            String projectFile = Path.Combine(projectDir, tb_gameName.Text + EditorStatics.ProjectExt);
            if (File.Exists(projectFile))
            {
                MessageBox.Show("存在同名的项目文件，请另行选择");
            }

            EditorService.Instance.QueryModule<ProjectModule>(null).CreateProject(projectDir, gameName, author);

            ProjFile = Path.Combine(projectDir, gameName +  ".lfp");

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

        private void btn_browseProjectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                String path = fbd.SelectedPath;
                tb_projectPath.Text = path;
            }
        }
    }
}
