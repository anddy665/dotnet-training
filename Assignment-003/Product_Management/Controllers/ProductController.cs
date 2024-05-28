using Microsoft.AspNetCore.Mvc;
using Product_Management.Interfaces;
using Product_Management.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;

namespace Product_Management.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAuthService _authService;

        public ProductController(IProductService productService, IAuthService authService)
        {
            _productService = productService;
            _authService = authService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var products = _productService.GetProductsByUserId(int.Parse(userId));
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine("UserId: " + userId);
            product.UserId = int.Parse(userId); // Asignar el UserId del usuario logueado

            if (TryValidateModel(product))
            {
                _productService.AddProduct(product);
                return RedirectToAction("Index");
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine("Error: " + error.ErrorMessage);
            }

            return View(product);
        }

        public IActionResult Edit(int code)
        {
            var product = _productService.GetProductByCode(code);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            product.UserId = int.Parse(userId); // Asignar el UserId del usuario logueado

            if (TryValidateModel(product))
            {
                _productService.UpdateProduct(product);
                return RedirectToAction("Index");
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine("Error: " + error.ErrorMessage);
            }

            return View(product);
        }

        public IActionResult Delete(int code)
        {
            var product = _productService.GetProductByCode(code);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int code)
        {
            _productService.DeleteProduct(code);
            return RedirectToAction("Index");
        }
    }
}
