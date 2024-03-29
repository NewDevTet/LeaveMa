﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Entities
{
    public class Leave : BaseEntity
    {
        public long Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EmployeeId { get; set; }

        public string? ReviewedBy { get; set; }
        public Employee? Employee { get; set; }
        public string? StatusCode { get; set; }
        public Status? Status { get; set; }
    }
}
