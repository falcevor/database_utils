using System.Xml.Serialization;

namespace DatabaseMetadata
{
    [XmlRoot]
    public class Table
    {
        [XmlAttribute]
        public string Name { get; set; }
        
        [XmlArrayItem]
        public Column[] Columns { get; set; }
    }
}
