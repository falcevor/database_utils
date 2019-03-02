using System;
using DatabaseMetadata;
using DatabaseScriptGenerator.Templates.Oracle;

namespace DatabaseScriptGenerator
{
    internal class OracleGenerator : IGenerator
    {
        public string GenerateFunctionScript(FunctionActionTypes action, string name, Table table, Parameter[] prms)
        {
            throw new NotImplementedException();
        }

        public string GenerateProcedureScript(ProcedureActionTypes action, string name, Table table, Parameter[] prms)
        {
            switch (action)
            {
                case ProcedureActionTypes.Add:
                    return GenerateAddProcedure(name, table, prms);
                case ProcedureActionTypes.Modify:
                    return GenerateModifyProcedure(name, table, prms);
                case ProcedureActionTypes.Remove:
                    return GenerateRemoveProcedure(name, table, prms);
                default:
                    return string.Empty;
            }
        }

        public string GenerateViewScript(string name, Table table)
        {
            throw new NotImplementedException();
        }

        private string GenerateAddProcedure(string name, Table table, Parameter[] prms)
        {
            var template = new AddProcedureTemplate();
            template.Generate(name, table, prms);
            return template.TransformText();
        }

        private string GenerateModifyProcedure(string name, Table table, Parameter[] prms)
        {
            var template = new ModifyProcedureTemplate();
            template.Generate(name, table, prms);
            return template.TransformText();
        }

        private string GenerateRemoveProcedure(string name, Table table, Parameter[] prms)
        {
            var template = new RemoveProcedureTemplate();
            template.Generate(name, table, prms);
            return template.TransformText();
        }
    }
}
