using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Repository.Project
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Data.Entities.Project>> GetProjects();
    }
}
