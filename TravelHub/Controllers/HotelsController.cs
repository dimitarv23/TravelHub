namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using TravelHub.ViewModels.Hotels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class HotelsController : Controller
    {
        private readonly IHotelService hotelService;

        private readonly IDestinationService destinationService;

        public HotelsController(IHotelService _hotelService,
            IDestinationService _destinationService)
        {
            this.hotelService = _hotelService;
            this.destinationService = _destinationService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int page)
        {
            var hotels = await this.hotelService.GetAllAsync();

            if (page == 0)
            {
                page = 1;
            }

            ViewData["NumberOfTravels"] = hotels.Count;
            ViewData["CurrPageNumber"] = page;
            int hotelsPerPage = 6;

            var model = hotels
                .Skip((page - 1) * hotelsPerPage)
                .Take(hotelsPerPage)
                .ToList();

            if (hotels.Any() && !model.Any())
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int hotelId)
        {
            var model = await this.hotelService.GetByIdForDetailsAsync(hotelId);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Add(string returnParams)
        {
            var model = new HotelFormModel()
            {
                Destinations = await this.destinationService.GetAllForSelectionAsync()
            };

            ViewData["ReturnParams"] = returnParams ?? string.Empty;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(HotelFormModel model, string? returnParams)
        {
            if (!ModelState.IsValid)
            {
                model.Destinations = await this.destinationService.GetAllForSelectionAsync();

                return View(model);
            }

            await this.hotelService.CreateAsync(model);

            if (string.IsNullOrWhiteSpace(returnParams))
            {
                return RedirectToAction(nameof(All));
            }

            var returnParamsSplit = returnParams
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            return RedirectToAction(returnParamsSplit[1], returnParamsSplit[0]);
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Edit(int hotelId)
        {
            var model = await this.hotelService.GetByIdForEditAsync(hotelId);

            if (model == null)
            {
                return NotFound();
            }

            model.Destinations = await this.destinationService.GetAllForSelectionAsync();
            ViewData["HotelId"] = hotelId;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HotelFormModel model, int hotelId)
        {
            if (!ModelState.IsValid)
            {
                model.Destinations = await this.destinationService.GetAllForSelectionAsync();

                return View(model);
            }

            await this.hotelService.EditAsync(hotelId, model);

            return RedirectToAction(nameof(Details), new { hotelId = hotelId });
        }

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Delete(int hotelId)
        {
            bool isDeleted = await this.hotelService.DeleteAsync(hotelId);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}