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
    public class RolePermissionConfiguration : BaseEntityConfiguration<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            base.Configure(builder);
            builder.ToTable("RolePermission");
            builder.HasKey(rp => new { rp.RoleId, rp.PermissionCode});

            builder.HasOne<Role>(rp => rp.Role)
                    .WithMany(r => r.RolePermissions)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasForeignKey(rp => rp.RoleId);
                    

            builder.HasOne<Permission>(rp => rp.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(rp => rp.PermissionCode);
        }
    }
}
