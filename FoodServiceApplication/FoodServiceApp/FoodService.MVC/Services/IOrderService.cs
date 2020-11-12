using FoodService.MVC.Models.DTO;
using System.Threading.Tasks;

namespace FoodService.MVC.Services
{
    public interface IOrderService
    {
        public Task Order(OrderDto orderDto);
    }
}