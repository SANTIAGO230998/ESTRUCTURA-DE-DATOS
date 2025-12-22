using System;
using System.Collections.Generic;

// Clase que gestiona la agenda de turnos de la clínica.
// Utiliza estructuras de datos vistas hasta la semana 4:
// listas (vectores dinámicos), registros y enumeraciones.
public class ClinicaService
{
    // LISTA: almacena los pacientes registrados
    private List<Paciente> pacientes;

    // LISTA: almacena los doctores registrados
    private List<Doctor> doctores;

    // LISTA: almacena los turnos registrados
    private List<Turno> turnos;

    // Contador para generar identificadores únicos de turnos
    private int contadorTurnos;

    // Constructor del servicio
    public ClinicaService()
    {
        pacientes = new List<Paciente>();
        doctores = new List<Doctor>();
        turnos = new List<Turno>();
        contadorTurnos = 1;

        // ================= DATOS INICIALES =================
        // Pacientes de ejemplo
        pacientes.Add(new Paciente("0102030405", "Ana Torres", "0991234567"));
        pacientes.Add(new Paciente("0607080910", "Luis Medina", "0987654321"));

        // Doctores de ejemplo
        doctores.Add(new Doctor("D01", "Juan Pérez", "Cardiología"));
        doctores.Add(new Doctor("D02", "María Gómez", "Pediatría"));
    }

    // ===================== REPORTERÍA =====================

    // Lista todos los pacientes registrados
    public void ListarPacientes()
    {
        Console.WriteLine("\n--- PACIENTES ---");

        foreach (var p in pacientes)
        {
            Console.WriteLine($"Paciente: {p.Nombre} (CI: {p.Cedula})");
            Console.WriteLine($"Teléfono: {p.Telefono}");
            Console.WriteLine();
        }
    }

    // Lista todos los doctores registrados
    public void ListarDoctores()
    {
        Console.WriteLine("\n--- DOCTORES ---");

        foreach (var d in doctores)
        {
            Console.WriteLine($"Doctor: {d.Nombre}");
            Console.WriteLine($"Código: {d.Codigo}");
            Console.WriteLine($"Especialidad: {d.Especialidad}");
            Console.WriteLine();
        }
    }

    // Lista todos los turnos registrados
    public void ListarTurnos()
    {
        Console.WriteLine("\n--- TURNOS ---");

        foreach (var t in turnos)
        {
            Console.WriteLine($"Turno #{t.Id}");
            Console.WriteLine($"Fecha y Hora: {t.Fecha:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Paciente: {t.Paciente.Nombre}");
            Console.WriteLine($"Doctor: {t.Doctor.Nombre} - {t.Doctor.Especialidad}");
            Console.WriteLine($"Estado: {t.Estado}");
            Console.WriteLine();
        }
    }

    // ===================== BÚSQUEDAS =====================

    // Busca un paciente por su cédula
    public Paciente BuscarPaciente(string cedula)
    {
        foreach (var p in pacientes)
        {
            if (p.Cedula == cedula)
                return p;
        }
        return null;
    }

    // Busca un doctor por su código
    public Doctor BuscarDoctor(string codigo)
    {
        foreach (var d in doctores)
        {
            if (d.Codigo == codigo)
                return d;
        }
        return null;
    }

    // Muestra los turnos asociados a un paciente específico
    public void BuscarTurnosPorPaciente(string cedula)
    {
        Console.WriteLine("\n--- TURNOS DEL PACIENTE ---");
        bool encontrado = false;

        foreach (var t in turnos)
        {
            if (t.Paciente.Cedula == cedula)
            {
                Console.WriteLine($"Turno #{t.Id}");
                Console.WriteLine($"Fecha y Hora: {t.Fecha:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"Doctor: {t.Doctor.Nombre} - {t.Doctor.Especialidad}");
                Console.WriteLine($"Estado: {t.Estado}");
                Console.WriteLine();
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron turnos para este paciente.");
        }
    }

    // ===================== OPERACIONES =====================

    // Agrega un nuevo paciente a la lista
    public void AgregarPaciente(string cedula, string nombre, string telefono)
    {
        pacientes.Add(new Paciente(cedula, nombre, telefono));
    }

    // Registra un nuevo turno médico
    public void AgregarTurno(Paciente paciente, Doctor doctor, DateTime fecha)
    {
        Turno nuevoTurno = new Turno(contadorTurnos++, paciente, doctor, fecha);
        turnos.Add(nuevoTurno);
    }

    // Cambia el estado de un turno existente
    public void CambiarEstadoTurno(int idTurno, EstadoTurno nuevoEstado)
    {
        foreach (var t in turnos)
        {
            if (t.Id == idTurno)
            {
                t.Estado = nuevoEstado;
                Console.WriteLine("Estado del turno actualizado correctamente.");
                return;
            }
        }

        Console.WriteLine("Turno no encontrado.");
    }
}
