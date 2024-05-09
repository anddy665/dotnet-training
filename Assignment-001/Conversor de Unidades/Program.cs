using System;

namespace UnitConverter
{
    public interface IConversorUnidades
    {
        double Convertir(double valor);
        string UnidadOrigen { get; }
        string UnidadDestino { get; }
    }

    public class MetrosAPies : IConversorUnidades
    {
        public string UnidadOrigen => "metros";
        public string UnidadDestino => "pies";

        public double Convertir(double valor)
        {
            return valor * 3.28084;
        }
    }

    public class PiesAMetros : IConversorUnidades
    {
        public string UnidadOrigen => "pies";
        public string UnidadDestino => "metros";

        public double Convertir(double valor)
        {
            return valor * 0.3048;
        }
    }

    public class LitrosAGalones : IConversorUnidades
    {
        public string UnidadOrigen => "litros";
        public string UnidadDestino => "galones";

        public double Convertir(double valor)
        {
            return valor * 0.264172;
        }
    }

    public class GalonesALitros : IConversorUnidades
    {
        public string UnidadOrigen => "galones";
        public string UnidadDestino => "litros";

        public double Convertir(double valor)
        {
            return valor * 3.78541;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IConversorUnidades[] conversores = {
                new MetrosAPies(),
                new PiesAMetros(),
                new LitrosAGalones(),
                new GalonesALitros()
            };

            while (true)
            {
                Console.WriteLine("Conversor de Unidades");
                for (int i = 0; i < conversores.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. Convertir de {conversores[i].UnidadOrigen} a {conversores[i].UnidadDestino}");
                }
                Console.WriteLine($"{conversores.Length + 1}. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                int indice = int.Parse(opcion) - 1;

                if (indice == conversores.Length)
                {
                    break;
                }

                if (indice < 0 || indice >= conversores.Length)
                {
                    Console.WriteLine("Opción no válida.");
                    continue;
                }

                Console.Write($"Ingrese el número de {conversores[indice].UnidadOrigen}: ");
                double valor = double.Parse(Console.ReadLine());
                double resultado = conversores[indice].Convertir(valor);
                Console.WriteLine($"Resultado: {resultado} {conversores[indice].UnidadDestino}");
                Console.WriteLine();
            }
        }
    }
}
