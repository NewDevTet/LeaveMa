﻿using LeaveMa.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Configuration
{
    public class PermissionConfiguration : BaseEntityConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);
        }
    }
}
