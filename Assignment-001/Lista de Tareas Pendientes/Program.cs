using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tasks = new List<string>();
            List<bool> taskStatus = new List<bool>();

            while (true)
            {
                Console.WriteLine("1. Agregar tarea");
                Console.WriteLine("2. Marcar tarea como completada");
                Console.WriteLine("3. Mostrar tareas");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                int option = Convert.ToInt16(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Ingrese el nombre de la tarea: ");
                        string task = Console.ReadLine();
                        tasks.Add(task);
                        taskStatus.Add(false);
                        break;

                    case 2:
                        Console.WriteLine("Lista de tareas pendientes:");
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            if (!taskStatus[i])
                                Console.WriteLine($"{i + 1}. {tasks[i]}");
                        }

                        Console.Write("Seleccione el número de la tarea para marcarla como completada: ");
                        int taskNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (taskNumber >= 0 && taskNumber < tasks.Count)
                        {
                            taskStatus[taskNumber] = true;
                        }
                        break;

                    case 3:
                        Console.WriteLine("Tareas:");
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            string status = taskStatus[i] ? "Completada" : "Pendiente";
                            Console.WriteLine($"{i + 1}. {tasks[i]} - {status}");
                        }
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}