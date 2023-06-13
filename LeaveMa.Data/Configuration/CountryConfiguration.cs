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
    public class CountryConfiguration : BaseEntityConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);
            builder.HasKey(e => e.Code);
            builder.Property(e => e.Code).IsRequired();
            builder.HasMany<Holiday>(h => h.Holidays)
            .WithOne(s => s.Country)
            .HasForeignKey(s => s.Code)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
