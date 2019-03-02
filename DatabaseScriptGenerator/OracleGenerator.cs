using System;
using DatabaseMetadata;
using DatabaseScriptGenerator.Templates.Oracle;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseScriptGenerator
{
    internal class OracleGenerator : IGenerator
    {
        private OracleConnection _connection;

        public void Connect(string connectionString)
        {
            //_connection = new OracleConnection(connectionString);
        }

        public string GenerateFunctionScript(FunctionActionTypes action, string name, Table table, Parameter[] prms)
        {
            throw new NotImplementedException();
        }

        public string GenerateProcedureScript(ProcedureActionTypes action, string name, Table table, Parameter[] prms)
        {
            AddProcedureTemplate template = new AddProcedureTemplate();
            template.Generate(name, table, prms);
            return template.TransformText();
        }

        public string GenerateViewScript(string name, Table table)
        {
            throw new NotImplementedException();
        }
    }
}
