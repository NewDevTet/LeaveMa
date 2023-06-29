using LeaveMa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Repository.Profile
{
    public interface IEmployeeRepository
    {
        Task CreateEmployeeAsync(string id);
        Task<Employee> GetEmployeeByIdAsync(string id);
    }
}
