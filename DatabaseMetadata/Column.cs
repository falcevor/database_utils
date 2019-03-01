using System.Xml.Serialization;
namespace DatabaseMetadata
{
    [XmlRoot]
    public class Column
    {
        [XmlAttribute]
        public string Name { get; set; }
    }
}
