using CarBook.ViewModel.ViewModels.CarDescriptionViewModels;
using CarBook.ViewModel.ViewModels.ReviewViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class AdminCarDetailsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarDetailsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Car Description
            GetCarDescriptionByCarIdViewModel? description = null;
            var descResp = await client.GetAsync("https://localhost:7238/api/CarDescription?id=" + id);
            if (descResp.IsSuccessStatusCode)
            {
                var json = await descResp.Content.ReadAsStringAsync();
                description = JsonConvert.DeserializeObject<GetCarDescriptionByCarIdViewModel>(json);
            }

            // Reviews
            List<GetReviewByCarIdViewModel> reviews = new();
            var reviewsResp = await client.GetAsync("https://localhost:7238/api/Review/GetReviewsByCarId?id=" + id);
            if (reviewsResp.IsSuccessStatusCode)
            {
                var json = await reviewsResp.Content.ReadAsStringAsync();
                reviews = JsonConvert.DeserializeObject<List<GetReviewByCarIdViewModel>>(json) ?? new List<GetReviewByCarIdViewModel>();
            }

            ViewBag.CarId = id;
            ViewBag.Description = description;
            return View(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReview(int id, int carId)
        {
            var client = _httpClientFactory.CreateClient();
            var resp = await client.DeleteAsync("https://localhost:7238/api/Review?id=" + id);
            return RedirectToAction("Index", new { id = carId });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDescription(int carId, string details)
        {
            var client = _httpClientFactory.CreateClient();
            var payload = new
            {
                CarId = carId,
                Details = details
            };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resp = await client.PutAsync("https://localhost:7238/api/CarDescription", content);
            return RedirectToAction("Index", new { id = carId });
        }
    }
}
