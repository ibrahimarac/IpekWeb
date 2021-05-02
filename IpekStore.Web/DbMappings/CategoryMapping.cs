using IpekStore.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.DbMappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Burada Category ve miras aldığı AuditableEntity sınıflarından
            //gelecek property'ler için mapping tanımlamaları yapılıyor.
            builder
                .Property(c => c.Id)
                .UseIdentityColumn();
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder
                .Property(c => c.CreateUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder
                .Property(c => c.LastupUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder
                .ToTable("Categories");
        }
    }
}
