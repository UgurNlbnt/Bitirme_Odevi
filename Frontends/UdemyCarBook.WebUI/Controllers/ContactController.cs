using CarBook.ViewModel.ViewModels.ContactViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "İLETİŞİM";
            ViewBag.v2 = "Bize Ulaşın";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactVİewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            model.SendDate = DateTime.Now;
            var JsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7238/api/Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["ContactState"] = "success";
                return RedirectToAction(nameof(ContactController.Index));
            }
            TempData["ContactState"] = "error";
            return View();
        }
    }
}
