using System;

// Clase principal del programa
class Program
{
    static void Main()
    {
        // Se crea el servicio de la clínica
        ClinicaService clinica = new ClinicaService();
        bool salir = false;

        // Menú principal
        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Listar pacientes");
            Console.WriteLine("2. Listar doctores");
            Console.WriteLine("3. Listar turnos");
            Console.WriteLine("4. Buscar turnos por paciente");
            Console.WriteLine("5. Agregar turno");
            Console.WriteLine("6. Cambiar estado del turno");
            Console.WriteLine("7. Agregar paciente");
            Console.WriteLine("0. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    clinica.ListarPacientes();
                    break;

                case "2":
                    clinica.ListarDoctores();
                    break;

                case "3":
                    clinica.ListarTurnos();
                    break;

                case "4":
                    Console.Write("CI del paciente: ");
                    clinica.BuscarTurnosPorPaciente(Console.ReadLine());
                    break;

                case "5":
                    Console.Write("Fecha (dd/MM/yyyy HH:mm): ");
                    DateTime fecha = DateTime.Parse(Console.ReadLine());

                    Console.Write("CI del paciente: ");
                    string ci = Console.ReadLine();

                    Console.Write("Matrícula del doctor: ");
                    string matricula = Console.ReadLine();

                    Console.Write("Motivo: ");
                    string motivo = Console.ReadLine();

                    clinica.AgregarTurno(fecha, ci, matricula, motivo);
                    break;

                case "6":
                    Console.Write("ID del turno: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Estado (Pendiente / Atendido / Cancelado): ");
                    Enum.TryParse(Console.ReadLine(), out EstadoTurno estado);

                    clinica.CambiarEstadoTurno(id, estado);
                    break;

                case "7":
                    Console.Write("CI: ");
                    string nuevoCI = Console.ReadLine();

                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Teléfono: ");
                    string telefono = Console.ReadLine();

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    clinica.AgregarPaciente(new Paciente(nuevoCI, nombre, telefono, email));
                    break;

                case "0":
                    salir = true;
                    Console.WriteLine("Gracias por usar el sistema.");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
