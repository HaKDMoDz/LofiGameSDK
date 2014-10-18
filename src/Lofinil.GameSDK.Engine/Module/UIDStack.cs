using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lofinil.GameSDK.Engine
{
    public class UIDStack
    {
        public String Name;
        public Stack<int> Ids;
        public int Capacity;

        public UIDStack()
        {
            Name = "";
            Ids = new Stack<int>();
            Capacity = 0;
        }

        public UIDStack(UIDStackData info)
        {
            Name = info.Name;
            Ids = new Stack<int>(info.Ids);
            Ids.Reverse();
            Capacity = info.Capacity;
        }

        public UIDStackData CreateInfo()
        {
            UIDStackData info = new UIDStackData();
            info.Name = Name;
            info.Ids = new List<int>(Ids.ToArray().Reverse());
            info.Capacity = Capacity;
            return info;
        }
    }

    public class UIDStackData
    {
        public String Name;
        public List<int> Ids;
        public int Capacity;
    }

    public class UIDStackModule : BaseModule
    {
        public List<UIDStack> IdCats;

        public UIDStackModule()
        {
            IdCats = new List<UIDStack>();
        }

        public override void Initialize(Architecture.IService service)
        {
            base.Initialize(service);
        }
        
        #region 文件操作

        public void New(String path)
        {
            List<UIDStackData> list = new List<UIDStackData>();
            XmlSerialize.Serialize(path, list);
        }

        public void Read(String path)
        {
            List<UIDStackData> list = (List<UIDStackData>)XmlSerialize.Deserialize(path, typeof(List<UIDStackData>));
            IdCats = new List<UIDStack>();
            foreach (UIDStackData i in list)
            {
                IdCats.Add(new UIDStack(i));
            }
        }

        public void Write(String path)
        {
            List<UIDStackData> list = new List<UIDStackData>();
            foreach (UIDStack ids in IdCats)
            {
                UIDStackData i = ids.CreateInfo();
                list.Add(i);
            }
            XmlSerialize.Serialize(path, list);
        }

        #endregion 文件操作

        #region Take & Recycle

        public int Take(Type type)
        {
            String typeName = type.ToString();
            UIDStack cat = IdCats.Find(c => c.Name == typeName);
            if (cat == null)
            {
                cat = new UIDStack();
                cat.Name = typeName;
                IdCats.Add(cat);
            }
            if (cat.Ids.Count == 0)
            {
                for (int i = cat.Capacity + 100; i > cat.Capacity; i--)
                {
                    cat.Ids.Push(i);
                }
                cat.Capacity += 100;
            }
            return cat.Ids.Pop();
        }

        public void Recycle(Type type, int id)
        {
            String typeName = type.ToString();
            UIDStack cat = IdCats.Find(c => c.Name == typeName);
            if (cat != null)
            {
                cat.Ids.Push(id);
            }
        }

        #endregion Take & Recycle
    }
}
