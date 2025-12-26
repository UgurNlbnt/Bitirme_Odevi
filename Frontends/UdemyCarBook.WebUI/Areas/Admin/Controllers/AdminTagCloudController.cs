using CarBook.ViewModel.ViewModels.TagCloudViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class AdminTagCloudController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminTagCloudController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7238/api/TagCloud");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTagCloudViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteTagCloud(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7238/api/TagCloud?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]

        public async Task<IActionResult> CreateTagCloud()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudViewModel TagCloud)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(TagCloud);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7238/api/TagCloud", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "İşlem Başarılı";
                return RedirectToAction("Index", "AdminTagCloud");
                //new { area = "Admin" } → MVC’ye “bu yönlendirme Admin alanındaki Controller’a ait” demektir.
            }
            TempData["Error"] = "İşlem Başarılı";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTagCloud(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7238/api/TagCloud/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTagCloudViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudViewModel TagCloud)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(TagCloud);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7238/api/TagCloud", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "İşlem Başarılı";
                return RedirectToAction("Index", "AdminTagCloud");
            }
            return View();
        }
    }
}
