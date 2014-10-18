using System;
using System.IO;
using System.Windows.Forms;
using LofiEditor.Projects;
using LofiEngine.Helpers;

namespace LofiEditor.SupportForms
{
    public partial class CreateProjectForm : Form
    {
        public CreateProjectForm()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            Project projectFile = new Project();

            projectFile.Path = tb_projectPath.Text;
            projectFile.Name = tb_projectName.Text;
            projectFile.GameName = tb_gameName.Text;

            String projectFolder = Path.Combine(projectFile.Path, projectFile.Name);
            if(Directory.Exists(projectFolder))
            {
                MessageBox.Show("指定目录下已经存在一个同名的工程");
                return;
            }

            Directory.CreateDirectory(projectFolder);
            Directory.CreateDirectory(Path.Combine(projectFolder, projectFile.TexturePath));
            Directory.CreateDirectory(Path.Combine(projectFolder, projectFile.SongPath));
            Directory.CreateDirectory(Path.Combine(projectFolder, projectFile.FontPath));
            Directory.CreateDirectory(Path.Combine(projectFolder, projectFile.DramaPath));
            Directory.CreateDirectory(Path.Combine(projectFolder, projectFile.ScenePath));
            Directory.CreateDirectory(Path.Combine(projectFolder, "Release"));

            SerializeHelper.Serialize(Path.Combine(projectFolder, projectFile.Name + ".lfxproj"), typeof(Project), projectFile);
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
