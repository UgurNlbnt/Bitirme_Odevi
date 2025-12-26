using CarBook;
using CarBook.WebApi.Berkay;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;


namespace CarBook.WebApi.Hubs
{
    public class CarHub:Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task CarCount()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7238/api/Statistics/CarCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                int v1 = random.Next(0, 101);
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CarCountViewModel>(jsonData);
                await Clients.All.SendAsync("CarCount", value.CarCount);
            }
        }

      
    }
}
