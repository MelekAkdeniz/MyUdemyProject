using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(IFormFile file)
        //{
        //    var stream = new MemoryStream();
        //    await file.CopyToAsync(stream);
        //    var bytes= stream.ToArray();

        //    ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
        //    byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
        //    MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
        //    multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
        //    var httpclient= new HttpClient();
        //    await httpclient.PostAsync("https://localhost:40510/api/FileImage", multipartFormDataContent);
      
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Lütfen bir dosya seçin.");
                return View();
            }

            // Dosyayı memory stream'e al
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            // ByteArrayContent oluştur
            var byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            // MultipartFormDataContent oluştur
            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(byteArrayContent, "file", file.FileName);

            // HttpClientHandler ile sertifika doğrulamasını atla (sadece test için)
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            using var httpClient = new HttpClient(handler);

            try
            {
                var response = await httpClient.PostAsync("https://localhost:40510/api/FileImage", multipartContent);

                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "Dosya yükleme başarısız oldu: " + response.ReasonPhrase);
                }
                else
                {
                    ViewBag.Message = "Dosya başarıyla yüklendi!";
                }
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError("", "HTTP hatası: " + ex.Message);
            }

            return View();
        }
    }
}
