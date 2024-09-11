using ProductMicroservice.Data;
using ProductMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;
        public ProductService(ProductDbContext context)
        {
            _context = context;
        }
        //=======================================================
        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        //=======================================================
        public async Task<ProductModel> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        //=======================================================
        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;

        }

    }
}
