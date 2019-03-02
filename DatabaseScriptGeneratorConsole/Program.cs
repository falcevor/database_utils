using DatabaseMetadata;
using DatabaseScriptGenerator;
using System;
using System.Xml.Serialization;

namespace DatabaseScriptGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var columns = new Column[] { new Column() { Name = "column1" }, new Column() { Name = "column2" } };
            var prms = new Parameter[] { new Parameter() { Name = "p_column1", Type = "NUMBER" }, new Parameter() { Name = "p_column2", Type = "VARCHAR(2000)" } };
            var table = new Table() { Name = "tableName", Columns = columns };
            var serializer = new XmlSerializer(typeof(Table));
            serializer.Serialize(Console.Out, table);
            Console.WriteLine("\r\n");

            var generator = GeneratorFactory.Create(DataProviderTypes.Oracle);
            Console.WriteLine(generator.GenerateProcedureScript(ProcedureActionTypes.Add, "test_procedure", table, prms));
            Console.WriteLine();
            Console.WriteLine(generator.GenerateProcedureScript(ProcedureActionTypes.Modify, "test_procedure", table, prms));
            Console.WriteLine();
            Console.WriteLine(generator.GenerateProcedureScript(ProcedureActionTypes.Remove, "test_procedure", table, prms));
        }
    }
}
