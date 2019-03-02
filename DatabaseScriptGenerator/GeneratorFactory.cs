using System;

namespace DatabaseScriptGenerator
{
    public static class GeneratorFactory
    {
        public static IGenerator Create(DataProviderTypes type)
        {
            switch (type)
            {
                case DataProviderTypes.PostgreSQL:
                    return new PosrgreSqlGenerator();
                case DataProviderTypes.Oracle:
                    return new OracleGenerator();
                case DataProviderTypes.MSSqlServer:
                    throw new NotSupportedException(type.ToString());
                default:
                    throw new NotSupportedException(type.ToString());
            }
        }
    }

    public enum DataProviderTypes
    {
        PostgreSQL,
        Oracle,
        MSSqlServer
    }
}
