using System;


namespace Items
{
    public class Product
    {
        private List<Product> products = new List<Product>();
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }

        public Product( int code, string name, string description, double price, int stock, string category)
        {
            Code = code;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Category = category;
        }

        public void ShowProducts()
        {
            if (products.Any())
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Nombre: {product.Name}, Descripción: {product.Description}, Precio: {product.Price}, Stock: {product.Stock}, Categoría: {product.Category}");
                }
            }
            else
            {
                Console.WriteLine("No hay productos registrados.");
            }
        }

        public void UpdateStock(int quantity)
        {
            Stock += quantity;
        }
    }
}
