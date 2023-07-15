using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Models
{
    public class EmployeeProjectModel
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrent { get; set; }
        public EmployeeModel Employee { get; set; }
        public ProjectModel Project { get; set; }

    }
}
