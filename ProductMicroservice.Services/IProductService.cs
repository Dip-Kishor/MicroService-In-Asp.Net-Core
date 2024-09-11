using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProducts();
        Task<ProductModel> GetProductById(int id);
        Task<ProductModel> AddProduct(ProductModel product);
        
    }
}
