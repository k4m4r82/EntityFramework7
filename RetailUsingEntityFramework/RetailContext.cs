using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using RetailUsingEntityFramework.Mapping;
using Retail.Model;

namespace RetailUsingEntityFramework
{
    public partial class RetailContext : DbContext
    {
        static RetailContext()
        {
            Database.SetInitializer<RetailContext>(null);
        }

        public RetailContext()
            : base("Name=RetailContext")
        {
        }

        public DbSet<Barang> Barangs { get; set; }
        public DbSet<Beli> Belis { get; set; }
        public DbSet<ItemBeli> ItemBelis { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BarangMap());
            modelBuilder.Configurations.Add(new BeliMap());
            modelBuilder.Configurations.Add(new ItemBeliMap());
            modelBuilder.Configurations.Add(new SupplierMap());
        }
    }
}
