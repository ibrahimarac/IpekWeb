using IpekStore.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Seeder
{
    public static class ProductSeeder
    {
        public static void SeedProducts(this ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, CategoryId = 1, CreateUser = "admin", LastupUser = "admin", Name = "Product 1" },
                    new Product { Id = 2, CategoryId = 2, CreateUser = "admin", LastupUser = "admin", Name = "Product 2" },
                    new Product { Id = 3, CategoryId = 2, CreateUser = "admin", LastupUser = "admin", Name = "Product 3" }
                );
        }
    }
}
