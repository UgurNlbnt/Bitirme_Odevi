using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiCarReservation.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
