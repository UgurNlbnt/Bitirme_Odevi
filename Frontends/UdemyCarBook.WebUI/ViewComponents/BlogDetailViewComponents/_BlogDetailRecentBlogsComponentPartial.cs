using CarBook.ViewModel.ViewModels.BlogViewModels;
using CarBook.ViewModel.ViewModels.CommentViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogDetailRecentBlogsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailRecentBlogsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7238/api/Blog/GetLast3BlogWithCategoryandAuthorList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetLast3BlogWithCategoryandAuthorViewModel>>(jsonData);

                var commentCounts = new Dictionary<int, int>();
                foreach (var blog in values ?? new List<GetLast3BlogWithCategoryandAuthorViewModel>())
                {
                    var commentResp = await client.GetAsync($"https://localhost:7238/api/Comment/GetCommentByBlogId?id={blog.BlogId}");
                    if (commentResp.IsSuccessStatusCode)
                    {
                        var commentJson = await commentResp.Content.ReadAsStringAsync();
                        var comments = JsonConvert.DeserializeObject<List<ResultCommentViewModel>>(commentJson) ?? new List<ResultCommentViewModel>();
                        commentCounts[blog.BlogId] = comments.Count;
                    }
                    else
                    {
                        commentCounts[blog.BlogId] = 0;
                    }
                }

                ViewBag.CommentCounts = commentCounts;
                return View(values);
            }
            return View();
        }
    }
}
