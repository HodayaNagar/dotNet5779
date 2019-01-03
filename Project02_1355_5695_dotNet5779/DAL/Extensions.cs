using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DAL
{
    public static class Extensions
    {

        public static T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public static string ToXml<T>(this T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }

        //public static string ToXml(this object obj)
        //{
        //    if (obj == null) return string.Empty;

        //    var stringwriter = new System.IO.StringWriter();
        //    var serializer = new XmlSerializer(obj.GetType());
        //    serializer.Serialize(stringwriter, obj);
        //    return stringwriter.ToString();
        //}

    }
}
