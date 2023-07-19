namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using TravelHub.ViewModels.Travels;

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
        public async Task<IActionResult> Add()
        {
            TravelFormModel model = new TravelFormModel()
            {

            };

            return View(model);
        }
    }
}