using IpekStore.Web.DbMappings;
using IpekStore.Web.Models.Entities;
using IpekStore.Web.Seeder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Context
{
    public class IpekContext:DbContext
    {
        public IpekContext(DbContextOptions opt)
            :base(opt)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CategoryMapping
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            //ProductMapping
            modelBuilder.ApplyConfiguration(new ProductMapping());

            //Category Data Seeding
            modelBuilder.SeedCategories();
            //Product Data Seeding
            modelBuilder.SeedProducts();
        }

    }
}
