using System.Xml.Serialization;

namespace DatabaseMetadata
{
    [XmlRoot]
    public class Schema
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArrayItem]
        public Table[] Tables { get; set; }
    }
}
