
using IpekStore.Core.Domain.Entities;
using IpekStore.Data.Sql.DbMappings;
using IpekStore.Data.Sql.Seeder;
using Microsoft.EntityFrameworkCore;

namespace IpekStore.Data.Sql
{
    public class IpekContext:DbContext
    {
        public IpekContext(DbContextOptions opt)
            :base(opt)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CategoryMapping
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            //ProductMapping
            modelBuilder.ApplyConfiguration(new ProductMapping());

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Category Data Seeding
            modelBuilder.SeedCategories();
            //Product Data Seeding
            modelBuilder.SeedProducts();
        }

    }
}
