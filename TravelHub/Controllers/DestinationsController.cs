﻿namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using TravelHub.ViewModels.Destinations;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class DestinationsController : Controller
    {
        private readonly IDestinationService destinationService;

        public DestinationsController(IDestinationService _destinationService)
        {
            this.destinationService = _destinationService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await this.destinationService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int destinationId)
        {
            var model = await this.destinationService
                .GetByIdForDetailsAsync(destinationId);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Organizer")]
        public IActionResult Add(string returnParams)
        {
            DestinationFormModel model = new DestinationFormModel();

            ViewData["ReturnParams"] = returnParams ?? "";
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Add(DestinationFormModel model, string returnParams)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.destinationService.CreateAsync(model);

            if (string.IsNullOrWhiteSpace(returnParams))
            {
                return RedirectToAction(nameof(All));
            }

            var returnParamsSplit = returnParams
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            return RedirectToAction(returnParamsSplit[1], returnParamsSplit[0]);
        }

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public async Task<IActionResult> Delete(int destinationId)
        {
            bool isDeleted = await this.destinationService.DeleteAsync(destinationId);

            return isDeleted ? Ok() : NotFound();
        }
    }
}