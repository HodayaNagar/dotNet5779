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

        // Clean Xml
        public static string ToXml<T>(this T obj)
        {
            if (obj == null) return string.Empty;

            // Create our own empty namespace
            XmlSerializerNamespaces emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(textWriter, settings))
                {
                    xmlSerializer.Serialize(textWriter, obj, emptyNamespaces);
                    return textWriter.ToString();
                }
            }
        }

        /*
        public static string Serialize<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }
        */
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