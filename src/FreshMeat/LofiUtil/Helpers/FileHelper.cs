using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace LofiUtil.Helpers
{
    public static class FileHelper
    {
        // Get the file name array of a given directory
        public static void FileTree2Xml(XmlDocument xmlDoc, ref XmlElement xmlElement)
        {
            String[] subDirs = Directory.GetDirectories(xmlElement.GetAttribute("Info"));
            foreach (String sd in subDirs)
            {
                XmlElement newElement = xmlDoc.CreateElement("Path");
                newElement.SetAttribute("Info", sd);
                FileTree2Xml(xmlDoc, ref newElement);
                xmlElement.AppendChild(newElement);
            }
            String[] files = Directory.GetFiles(xmlElement.GetAttribute("Info"));
            foreach (String file in files)
            {
                XmlElement fileElement = xmlDoc.CreateElement("File");
                fileElement.SetAttribute("Info", file);
                xmlElement.AppendChild(fileElement);
            }
        }
    }
}
