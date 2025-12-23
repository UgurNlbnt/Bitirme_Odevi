using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiCarReservation.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminnNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminnSidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminnFooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminnScriptPartial()
        {
            return PartialView();
        }
    }
}
