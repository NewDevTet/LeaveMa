using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveMa.Presentation.Controllers
{
    [Authorize]
    public class LeaveController : Controller
    {
        public IActionResult Requests()
        {
            return View();
        }

        public IActionResult RequestLeave()
        {
            return View();
        }

        
    }
}
