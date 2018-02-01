using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daifuku.SampleWeb.Models;
using Daifuku.SampleWeb.Exceptions;

namespace Daifuku.SampleWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        [Route("send-token")]
        public IActionResult SendToken(HomeSendToken m)
        {
            if (ModelState.IsValid)
            {
                if (m.Token.Equals("none", StringComparison.OrdinalIgnoreCase))
                    throw new AppException("None is one bad-ass code which we do not accept.");
            }

            return View("Contact");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}