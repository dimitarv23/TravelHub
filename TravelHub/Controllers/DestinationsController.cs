namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using TravelHub.ViewModels.Destinations;

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
        public IActionResult Add()
        {
            DestinationFormModel model = new DestinationFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DestinationFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.destinationService.CreateAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int destinationId)
        {
            await this.destinationService.DeleteAsync(destinationId);

            return Ok();
        }
    }
}