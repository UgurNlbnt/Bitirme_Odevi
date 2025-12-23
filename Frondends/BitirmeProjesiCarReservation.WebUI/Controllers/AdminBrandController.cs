using BitirmeProjesiCarReservation.Dto.BrandDto;
using BitirmeProjesiCarReservation.Dto.FutureDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BitirmeProjesiCarReservation.WebUI.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminBrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7096/api/Brand");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(cars);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsData = JsonConvert.SerializeObject(createBrandDto);
            StringContent stringContent = new StringContent(jsData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7096/api/Brand", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> RemoveBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7096/api/Brand?id="+id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7096/api/Brand/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var car = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(car);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsData = JsonConvert.SerializeObject(updateBrandDto);
            StringContent stringContent = new StringContent(jsData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7096/api/Brand", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
