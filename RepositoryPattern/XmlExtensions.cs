using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RepositoryPattern
{
    public static class XmlExtensions
    {
        public static void WriteToXml<T>(List<T> source, string filename)
        {
            XmlSerializer xmlSerializer = new(typeof(List<T>));
            using TextWriter writer = new StreamWriter(filename);
            xmlSerializer.Serialize(writer, source);
        }

        public static List<T> LoadFromXml<T>(string filename)
        {
            XmlSerializer xmlSerializer = new(typeof(List<T>));
            using FileStream fs = new(filename, FileMode.OpenOrCreate);
            if (fs.Length == 0)
            {
                return new List<T>();
            }

            List<T> data = (List<T>)xmlSerializer.Deserialize(fs);
            return data;
        }
    }
}
