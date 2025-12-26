using CarBook.ViewModel.ViewModels.CarPricingViewModels;
using CarBook.ViewModel.ViewModels.CarViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int? pricingId = 2)
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Paketleri";

            // Aktif butonu seçmek için (View tarafında)
            ViewBag.SelectedPricing = pricingId ?? 0;

            var client = _httpClientFactory.CreateClient();

            // API isteği
            var responseMessage = await client.GetAsync("https://localhost:7238/api/CarPricings/GetCarPricingWithCarByPricingId?pricing%C4%B1d=" + pricingId);

            if (!responseMessage.IsSuccessStatusCode)
                return View(new List<ResultCarPricingViewModel>()); // boş liste döner

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultCarPricingViewModel>>(jsonData);

            return View(values);
        }


        public IActionResult CarDetail(int id)
        {
			ViewBag.v1 = "Araç Detayları";
			ViewBag.v2 = "Aracın Teknik ve Aksesuar Özellikleri";
            ViewBag.carId = id;
			return View();
        }
    }
}
