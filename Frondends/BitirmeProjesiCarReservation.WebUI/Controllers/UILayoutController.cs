using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiCarReservation.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
