using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Retail.Model;

namespace RetailUsingEntityFramework.Mapping
{
    public class BarangMap : EntityTypeConfiguration<Barang>
    {
        public BarangMap()
        {
            // Primary Key
            this.HasKey(t => t.BarangID);

            // Properties
            this.Property(t => t.BarangID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.NamaBarang)
                .HasMaxLength(50);

            this.Property(t => t.Stok)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Barang");
            this.Property(t => t.BarangID).HasColumnName("BarangID");
            this.Property(t => t.NamaBarang).HasColumnName("NamaBarang");
            this.Property(t => t.HargaBeli).HasColumnName("HargaBeli");
            this.Property(t => t.HargaJual).HasColumnName("HargaJual");
            this.Property(t => t.Stok).HasColumnName("Stok");
        }
    }
}
