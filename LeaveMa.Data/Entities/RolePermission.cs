using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Entities
{
    public class RolePermission : BaseEntity
    {
        public int PermissionCode { get; set; }
        public Permission Permission { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}
