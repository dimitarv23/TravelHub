namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Extensions;
    using Microsoft.AspNetCore.Mvc;

    public class BookingsController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService _bookingService)
        {
            this.bookingService = _bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(int travelId)
        {
            await this.bookingService.CreateBookingAsync(travelId, User.GetId());

            return RedirectToAction(nameof(My));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBooking(int travelId)
        {
            await this.bookingService.RemoveBookingAsync(travelId, User.GetId());

            return RedirectToAction(nameof(My));
        }

        [HttpGet]
        public async Task<IActionResult> My()
        {
            return View();
        }
    }
}