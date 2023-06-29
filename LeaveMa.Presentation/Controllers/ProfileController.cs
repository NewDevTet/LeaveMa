using AutoMapper;
using LeaveMa.Business.Models;
using LeaveMa.Business.Repository.Profile;
using LeaveMa.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LeaveMa.Presentation.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        public ProfileController(IEmployeeRepository employeeRepository, UserManager<Employee> userManager, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _employeeRepository.GetEmployeeByIdAsync(userId);

            var employeeModel = _mapper.Map<Employee, EmployeeModel>(employee);

            return View(employeeModel);
        }
    }
}
