using BitirmeProjesiCarReservation.Dto.BrandDto;
using BitirmeProjesiCarReservation.Dto.CarDto;
using BitirmeProjesiCarReservation.Dto.FutureDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace BitirmeProjesiCarReservation.WebUI.Controllers
{
    public class AdminFutureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminFutureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7096/api/Features");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(cars);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent stringContent = new StringContent(jsData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7096/api/Features", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> RemoveFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7096/api/Features/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7096/api/Features/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var car = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(car);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsData = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent stringContent = new StringContent(jsData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7096/api/Features", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
