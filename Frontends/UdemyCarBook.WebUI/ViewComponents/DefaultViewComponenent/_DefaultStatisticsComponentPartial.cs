using CarBook.ViewModel.ViewModels.StatisticsViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponenent
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region CarCount
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7238/api/Statistics/CarCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData);
                ViewBag.carCount = values!.CarCount;
            }
            #endregion
            #region LocationCount
            var responseMessage2 = await client.GetAsync("https://localhost:7238/api/Statistics/LocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData2);
                ViewBag.LocationCount = values2!.LocationCount;
            }
            #endregion
            #region BrandCount 
            var responseMessage4 = await client.GetAsync("https://localhost:7238/api/Statistics/BrandCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData4);
                ViewBag.BrandCount = values4!.BrandCount;
            }
            #endregion
            #region BlogCount
            var responseMessage3 = await client.GetAsync("https://localhost:7238/api/Statistics/BlogCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData3);
                ViewBag.BlogCount = values3!.BlogCount;
            }
            #endregion

            return View();
        }
    }
}
