using IpekStore.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Data.Sql.DbMappings
{
    public class CategoryMapping : BaseEntityMapping<Category>
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
                .ToTable("Categories");
        }
    }
}
