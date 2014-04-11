using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Retail.Model;

namespace RetailUsingEntityFramework.Mapping
{
    public class ItemBeliMap : EntityTypeConfiguration<ItemBeli>
    {
        public ItemBeliMap()
        {
            // Primary Key
            this.HasKey(t => t.ItemBeliID);

            // Properties
            this.Property(t => t.Nota)
                .HasMaxLength(10);

            this.Property(t => t.BarangID)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ItemBeli");
            this.Property(t => t.ItemBeliID).HasColumnName("ItemBeliID");
            this.Property(t => t.Nota).HasColumnName("Nota");
            this.Property(t => t.BarangID).HasColumnName("BarangID");
            this.Property(t => t.Jumlah).HasColumnName("Jumlah");
            this.Property(t => t.HargaBeli).HasColumnName("HargaBeli");
            this.Property(t => t.HargaJual).HasColumnName("HargaJual");

            // Relationships
            this.HasOptional(t => t.Barang)
                .WithMany(t => t.ItemBelis)
                .HasForeignKey(d => d.BarangID);
            this.HasOptional(t => t.Beli)
                .WithMany(t => t.ItemBelis)
                .HasForeignKey(d => d.Nota);

        }
    }
}
