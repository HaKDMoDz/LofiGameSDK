using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LofiEngine.Helpers;
using System.IO;

namespace LofiEditor.Projects
{
    class ProjectMgr
    {
        #region Variables
        public String ProjectPath = "";
        public Project CurrentProject = null;
        #endregion

        #region Instance
        private static ProjectMgr instance;
        public static ProjectMgr Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProjectMgr();
                return instance;
            }
        }
        private ProjectMgr()
        {
        }
        #endregion

        #region Manager Project
        public void OpenProject(String path)
        {
            CurrentProject = (Project)(SerializeHelper.Deserialize(path, typeof(Project)));

            LoadHelper.TexturePath = CurrentProject.TexturePath;
            LoadHelper.FontPath = CurrentProject.FontPath;
            LoadHelper.ScenePath = CurrentProject.ScenePath;
            LoadHelper.SongPath = CurrentProject.SongPath;
            LoadHelper.DramaPath = CurrentProject.DramaPath;
        }
        #endregion
    }
}
