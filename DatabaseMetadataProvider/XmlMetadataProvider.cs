using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using DatabaseMetadata;

namespace DatabaseMetadataProvider
{
    internal class XmlMetadataProvider : IMetadataProvider
    {
        private readonly XmlSerializer _serializer;

        public XmlMetadataProvider()
        {
            _serializer = new XmlSerializer(typeof(Schema));
        }

        public Schema Import(string source)
        {
            var stream = new FileStream(source, FileMode.Open);
            if (!(_serializer.Deserialize(stream) is Schema schema))
                throw new SerializationException("Deserializer returned NULL");
            return schema;
        }

        public void Export(Schema schema, string destination)
        {
            var stream = new FileStream(destination, FileMode.Create);
            _serializer.Serialize(stream, schema);
        }
    }
}
