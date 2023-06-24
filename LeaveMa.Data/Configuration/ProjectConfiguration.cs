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
    public class ProjectConfiguration : BaseEntityConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);
            builder.ToTable("Project");
            builder.HasKey(p => p.Code);
            builder.Property(p => p.Code).IsRequired();
        }
    }
}
