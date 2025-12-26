using CarBook.ViewModel.ViewModels.ServiceViewModels;
using CarBook.ViewModel.ViewModels.StatisticsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
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
            #region BlogCount
            var responseMessage3 = await client.GetAsync("https://localhost:7238/api/Statistics/BlogCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int v3= random.Next(0, 101);
                var jsonData3= await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData3);
                ViewBag.BlogCount = values3!.BlogCount;
                ViewBag.randomProgressBlogCount = v3;
            }
            #endregion
            #region AuthorCount
            var responseMessage5 = await client.GetAsync("https://localhost:7238/api/Statistics/AuthorCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int v5= random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData5);
                ViewBag.AuthorCount = values5!.AuthorCount;
                ViewBag.randomProgressAuthorCount = v5;
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
            #region AvgCarHourlyRentalPrice 
            var responseMessage9 = await client.GetAsync("https://localhost:7238/api/Statistics/AvgRentPriceForHourly");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int v9 = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData9);
                ViewBag.AvgRentPriceForHourly = values9!.AvgRentPriceForHourly;
                ViewBag.randomProgressAvgRentPriceForHourly = v9;
            }
            #endregion
            #region AvgCarDailyRentalPrice 
            var responseMessage6 = await client.GetAsync("https://localhost:7238/api/Statistics/AvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int v6 = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData6);
                ViewBag.AvgRentPriceForDaily = values6!.AvgRentPriceForDaily;
                ViewBag.randomProgressAvgRentPriceForDaily = v6;
            }
            #endregion
            #region AvgCarWeeklyRentalPrice 
            var responseMessage7 = await client.GetAsync("https://localhost:7238/api/Statistics/AvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int v7 = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData7);
                ViewBag.AvgRentPriceForWeekly = values7!.AvgRentPriceForWeekly;
                ViewBag.randomProgressAvgRentPriceForWeekly = v7;
            }
            #endregion
            #region AvgCarMonthlyRentalPrice 
            var responseMessage8 = await client.GetAsync("https://localhost:7238/api/Statistics/AvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int v8 = random.Next(0, 101);
                var jsonData8= await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData8);
                ViewBag.AvgRentPriceForMonthly = values8!.AvgRentPriceForMonthly;
                ViewBag.randomProgressAvgRentPriceForMonthly = v8;
            }
            #endregion
            #region CountTransmissionisAuto 
            var responseMessage10 = await client.GetAsync("https://localhost:7238/api/Statistics/CarCountByTranmissionIsAuto");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int v10 = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData10);
                ViewBag.CarCountByTranmissionIsAuto = values10!.CarCountByTranmissionIsAuto;
                ViewBag.randomProgressCarCountByTranmissionIsAuto = v10;
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
            #region BlogTitleByMaxBlogComment 
            var responseMessage12 = await client.GetAsync("https://localhost:7238/api/Statistics/BlogTitleByMaxBlogComment");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int v12 = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData12);
                ViewBag.BlogTitleByMaxBlogComment = values12!.BlogTitleByMaxBlogComment;
                ViewBag.randomProgressBlogTitleByMaxBlogComment = v12;
            }
            #endregion
            #region CarCountThenSmallerThan1000 
            var responseMessage13 = await client.GetAsync("https://localhost:7238/api/Statistics/CarCountByKmSmallerThen1000");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int v13 = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData13);
                ViewBag.CarCountByKmSmallerThen1000 = values13!.CarCountByKmSmallerThen1000;
                ViewBag.randomProgressCarCountByKmSmallerThen1000 = v13;
            }
            #endregion
            #region CarCountFuelisGasolineorDiesel 
            var responseMessage14 = await client.GetAsync("https://localhost:7238/api/Statistics/CarCountByFuelGasolineOrDiesel");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int v14 = random.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData14);
                ViewBag.CarCountByFuelGasolineOrDiesel = values14!.CarCountByFuelGasolineOrDiesel;
                ViewBag.randomProgressCarCountByFuelGasolineOrDiesel = v14;
            }
            #endregion
            #region CarCountFuelisElectric 
            var responseMessage15 = await client.GetAsync("https://localhost:7238/api/Statistics/CarCountByFuelElectric");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int v15 = random.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData15);
                ViewBag.CarCountByFuelElectric = values15!.CarCountByFuelElectric;
                ViewBag.randomProgressCarCountByFuelElectric = v15;
            }
            #endregion
            #region CarBrandAndModelByRentPriceDailyMax
            var responseMessage16 = await client.GetAsync("https://localhost:7238/api/Statistics/CarBrandAndModelByRentPriceDailyMax");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int v16 = random.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData16);
                ViewBag.CarBrandAndModelByRentPriceDailyMax = values16!.CarBrandAndModelByRentPriceDailyMax;
                ViewBag.randomProgressCarBrandAndModelByRentPriceDailyMax = v16;
            }
            #endregion
            #region CarBrandAndModelByRentPriceDailyMin
            var responseMessage17 = await client.GetAsync("https://localhost:7238/api/Statistics/CarBrandAndModelByRentPriceDailyMin");
            if (responseMessage17.IsSuccessStatusCode)
            {
                int v17 = random.Next(0, 101);
                var jsonData17 = await responseMessage17.Content.ReadAsStringAsync();
                var values17 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData17);
                ViewBag.CarBrandAndModelByRentPriceDailyMin = values17!.CarBrandAndModelByRentPriceDailyMin;
                ViewBag.randomProgressCarBrandAndModelByRentPriceDailyMin = v17;
            }
            #endregion
            #region CarCountThenBiggerThan30000
            var responseMessage18 = await client.GetAsync("https://localhost:7238/api/Statistics/CarCountByKmBiggerThen30000");
            if (responseMessage18.IsSuccessStatusCode)
            {
                int v18 = random.Next(0, 101);
                var jsonData18 = await responseMessage18.Content.ReadAsStringAsync();
                var values18= JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData18);
                ViewBag.CarCountByKmBiggerThen30000 = values18!.CarCountByKmBiggerThen30000;
                ViewBag.randomProgressCarCountByKmBiggerThen30000 = v18;
            }
            #endregion
            #region FiveSeatHaveCarCount
            var responseMessage19 = await client.GetAsync("https://localhost:7238/api/Statistics/FiveSeatCarCount");
            if (responseMessage19.IsSuccessStatusCode)
            {
                int v19 = random.Next(0, 101);
                var jsonData19 = await responseMessage19.Content.ReadAsStringAsync();
                var values19 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData19);
                ViewBag.FiveSeatCarCount = values19!.FiveSeatCarCount;
                ViewBag.randomProgressFiveSeatCarCount = v19;
            }
            #endregion
            #region LargeLuggageHaveCarCount
            var responseMessage20 = await client.GetAsync("https://localhost:7238/api/Statistics/LargeLuggageCarCount");
            if (responseMessage20.IsSuccessStatusCode)
            {
                int v20 = random.Next(0, 101);
                var jsonData20 = await responseMessage20.Content.ReadAsStringAsync();
                var values20 = JsonConvert.DeserializeObject<ResultStatisticViewModel>(jsonData20);
                ViewBag.LargeLuggageCarCount = values20!.LargeLuggageCarCount;
                ViewBag.randomProgressLargeLuggageCarCount = v20;
            }
            #endregion
            return View();
        }
    }
}
