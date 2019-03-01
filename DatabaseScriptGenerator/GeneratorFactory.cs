using System;

namespace DatabaseScriptGenerator
{
    public static class GeneratorFactory
    {
        public static IGenerator Create(DataProviderTypes type, string connectionString)
        {
            IGenerator instance = null;
            switch (type)
            {
                case DataProviderTypes.PostgreSQL:
                    instance = null;
                    break;
                case DataProviderTypes.Oracle:
                    instance = new OracleGenerator();
                    break;
                case DataProviderTypes.MSSqlServer:
                    instance = null;
                    break;
                default:
                    throw new NotSupportedException(type.ToString());
            }
            instance.Connect(connectionString);
            return instance;
        }
    }

    public enum DataProviderTypes
    {
        PostgreSQL,
        Oracle,
        MSSqlServer
    }
}
