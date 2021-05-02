using IpekStore.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Seeder
{
    public static class CategorySeeder
    {
        public static void SeedCategories(this ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Kategori 1", CreateUser = "admin", LastupUser = "admin" },
                    new Category { Id = 2, Name = "Kategori 2", CreateUser = "admin", LastupUser = "admin" },
                    new Category { Id = 3, Name = "Kategori 3", CreateUser = "admin", LastupUser = "admin" }
                );
        }
    }
}
