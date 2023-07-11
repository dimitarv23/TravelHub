namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;

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
            var travels = await this.travelService.GetAllAsync();

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
                .GetDetailsByIdAsync(travelId, GetCurrentUserId());

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

        [HttpPost]
        public async Task<IActionResult> Book(int travelId)
        {
            await this.travelService.BookAsync(travelId, GetCurrentUserId());

            return RedirectToAction(nameof(Details), new { travelId = travelId });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBooking(int travelId)
        {
            await this.travelService.RemoveBookingAsync(travelId, GetCurrentUserId());

            return RedirectToAction(nameof(Details), new { travelId = travelId });
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(int travelId)
        {

            return RedirectToAction(nameof(Details), new { travelId = travelId });
        }

        private string GetCurrentUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}