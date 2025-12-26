using CarBook.ViewModel.ViewModels.BlogViewModels;
using CarBook.ViewModel.ViewModels.CommentViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace UdemyCarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int? categoryId = null, string? q = null)
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7238/api/Blog/GetAllBlogWithOthersList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonContent = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllBlogWithOthersViewModel>>(jsonContent);

                if (values != null)
                {
                    if (categoryId.HasValue)
                    {
                        values = values.Where(x => x.CategoryId == categoryId.Value).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(q))
                    {
                        var term = q.Trim().ToLower();
                        values = values.Where(x =>
                            (!string.IsNullOrEmpty(x.Title) && x.Title.ToLower().Contains(term)) ||
                            (!string.IsNullOrEmpty(x.Description) && x.Description.ToLower().Contains(term)) ||
                            (!string.IsNullOrEmpty(x.AuthorName) && x.AuthorName.ToLower().Contains(term)) ||
                            (!string.IsNullOrEmpty(x.CategoryName) && x.CategoryName.ToLower().Contains(term))
                        ).ToList();
                    }

                    var commentCounts = new Dictionary<int, int>();
                    foreach (var item in values)
                    {
                        var commentResponse = await client.GetAsync($"https://localhost:7238/api/Comment/GetCommentByBlogId?id={item.BlogId}");
                        if (commentResponse.IsSuccessStatusCode)
                        {
                            var commentJson = await commentResponse.Content.ReadAsStringAsync();
                            var comments = JsonConvert.DeserializeObject<List<ResultCommentViewModel>>(commentJson);
                            commentCounts[item.BlogId] = comments?.Count ?? 0;
                        }
                        else
                        {
                            commentCounts[item.BlogId] = 0;
                        }
                    }
                    ViewBag.CommentCounts = commentCounts;
                }
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            ViewBag.BlogId = id;
            return View();
        }

        [HttpPost] /*Bu metod sadece POST isteklerini kabul eder*/
        public async Task<IActionResult> CreateComment(CreateCommentViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            model.CreatedDate = DateTime.Now;

            var data = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7238/api/Comment", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "true";
                return RedirectToAction("BlogDetail", new { id = model.BlogId });
            }

            TempData["Success"] = "false";
            return RedirectToAction("BlogDetail", new { id = model.BlogId });
        }

    }
}
