using LeaveMa.Business.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Entities
{
    public class RoleModel
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EmployeeModel> Employees { get; set; }
        public ICollection<RolePermissionModel> RolePermissions { get; set; }
    }
}
