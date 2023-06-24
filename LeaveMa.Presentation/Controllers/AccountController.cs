﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;

namespace LeaveMa.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
