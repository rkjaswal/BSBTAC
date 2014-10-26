using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DAL;
using System.Data.Entity;
using BSBTAC.Domain.Models;

namespace BSBTAC.Domain
{
    public class CADMContext : DataContext
    {
        public CADMContext()
            : base("Name=CADMContext")
        {
            Database.SetInitializer<BSBTACContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiteLogin>().ToTable("SiteLogin");

            modelBuilder.Entity<SiteLogin>()
                .MapToStoredProcedures(p => p.Update(s => s.HasName("CreateSiteLogin")));

            base.OnModelCreating(modelBuilder);
        }
    }
}
