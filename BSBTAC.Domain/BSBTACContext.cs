using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BSBTAC.Domain.Models;
using Common.DAL;

namespace BSBTAC.Domain
{
    public partial class BSBTACContext : DataContext
    {
        public BSBTACContext()
            : base("Name=BSBTACContext")
        {
            Database.SetInitializer<BSBTACContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplSummary>().ToTable("ApplSummary");
            modelBuilder.Entity<Cameo2006>().ToTable("Cameo2006");
            modelBuilder.Entity<SearchDefinition>().ToTable("SearchDefinition");
            modelBuilder.Entity<UploadDetail>().ToTable("UploadDetail");
            modelBuilder.Entity<ServiceType>().ToTable("ServiceType");

            modelBuilder.Entity<SearchDefinition>()
                .MapToStoredProcedures(p => p.Update(u => u.HasName("spUpdateSearchStatus")
                    .Parameter(b => b.SearchDefinitionId, "SearchDefinitionId")
                    .Parameter(b => b.LastUpdatedDatetime, "LastUpdatedDatetime")
                    .Parameter(b => b.Status, "Status")));
        }
    }
}
