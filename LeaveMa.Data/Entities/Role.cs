using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Entities
{
    public class Role : BaseEntity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long EmployeeId { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
