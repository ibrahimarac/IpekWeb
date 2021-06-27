using IpekStore.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Data.Sql.DbMappings
{
    public class ProductMapping : BaseEntityMapping<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            //Product sınıfının miras aldığı Auditable Entity türünden
            //gelecek Property'ler veritabanına map leniyor.
            base.Configure(builder);


            //Product Entity'nin kendisine ait Propertyler map leniyor.            
            builder
                .Property(p => p.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();

            //Birden çoğa ilişki kuruluyor
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            builder.Property(p => p.CreateUser)
               .HasColumnType("varchar(10)")
               .HasColumnName("CreatedBy")
               .IsRequired();

            builder.Property(p => p.LastupUser)
                .HasColumnType("varchar(10)")
                .HasColumnName("UpdatedBy")
                .IsRequired();

            builder.Property(p => p.LastupDate)
                .HasColumnName("Updated");

            builder.Property(p => p.CreateDate)
                .HasColumnName("Created");

            builder.Property(p => p.IsActive)
                .HasColumnName("Active");

            builder
                .ToTable("Products");
        }
    }
}
