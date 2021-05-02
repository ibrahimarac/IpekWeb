using IpekStore.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.DbMappings
{
    public class CategoryMapping : AuditableEntityMapping<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            //Category sınıfının miras aldığı Auditable Entity türünden
            //gelecek Property'ler veritabanına map leniyor.
            base.Configure(builder);

            //Category Entity'nin kendisine ait Propertyler map leniyor.
            builder
                .Property(c => c.Name)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder
                .ToTable("Categories");
        }
    }
}
