using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public static class Extensions
    {
        public static string ToXml(this object obj)
        {
            if (obj == null) return string.Empty;
            
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(stringwriter, obj);
            return stringwriter.ToString();
        }

    }
}
