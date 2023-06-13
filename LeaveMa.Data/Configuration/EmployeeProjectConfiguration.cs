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
    public class EmployeeProjectConfiguration : BaseEntityConfiguration<EmployeeProject>
    {
        public override void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            base.Configure(builder);
            builder.HasKey(sc => new { sc.Id, sc.Code });
            builder.Property(e => e.Code).IsRequired();
            builder.Property(e => e.Id).IsRequired();
            builder.HasOne<Employee>(sc => sc.Employee)
            .WithMany(s => s.EmployeeProjects)
            .HasForeignKey(sc => sc.Id);

            builder.HasOne<Project>(sc => sc.Project)
            .WithMany(s => s.EmployeeProject)
            .HasForeignKey(sc => sc.Code);
        }
    }
}
