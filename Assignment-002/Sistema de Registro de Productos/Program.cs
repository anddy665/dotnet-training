using System;
using Items;


class Program
{

    static List<Product> products = new List<Product>();
    Items.Product product = new Items.Product(0, "", "", 0, 0, "");
    static void Main(string[] args)
    {
        const string currentUser = "admin";
        const string currentPassword = "admin123";

        Console.WriteLine("Ingrese su usuario:");
        string user = Console.ReadLine();
        Console.WriteLine("Ingrese su contraseña:");
        string password = Console.ReadLine();

        if (user == currentUser && password == currentPassword)
        {
            Console.WriteLine("Autenticación exitosa.");
            ShowMenu();
        }
        else
        {
            Console.WriteLine("Usuario o contraseña incorrectos.");
            return;
        }
    }

    static void ShowMenu()
    {
        string opcion;
        do
        {
            Console.WriteLine("\nMenú de Gestión de Productos");
            Console.WriteLine("1. Ver lista de todos los productos");
            Console.WriteLine("2. Agregar un nuevo producto");
            Console.WriteLine("3. Actualizar la información de un producto existente");
            Console.WriteLine("4. Eliminar un producto del sistema");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // use showProducts method from Product class
                    Product.ShowProducts();
                    break;
                case "2":
                    AddProduct();
                    break;
                case "3":
                    UpdateProduct();
                    break;
                case "4":
                    DeleteProduct();
                    break;
                case "5":
                    Console.WriteLine("Saliendo del sistema.");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        } while (opcion != "5");
    }

    static void AddProduct()
    {

        Console.Write("Ingrese el Código del producto: ");
        int code = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el Nombre del producto: ");
        string name = Console.ReadLine();
        Console.Write("Ingrese la Descripción del producto: ");
        string description = Console.ReadLine();
        Console.Write("Ingrese el Precio del producto: ");
        double price = double.Parse(Console.ReadLine());
        Console.Write("Ingrese el Stock del producto: ");
        int stock = int.Parse(Console.ReadLine());
        Console.Write("Ingrese la Categoría del producto: ");
        string category = Console.ReadLine();

        products.Add(new Product( code, name, description, price, stock, category));
        Console.WriteLine("Producto agregado correctamente.");
    }

    static void UpdateProduct()
    {
        Console.Write("Ingrese el codigo del producto a actualizar: ");
        int code = int.Parse(Console.ReadLine());
        var product = products.FirstOrDefault(p => p.Code == code );

        if (product != null)
        {
            Console.Write("Ingrese el nuevo nombre del producto: ");
            product.Name = Console.ReadLine();
            Console.Write("Ingrese la nueva descripción del producto: ");
            product.Description = Console.ReadLine();
            Console.Write("Ingrese el nuevo precio del producto: ");
            product.Price = double.Parse(Console.ReadLine());
            Console.Write("Ingrese el nuevo stock del producto: ");
            product.Stock = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la nueva categoría del producto: ");
            product.Category = Console.ReadLine();
            Console.WriteLine("Producto actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void DeleteProduct()
    {
        Console.Write("Ingrese el codigo del producto a eliminar: ");
        int code = int.Parse(Console.ReadLine());
        var product = products.FirstOrDefault(p => p.Code == code);

        if (product != null)
        {
            products.Remove(product);
            Console.WriteLine("Producto eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

}
