using System.Xml.Serialization;

namespace DatabaseMetadata
{
    [XmlRoot]
    public class ColumnBase
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Type { get; set; }
    }
}
