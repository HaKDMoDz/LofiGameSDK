using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Lofinil.GameSDK.Engine;
using System.IO;

namespace Lofinil.GameSDK.Editor
{
    public class ResourceData
    {
        public String ResourceKey;

        public String Processor;            // 资源处理器
        public String Argument;             // 相关参数

        public ContentType ContentType;     // 输出内容类型
        public int ContentId;
        public String ContentKey;

        public ContentData CreateContentData()
        {
            ContentData cData = new ContentData();
            cData.Id = ContentId;
            cData.Key = ContentKey;
            cData.Type = ContentType;
            return cData;
        }
    }

    public class ResourceSetData
    {
        public int Id;

        public String Name;

        [XmlIgnore]
        public String Path;

        public List<ResourceData> ResourceDataList;

        public ResourceSetData()
        {
            ResourceDataList = new List<ResourceData>();
        }

        public ContentSetData CreateContentSetData()
        {
            ContentSetData csInfo = new ContentSetData();
            csInfo.Name = this.Name;
            foreach (ResourceData ri in ResourceDataList)
            {
                ContentData ci = new ContentData();
                ci.Id = ri.ContentId;
                ci.Key = ri.ContentKey;
                ci.Type = ri.ContentType;
                csInfo.ContentDataList.Add(ci);
            }

            return csInfo;
        }

        #region 一级子项 ResourceData
        public void Add(ResourceData data)
        {
            ResourceDataList.Add(data);
        }
        #endregion 一级子项 ResourceData
    }
}
