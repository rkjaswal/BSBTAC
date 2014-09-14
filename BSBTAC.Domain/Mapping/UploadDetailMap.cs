using BSBTAC.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BSBTAC.Domain.Mapping
{
    public class UploadDetailMap : EntityTypeConfiguration<UploadDetail>
    {
        public UploadDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.UploadDetailId);

            // Properties
            this.Property(t => t.Filename)
                .IsRequired();

            this.Property(t => t.UploadedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UploadDetail");
            this.Property(t => t.UploadDetailId).HasColumnName("UploadDetailId");
            this.Property(t => t.Filename).HasColumnName("Filename");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.UploadedBy).HasColumnName("UploadedBy");
            this.Property(t => t.UploadDatetime).HasColumnName("UploadDatetime");
        }
    }
}
