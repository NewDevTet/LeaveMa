using AutoMapper;
using LeaveMa.Business.Enums;
using LeaveMa.Business.Models;
using LeaveMa.Business.Repository.Country;
using LeaveMa.Business.Repository.Leave;
using LeaveMa.Business.Repository.Profile;
using LeaveMa.Business.Repository.Project;
using LeaveMa.Data.Entities;
using LeaveMa.Data.Migrations;
using LeaveMa.Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Data;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using LeaveMa.Business.Repository.Role;
using LeaveMa.Business.Repository.EmployeeProject;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;

namespace LeaveMa.Presentation.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILeaveRepository _leaveRepository;
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectRepository _projectRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly SignInManager<Employee> _signInManager;
        private readonly IUserStore<Employee> _userStore;
        private readonly IUserEmailStore<Employee> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly IEmployeeProjectRepository _employeeProjectRepository;

        public ProfileController(IEmployeeRepository employeeRepository,
            UserManager<Employee> userManager,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILeaveRepository leaveRepository,
            IProjectRepository projectRepository,
            ICountryRepository countryRepository,
            IRoleRepository roleRepository,
            IUserStore<Employee> userStore,
            SignInManager<Employee> signInManager,
            IEmailSender emailSender,
            IEmployeeProjectRepository employeeProjectRepository)
        {
            _employeeRepository = employeeRepository;
            _leaveRepository = leaveRepository;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _projectRepository = projectRepository;
            _countryRepository = countryRepository;
            _signInManager = signInManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<Employee>)GetEmailStore();
            _emailSender = emailSender;
            _roleRepository = roleRepository;
            _employeeProjectRepository = employeeProjectRepository;
        }
        [HttpGet("Home")]
        public async Task<IActionResult> HomeAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _employeeRepository.GetLeavesWithoutRejectedByEmployeeId(userId);
            var teamLeaves = await _employeeRepository.GetTeamLeavesByEmployeeId(userId);
            ViewData["TeamLeaves"] = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeModel>>(teamLeaves);
            return View(_mapper.Map<Employee, EmployeeModel>(employee));
        }

        public async Task<IActionResult> IndexAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = userId is not null ? await _employeeRepository.GetEmployeeByIdAsync(userId) : null;

            if (employee is null)
            {
                // return not found
            }
            return View(_mapper.Map<Employee, EmployeeModel>(employee));
        }

        [HttpGet("Register")]
        public async Task<IActionResult> RegisterAsync()
        {
            var projects = await _projectRepository.GetProjects();
            var countries = await _countryRepository.GetCountries();
            var roles = await _roleRepository.GetRoles();
            ViewData["Projects"] = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectModel>>(projects);
            ViewData["Countries"] = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryModel>>(countries);
            ViewData["Roles"] = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleModel>>(roles);
            return View(new RegisterModel());
        }

        [HttpPost("Whatever")]
        public async Task<IActionResult> RegisterEmployeeAsync(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<RegisterModel, Employee>(model);

                await _userStore.SetUserNameAsync((Employee)user, model.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync((Employee)user, model.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync((Employee)user, model.Password);

                if (result.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync((Employee)user);
                    await _employeeProjectRepository.AddProjectAsync(new EmployeeProject() { Id = userId, Code = model.ProjectCode, IsCurrent = true });
                    var createdUser = await _employeeRepository.FindOneAsync(userId);
                    result = await _userManager.AddToRoleAsync(createdUser, model.RoleName);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync((Employee)user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(model.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    await _unitOfWork.CompleteAsync();

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
            }
            return RedirectToAction("Index");
        }


        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(EmployeeModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _employeeRepository.FindOneAsync(userId);

            if (employee is null)
            {
                // Bad request
            }
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Email = model.Email;
            employee.UserName = model.Email;
            employee.NormalizedEmail = model.Email.ToUpper();
            employee.NormalizedUserName = model.Email.ToUpper();

            await _unitOfWork.CompleteAsync();

            return RedirectToAction("Index");
        }

        [HttpGet("Requests")]
        public async Task<IActionResult> RequestsAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _employeeRepository.GetLeavesByEmployeeId(userId);

            return View(_mapper.Map<Employee, EmployeeModel>(employee));
        }

        [HttpGet("Approval")]
        public async Task<IActionResult> ApprovalAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _employeeRepository.GetLeavesByEmployeeId(userId);
            var leaves = await _leaveRepository.GetLeavesByLeadId(userId);

            return View(_mapper.Map<IEnumerable<Leave>, IEnumerable<LeaveModel>>(leaves));
        }

        [HttpGet("Holidays")]
        public async Task<IActionResult> HolidaysAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _employeeRepository.GetHolidaysEmployeeId(userId);

            return View(_mapper.Map<IEnumerable<Holiday>, IEnumerable<HolidayModel>>(employee?.Country?.Holidays));
        }
        [HttpPost("Request")]
        public async Task<IActionResult> RequestAsync(long id)
        {
            var leave = await _leaveRepository.GetLeaveAsync(id);
            return Json(_mapper.Map<Leave, LeaveModel>(leave));
        }

        [HttpPost("Requests/Update")]
        public async Task<IActionResult> UpdateRequestAsync(LeaveRequestModel model)
        {
            var leave = await _leaveRepository.GetLeaveAsync(model.Id);
            var startDate = DateTime.Parse(model.RequestPeriod.Split('-')[0]);
            var endDate = DateTime.Parse(model.RequestPeriod.Split('-')[1]);
            var initialStartDate = leave.StartDate;
            var initialEndDate = leave.EndDate;
            leave.StartDate = startDate;
            leave.EndDate = endDate;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _employeeRepository.FindOneAsync(userId);

            var basicBalance = employee.Balance + (initialEndDate.Value - initialStartDate.Value).TotalDays + 1;
            var balance = basicBalance - (endDate - startDate).TotalDays - 1;
            employee.Balance = balance;

            await _unitOfWork.CompleteAsync();

            return RedirectToAction("Requests");
        }

        [HttpPost("Requests/Request/Approve")]
        public async Task<IActionResult> ApproveRequestAsync(LeaveRequestModel model)
        {
            var leave = await _leaveRepository.GetLeaveAsync(model.Id);
            leave.StatusCode = nameof(LeaveStatusCode.APPROVED);
            leave.ReviewedBy = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _unitOfWork.CompleteAsync();

            return RedirectToAction("Approval");
        }

        [HttpPost("Requests/Request/Reject")]
        public async Task<IActionResult> RejectRequestAsync(LeaveRequestModel model)
        {
            var leave = await _leaveRepository.GetLeaveAsync(model.Id);
            leave.StatusCode = nameof(LeaveStatusCode.REJECTED);
            leave.ReviewedBy = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _unitOfWork.CompleteAsync();

            return RedirectToAction("Approval");
        }

        [HttpPost("Requests/Delete")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var leave = await _leaveRepository.GetLeaveAsync(id);
             _leaveRepository.DeleteLeaveAsync(leave);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _employeeRepository.FindOneAsync(userId);

            var initialStartDate = leave.StartDate;
            var initialEndDate = leave.EndDate;
            var basicBalance = employee.Balance + (initialEndDate.Value - initialStartDate.Value).TotalDays + 1;

            employee.Balance = basicBalance;
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Requests");
        }

        [HttpPost("Requests/Create")]
        public async Task<IActionResult> CreateAsync(LeaveRequestModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var startDate = DateTime.Parse(model.RequestPeriod.Split('-')[0]);
            var endDate = DateTime.Parse(model.RequestPeriod.Split('-')[1]);
            var leave = new Leave()
            {
                StartDate = startDate,
                EndDate = endDate,
                EmployeeId = userId,
                StatusCode = nameof(LeaveStatusCode.PENDING),
            };

            await _leaveRepository.CreateLeaveAsync(leave);
            var employee = await _employeeRepository.FindOneAsync(userId);
            var balance = employee.Balance - (endDate - startDate).TotalDays - 1;
            employee.Balance = balance;

            await _unitOfWork.CompleteAsync();

            return RedirectToAction("Requests");
        }

        private Employee CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Employee>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Employee)}'. " +
                    $"Ensure that '{nameof(Employee)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<Employee> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Employee>)_userStore;
        }
    }
}
