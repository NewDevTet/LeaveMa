using LeaveMa.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Configuration
{
    public class BaseEntityIdentityRoleConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntityIdentityRole
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.DateCreated).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.DateModified).HasDefaultValueSql("GETDATE()");
        }
    }
}
