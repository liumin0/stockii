using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Stockii
{
    public static class MySerializer
    {
        /// <summary>
        /// 序列化对象到XML文件
        /// </summary>
        /// <param name="fileName">文件全名</param>
        /// <param name="obj">对象</param>
        public static void SaveToXml(string fileName, object obj)
        {
            SaveToXml(fileName, obj, obj.GetType());
        }

        /// <summary>
        /// 序列化某对象到本地文件
        /// </summary>
        /// <param name="fileName">文件全名</param>
        /// <param name="obj">对象</param>
        /// <param name="type">指定对象类型</param>
        public static void SaveToXml(string fileName, object obj, Type type)
        {
            using (var writer = new StreamWriter(fileName))
            {
                var xs = new XmlSerializer(type);
                xs.Serialize(writer, obj);
            }
        }

        /// <summary>
        /// 从XML格式文件反序列化对象
        /// </summary>
        /// <param name="fileName">文件全名</param>
        /// <param name="type">对象类型</param>
        /// <returns>对象</returns>
        public static object LoadFromXml(string fileName, Type type)
        {
            using (var reader = new StreamReader(fileName))
            {
                var xs = new XmlSerializer(type);
                object obj = xs.Deserialize(reader);
                return obj;
            }
        }
    }
}
