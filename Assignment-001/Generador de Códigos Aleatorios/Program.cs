using System;
using System.Collections.Generic;

namespace RandomCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> codigosGenerados = new List<string>();
            Random random = new Random();
            int cantidadCodigos = SolicitarCantidadCodigos();

            while (codigosGenerados.Count < cantidadCodigos)
            {
                string nuevoCodigo = GenerarCodigoAleatorio(random, 10); 
                if (!codigosGenerados.Contains(nuevoCodigo))
                {
                    codigosGenerados.Add(nuevoCodigo);
                }
            }

            MostrarCodigos(codigosGenerados);
        }

        static int SolicitarCantidadCodigos()
        {
            Console.Write("Ingrese la cantidad de códigos únicos a generar: ");
            return int.Parse(Console.ReadLine());
        }

        static string GenerarCodigoAleatorio(Random random, int longitud)
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] buffer = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                buffer[i] = caracteres[random.Next(caracteres.Length)];
            }
            return new string(buffer);
        }

        static void MostrarCodigos(List<string> codigos)
        {
            Console.WriteLine("Códigos generados:");
            foreach (string codigo in codigos)
            {
                Console.WriteLine(codigo);
            }
        }
    }
}
