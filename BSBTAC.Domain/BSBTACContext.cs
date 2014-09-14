using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BSBTAC.Domain.Mapping;
using BSBTAC.Domain.Models;
using Common.DAL;

namespace BSBTAC.Domain
{
    public partial class BSBTACContext : DataContext
    {
        static BSBTACContext()
        {
            Database.SetInitializer<BSBTACContext>(null);
        }

        public BSBTACContext()
            : base("Name=BSBTACContext")
        {
        }

        public DbSet<ApplSummary> ApplSummaries { get; set; }
        public DbSet<Cameo2006> Cameo2006 { get; set; }
        public DbSet<SearchDefinition> SearchDefinitions { get; set; }
        public DbSet<UploadDetail> UploadDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplSummaryMap());
            modelBuilder.Configurations.Add(new Cameo2006Map());
            modelBuilder.Configurations.Add(new SearchDefinitionMap());
            modelBuilder.Configurations.Add(new UploadDetailMap());

            modelBuilder.Entity<SearchDefinition>()
                .MapToStoredProcedures(p => p.Update(u => u.HasName("spUpdateSearchStatus")
                    .Parameter(b => b.SearchDefinitionId, "SearchDefinitionId")
                    .Parameter(b => b.LastUpdatedDatetime, "LastUpdatedDatetime")
                    .Parameter(b => b.Status, "Status")));
        }
    }
}
