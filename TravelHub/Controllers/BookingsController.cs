namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    public class BookingsController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService _bookingService)
        {
            this.bookingService = _bookingService;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateBooking(int travelId)
        {
            await this.bookingService.CreateBookingAsync(travelId, User.GetId());

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBooking(int travelId, string? userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                userId = User.GetId();
            }

            await this.bookingService.RemoveBookingAsync(travelId, userId);

            if (User.IsInRole("Organizer"))
            {
                return RedirectToAction(nameof(All));
            }
            
            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> All()
        {
            var model = await this.bookingService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Mine()
        {
            var model = await this.bookingService.GetForUserAsync(User.GetId());

            return View(model);
        }
    }
}