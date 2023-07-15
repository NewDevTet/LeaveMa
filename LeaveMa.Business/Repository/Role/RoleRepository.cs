using LeaveMa.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Repository.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly LeaveMaDbContext _context;
        public RoleRepository(LeaveMaDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Data.Entities.Role>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
