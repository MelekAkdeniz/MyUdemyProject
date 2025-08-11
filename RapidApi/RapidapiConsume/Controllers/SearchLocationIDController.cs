using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidapiConsume.Models;

namespace RapidapiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={cityName}"),
                    Headers =
    {
        { "x-rapidapi-key", "b7d12692e3msh1f3ad94cf6bbe2ap10af52jsn8e0f11eabc88" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel>(body);
                    var locations = result.data;
                    return View(locations.Take(1).ToList());
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query=paris"),
                    Headers =
    {
        { "x-rapidapi-key", "b7d12692e3msh1f3ad94cf6bbe2ap10af52jsn8e0f11eabc88" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel>(body);
                    var locations = result.data;
                    return View(locations.Take(1).ToList());
                }
            }
           
        }
    }
}
