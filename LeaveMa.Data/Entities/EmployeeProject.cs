using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Entities
{
    public class EmployeeProject : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrent { get; set; }
        public string Id { get; set; }
        public Employee Employee { get; set; }
        public string Code { get; set; }
        public Project Project { get; set; }

    }
}
