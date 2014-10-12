using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSBTAC.Service.Interface
{
    public interface ISqlBulkCopyService
    {
        void BulkCopyFile(string filePath, string fileName);
    }
}
