using DatabaseMetadata;

namespace DatabaseScriptGenerator
{
    public interface IGenerator
    {
        void Connect(string connectionString);
        string GenerateViewScript(string name, Table table);
        string GenerateProcedureScript(ProcedureActionTypes action, string name, Table table);
        string GenerateFunctionScript(FunctionActionTypes action, string name, Table table);
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
}
