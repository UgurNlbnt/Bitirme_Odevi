using BitirmeProjesiCarReservation.Dto.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BitirmeProjesiCarReservation.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial : ViewComponent
    {

        // http isteklerini yaparken httpclientfactory kullanarak istekleri yönetebiliriz.
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //about us sayfasındaki ortak kısımları tutan viewcomponent
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();//istekte bulunmak için client oluşturduk.
            var responseMessage = await client.GetAsync("https://localhost:7096/api/About");//apiye istek attık.

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//responseden gelen içeriği(api) string formatında okur.
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }

            return View();
        }

    }
}
