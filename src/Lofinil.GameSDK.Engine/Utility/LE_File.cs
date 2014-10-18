using System;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework.Storage;

namespace Lofinil.GameSDK.Engine
{
    public static class LE_File
    {
        public static String GetFileName(String path)
        {
            FileInfo info = new FileInfo(path);
            return info.Name;
        }

        public static StorageContainer GetStorageContainer()
        {
            StorageDevice sDevice = Storage.GetStorageDevice();

            if ((sDevice != null) && sDevice.IsConnected)
            {
                // Wait for the WaitHandle to become signaled. ???
                IAsyncResult result =
                    sDevice.BeginOpenContainer("SDF", null, null);

                result.AsyncWaitHandle.WaitOne();

                return sDevice.EndOpenContainer(result);
            }
            return null;
        }

        // Get the file names array of a given directory
        public static void FileTree2Xml(XmlDocument xmlDoc, ref XmlElement xmlElement, bool recurse, String ext)
        {
            if (recurse)
            {
                String[] subDirs = Directory.GetDirectories(xmlElement.GetAttribute("Info"));
                foreach (String sd in subDirs)
                {
                    XmlElement newElement = xmlDoc.CreateElement("Path");
                    newElement.SetAttribute("Info", sd);
                    FileTree2Xml(xmlDoc, ref newElement, recurse, ext);
                    xmlElement.AppendChild(newElement);
                }
            }
            String[] files = Directory.GetFiles(xmlElement.GetAttribute("Info"));
            foreach (String file in files)
            {
                if (!String.IsNullOrEmpty(ext))
                {
                    FileInfo fInfo = new FileInfo(file);
                    if (fInfo.Extension != ext)
                        continue;
                }
                
                XmlElement fileElement = xmlDoc.CreateElement("File");
                fileElement.SetAttribute("Info", file);
                xmlElement.AppendChild(fileElement);
            }
        }
    }
}