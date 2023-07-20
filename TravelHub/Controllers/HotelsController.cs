namespace TravelHub.Controllers
{
    using TravelHub.Core.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using TravelHub.ViewModels.Hotels;
    using TravelHub.ViewModels.Travels;

    public class HotelsController : Controller
    {
        private readonly IHotelService hotelService;

        public HotelsController(IHotelService _hotelService)
        {
            this.hotelService = _hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await this.hotelService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int hotelId)
        {
            var model = await this.hotelService.GetByIdForDetailsAsync(hotelId);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            var model = new TravelFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HotelFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.hotelService.CreateAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int hotelId)
        {
            var model = await this.hotelService.GetByIdForEditAsync(hotelId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HotelFormModel model, int hotelId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.hotelService.EditAsync(hotelId, model);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int hotelId)
        {
            await this.hotelService.DeleteAsync(hotelId);

            return RedirectToAction(nameof(All));
        }
    }
}