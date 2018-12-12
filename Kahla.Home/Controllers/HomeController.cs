using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aiursoft.Pylon.Attributes;
using Aiursoft.Pylon;
using Kahla.Home.Services;

namespace Kahla.Home.Controllers
{
    public class HomeController : Controller
    {
        private readonly VersionChecker _version;
        public HomeController(VersionChecker version)
        {
            _version = version;
        }
        public async Task<IActionResult> Index()
        {
            var latest = _version.CheckKahla();
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
