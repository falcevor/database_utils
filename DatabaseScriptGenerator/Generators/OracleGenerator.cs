using System;
using DatabaseMetadata;
using DatabaseScriptGenerator.Parameters;
using DatabaseScriptGenerator.Templates.Oracle;

namespace DatabaseScriptGenerator.Generators
{
    internal class OracleGenerator : IGenerator
    {
        public string GenerateFunctionScript(FunctionActionTypes action, GeneratorParameters parameters)
        {
            throw new NotImplementedException();
        }

        public string GenerateProcedureScript(ProcedureActionTypes action, GeneratorParameters parameters)
        {
            switch (action)
            {
                case ProcedureActionTypes.Add:
                    return GenerateAddProcedure(parameters.Name, parameters.TableName, parameters.Columns,
                        parameters.Parameters);
                case ProcedureActionTypes.Modify:
                    return GenerateModifyProcedure(parameters.Name, parameters.TableName, parameters.Columns,
                        parameters.Parameters, parameters.FilterColumns, parameters.FilterParameters);
                case ProcedureActionTypes.Remove:
                    return GenerateRemoveProcedure(parameters.Name, parameters.TableName, parameters.FilterColumns,
                        parameters.FilterParameters);
                default:
                    return string.Empty;
            }
        }

        public string GenerateViewScript(string name, Table table)
        {
            throw new NotImplementedException();
        }

        private string GenerateAddProcedure(string name, string tableName, Column[] columns, 
            Parameter[] parameters)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentException(nameof(tableName));
            if (columns == null)
                throw new ArgumentException(nameof(columns));
            if (parameters == null)
                throw new ArgumentException(nameof(parameters));
            if (columns.Length != parameters.Length)
                throw new ArgumentException($"{nameof(columns)}'s length is not equal to {nameof(parameters)}'s length");

            var template = new AddProcedureTemplate();
            template.Generate(name, tableName, columns, parameters);
            return template.TransformText();
        }

        private string GenerateModifyProcedure(string name, string tableName, Column[] columns, 
            Parameter[] parameters, Column[] filterColumns, Parameter[] filterParameters)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentException(nameof(tableName));
            if (columns == null)
                throw new ArgumentException(nameof(columns));
            if (parameters == null)
                throw new ArgumentException(nameof(parameters));
            if (columns.Length != parameters.Length)
                throw new ArgumentException($"{nameof(columns)}'s length is not equal to {nameof(parameters)}'s length");
            if (filterColumns?.Length != filterParameters?.Length)
                throw new ArgumentException($"{nameof(filterColumns)}'s length is not equal to {nameof(filterParameters)}'s length");

            var template = new ModifyProcedureTemplate();
            template.Generate(name, tableName, columns, parameters, filterColumns, filterParameters);
            return template.TransformText();
        }

        private string GenerateRemoveProcedure(string name, string tableName, Column[] filterColumns,
            Parameter[] filterParameters)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentException(nameof(tableName));
            if (filterColumns?.Length != filterParameters?.Length)
                throw new ArgumentException($"{nameof(filterColumns)}'s length is not equal to {nameof(filterParameters)}'s length");

            var template = new RemoveProcedureTemplate();
            template.Generate(name, tableName, filterColumns, filterParameters);
            return template.TransformText();
        }
    }
}
