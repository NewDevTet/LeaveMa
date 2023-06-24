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
    public class EmailConfiguration : BaseEntityConfiguration<Email>
    {
        public override void Configure(EntityTypeBuilder<Email> builder)
        {
            base.Configure(builder);
            builder.ToTable("Email");
            builder.HasKey(e => e.Code);
            builder.Property(e => e.Code).IsRequired();
            builder.Property(e => e.Value).IsRequired();
        }
    }
}
