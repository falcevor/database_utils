using System.Text;
using System.Xml.Serialization;

namespace DatabaseMetadata
{
    [XmlRoot]
    public class DataType
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public int Length { get; set; }

        [XmlAttribute]
        public int Precision { get; set; }

        [XmlAttribute]
        public bool NotNull { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Name);
            if (Length > 0)
            {
                sb.Append("(");
                sb.Append(Length);
                if (Precision > 0)
                {
                    sb.Append(", ");
                    sb.Append(Precision);
                }
                sb.Append(")");
            }
            return sb.ToString();
        }
    }
}
