using System;

namespace BasicCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Calculadora Básica de Números");
                Console.WriteLine("1. Suma");
                Console.WriteLine("2. Resta");
                Console.WriteLine("3. Multiplicación");
                Console.WriteLine("4. División");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt16(Console.ReadLine());

                if (opcion == 5)
                {
                    break;
                }

                Console.Write("Ingrese el primer número: ");
                double numero1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ingrese el segundo número: ");
                double numero2 = Convert.ToDouble(Console.ReadLine());

                double resultado = 0;
                bool operacionValida = true;

                switch (opcion)
                {
                    case 1:
                        resultado = numero1 + numero2;
                        Console.WriteLine($"Resultado: {numero1} + {numero2} = {resultado}");
                        break;

                    case 2:
                        resultado = numero1 - numero2;
                        Console.WriteLine($"Resultado: {numero1} - {numero2} = {resultado}");
                        break;

                    case 3:
                        resultado = numero1 * numero2;
                        Console.WriteLine($"Resultado: {numero1} * {numero2} = {resultado}");
                        break;

                    case 4:
                        if (numero2 != 0)
                        {
                            resultado = numero1 / numero2;
                            Console.WriteLine($"Resultado: {numero1} / {numero2} = {resultado}");
                        }
                        else
                        {
                            Console.WriteLine("Error: División por cero no permitida.");
                            operacionValida = false;
                        }
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        operacionValida = false;
                        break;
                }

                if (operacionValida)
                {
                    Console.WriteLine("Operación realizada con éxito.");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Gracias por usar la calculadora. ¡Adiós!");
        }
    }
}
