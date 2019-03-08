using DatabaseMetadata;

namespace DatabaseScriptGenerator
{
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