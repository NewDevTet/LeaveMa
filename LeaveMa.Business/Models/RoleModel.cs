using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Models
{
    public class RoleModel
    {
        public string? Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EmployeeModel> Employees { get; set; }
        public ICollection<RolePermissionModel> RolePermissions { get; set; }
    }
}
