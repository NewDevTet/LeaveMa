using AutoMapper;
using LeaveMa.Business.Models;
using LeaveMa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Profiles
{
    public class EmployeeProjectProfile : Profile
    {
        public EmployeeProjectProfile()
        {
            CreateMap<EmployeeProject, EmployeeProjectModel>();
        }
    }
}
