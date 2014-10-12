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
    public class AccountFileParserService : IFileParserService
    {
        private OleDbConnection connection;
        private OleDbCommand command;
        private OleDbDataReader reader;
        private string fileName;
        private IUnitOfWork uow;

        public AccountFileParserService(OleDbConnection connection, OleDbCommand command, 
            OleDbDataReader reader, string fileName, IUnitOfWork uow)
        {
            this.connection = connection;
            this.command = command;
            this.reader = reader;
            this.fileName = fileName;
            this.uow = uow;
        }

        public void ParseFile(string filePath, int uploadDetailId)
        {
            
        }
    }
}
