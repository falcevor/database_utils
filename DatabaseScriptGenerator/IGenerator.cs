using DatabaseMetadata;

namespace DatabaseScriptGenerator
{
    public interface IGenerator
    {
        string GenerateViewScript(string name, Table table);
        string GenerateProcedureScript(ProcedureActionTypes action, GeneratorParameters parameters);
        string GenerateFunctionScript(FunctionActionTypes action, GeneratorParameters parameters);
    }

    public enum ProcedureActionTypes
    {
        Add,
        Remove,
        Modify
    }

    public enum FunctionActionTypes
    {
        GetByKey,
        GetAll
    }

    public class GeneratorParameters
    {
        public string Name { get; set; }
        public string TableName { get; set; }
        public Column[] Columns { get; set; }
        public Column[] FilterColumns { get; set; }
        public Parameter[] Parameters { get; set; }
        public Parameter[] FilterParameters { get; set; }
    }
}
