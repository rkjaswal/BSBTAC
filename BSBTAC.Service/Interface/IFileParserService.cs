using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSBTAC.Service.Interface
{
    public interface IFileParserService
    {
        void ParseFile(string filePath, int uploadDetailId);
    }
}
