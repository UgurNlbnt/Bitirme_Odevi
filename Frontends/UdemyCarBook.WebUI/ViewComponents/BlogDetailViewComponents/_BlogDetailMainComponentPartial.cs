using CarBook.ViewModel.ViewModels.BlogViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogDetailMainComponentPartial:ViewComponent
    {
     
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.blogId = id;
            return View();
        }
    }
}
