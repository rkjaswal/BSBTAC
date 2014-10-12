using BSBTAC.Service.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSBTAC.Service
{
    public class SqlBulkCopyService : ISqlBulkCopyService
    {
        public void BulkCopyFile(string filePath, string fileName)
        {
            string connString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='text;HDR=Yes;FMT=Delimited(,)';", filePath);
            using (OleDbConnection con =
                    new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand(string.Format
                                          ("SELECT * FROM [{0}]", fileName), con))
                {
                    con.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["BSBTACNonEF"].ConnectionString);
                            bulkCopy.BatchSize = 1000;

                            bulkCopy.ColumnMappings.Add(0, 2);
                            bulkCopy.ColumnMappings.Add(1, 3);
                            bulkCopy.ColumnMappings.Add(2, 4);
                            bulkCopy.ColumnMappings.Add(3, 5);
                            bulkCopy.ColumnMappings.Add(4, 6);
                            bulkCopy.ColumnMappings.Add(5, 7);
                            bulkCopy.ColumnMappings.Add(6, 8);
                            bulkCopy.ColumnMappings.Add(7, 9);
                            bulkCopy.ColumnMappings.Add(8, 10);
                            bulkCopy.ColumnMappings.Add(9, 11);
                            bulkCopy.ColumnMappings.Add(10, 12);
                            bulkCopy.ColumnMappings.Add(11, 13);

                            bulkCopy.DestinationTableName = "SearchDefinition";
                            bulkCopy.WriteToServer(reader);
                        }
                    }
                }
            }
        }
    }
}
