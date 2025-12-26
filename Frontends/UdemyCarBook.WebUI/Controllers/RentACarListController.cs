using CarBook.ViewModel.ViewModels.CategoryViewModels;
using CarBook.ViewModel.ViewModels.RentACarListViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Security.Policy;
using System.Text;
using static System.Net.WebRequestMethods;

namespace UdemyCarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(RentACarRequestViewModel model)
        {
            ViewBag.v1 = "Lokasyonlar";
            ViewBag.v2 = "Bu Lokasyonda Bulunan Araçlar";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7238/api/RentACars?LocationId={model.LocationId}&status=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //Artık string elimizde olduğu için, dönüştürücü metni analiz edip programlama dilinin kullanabileceği nesneleri oluşturabilir
                //C# kodu, ham ağ verisini doğrudan nesneye çeviremez; önce JSON'un metin formatını temsil eden saf bir string elde etmesi gerekir.
                var values = JsonConvert.DeserializeObject<List<FilterRentACarViewModel>>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}
//🔹 Sayfayı yenilersen neden hâlâ görünüyor gibi oluyor?
//POST isteğinden sonra sayfa yenilendiğinde (F5), tarayıcı POST isteğini tekrar göndermek ister. Bu yüzden ViewBag verileri gidiyor gibi görünmüyor - aslında her yenilemede POST tekrar çalışıyor!
//F5 yaptığında ViewBag aslında kalmıyor, sadece tarayıcı önceki POST isteğini tekrar gönderiyor.
//Bu yüzden controller tekrar çalışıyor, ViewBag yeniden doluyor ve sanki veriler hiç gitmemiş gibi görünüyor.