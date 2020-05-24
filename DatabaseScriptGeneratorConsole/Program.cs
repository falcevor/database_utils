using DatabaseMetadata;
using DatabaseScriptGenerator;
using System;
using System.Data;
using System.Linq;
using System.Xml.Serialization;
using DatabaseScriptGenerator.Parameters;

namespace DatabaseScriptGeneratorConsole
{
    internal static class Program
    {
        //var generator = GeneratorFactory.Create(DataProviderTypes.PostgreSql);
        //var metadataProvider = MetadataProviderFactory.Create(MetadataProviderTypes.PostgreSql);
        //var schema = metadataProvider.Import("User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=TaxService;");

        private static void Main(string[] args)
        {
            var columns = new[] { new Column() { Name = "column1", Type = new DataType() { Name = "INTEGER" } }, new Column() { Name = "column2", Type = new DataType() { Name = "VARCHAR", Length = 2000 } } };
            var parameters = new[] { new Parameter() { Name = "p_column1", Type = new DataType() { Name = "INTEGER" } }, new Parameter() { Name = "p_column2", Type = new DataType() { Name = "VARCHAR", Length = 2000 } } };
            var table = new Table() { Name = "tableName", Columns = columns };
            var generatorParameters = new GeneratorParameters()
            {
                Name = "test_procedure",
                Columns = table.Columns,
                Parameters = parameters,
                TableName = "test_table_name",
                FilterColumns = new[] { columns[0] },
                FilterParameters = new[] { new Parameter() { Name = "p_column3", Type = new DataType() { Name = "INTEGER" } } }
            };
            var serializer = new XmlSerializer(typeof(Table));
            serializer.Serialize(Console.Out, table);
            Console.WriteLine("\r\n");

            var generator = GeneratorFactory.Create(DataProviderTypes.Oracle);
            Console.WriteLine(generator.GenerateProcedureScript(ProcedureActionTypes.Add, generatorParameters));
            Console.WriteLine();
            Console.WriteLine(generator.GenerateProcedureScript(ProcedureActionTypes.Modify, generatorParameters));
            Console.WriteLine();
            Console.WriteLine(generator.GenerateProcedureScript(ProcedureActionTypes.Remove, generatorParameters));
        }

        private static Parameter[] CreateParameters(Column[] columns)
        {
            return columns.Select(column => new Parameter() {Name = $"p_{column.Name}", Type = column.Type}).ToArray();
        }
    }
}
