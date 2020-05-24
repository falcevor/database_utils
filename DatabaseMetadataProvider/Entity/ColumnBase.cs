using System.Xml.Serialization;

namespace DatabaseMetadata
{
    [XmlRoot]
    public class ColumnBase
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public DataType Type { get; set; }
    }
}
