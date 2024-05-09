using System;
using System.Collections.Generic;

namespace TemperatureLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> temperaturas = new List<double>();
            while (true)
            {
                Console.WriteLine("Introduce una temperatura o escribe 'fin' para terminar:");
                string entrada = Console.ReadLine();

                if (entrada.ToLower() == "fin")
                {
                    break;
                }

                try
                {
                    double temperatura = Convert.ToDouble(entrada);
                    temperaturas.Add(temperatura);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, introduce un número válido.");
                }
            }

            if (temperaturas.Count > 0)
            {
                double suma = 0;
                foreach (double temp in temperaturas)
                {
                    suma += temp;
                }
                double promedio = suma / temperaturas.Count;
                Console.WriteLine($"El promedio de las temperaturas registradas es: {promedio} grados.");
            }
            else
            {
                Console.WriteLine("No se introdujeron temperaturas.");
            }
        }
    }
}
