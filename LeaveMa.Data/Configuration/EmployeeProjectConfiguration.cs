using LeaveMa.Data.Entities;
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
        }
    }
}
