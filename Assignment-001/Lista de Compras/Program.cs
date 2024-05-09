using System;
using System.Collections.Generic;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> productos = new List<string>();
            List<bool> comprado = new List<bool>();

            while (true)
            {
                Console.WriteLine("Lista de Compras");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Marcar como comprado");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Mostrar lista");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el nombre del producto: ");
                        string producto = Console.ReadLine();
                        productos.Add(producto);
                        comprado.Add(false);
                        break;
                    case 2:
                        MostrarProductos(productos, comprado);
                        Console.Write("Seleccione el número del producto a marcar como comprado: ");
                        int indiceComprado = int.Parse(Console.ReadLine()) - 1;
                        if (indiceComprado >= 0 && indiceComprado < productos.Count)
                        {
                            comprado[indiceComprado] = true;
                        }
                        break;
                    case 3:
                        MostrarProductos(productos, comprado);
                        Console.Write("Seleccione el número del producto a eliminar: ");
                        int indiceEliminar = int.Parse(Console.ReadLine()) - 1;
                        if (indiceEliminar >= 0 && indiceEliminar < productos.Count)
                        {
                            productos.RemoveAt(indiceEliminar);
                            comprado.RemoveAt(indiceEliminar);
                        }
                        break;
                    case 4:
                        MostrarProductos(productos, comprado);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void MostrarProductos(List<string> productos, List<bool> comprado)
        {
            Console.WriteLine("Productos en la lista:");
            for (int i = 0; i < productos.Count; i++)
            {
                string estado = comprado[i] ? "Comprado" : "Pendiente";
                Console.WriteLine($"{i + 1}. {productos[i]} - {estado}");
            }
        }
    }
}
