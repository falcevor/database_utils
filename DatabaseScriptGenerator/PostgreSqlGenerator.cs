using System;
using DatabaseMetadata;
using DatabaseScriptGenerator.Templates.PostgreSQL;

namespace DatabaseScriptGenerator
{
    internal class PosrgreSqlGenerator : IGenerator
    {
        public string GenerateFunctionScript(FunctionActionTypes action, GeneratorParameters parameters)
        {
            throw new NotImplementedException();
        }

        public string GenerateProcedureScript(ProcedureActionTypes action, GeneratorParameters prms)
        {
            switch (action)
            {
                case ProcedureActionTypes.Add:
                    return GenerateAddProcedure(prms.Name, prms.TableName, prms.Columns, prms.Parameters);
                case ProcedureActionTypes.Modify:
                    return GenerateModifyProcedure(prms.Name, prms.TableName, prms.Columns, prms.Parameters, prms.FilterColumns, prms.FilterParameters);
                case ProcedureActionTypes.Remove:
                    return GenerateRemoveProcedure(prms.Name, prms.TableName, prms.FilterColumns, prms.FilterParameters);
                default:
                    return string.Empty;
            }
        }

        public string GenerateViewScript(string name, Table table)
        {
            throw new NotImplementedException();
        }

        private string GenerateAddProcedure(string name, string tableName, Column[] columns, Parameter[] prms)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentException(nameof(tableName));
            if (columns == null) throw new ArgumentException(nameof(columns));
            if (prms == null) throw new ArgumentException(nameof(prms));
            if (columns.Length != prms.Length) throw new ArgumentException($"{nameof(columns)}'s length is not equal to {nameof(prms)}'s length");

            var template = new AddProcedureTemplate();
            template.Generate(name, tableName, columns, prms);
            return template.TransformText();
        }

        private string GenerateModifyProcedure(string name, string tableName, Column[] columns, Parameter[] prms, Column[] filterColumns, Parameter[] filterPrms)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentException(nameof(tableName));
            if (columns == null) throw new ArgumentException(nameof(columns));
            if (prms == null) throw new ArgumentException(nameof(prms));
            if (columns.Length != prms.Length) throw new ArgumentException($"{nameof(columns)}'s length is not equal to {nameof(prms)}'s length");
            if (filterColumns?.Length != filterPrms?.Length) throw new ArgumentException($"{nameof(filterColumns)}'s length is not equal to {nameof(filterPrms)}'s length");

            var template = new ModifyProcedureTemplate();
            template.Generate(name, tableName, columns, prms, filterColumns, filterPrms);
            return template.TransformText();
        }

        private string GenerateRemoveProcedure(string name, string tableName, Column[] filterColumns, Parameter[] filterPrms)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentException(nameof(tableName));
            if (filterColumns?.Length != filterPrms?.Length) throw new ArgumentException($"{nameof(filterColumns)}'s length is not equal to {nameof(filterPrms)}'s length");

            var template = new RemoveProcedureTemplate();
            template.Generate(name, tableName, filterColumns, filterPrms);
            return template.TransformText();
        }
    }
}
