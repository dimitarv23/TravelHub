namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using TravelHub.Domain.Models;

    [Authorize]
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
        public async Task<IActionResult> All(int page)
        {
            var bookings = await this.bookingService.GetAllAsync();

            if (page == 0)
            {
                page = 1;
            }

            ViewData["NumberOfTravels"] = bookings.Count;
            ViewData["CurrPageNumber"] = page;
            int travelsPerPage = 4;
            var model = bookings
                .Skip((page - 1) * travelsPerPage)
                .Take(travelsPerPage)
            .ToList();

            if (bookings.Any() && !model.Any())
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Mine(int page)
        {
            var bookings = await this.bookingService.GetForUserAsync(User.GetId());

            if (page == 0)
            {
                page = 1;
            }

            ViewData["NumberOfTravels"] = bookings.Count;
            ViewData["CurrPageNumber"] = page;
            int bookingsPerPage = 4;
            var model = bookings
                .Skip((page - 1) * bookingsPerPage)
                .Take(bookingsPerPage)
                .ToList();

            if (bookings.Any() && !model.Any())
            {
                return NotFound();
            }

            return View(model);
        }
    }
}