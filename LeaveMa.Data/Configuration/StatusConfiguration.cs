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
    public class StatusConfiguration : BaseEntityConfiguration<Status>
    {
        public override void Configure(EntityTypeBuilder<Status> builder)
        {
            base.Configure(builder);
            builder.ToTable("Status");
            builder.HasKey(e => e.Code);
            builder.Property(e => e.Code).IsRequired();
            builder.HasMany<Leave>(h => h.Leaves)
            .WithOne(s => s.Status)
            .HasForeignKey(s => s.StatusCode);
        }
    }
}
