using CarBook.ViewModel.ViewModels.CarPricingViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public CarPricingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()  // Varsayılan: Saatlik
		{
			ViewBag.v1 = "Paketler";
			ViewBag.v2 = "Araç Paketleri";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7238/api/CarPricings/GetCarPricingWithTimePeriodQuery");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResuıltCarPricingWithTimePeriodAndBrandViewModel>>(jsonData);
				return View(values);
			}
			return View();
		}

	}
}
