using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DatabaseMetadata;
using Npgsql;

namespace DatabaseMetadataProvider
{
    public class PostgreSqlMetadataProvider : IMetadataProvider
    {
        public Schema Import(string source)
        {
            using (var connection = new NpgsqlConnection(source))
            {
                DataTable schema = connection.GetSchema("Tables");
                var tables = schema.Rows.Cast<DataRow>().Select(
                    table =>
                    {
                        var tableName = table["table_name"].ToString();
                        var schemaName = "public";
                        var databaseName = connection.Database;
                        var rowsData = connection.GetSchema("Columns", new string[]{ databaseName, schemaName, tableName });
                        var rows = rowsData.Rows.Cast<DataRow>();
                        return CreateTableMetadata(table, rows);
                    });
                return new Schema()
                {
                    Name = "public",
                    Tables = tables.ToArray()
                };
            }
        }

        private Table CreateTableMetadata(DataRow tableRow, IEnumerable<DataRow> columnRows)
        {
            var tableName = tableRow["table_name"].ToString();
            var columns = columnRows.Select(
                row => new Column()
                {
                    Name = row["column_name"].ToString(),
                    Type = new DataType() { Name = row["data_type"].ToString() }
                }
            ).ToArray();
            
            return new Table()
            {
                Name = tableName,
                Columns = columns
            };
        }

        public void Export(Schema schema, string destination)
        {
            throw new NotImplementedException();
        }
    }
}
