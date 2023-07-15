using LeaveMa.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Repository.Project
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly LeaveMaDbContext _context;

        public ProjectRepository(LeaveMaDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Data.Entities.Project>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }
    }
}
