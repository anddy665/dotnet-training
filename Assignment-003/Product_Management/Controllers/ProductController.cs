using Microsoft.AspNetCore.Mvc;
using Product_Management.Models;

namespace Product_Management.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Code = 1, Name = "Laptop", Description = "High-end laptop", Price = 1500.00, Stock = 10, Category = "Electronics" },
            new Product { Code = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 800.00, Stock = 20, Category = "Electronics" }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int code)
        {
            var product = products.FirstOrDefault(p => p.Code == code);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Code == product.Code);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                existingProduct.Category = product.Category;
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Delete(int code)
        {
            var product = products.FirstOrDefault(p => p.Code == code);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int code)
        {
            var product = products.FirstOrDefault(p => p.Code == code);
            if (product != null)
            {
                products.Remove(product);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
