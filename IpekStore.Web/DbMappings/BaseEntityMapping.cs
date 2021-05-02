using IpekStore.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.DbMappings
{
    public class BaseEntityMapping<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .Property(p => p.Id)
                .UseIdentityColumn();
            builder
                .HasKey(p => p.Id);

            builder.Property(p => p.IsActive)
                .HasColumnName("Active");
        }
    }
}
