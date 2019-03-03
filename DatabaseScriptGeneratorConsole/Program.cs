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
            var columns = new Column[] { new Column() { Name = "column1", Type = new DataType() { Name = "INTEGER" } }, new Column() { Name = "column2", Type = new DataType() { Name = "VARCHARH", Length = 2000 } } };
            var prms = new Parameter[] { new Parameter() { Name = "p_column1", Type = new DataType() { Name = "INTEGER" } }, new Parameter() { Name = "p_column2", Type = new DataType() { Name = "VARCHARH", Length = 2000 } } };
            var table = new Table() { Name = "tableName", Columns = columns };
            var parameters = new GeneratorParameters()
            {
                Name = "test_procedure",
                Columns = table.Columns,
                Parameters = prms,
                TableName = "test_table_name",
                FilterColumns = new Column[] { columns[0] },
                FilterParameters = new Parameter[] { new Parameter() { Name = "p_column3", Type = new DataType() { Name = "INTEGER" } } }
            };
            var serializer = new XmlSerializer(typeof(Table));
            serializer.Serialize(Console.Out, table);
            Console.WriteLine("\r\n");

            var generator = GeneratorFactory.Create(DataProviderTypes.Oracle);
            Console.WriteLine(generator.GenerateProcedureScript(ProcedureActionTypes.Add, parameters));
            Console.WriteLine();
            Console.WriteLine(generator.GenerateProcedureScript(ProcedureActionTypes.Modify, parameters));
            Console.WriteLine();
            Console.WriteLine(generator.GenerateProcedureScript(ProcedureActionTypes.Remove, parameters));
        }
    }
}
