using DatabaseMetadata;

namespace DatabaseScriptGenerator
{
    public interface IGenerator
    {
        string GenerateViewScript(string name, Table table);
        string GenerateProcedureScript(ProcedureActionTypes action, GeneratorParameters parameters);
        string GenerateFunctionScript(FunctionActionTypes action, GeneratorParameters parameters);
    }
}
