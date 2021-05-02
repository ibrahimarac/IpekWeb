using IpekStore.Web.Models.Entities;
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

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Mapping

            //CategoryMapping
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .UseIdentityColumn();            
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasColumnType("varchar(30)")
                .IsRequired();

            //modelBuilder.Entity<Category>()
            //    .Property(c => c.CreateUser)
            //    .HasColumnType("varchar(10)");

            //modelBuilder.Entity<Category>()
            //    .Property(c => c.LastupUser)
            //    .HasColumnType("varchar(10)");

            modelBuilder.Entity<Category>()
                .ToTable("Categories");

            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.Products)
            //    .WithOne(p => p.Category)
            //    .HasForeignKey(p => p.CategoryId);




            //ProductMapping
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .UseIdentityColumn();
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
               .Property(p => p.Name)
               .HasColumnType("varchar(150)")
               .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.IsActive);
                //.HasDefaultValueSql("1");

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            //modelBuilder.Entity<Product>()
            //   .Property(c => c.CreateUser)
            //   .HasColumnType("varchar(10)");

            //modelBuilder.Entity<Product>()
            //    .Property(c => c.LastupUser)
            //    .HasColumnType("varchar(10)");


            modelBuilder.Entity<Product>()
                .ToTable("Products");

        }

    }
}
