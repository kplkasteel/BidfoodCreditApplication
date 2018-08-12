using System.IO;
using System.Xml.Serialization;

namespace BidfoodCreditApplication.Models
{
    [XmlRoot("BusinessObject")]
    public sealed class CherwellBusinessObject
    {
        public CherwellBusinessObject()
        {
            FieldList = null;
        }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Global.NewUserRecordId")]
        public string RecId { get; set; }

        [XmlElement("FieldList", Type = typeof(CherwellFieldList))]
        public CherwellFieldList FieldList { get; set; }

        public static CherwellBusinessObject FromXmlString(string xmlString)
        {
            var textReader = new StringReader(xmlString);
            var xmlSerializer = new XmlSerializer(typeof(CherwellBusinessObject));
            return (CherwellBusinessObject) xmlSerializer.Deserialize(textReader);
        }

        public string ToXmlString()
        {
            var stringWriter = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(CherwellBusinessObject));
            xmlSerializer.Serialize(stringWriter, this);
            return stringWriter.ToString();
        }
    }
}