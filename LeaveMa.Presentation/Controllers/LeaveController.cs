using AutoMapper;
using LeaveMa.Business.Models;
using LeaveMa.Business.Repository.Leave;
using LeaveMa.Business.Repository.Profile;
using LeaveMa.Data.Entities;
using LeaveMa.Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LeaveMa.Presentation.Controllers
{
    [Authorize]
    public class LeaveController : Controller
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public LeaveController(ILeaveRepository leaveRepository, UserManager<Employee> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _leaveRepository = leaveRepository;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult RequestLeave()
        {
            return View();
        }

        
    }
}
