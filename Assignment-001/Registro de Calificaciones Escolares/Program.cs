using System;

namespace SchoolGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la cantidad de estudiantes: ");
            int cantidadEstudiantes = int.Parse(Console.ReadLine());

            string[] asignaturas = { "Matemáticas", "Ciencias", "Historia" };
            double[,] calificaciones = new double[cantidadEstudiantes, asignaturas.Length];

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                Console.WriteLine($"Ingrese calificaciones para el estudiante {i + 1}:");
                for (int j = 0; j < asignaturas.Length; j++)
                {
                    Console.Write($"Calificación en {asignaturas[j]}: ");
                    calificaciones[i, j] = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nResultados de Calificaciones:");
            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                double suma = 0;
                Console.WriteLine($"\nEstudiante {i + 1}:");
                for (int j = 0; j < asignaturas.Length; j++)
                {
                    Console.WriteLine($"{asignaturas[j]}: {calificaciones[i, j]}");
                    suma += calificaciones[i, j];
                }
                double promedio = suma / asignaturas.Length;
                Console.WriteLine($"Promedio: {promedio:N2}");
            }
        }
    }
}
