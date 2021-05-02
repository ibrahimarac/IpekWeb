using IpekStore.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.DbMappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Burada Product ve miras aldığı AuditableEntity sınıflarından
            //gelecek property'ler için mapping tanımlamaları yapılıyor.
            //CategoryId için özel bir mapping yapmadık. Özel mapping işlemi
            //yapmadığımız property'ler için EF varsayılan türleri kullanır.

            builder
                .Property(p => p.Id)
                .UseIdentityColumn();
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(p => p.CreateUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder
                .Property(p => p.LastupUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            //Birden çoğa ilişki kuruluyor
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            builder
                .ToTable("Products");
        }
    }
}
