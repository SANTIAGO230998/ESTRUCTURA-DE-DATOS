using System;

// Clase principal
class Program
{
    static void Main()
    {
        ClinicaService clinica = new ClinicaService();
        int opcion;

        do
        {
            Console.WriteLine("\n===== MENÚ AGENDA DE TURNOS =====");
            Console.WriteLine("1. Listar pacientes");
            Console.WriteLine("2. Listar doctores");
            Console.WriteLine("3. Listar turnos");
            Console.WriteLine("4. Buscar turnos por paciente");
            Console.WriteLine("5. Agregar turno");
            Console.WriteLine("6. Cambiar estado del turno");
            Console.WriteLine("7. Agregar paciente");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    clinica.ListarPacientes();
                    break;

                case 2:
                    clinica.ListarDoctores();
                    break;

                case 3:
                    clinica.ListarTurnos();
                    break;

                case 4:
                    Console.Write("Cédula del paciente: ");
                    clinica.BuscarTurnosPorPaciente(Console.ReadLine());
                    break;

                case 5:
                    Console.Write("Cédula del paciente: ");
                    string cedula = Console.ReadLine();

                    Console.Write("Código del doctor: ");
                    string codigo = Console.ReadLine();

                    Console.Write("Fecha (dd/mm/yyyy HH:mm): ");
                    DateTime fecha = DateTime.Parse(Console.ReadLine());

                    Paciente p = clinica.BuscarPaciente(cedula);
                    Doctor d = clinica.BuscarDoctor(codigo);

                    if (p != null && d != null)
                        clinica.AgregarTurno(p, d, fecha);
                    else
                        Console.WriteLine("Paciente o doctor no encontrado.");
                    break;

                case 6:
                    Console.Write("ID del turno: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("1 Pendiente  2 Atendido  3 Cancelado");
                    int est = int.Parse(Console.ReadLine());

                    clinica.CambiarEstadoTurno(id, (EstadoTurno)(est - 1));
                    break;

                case 7:
                    Console.Write("Cédula: ");
                    string c = Console.ReadLine();
                    Console.Write("Nombre: ");
                    string n = Console.ReadLine();
                    Console.Write("Teléfono: ");
                    string tlf = Console.ReadLine();

                    clinica.AgregarPaciente(c, n, tlf);
                    Console.WriteLine("Paciente agregado correctamente.");
                    break;

                case 0:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }
}
