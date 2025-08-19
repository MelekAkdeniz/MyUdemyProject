using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminGuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminGuestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:40510/api/Guest");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> AddGuest(CreateGuestDto createGuestDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var client = _httpClientFactory.CreateClient();
        //        var jsonData = JsonConvert.SerializeObject(createGuestDto);
        //        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //        var responseMessage = await client.PostAsync("http://localhost:40510/api/Guest", stringContent);
        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        return View();
        //    }
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDto createGuestDto, [FromServices] IValidator<CreateGuestDto> validator)
        {
            // FluentValidation ile manuel doğrulama
            var validationResult = validator.Validate(createGuestDto);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(createGuestDto);
            }

            // Model geçerli, HTTP isteğini gönder
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createGuestDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:40510/api/Guest", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(createGuestDto);
        }

        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:40510/api/Guest/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:40510/api/Guest/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGuestDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGuest(UpdateGuestDto updateGuestDto, [FromServices] IValidator<UpdateGuestDto> validator)
        {
            // FluentValidation ile manuel doğrulama
            var validationResult = validator.Validate(updateGuestDto);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(updateGuestDto);
            }

            // Model geçerli, HTTP isteğini gönder
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateGuestDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("http://localhost:40510/api/Guest", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(updateGuestDto);
        }
    }
}

