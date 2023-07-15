using LeaveMa.Data.Context;
using LeaveMa.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Repository.EmployeeProject
{
    public class EmployeeProjectRepository : IEmployeeProjectRepository
    {
        private readonly LeaveMaDbContext _context;

        public EmployeeProjectRepository(LeaveMaDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddProjectAsync(Data.Entities.EmployeeProject data)
        {
            await _context.EmployeeProjects.AddAsync(data);
            return true;
        }

    }
}
