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
    public class HolidayConfiguration : BaseEntityConfiguration<Holiday>
    {
        public override void Configure(EntityTypeBuilder<Holiday> builder)
        {
            base.Configure(builder);
            builder.ToTable("Holiday");
            builder.HasKey(e => e.Code);
            builder.Property(e => e.Code).IsRequired();
            builder.HasOne<Country>(s => s.Country)
            .WithMany(g => g.Holidays)
            .HasForeignKey(s => s.CountryCode);
        }
    }
}
