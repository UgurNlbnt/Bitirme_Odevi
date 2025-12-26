using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CampaignCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
