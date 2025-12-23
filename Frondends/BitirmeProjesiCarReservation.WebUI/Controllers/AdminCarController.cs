using BitirmeProjesiCarReservation.Dto.BrandDto;
using BitirmeProjesiCarReservation.Dto.CarDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace BitirmeProjesiCarReservation.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7096/api/Car/GetCarWithBrand");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(cars);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7096/api/Brand");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);

            List<SelectListItem> brandValues = values.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.BrandId.ToString()
            }).ToList();

            ViewBag.BrandValues = brandValues;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsData = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7096/api/Car", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // POST başarısız olursa, Brand verilerini yeniden yükle
            var brandClient = _httpClientFactory.CreateClient();
            var brandResponse = await brandClient.GetAsync("https://localhost:7096/api/Brand");
            var brandJsonData = await brandResponse.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandJsonData);

            List<SelectListItem> brandValues = values.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.BrandId.ToString()
            }).ToList();

            ViewBag.BrandValues = brandValues;
            return View(createCarDto);
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7096/api/Car/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response1 = await client.GetAsync("https://localhost:7096/api/Brand");
            var jsonData1 = await response1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);

            List<SelectListItem> brandValues = (from x in values1 select new SelectListItem
            {
                Text = x.Name,
                Value = x.BrandId.ToString()
            }).ToList();

            ViewBag.BrandValues = brandValues;


            var response = await client.GetAsync($"https://localhost:7096/api/Car/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var car = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(car);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsData = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7096/api/Car", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}