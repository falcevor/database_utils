using System;
using DatabaseMetadata;

namespace DatabaseMetadataProvider
{
    internal class XmlMetadataProvider : IMetadataProvider
    {
        public Schema Import(string source)
        {
            throw new NotImplementedException();
        }

        public void Export(Schema schema, string destination)
        {
            throw new NotImplementedException();
        }
    }
}
