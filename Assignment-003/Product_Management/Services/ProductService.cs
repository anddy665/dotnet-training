using Product_Management.Interfaces;
using Product_Management.Models;
using Product_Management.Data;
using System.Collections.Generic;
using System.Linq;

namespace Product_Management.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByUserId(int userId)
        {
            return _context.Products.Where(p => p.UserId == userId).ToList();
        }

        public Product GetProductByCode(int code)
        {
            return _context.Products.FirstOrDefault(p => p.Code == code);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductByCode(product.Code);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                existingProduct.Category = product.Category;
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int code)
        {
            var product = GetProductByCode(code);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
