using System;
using DatabaseMetadata;
using DatabaseScriptGenerator.Generators;

namespace DatabaseScriptGenerator
{
    public static class GeneratorFactory
    {
        public static IGenerator Create(DataProviderTypes type)
        {
            switch (type)
            {
                case DataProviderTypes.PostgreSql:
                    return new PostgreSqlGenerator();
                case DataProviderTypes.Oracle:
                    return new OracleGenerator();
                case DataProviderTypes.MsSqlServer:
                    throw new NotSupportedException(type.ToString());
                default:
                    throw new NotSupportedException(type.ToString());
            }
        }
    }
}
