using System.IO;
using System.Xml.Serialization;

namespace Common.XMLDataParser
{
    public static class XMLDataParser
    {
        public static T ParseXML<T>(string xml, string rootAttr) where T : class
        {
            var result = default(T);
            using (TextReader sr = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootAttr));
                result = (T)serializer.Deserialize(sr);
            }

            return result;
        }
    }
}
