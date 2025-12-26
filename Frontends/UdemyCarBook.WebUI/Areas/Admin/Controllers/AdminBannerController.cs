using CarBook.ViewModel.ViewModels.BannerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class AdminBannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7238/api/Banner");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerVİewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7238/api/Banner?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]

        public async Task<IActionResult> CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerViewModel Banner)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(Banner);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7238/api/Banner", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "İşlem Başarılı";
                return RedirectToAction("Index","AdminBanner");
                //new { area = "Admin" } → MVC’ye “bu yönlendirme Admin alanındaki Controller’a ait” demektir.
            }
            TempData["Error"] = "İşlem Başarılı";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7238/api/Banner/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBannerVİewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerVİewModel Banner)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(Banner);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7238/api/Banner", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "İşlem Başarılı";
                return RedirectToAction("Index", "AdminBanner");
            }
            return View();
        }
    }
}
/*👉 [Area("Admin")], bu controller’ın “Admin” adlı bölüme (area’ya) ait olduğunu belirtir.
Böylece proje, büyük modüllere ayrılır (örneğin Admin, User, Customer gibi).
Yani:
“Bu controller, Admin paneline ait” demenin C# karşılığıdır. ✅*/

//----------------------------------------
//[Route], bir Action veya Controller’ın hangi URL’den çalışacağını açıkça belirleyen bir “adres tanımıdır”.
//[Route] → bir adres tanımlayıcısıdır.
//Yani, “bu method hangi URL’den çalışsın” onu belirtir.
//📌 Neden kullanılır?
//URL’leri daha düzenli ve anlamlı yapmak için,
//Admin, API, User gibi farklı bölümleri ayırmak için,
//Varsayılan yönlendirmeyi (controller/action) özelleştirmek için.
//🧠 Özetle:
//[Route], bir Action veya Controller’ın adresini senin elinle belirlemene yarar.