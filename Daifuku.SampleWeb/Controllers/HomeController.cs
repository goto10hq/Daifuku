using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Daifuku.SampleWeb.Models;
using Daifuku.SampleWeb.Exceptions;
using Daifuku.Attributes;
using Daifuku.Validations;
using Daifuku.Extensions;

namespace Daifuku.SampleWeb.Controllers
{
    public class HomeController : Controller
    {
        Random _random;

        public HomeController()
        {
            _random = new Random();
        }

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

            return View(new HomeSendToken());
        }

        [HttpPost]
        [Route("contact")]
        [ValidateModel("Error validating token", "Contact")]
        public IActionResult SendToken(HomeSendToken m)
        {
            if (ModelState.IsValid)
            {
                if (m.Token.Equals("none", StringComparison.OrdinalIgnoreCase))
                    throw new AppException("None is one bad-ass code which we do not accept.");

                if (m.Token.Equals("everything", StringComparison.OrdinalIgnoreCase))
                    ModelState.AddModelError(string.Empty, "Too greedy token!");

                if (m.Token.Equals("secret", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        throw new AppException("It is secret, you know. No clue.");
                    }
                    catch (AppException ex)
                    {
                        ModelState.AddModelErrors(ex);
                    }
                }

                if (m.Token.Equals("error", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Error!");
                }
            }

            return View("Contact", m);
        }

        [HttpGet]
        [Route("api/ajax-ok")]
        [AjaxOnly]
        public int AjaxOk()
        {
            return _random.Next(100);
        }

        [HttpGet]
        [Route("api/ajax-bad")]
        [AjaxOnly]
        public IActionResult AjaxBad()
        {
            throw new AppException("I'm stupid. I cannot think of a random number.");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}