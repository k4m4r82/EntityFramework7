using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Retail.Model;

namespace RetailUsingEntityFramework.Mapping
{
    public class SupplierMap : EntityTypeConfiguration<Supplier>
    {
        public SupplierMap()
        {
            // Primary Key
            this.HasKey(t => t.SupplierID);

            // Properties
            this.Property(t => t.NamaSupplier)
                .HasMaxLength(50);

            this.Property(t => t.Jalan)
                .HasMaxLength(100);

            this.Property(t => t.Kota)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Supplier");
            this.Property(t => t.SupplierID).HasColumnName("SupplierID");
            this.Property(t => t.NamaSupplier).HasColumnName("NamaSupplier");
            this.Property(t => t.Jalan).HasColumnName("Jalan");
            this.Property(t => t.Kota).HasColumnName("Kota");
        }
    }
}
