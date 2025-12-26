using CarBook.ViewModel.ViewModels.CarFeatureDetailViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7238/api/CarFeature/"+ id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureDetailViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        //CarID URL'den gelip Model'e doluyor
        public async Task<IActionResult> Index(List<ResultCarFeatureDetailViewModel> Features)
        {
            foreach (var item in Features)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7238/api/CarFeature", content);
            }
            return RedirectToAction("Index","AdminCar");
        }
    }
}
//ASP.NET Core’un model binding sistemi, form verilerini liste (List<T>) veya dizi (array) halindeki modellere eşleştirebilmek için index ([@i]) bilgisini ister.
//    Ve her satır kendi CarFeatureId, FeatureID, Avaiable değerini doğru nesneye koyar.
//    Features[@i].CarFeatureId = “Features listesinin i’inci elemanının CarFeatureId özelliği”Features[@i].CarFeatureId = “Features listesinin i’inci elemanının CarFeatureId özelliği”