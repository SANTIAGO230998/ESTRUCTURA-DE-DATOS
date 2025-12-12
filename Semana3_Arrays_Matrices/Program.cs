// Clase principal Program
// Contiene el método Main(), punto de entrada de la aplicación.
// Aquí se capturan los datos ingresados por el usuario desde
// la consola, se crea un objeto Estudiante y se muestran los datos.
using System;
class Program
{
    static void Main()
    {
        // Solicitar el ID del estudiante
        Console.Write("Ingrese ID: ");
        int id = int.Parse(Console.ReadLine());

        // Solicitar los nombres
        Console.Write("Ingrese nombres: ");
        string nombres = Console.ReadLine();

        // Solicitar los apellidos
        Console.Write("Ingrese apellidos: ");
        string apellidos = Console.ReadLine();

        // Solicitar la dirección
        Console.Write("Ingrese dirección: ");
        string direccion = Console.ReadLine();

        // Declaración del arreglo de teléfonos
        string[] telefonos = new string[3];

        // Ciclo para llenar el arreglo de teléfonos
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Ingrese teléfono {i + 1}: ");
            telefonos[i] = Console.ReadLine();
        }

        // Crear un objeto Estudiante enviando todos los datos
        // al constructor, incluyendo el arreglo de teléfonos
        Estudiante estudiante = new Estudiante(id, nombres, apellidos, direccion, telefonos);

        // Mostrar los datos ingresados
        Console.WriteLine("\n--- Datos Registrados ---");
        estudiante.MostrarDatos();
    }
}

