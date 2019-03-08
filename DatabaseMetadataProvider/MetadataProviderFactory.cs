using System;

namespace DatabaseMetadataProvider
{
    public static class MetadataProviderFactory
    {
        public static IMetadataProvider Create(MetadataProviderTypes type)
        {
            switch (type)
            {
                case MetadataProviderTypes.Xml:
                    return new XmlMetadataProvider();
                case MetadataProviderTypes.MsSqlServer:
                    return new MsSqlServerMetadataProvider();
                case MetadataProviderTypes.PostgreSql:
                    return new PostgreSqlMetadataProvider();
                case MetadataProviderTypes.Oracle:
                    return new OracleMetadataProvider();
                default:
                    throw new NotSupportedException(type.ToString());
            }
        }
    }
}
