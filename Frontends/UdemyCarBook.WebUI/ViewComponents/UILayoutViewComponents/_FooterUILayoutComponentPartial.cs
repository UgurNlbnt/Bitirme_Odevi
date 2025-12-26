using CarBook.ViewModel.ViewModels.FooterAddressViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7238/api/FooterAddress");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //Bir HTTP isteğinden gelen cevabın gövdesini(Content kısmını) string(metin) olarak okur.
                /*“Bir HTTP cevabındaki veriyi C# nesnesine dönüştürmeden önce mutlaka string olarak okumalıyız.”
                Çünkü DeserializeObject() metodu yalnızca string alır.*/
                //JSON verisi string olarak okunduğunda:
                // Teknik olarak: Bir C# string'idir (metin)
                //İçerik olarak: Hala JSON formatındadır
                var values = JsonConvert.DeserializeObject<List<ResultFooterAddressViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
