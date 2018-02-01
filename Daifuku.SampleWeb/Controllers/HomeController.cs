using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Daifuku.SampleWeb.Models;
using Daifuku.SampleWeb.Exceptions;

namespace Daifuku.SampleWeb.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        [Route("contact")]
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