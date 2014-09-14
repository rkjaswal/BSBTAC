using BSBTAC.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BSBTAC.Domain.Mapping
{
    public class Cameo2006Map : EntityTypeConfiguration<Cameo2006>
    {
        public Cameo2006Map()
        {
            // Primary Key
            this.HasKey(t => t.Cameo2006Id);

            // Properties
            this.Property(t => t.LocalityInformation)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Cameo2006");
            this.Property(t => t.Cameo2006Id).HasColumnName("Cameo2006Id");
            this.Property(t => t.SearchDefinitionId).HasColumnName("SearchDefinitionId");
            this.Property(t => t.LocalityInformation).HasColumnName("LocalityInformation");
            this.Property(t => t.CouncilTaxBand).HasColumnName("CouncilTaxBand");
        }
    }
}
