using System;
using System.Xml.Serialization;

namespace BidfoodCreditApplication.Models
{
    [Serializable]
    public class CherwellFieldList
    {
        public CherwellFieldList()
        {
            Fields = null;
        }

        [XmlElement("Field", Type = typeof(CherwellField))]
        public CherwellField[] Fields { get; set; }
    }
}