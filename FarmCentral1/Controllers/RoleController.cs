using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FarmCentral1.Core;

namespace FarmCentral1.Controllers
{

    public class RoleController : Controller
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

        //[Authorize(Policy = "RequireAdmin")]
        [Authorize(Roles =  $"{Constants.Roles.Administrator}, {Constants.Roles.Manager}")]

        public IActionResult Employee()
        {
            return View();
        }
    }
}
