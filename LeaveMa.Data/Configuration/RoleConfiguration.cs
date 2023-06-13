using LeaveMa.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Configuration
{
    public class RoleConfiguration : BaseEntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.HasKey(r => r.Code);
            builder.Property(r => r.Code).IsRequired();
        }
    }
}
