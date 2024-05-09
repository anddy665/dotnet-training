using System;
using System.Collections.Generic;

namespace RandomNumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> numerosAleatorios = new List<int>(); 

            Console.Write("Introduce el límite inferior del rango: ");
            int limiteInferior = int.Parse(Console.ReadLine());

            Console.Write("Introduce el límite superior del rango: ");
            int limiteSuperior = int.Parse(Console.ReadLine());

            Console.Write("¿Cuántos números aleatorios deseas generar? ");
            int cantidad = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                int numero = random.Next(limiteInferior, limiteSuperior + 1);
                numerosAleatorios.Add(numero);
            }

            Console.WriteLine("Números aleatorios generados:");
            foreach (int numero in numerosAleatorios)
            {
                Console.WriteLine(numero);
            }
        }
    }
}
