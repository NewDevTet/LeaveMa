using System;
using LeaveMa.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Repository.Leave
{
    public interface ILeaveRepository
    {
        Task<bool> CreateLeaveAsync(Data.Entities.Leave leave);
        bool DeleteLeaveAsync(Data.Entities.Leave leave);
        Task<Data.Entities.Leave> GetLeaveAsync(long id);
        Task<IEnumerable<Data.Entities.Leave>> GetLeavesByLeadId(string id);
    }
}
