namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using TravelHub.ViewModels.Travels;
    using Microsoft.AspNetCore.Mvc;

    public class TravelsController : Controller
    {
        private readonly ITravelService travelService;

        public TravelsController(ITravelService _travelService)
        {
            this.travelService = _travelService;
        }

        public async Task<IActionResult> All()
        {
            var travels = await this.travelService.GetAllTravelsAsync();

            return View(travels);
        }
    }
}