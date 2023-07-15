using LeaveMa.Business.Models;
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

        Task<Employee> FindOneAsync(string id);
        Task<Employee> GetLeavesByEmployeeId(string id);
        Task<Employee> GetLeavesWithoutRejectedByEmployeeId(string id);
        Task<Employee> GetHolidaysEmployeeId(string? userId);
        Task<IEnumerable<Data.Entities.Employee>> GetTeamLeavesByEmployeeId(string userId);
        Task<Employee> GetTeamLeadByUserId(string userId);
    }
}
