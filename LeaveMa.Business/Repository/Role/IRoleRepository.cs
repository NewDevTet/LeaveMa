using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Repository.Role
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Data.Entities.Role>> GetRoles();
    }
}
