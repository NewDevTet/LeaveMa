using LeaveMa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Repository.EmployeeProject
{
    public interface IEmployeeProjectRepository
    {
        Task<bool> AddProjectAsync(Data.Entities.EmployeeProject data);
    }
}
