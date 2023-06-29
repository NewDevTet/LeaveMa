using LeaveMa.Data.Entities;

namespace LeaveMa.Business.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public long Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public CountryModel Country { get; set; }
        public RoleModel Role { get; set; }
        public ICollection<LeaveModel> Leaves { get; set; }
        public ICollection<EmployeeProjectModel> EmployeeProjects { get; set; }
    }
}
