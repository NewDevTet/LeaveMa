﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Entities
{
    public class Country : BaseEntity
    {
        public string Code { get; set; }
        public string? Name { get; set; }
        public ICollection<Holiday> Holidays { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
