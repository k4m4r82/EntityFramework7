using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Retail.Model;

namespace RetailUsingEntityFramework.Mapping
{
    public class BeliMap : EntityTypeConfiguration<Beli>
    {
        public BeliMap()
        {
            // Primary Key
            this.HasKey(t => t.Nota);

            // Properties
            this.Property(t => t.Nota)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Keterangan)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Beli");
            this.Property(t => t.Nota).HasColumnName("Nota");
            this.Property(t => t.SupplierID).HasColumnName("SupplierID");
            this.Property(t => t.Tanggal).HasColumnName("Tanggal");
            this.Property(t => t.Keterangan).HasColumnName("Keterangan");

            // Relationships
            this.HasRequired(t => t.Supplier)
                .WithMany(t => t.Belis)
                .HasForeignKey(d => d.SupplierID);

        }
    }
}
