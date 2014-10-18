using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lofinil.GameSDK.Editor
{
    public class PathHelper
    {
        // 复制文件到指定目录
        public static String Copy(String fileName, String targetPath)
        {
            FileInfo fInfo = new FileInfo(fileName);
            String fName = fInfo.Name;
            String targetFile = Path.Combine(targetPath, fName);
            // HACK
            if(!File.Exists(targetFile))
                File.Copy(fileName, targetFile);
            return targetFile;
        }

        // 简单的绝对路径到相对路径转换
        public static String MakeRelative(String fullPath, String relativeTo)
        {
            String path = fullPath.Replace(relativeTo, "");
            if (path[0] == '\\' || path[0] == '/')
                path = path.Remove(0, 1);
            return path;
        }

        // 目录复制
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
  
            // If the source directory does not exist, throw an exception.
  
              if (!dir.Exists)
              {
                  throw new DirectoryNotFoundException(
                      "Source directory does not exist or could not be found: "
                      + sourceDirName);
              }
  
              // If the destination directory does not exist, create it.
  
              if (!Directory.Exists(destDirName))
              {
                  Directory.CreateDirectory(destDirName);
              }
  
  
              // Get the file contents of the directory to copy.
  
              FileInfo[] files = dir.GetFiles();
  
              foreach (FileInfo file in files)
              {
                  // Create the path to the new copy of the file.
  
                  string temppath = Path.Combine(destDirName, file.Name);
  
                  // Copy the file.
  
                  file.CopyTo(temppath, true);
              }
  
              // If copySubDirs is true, copy the subdirectories.
  
              if (copySubDirs)
              {
  
                  foreach (DirectoryInfo subdir in dirs)
                  {
                      // Create the subdirectory.
  
                      string temppath = Path.Combine(destDirName, subdir.Name);
  
                      // Copy the subdirectories.
  
                      DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                  }
              }
        }
    }
}
