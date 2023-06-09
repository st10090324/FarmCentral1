﻿using FarmCentral1.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmCentral1.Controllers
{
    public class RoleViewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = Constants.Policies.RequireManager)]
        public IActionResult Farmer()
        {
            return View();
        }

        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Employee()
        {
            return View();
        }
    }
}
