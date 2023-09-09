using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Diagnostics;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int hour=DateTime.Now.Hour;
            ViewBag.Greeting = hour > 12 ? "Good Afternoon" : "Good Morning";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
        [HttpGet]
        public IActionResult RSVP()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RSVP(GuestResponse guest)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guest);
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}