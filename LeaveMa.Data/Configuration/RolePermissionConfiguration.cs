using LeaveMa.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Configuration
{
    public class RolePermissionConfiguration : BaseEntityConfiguration<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            base.Configure(builder);
            builder.HasKey(rp => new { rp.RoleCode, rp.PermissionCode});

            builder.HasOne<Role>(rp => rp.Role)
                    .WithMany(r => r.RolePermisssions)
                    .HasForeignKey(rp => rp.RoleId);

            builder.HasOne<Permission>(rp => rp.Permission)
                    .WithMany(p => p.RolePermisssions)
                    .HasForeignKey(rp => rp.PermissionId);
        }
    }
}
