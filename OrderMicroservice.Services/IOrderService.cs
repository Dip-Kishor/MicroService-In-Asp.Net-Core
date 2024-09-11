using OrderMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetOrders();
        Task<OrderModel> GetOrderById(int id);
        Task<OrderModel> PlaceOrder(OrderModel order);
    }
}
