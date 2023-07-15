using LeaveMa.Business.Enums;
using LeaveMa.Data.Context;
using LeaveMa.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Repository.Leave
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly LeaveMaDbContext _context;

        public LeaveRepository(LeaveMaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateLeaveAsync(Data.Entities.Leave leave)
        {
           await _context.Leaves.AddAsync(leave);
            return true;
        }

        public bool DeleteLeaveAsync(Data.Entities.Leave leave)
        {
            _context.Leaves.Remove(leave);
            return true;
        }

        public async Task<Data.Entities.Leave> GetLeaveAsync(long id)
        {
            return await _context.Leaves.FindAsync(id);
        }

        public async Task<IEnumerable<Data.Entities.Leave>> GetLeavesByLeadId(string id)
        {
            return await _context.Leaves.Join(
                _context.EmployeeProjects,
                le => le.EmployeeId,
                ep => ep.Id,
                (le, ep) => new
                {
                    le,
                    ep
                }).Where(x => (bool)x.ep.IsCurrent && x.ep.Id != id && x.le.StatusCode == nameof(LeaveStatusCode.PENDING))
                .Join(_context.EmployeeProjects,
                eple => eple.ep.Code,
                eps => eps.Code,
                (eple, eps) => new
                {
                    eple,
                    eps
                })
                .Where(x => x.eps.Id == id && (bool)x.eps.IsCurrent)
                .Select(x => x.eple.le).Include(x => x.Employee)
                .ThenInclude(x => x.EmployeeProjects)
                .ThenInclude(x => x.Project)
                .GroupBy(x => x.Id).Select(x => x.FirstOrDefault()).ToListAsync();
        }
    }
}
