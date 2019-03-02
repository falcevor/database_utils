using System.Xml.Serialization;

namespace DatabaseMetadata
{
    [XmlRoot]
    public class Parameter
    {
        [XmlAttribute]
        public string Name { get; set; }
    }
}
