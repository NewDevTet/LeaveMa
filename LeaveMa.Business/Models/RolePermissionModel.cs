﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Models
{
    public class RolePermissionModel
    {
        public PermissionModel Permission { get; set; }
        public RoleModel Role { get; set; }
    }
}
