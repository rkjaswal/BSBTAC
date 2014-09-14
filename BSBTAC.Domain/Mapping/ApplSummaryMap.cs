using BSBTAC.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BSBTAC.Domain.Mapping
{
    public class ApplSummaryMap : EntityTypeConfiguration<ApplSummary>
    {
        public ApplSummaryMap()
        {
            // Primary Key
            this.HasKey(t => t.ApplSummaryId);

            // Properties
            this.Property(t => t.AccountInformation)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ApplSummary");
            this.Property(t => t.ApplSummaryId).HasColumnName("ApplSummaryId");
            this.Property(t => t.SearchDefinitionId).HasColumnName("SearchDefinitionId");
            this.Property(t => t.AccountInformation).HasColumnName("AccountInformation");
            this.Property(t => t.NumberOfDisputes).HasColumnName("NumberOfDisputes");
        }
    }
}
