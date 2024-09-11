using OrderMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using OrderMicroservice.Data;
using Microsoft.EntityFrameworkCore;

namespace OrderMicroservice.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;
        private readonly HttpClient _httpClient;
        public OrderService(OrderDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<OrderModel> PlaceOrder(OrderModel order)
        {

            var productResponse = await _httpClient.GetAsync($"https://localhost:7290/GetProductById/{order.ProductId}");
            if (!productResponse.IsSuccessStatusCode)
            {
                throw new Exception("Product not found");
            }
            var productJson = await productResponse.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<ProductDto>(productJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (product == null)
            {
                throw new Exception("Failed to deserialize product data");
            }
            order.UnitPrice = product.Price;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<OrderModel> GetOrderById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<OrderModel>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }
    }
    public class ProductDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("productPrice")]
        public decimal Price { get; set; }
    }
}
