using LeaveMa.Data.Context;
using LeaveMa.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeaveMa.Business.Repository.Profile
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly LeaveMaDbContext _context;

        public EmployeeRepository(LeaveMaDbContext context)
        {
            _context = context;
        }

        public Task CreateEmployeeAsync(string id)
        {
            var employee = new Employee();
            _context.ChangeTracker.Clear();
            _context.Employees.Add(employee);
            return Task.CompletedTask;
        }

        public async Task<Employee> FindOneAsync(string id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            var employee = await _context.Employees
                .Where(e => e.Id == id)
                .Include(e => e.EmployeeProjects)
                .ThenInclude(e => e.Project)
                .Include(e => e.Country)
                .FirstOrDefaultAsync();

                return employee;
        }
        public async Task<Employee> GetLeavesByEmployeeId(string id)
        {
            return await _context.Employees.Where(x => x.Id == id)
                .Include(e => e.Leaves)
                .ThenInclude(e => e.Status)
                .FirstOrDefaultAsync();
        }
    }
}
