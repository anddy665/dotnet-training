using Product_Management.Interfaces;
using Product_Management.Models;
using System.Collections.Generic;
using System.Linq;

namespace Product_Management.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>
            {
                new Product { Code = 1, Name = "Laptop", Description = "High-end laptop", Price = 1500.00, Stock = 10, Category = "Electronics" },
                new Product { Code = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 800.00, Stock = 20, Category = "Electronics" }
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductByCode(int code)
        {
            return _products.FirstOrDefault(p => p.Code == code);
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
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
            }
        }

        public void DeleteProduct(int code)
        {
            var product = GetProductByCode(code);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
