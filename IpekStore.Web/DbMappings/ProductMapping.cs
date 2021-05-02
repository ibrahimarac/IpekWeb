using IpekStore.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.DbMappings
{
    public class ProductMapping : AuditableEntityMapping<Product>
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

            builder
                .ToTable("Products");
        }
    }
}
