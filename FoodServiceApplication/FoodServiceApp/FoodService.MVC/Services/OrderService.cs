using FoodService.MVC.Models.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodService.MVC.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration Configuration;
        public OrderService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }

        public async Task Order(OrderDto orderDto)
        {
            var uri = Configuration["URI"];
           // var uri = "https://localhost:44314/api/PlaceOrder";
            var content = new StringContent(JsonConvert.SerializeObject(orderDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }
    }
}