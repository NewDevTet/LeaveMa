using AutoMapper;
using LeaveMa.Business.Models;
using LeaveMa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeModel>();
            CreateMap<Employee, RegisterModel>().ReverseMap();
        }
    }
}
