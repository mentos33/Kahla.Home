using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aiursoft.Pylon.Attributes;
using Aiursoft.Pylon;
using Kahla.Home.Services;
using Kahla.Home.Models.HomeViewModels;

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
            var latest = await _version.CheckKahla();
            var model = new IndexViewModel
            {
                LatestVersion = latest
            };
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
