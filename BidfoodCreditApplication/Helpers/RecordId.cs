using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace BidfoodCreditApplication.Helpers
{
    public class RecordId
    {
        public static List<string> GetRecordId(string userListString, string myXmlElement)
        {
            var list = new List<string>();
            using (var xmlReader = XmlReader.Create(new StringReader(userListString)))
            {
                while (!xmlReader.EOF)
                {
                    xmlReader.ReadToFollowing(myXmlElement);
                    xmlReader.MoveToNextAttribute();
                    xmlReader.MoveToNextAttribute();
                    if (!xmlReader.HasValue)
                        break;
                    list.Add(xmlReader.Value);
                }
            }
            return list;
        }
    }
}