using adov_db_15202.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace adov_db_15202.DAL
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext")
        {
        }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProvidersPrice> ProvidersPrices { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoresProduct> StoresProducts { get; set; }
        public DbSet<Utilities> Utilities { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}