using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Entities
{
    public class ProjectModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EmployeeProjectModel> EmployeeProject { get; set; }

    }
}
