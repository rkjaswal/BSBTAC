using BSBTAC.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BSBTAC.Domain.Mapping
{
    public class SearchDefinitionMap : EntityTypeConfiguration<SearchDefinition>
    {
        public SearchDefinitionMap()
        {
            // Primary Key
            this.HasKey(t => t.SearchDefinitionId);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.Forename)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Othername)
                .HasMaxLength(50);

            this.Property(t => t.BuildingNo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BuildingName)
                .HasMaxLength(50);

            this.Property(t => t.Locality)
                .HasMaxLength(50);

            this.Property(t => t.Sublocality)
                .HasMaxLength(50);

            this.Property(t => t.Posttown)
                .HasMaxLength(50);

            this.Property(t => t.Postcode)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SearchDefinition");
            this.Property(t => t.SearchDefinitionId).HasColumnName("SearchDefinitionId");
            this.Property(t => t.UploadDetailId).HasColumnName("UploadDetailId");
            this.Property(t => t.DebtCode).HasColumnName("DebtCode");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Forename).HasColumnName("Forename");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.Othername).HasColumnName("Othername");
            this.Property(t => t.DOB).HasColumnName("DOB");
            this.Property(t => t.BuildingNo).HasColumnName("BuildingNo");
            this.Property(t => t.BuildingName).HasColumnName("BuildingName");
            this.Property(t => t.Locality).HasColumnName("Locality");
            this.Property(t => t.Sublocality).HasColumnName("Sublocality");
            this.Property(t => t.Posttown).HasColumnName("Posttown");
            this.Property(t => t.Postcode).HasColumnName("Postcode");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.LastUpdatedDatetime).HasColumnName("LastUpdatedDatetime");
            this.Property(t => t.FailureReason).HasColumnName("FailureReason");
        }
    }
}
