using CarBook.ViewModel.ViewModels.ServiceViewModels;
using CarBook.ViewModel.ViewModels.TestimonialViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmetlerimiz";
            return View();
        }
    }
}
