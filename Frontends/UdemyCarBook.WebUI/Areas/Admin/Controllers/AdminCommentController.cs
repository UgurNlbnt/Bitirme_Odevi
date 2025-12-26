using CarBook.ViewModel.ViewModels.CommentViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class AdminCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Yorumları listeleme
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7238/api/Comment/GetCommentByBlogId?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentViewModel>>(jsonData);
                return View(values);
            }
            return View(new List<ResultCommentViewModel>());
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7238/api/Comment?id=" + id);

            if (response.IsSuccessStatusCode)
            {
                // Silme başarılı → AdminBlog sayfasına yönlendir
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }

            // Başarısız olursa da aynı yere dönelim
            return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
        }
    }
}
