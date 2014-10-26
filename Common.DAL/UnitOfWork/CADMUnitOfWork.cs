using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Common.DAL
{
    public class CADMUnitOfWork : UnitOfWork
    {
        public CADMUnitOfWork([Named("CADM")] IDataContext context)
        {
            _context = context;
        }
    }
}
