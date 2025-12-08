using BitirmeProjesiCarReservation.Dto.CarDto;
using BitirmeProjesiCarReservation.Dto.CarPricingDto;
using BitirmeProjesiCarReservation.Dto.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BitirmeProjesiCarReservation.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız"; //Controller’dan View’a küçük, geçici bilgiler göndermek için kullanılır.
            ViewBag.v2 = "Aracınızı Seçiniz";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7096/api/CarPricings/GetCarPricingWithCarList"); //apiden gelen veri jsondur.
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData); //jsondan nesneye çevirme
                return View(values);
            }

            return View();
        }
    }
}
//Bu client ile API’ya GET isteği gönderir.

//API’dan gelen cevap başarılı mı? diye kontrol eder.

//Başarılıysa içerikteki JSON metni okunur.

//JSON, ResultCarPricingWithCarDto listesine deserialize edilerek C# objelerine çevrilir.

//Bu liste View’a gönderilir ve ekranda araç + fiyat bilgileri gösterilir.

//Eğer API başarısız dönerse boş bir View gönderilir (çökme olmaz).