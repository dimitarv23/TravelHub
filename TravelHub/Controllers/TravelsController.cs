namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using TravelHub.ViewModels.Travels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class TravelsController : Controller
    {
        private readonly ITravelService travelService;

        public TravelsController(ITravelService _travelService)
        {
            this.travelService = _travelService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var travels = await this.travelService.GetAllTravelsAsync();

            return View(travels);
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Create()
        {
            // TODO

            return View();
        }

        //[HttpPost]
        //[Authorize(Roles = "Organizer")]
        //public async Task<IActionResult> Create(TravelFormModel model)
        //{
        //
        //}

        [HttpGet]
        public async Task<IActionResult> Details(int travelId)
        {
            var travel = await this.travelService
                .GetDetailsByIdAsync(travelId);

            if (travel == null)
            {
                return NotFound();
            }

            return View(travel);
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Edit()
        {
            // TODO

            return View();
        }

        //[HttpPost]
        //[Authorize(Roles = "Organizer")]
        //public async Task<IActionResult> Edit(TravelFormModel model)
        //{
        //    //TODO
        //
        //    return View();
        //}

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Delete()
        {
            // TODO

            return RedirectToAction(nameof(All));
        }
    }
}