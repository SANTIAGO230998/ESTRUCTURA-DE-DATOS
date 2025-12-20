using System;
using System.Collections.Generic;
using System.Linq;

// Clase que gestiona la lógica del sistema de la clínica
public class ClinicaService
{
    // Listas que almacenan los datos del sistema
    private List<Paciente> pacientes;
    private List<Doctor> doctores;
    private List<Turno> turnos;

    // Contador para generar IDs de turnos
    private int proximoIdTurno;

    // Constructor del servicio
    public ClinicaService()
    {
        pacientes = new List<Paciente>();
        doctores = new List<Doctor>();
        turnos = new List<Turno>();
        proximoIdTurno = 1;

        // Carga de datos iniciales
        CargarDatosEjemplo();
    }

    // Carga datos de ejemplo para pruebas
    private void CargarDatosEjemplo()
    {
        doctores.Add(new Doctor("D001", "Juan Pérez", "Cardiología"));
        doctores.Add(new Doctor("D002", "María Gómez", "Pediatría"));

        pacientes.Add(new Paciente("0102030405", "Ana Torres", "0991234567", "ana@mail.com"));
        pacientes.Add(new Paciente("0607080910", "Luis Medina", "0987654321", "luis@mail.com"));
    }

    // Agrega un nuevo paciente
    public void AgregarPaciente(Paciente paciente)
    {
        if (pacientes.Any(p => p.CI == paciente.CI))
        {
            Console.WriteLine("Ya existe un paciente con ese CI.");
            return;
        }

        pacientes.Add(paciente);
        Console.WriteLine("Paciente agregado correctamente.");
    }

    // Muestra todos los pacientes
    public void ListarPacientes()
    {
        Console.WriteLine("\n--- PACIENTES ---");
        foreach (var p in pacientes)
        {
            Console.WriteLine(p);
            Console.WriteLine();
        }
    }

    // Muestra todos los doctores
    public void ListarDoctores()
    {
        Console.WriteLine("\n--- DOCTORES ---");
        foreach (var d in doctores)
        {
            Console.WriteLine(d);
        }
    }

    // Agrega un nuevo turno médico
    public void AgregarTurno(DateTime fechaHora, string ciPaciente, string matriculaDoctor, string motivo)
    {
        var paciente = pacientes.FirstOrDefault(p => p.CI == ciPaciente);
        var doctor = doctores.FirstOrDefault(d => d.Matricula == matriculaDoctor);

        if (paciente == null || doctor == null)
        {
            Console.WriteLine("Paciente o doctor no encontrado.");
            return;
        }

        bool ocupado = turnos.Any(t =>
            t.Doctor.Matricula == matriculaDoctor &&
            t.FechaHora == fechaHora &&
            t.Estado != EstadoTurno.Cancelado);

        if (ocupado)
        {
            Console.WriteLine("El doctor ya tiene un turno en ese horario.");
            return;
        }

        var turno = new Turno(proximoIdTurno++, fechaHora, paciente, doctor, motivo);
        turnos.Add(turno);

        Console.WriteLine("Turno registrado exitosamente.");
    }

    // Lista todos los turnos
    public void ListarTurnos()
    {
        Console.WriteLine("\n--- TURNOS ---");
        foreach (var t in turnos.OrderBy(t => t.FechaHora))
        {
            Console.WriteLine(t);
            Console.WriteLine();
        }
    }

    // Busca turnos por CI del paciente
    public void BuscarTurnosPorPaciente(string ci)
    {
        var lista = turnos.Where(t => t.Paciente.CI == ci).ToList();

        if (!lista.Any())
        {
            Console.WriteLine("No se encontraron turnos.");
            return;
        }

        foreach (var t in lista)
        {
            Console.WriteLine(t);
            Console.WriteLine();
        }
    }

    // Cambia el estado de un turno
    public void CambiarEstadoTurno(int id, EstadoTurno nuevoEstado)
    {
        var turno = turnos.FirstOrDefault(t => t.Id == id);

        if (turno == null)
        {
            Console.WriteLine("Turno no encontrado.");
            return;
        }

        turno.Estado = nuevoEstado;
        Console.WriteLine("Estado del turno actualizado.");
    }
}
