namespace TravelHub.Controllers
{
    using TravelHub.ViewModels.Common;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> _logger)
        {
            this.logger = _logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Travels");
            }

            return View();
        }

        [HttpGet]
        [Route("Errors/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            return View($"../Errors/{statusCode}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}