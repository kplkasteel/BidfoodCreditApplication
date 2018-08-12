using System;
using System.Xml.Serialization;

namespace BidfoodCreditApplication.Models
{
    [Serializable]
    public class CherwellField
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}