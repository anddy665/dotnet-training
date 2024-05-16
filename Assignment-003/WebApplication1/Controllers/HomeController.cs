﻿using Microsoft.AspNetCore.Mvc;

namespace ProductManagementApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
