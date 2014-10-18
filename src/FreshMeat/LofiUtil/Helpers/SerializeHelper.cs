using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LofiUtil.Helpers
{
    public static class SerializeHelper
    {
        public static void Serialize(String path, Type type, Object obj)
        {
            XmlSerializer xs = new XmlSerializer(type);
            StreamWriter sw = new StreamWriter(path, false);
            xs.Serialize(sw.BaseStream, obj);
            sw.Flush();
            sw.Close();
        }

        public static Object Deserialize(String path, Type type)
        {
            XmlSerializer xs = new XmlSerializer(type);
            StreamReader sr = new StreamReader(path);
            Object obj = xs.Deserialize(sr.BaseStream);
            sr.Close();
            return obj;            
        }
    }
}
