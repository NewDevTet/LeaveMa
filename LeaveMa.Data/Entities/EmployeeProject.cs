﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Entities
{
    public class EmployeeProject : BaseEntity
    {
        public bool? IsCurren { get; set; }
        public string? Id { get; set; }
        public Employee? Employee { get; set; }
        public string? Code { get; set; }
        public Project? Project { get; set; }

    }
}
