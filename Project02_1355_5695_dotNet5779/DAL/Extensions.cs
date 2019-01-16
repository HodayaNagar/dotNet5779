using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DAL
{
    public static class Extensions
    {

        public static T ToObject<T>(this string input) where T : class
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
              //  Encoding = Encoding.UTF8,
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

        public static string xmlWriting(this string s)
        {
            s = s.Replace("&lt;", "<");
            s = s.Replace("&gt;", ">");
            //# this has to be last:
            s = s.Replace("&amp;", "&");
            return s;
        }

        /// <summary>
        /// Calculate hashed id number by using MD5 algorithm
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetHashedID(this string input)
        {
            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }


        public static string ToFullID(this string ID)
        {
            return ID.PadLeft(9, '0');
        }

        public static int NumberDayOfWeek(this DateTime d)
        {
            return (int)d.DayOfWeek;
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
