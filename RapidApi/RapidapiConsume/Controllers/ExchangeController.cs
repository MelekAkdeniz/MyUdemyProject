using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidapiConsume.Models;
using System.Net.Http.Headers;
using static RapidapiConsume.Models.ExchangeViewModel;


namespace RapidapiConsume.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
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
                Console.WriteLine(body); // Output penceresine yazar
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values.data.exchange_rates?.ToList());
            }
        }
    }
}
