using DatabaseMetadata;
using DatabaseScriptGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatabaseScriptGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var columns = new Column[] { new Column() { Name = "column1" }, new Column() { Name = "column2" } };
            var prms = new Parameter[] { new Parameter() { Name = "p_column1" }, new Parameter() { Name = "p_column2" } };
            var table = new Table() { Name = "tableName", Columns = columns };
            var serializer = new XmlSerializer(typeof(Table));
            serializer.Serialize(Console.Out, table);


            var generator = GeneratorFactory.Create(DataProviderTypes.Oracle, "");
            Console.WriteLine(generator.GenerateProcedureScript(ProcedureActionTypes.Add, "test_procedure", table, prms));
        }
    }
}
