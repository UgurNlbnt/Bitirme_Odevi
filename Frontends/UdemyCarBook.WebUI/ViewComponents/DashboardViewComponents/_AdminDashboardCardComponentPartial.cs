using CarBook.ViewModel.ViewModels.StatisticsViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardCardComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardCardComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();
            #region CarCount
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7238/api/Statistics/CarCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                int v1 = random.Next(0, 101);
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData);
                ViewBag.carCount = values!.CarCount;
                ViewBag.randomProgressCarCount = v1;
            }
            #endregion
            #region LocationCount
            var responseMessage2 = await client.GetAsync("https://localhost:7238/api/Statistics/LocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int v2 = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData2);
                ViewBag.LocationCount = values2!.LocationCount;
                ViewBag.randomProgressLocationCount = v2;
            }
            #endregion
            #region BrandNameByMaxCar 
            var responseMessage11 = await client.GetAsync("https://localhost:7238/api/Statistics/BrandNameByMaxCar");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int v11 = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData11);
                ViewBag.BrandNameByMaxCar = values11!.BrandNameByMaxCar;
                ViewBag.randomProgressBrandNameByMaxCar = v11;
            }
            #endregion
            #region BrandCount 
            var responseMessage4 = await client.GetAsync("https://localhost:7238/api/Statistics/BrandCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int v4 = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData4);
                ViewBag.BrandCount = values4!.BrandCount;
                ViewBag.randomProgressBrandCount = v4;
            }
            #endregion

            return View();
        }
    }
}
