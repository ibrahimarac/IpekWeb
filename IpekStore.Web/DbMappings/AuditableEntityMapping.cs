using IpekStore.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.DbMappings
{
    public class AuditableEntityMapping<TEntity> : BaseEntityMapping<TEntity>
        where TEntity : AuditableEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.Id)
                .UseIdentityColumn();
            builder.HasKey(p => p.Id);

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
        }
    }
}
