using System.Collections.Generic;
using Product_Management.Models;

namespace Product_Management.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByUserId(int userId);
        Product GetProductByCode(int code);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int code);
    }
}
