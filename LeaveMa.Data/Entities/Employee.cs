using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Entities
{
    public class Employee : BaseEntity
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; }
        public int RoleCode { get; set; }
        public Role Role { get; set; }
        public ICollection<Leave> Leaves { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }

    }
}
