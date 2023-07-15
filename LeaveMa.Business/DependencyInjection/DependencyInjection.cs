using LeaveMa.Business.Repository.Country;
using LeaveMa.Business.Repository.EmployeeProject;
using LeaveMa.Business.Repository.Leave;
using LeaveMa.Business.Repository.Profile;
using LeaveMa.Business.Repository.Project;
using LeaveMa.Business.Repository.Role;
using LeaveMa.Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IEmployeeProjectRepository, EmployeeProjectRepository>();

            return services;
        }
    }
}
