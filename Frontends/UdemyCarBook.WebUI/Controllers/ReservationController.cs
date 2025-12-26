using CarBook.ViewModel.ViewModels.CarViewModels;
using CarBook.ViewModel.ViewModels.LocationViewModels;
using CarBook.ViewModel.ViewModels.ReservationViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7238/api/Location");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultlLocationViewModel>>(jsonData);
            List<SelectListItem> LocationItems = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.LocationId.ToString()
                                                  }).ToList();
            ViewBag.LocationItems = LocationItems;

           
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7238/api/Cars/" + id);
            var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<ResultCarViewModel>(jsondata2);
            ViewBag.carid = values2!.CarId;
            ViewBag.v3 = values2!.BrandName + " " + values2.BrandModel;
            ViewBag.ımage = values2.BigImageUrl;
            ViewBag.v1 = "Rezervasyon";
            ViewBag.v2 = "Rezarvasyon Oluştur";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonvalue = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonvalue, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7238/api/Reservation", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["ReservationState"] = "success";
                return RedirectToAction(nameof(ReservationController.Index));

            }
            TempData["ReservationState"] = "error";
            return RedirectToAction(nameof(ReservationController.Index));
        }
    }
}
