using BSBTAC.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSBTAC.Service
{
    public class AllInfoFileParserService : IFileParserService
    {
        private OleDbConnection connection;
        private OleDbCommand command;
        private OleDbDataReader reader;
        private string fileName;

        public AllInfoFileParserService(OleDbConnection connection, OleDbCommand command, 
            OleDbDataReader reader, string fileName)
        {
            this.connection = connection;
            this.command = command;
            this.reader = reader;
            this.fileName = fileName;
        }

        public void ParseFile(string filePath, int uploadDetailId)
        {
            
        }
    }
}
