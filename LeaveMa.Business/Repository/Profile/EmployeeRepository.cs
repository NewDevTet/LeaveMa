using LeaveMa.Business.Enums;
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

        public async Task<Employee> GetHolidaysEmployeeId(string? userId)
        {
            return await _context.Employees.Where(x => x.Id == userId)
                .Include(e => e.Country)
                .ThenInclude(h => h.Holidays)
                .FirstOrDefaultAsync();

        }

        public async Task<Employee> GetLeavesByEmployeeId(string id)
        {
            return await _context.Employees.Where(x => x.Id == id)
                .Include(e => e.Leaves)
                .ThenInclude(e => e.Status)
                .FirstOrDefaultAsync();
        }

        public async Task<Employee> GetLeavesWithoutRejectedByEmployeeId(string id)
        {
            return await _context.Employees.Where(x => x.Id == id)
                .Include(e => e.Leaves)
                .Include(c => c.Country)
                .ThenInclude(h => h.Holidays)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetTeamLeavesByEmployeeId(string userId)
        {
            var currentProject =  await _context.EmployeeProjects.Where(x => x.Id == userId && (bool)x.IsCurrent)
                .FirstOrDefaultAsync();

            return await _context.Employees.Where(x => x.Id != userId)
                .Include(r => r.EmployeeProjects)
                .Where(p => p.EmployeeProjects.Any(c => c.Code == currentProject.Code && (bool)c.IsCurrent))
                .Include(l => l.Leaves)
                .ToListAsync();



        }
    }
}
