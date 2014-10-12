using BSBTAC.Domain;
using BSBTAC.Service.Interface;
using Common.DAL;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSBTAC.Service
{
    public class FileParserFactory
    {
        public static IFileParserService CreateFileParser(string fileName)
        {
            string conn = "";
            if (true)
            {
                IFileParserService fileParser = 
                    new AccountFileParserService(
                        new OleDbConnection(conn), 
                        new OleDbCommand(),
                        new OleDbDataReader(),
                        fileName,
                        new UnitOfWork(new BSBTACContext()));
            }
            else
            {
                IFileParserService fileParser =
                    new AllInfoFileParserService(
                        new OleDbConnection(conn),
                        new OleDbCommand(),
                        new OleDbDataReader(),
                        fileName);
            }

        }
    }
}
