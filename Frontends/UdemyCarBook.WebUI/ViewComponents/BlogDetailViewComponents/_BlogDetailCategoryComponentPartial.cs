using CarBook.ViewModel.ViewModels.CategoryViewModels;
using CarBook.ViewModel.ViewModels.BlogViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogDetailCategoryComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =  _httpClientFactory.CreateClient();

            var categoryResponse = await client.GetAsync("https://localhost:7238/api/Category");
            var blogResponse = await client.GetAsync("https://localhost:7238/api/Blog/GetAllBlogWithOthersList");

            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryViewModel>>(categoryJson);

                if (blogResponse.IsSuccessStatusCode)
                {
                    var blogJson = await blogResponse.Content.ReadAsStringAsync();
                    var blogs = JsonConvert.DeserializeObject<List<GetAllBlogWithOthersViewModel>>(blogJson) ?? new List<GetAllBlogWithOthersViewModel>();
                    var categoryBlogCounts = blogs
                        .GroupBy(b => b.CategoryId)
                        .ToDictionary(g => g.Key, g => g.Count());
                    ViewBag.CategoryBlogCounts = categoryBlogCounts;
                }
                else
                {
                    ViewBag.CategoryBlogCounts = new Dictionary<int, int>();
                }

                return View(categories);
            }
            return View();
        }
    }
}
