using DatabaseMetadata;

namespace DatabaseMetadataProvider
{
    public interface IMetadataProvider
    {
        Schema Import(string source);
        void Export(Schema schema, string destination);
    }
}
