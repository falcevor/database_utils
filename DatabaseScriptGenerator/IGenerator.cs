using DatabaseScriptGenerator.Parameters;

namespace DatabaseScriptGenerator
{
    public interface IGenerator
    {
        string GenerateViewScript(GeneratorParameters parameters);
        string GenerateProcedureScript(ProcedureActionTypes action, GeneratorParameters parameters);
        string GenerateFunctionScript(FunctionActionTypes action, GeneratorParameters parameters);
    }
}
