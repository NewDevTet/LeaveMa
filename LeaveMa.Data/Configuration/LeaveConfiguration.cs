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
    public class LeaveConfiguration : BaseEntityConfiguration<Leave>
    {
        public override void Configure(EntityTypeBuilder<Leave> builder)
        {
            base.Configure(builder);
            builder.ToTable("Leave");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.HasOne<Employee>(s => s.Employee)
            .WithMany(g => g.Leaves)
            .HasForeignKey(s => s.EmployeeId);
            builder.HasOne<Status>(s => s.Status)
            .WithMany(g => g.Leaves)
            .HasForeignKey(s => s.StatusCode);
        }
    }
}
