using System.Reflection;
using Core.Controllers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext 
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Product>  products { get; set; }
    public object Products { get; internal set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}