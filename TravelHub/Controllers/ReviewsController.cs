namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using TravelHub.ViewModels.Reviews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ReviewsController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService _reviewService)
        {
            this.reviewService = _reviewService;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            await this.reviewService.AddAsync(model);

            return RedirectToAction("Details", "Hotels", new { hotelId = model.HotelId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int reviewId)
        {
            int hotelId = await this.reviewService
                .DeleteAsync(reviewId);

            if (hotelId == 0)
            {
                return NotFound();
            }

            return RedirectToAction("Details", "Hotels", new { hotelId = hotelId });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int hotelId)
        {
            var reviews = await this.reviewService.GetAllForHotelAsync(hotelId);

            return Ok(reviews);
        }
    }
}