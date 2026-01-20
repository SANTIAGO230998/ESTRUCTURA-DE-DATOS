using System;

namespace ParqueDiversiones
{
    // Clase principal del programa
    // Contiene el método Main, que es el punto de entrada de la aplicación
    class Program
    {
        // Método principal donde inicia la ejecución del programa
        static void Main(string[] args)
        {
            // Se crea una instancia del sistema del parque de diversiones
            // Esta instancia permitirá acceder a los métodos que gestionan la fila
            SistemaParque sistema = new SistemaParque();

            // Variable para almacenar la opción seleccionada por el usuario
            int opcion;

            // Ciclo do-while que permite mostrar el menú
            // El menú se repite hasta que el usuario seleccione la opción 0 (Salir)
            do
            {
                // Se muestra el menú principal del sistema
                Console.WriteLine("\n=== PARQUE DE DIVERSIONES ===");
                Console.WriteLine("1. Agregar persona a la fila");
                Console.WriteLine("2. Ingresar persona a la atracción");
                Console.WriteLine("3. Mostrar fila");
                Console.WriteLine("4. Mostrar asientos disponibles");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                // Se lee la opción ingresada por el usuario desde la consola
                opcion = int.Parse(Console.ReadLine());

                // Estructura switch para evaluar la opción seleccionada
                switch (opcion)
                {
                    // Opción para agregar una persona a la fila
                    case 1:
                        Console.Write("Ingrese el nombre de la persona: ");
                        string nombre = Console.ReadLine();

                        // Se llama al método que agrega la persona a la cola
                        sistema.AgregarPersona(nombre);
                        break;

                    // Opción para permitir el ingreso de una persona a la atracción
                    case 2:
                        // Se llama al método que atiende a la primera persona de la fila
                        sistema.IngresarAtraccion();
                        break;

                    // Opción para mostrar todas las personas que se encuentran en la fila
                    case 3:
                        sistema.MostrarFila();
                        break;

                    // Opción para mostrar la cantidad de asientos disponibles
                    case 4:
                        sistema.MostrarDisponibilidad();
                        break;

                    // Opción para finalizar la ejecución del programa
                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    // Caso por defecto en caso de que el usuario ingrese una opción inválida
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

            } while (opcion != 0); // El ciclo se repite mientras la opción sea diferente de 0
        }
    }
}
