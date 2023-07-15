using LeaveMa.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Configuration
{
    public class EmployeeConfiguration : BaseEntityIdentityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.ToTable("Employee");
            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasOne<Country>(s => s.Country)
                    .WithMany(g => g.Employees)
                    .HasForeignKey(s => s.CountryCode);
            builder.HasOne<Role>(s => s.Role)
                   .WithMany(g => g.Employees)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(s => s.RoleId);
            builder.HasMany<Leave>(h => h.Leaves)
            .WithOne(s => s.Employee)
            .HasForeignKey(s => s.EmployeeId);
        }
    }
}
