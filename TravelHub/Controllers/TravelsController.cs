﻿namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Extensions;
    using TravelHub.ViewModels.Travels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class TravelsController : Controller
    {
        private readonly ITravelService travelService;

        private readonly IDestinationService destinationService;

        private readonly IHotelService hotelService;

        public TravelsController(ITravelService _travelService,
            IDestinationService _destinationService,
            IHotelService _hotelService)
        {
            this.travelService = _travelService;
            this.destinationService = _destinationService;
            this.hotelService = _hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int page)
        {
            var travels = (await this.travelService.GetAllAsync())
                .OrderByDescending(t => t.Id)
                .ToList();

            if (page == 0)
            {
                page = 1;
            }

            ViewData["NumberOfTravels"] = travels.Count;
            ViewData["CurrPageNumber"] = page;
            int travelsPerPage = 4;

            var model = travels
                .Skip((page - 1) * travelsPerPage)
                .Take(travelsPerPage)
                .ToList();

            if (travels.Any() && !model.Any())
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Add()
        {
            TravelFormModel model = new TravelFormModel()
            {
                Destinations = await this.destinationService.GetAllForSelectionAsync(),
                Hotels = await this.hotelService.GetAllForTravelAsync()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TravelFormModel model)
        {
            if (model.DateTo < model.DateFrom)
            {
                ModelState.AddModelError(nameof(model.DateTo), "DateTo cannot be before DateFrom.");
            }

            if (!ModelState.IsValid)
            {
                model = new TravelFormModel()
                {
                    Destinations = await this.destinationService.GetAllForSelectionAsync(),
                    Hotels = await this.hotelService.GetAllForTravelAsync()
                };

                return View(model);
            }

            await this.travelService.CreateAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int travelId)
        {
            var travel = await this.travelService
                .GetByIdForDetailsAsync(travelId, User.GetId());

            if (travel == null)
            {
                return NotFound();
            }

            return View(travel);
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Edit(int travelId)
        {
            var model = await this.travelService.GetByIdForEditAsync(travelId);

            if (model == null)
            {
                return NotFound();
            }

            model.Destinations = await this.destinationService.GetAllForSelectionAsync();
            model.Hotels = await this.hotelService.GetAllForTravelAsync();
            ViewData["TravelId"] = travelId;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TravelFormModel model, int travelId)
        {
            if (model.DateTo < model.DateFrom)
            {
                ModelState.AddModelError(nameof(model.DateTo), "DateTo cannot be before DateFrom.");
            }

            if (!ModelState.IsValid)
            {
                model.Destinations = await this.destinationService.GetAllForSelectionAsync();
                model.Hotels = await this.hotelService.GetAllForTravelAsync();

                return View(model);
            }

            await this.travelService.EditAsync(travelId, model);

            return RedirectToAction(nameof(Details), new { travelId = travelId });
        }

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Delete(int travelId)
        {
            bool isDeleted = await this.travelService.DeleteAsync(travelId);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}