using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Lofinil.GameSDK.Engine
{
    public static class XmlSerialize
    {
        public static void Serialize(String path, Object obj)
        {
            Serialize(path, obj.GetType(), obj);
        }

        public static void Serialize(String path, Type type, Object obj)
        {
            // TECHNOTE 使用StreamWriter可以将原始文件清空，然后复写，FileStream则只是从文件前面开始覆盖
            // TECHNOTE 将FileStream的FileMode设置为Create也可以达到清空原始文件的目的
            // new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            FileInfo fInfo = new FileInfo(path);
            if (!fInfo.Directory.Exists)
                fInfo.Directory.Create();
            Stream stream = new StreamWriter(path, false).BaseStream;
            Serialize(stream, type, obj);
            stream.Close();
        }

        public static void Serialize(Stream stream, Type type, Object obj)
        {
            //Sprite sp = new Sprite();
            //Transform tr = new Transform();
            //FrameAnimator fr = new FrameAnimator();
            //TriggerBind tb = new TriggerBind();

            //ComponentList cl = new ComponentList();
            //cl.Add(sp);
            //cl.Add(tr);
            //cl.Add(fr);
            //cl.Add(tb);

            //StageData sd = new StageData();
            //sd.CompList.Add(sp);
            //sd.CompList.Add(tr);
            //sd.CompList.Add(fr);
            //sd.CompList.Add(tb);

            ////obj = cl;
            //obj = sd;
            //type = obj.GetType();

            //XmlAttributes xas = new XmlAttributes();
            //xas.XmlElements.Add(new XmlElementAttribute("BaseComponent", typeof(BaseComponent)));   // TECHNOTE 基类如果不单独序列化，则无需注册
            //xas.XmlElements.Add(new XmlElementAttribute("Sprite", typeof(Sprite)));
            //xas.XmlElements.Add(new XmlElementAttribute("Transform", typeof(Transform)));
            //xas.XmlElements.Add(new XmlElementAttribute("FrameAnimator", typeof(FrameAnimator)));
            //xas.XmlElements.Add(new XmlElementAttribute("TriggerBind", typeof(TriggerBind)));

            XmlAttributeOverrides o = /* new XmlAttributeOverrides();// */ GameService.Instance.QueryModule<AssemblyModule>().SharedXmlAttrOverrides;
            // o.Add(typeof(ComponentList), "CompList", xas);
            // o.Add(typeof(List<BaseComponent>), xas);        // TECHNOTE Xml特性替换不支持泛型类型

            XmlSerializer xs = new XmlSerializer(type, o);
            xs.Serialize(stream, obj);
            stream.Flush();
            stream.Close();
        }

        public static Object Deserialize(String path, Type type)
        {
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            return Deserialize(stream, type);
        }

        public static Object Deserialize(Stream stream, Type type)
        {
            XmlSerializer xs = new XmlSerializer(type, GameService.Instance.QueryModule<AssemblyModule>().SharedXmlAttrOverrides);
            Object obj = xs.Deserialize(stream);
            stream.Close();
            return obj;
        }
    }
}