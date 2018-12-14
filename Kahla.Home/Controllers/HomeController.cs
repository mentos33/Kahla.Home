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
        private static DateTime _cachedTime = DateTime.MinValue;
        private static string _cachedVersion = "";

        private readonly VersionChecker _version;
        public HomeController(VersionChecker version)
        {
            _version = version;
        }

        public async Task<IActionResult> Index()
        {
            string latest = null;
            if (DateTime.UtcNow < _cachedTime + new TimeSpan(0, 20, 0) && !string.IsNullOrEmpty(_cachedVersion))
            {
                latest = _cachedVersion;
            }
            else
            {
                latest = await _version.CheckKahla();
                _cachedTime = DateTime.UtcNow;
                _cachedVersion = latest;
            }
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
