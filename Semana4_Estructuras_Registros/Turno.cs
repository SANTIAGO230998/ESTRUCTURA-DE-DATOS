using System;

// Clase que representa un turno médico
public class Turno
{
    // Identificador único del turno
    public int Id { get; }

    // Fecha y hora del turno
    public DateTime FechaHora { get; set; }

    // Paciente asociado al turno
    public Paciente Paciente { get; set; }

    // Doctor asignado al turno
    public Doctor Doctor { get; set; }

    // Estado del turno
    public EstadoTurno Estado { get; set; }

    // Motivo de la consulta
    public string Motivo { get; set; }

    // Constructor del turno
    public Turno(int id, DateTime fechaHora, Paciente paciente, Doctor doctor, string motivo)
    {
        Id = id;
        FechaHora = fechaHora;
        Paciente = paciente;
        Doctor = doctor;
        Motivo = motivo;

        // Estado inicial del turno
        Estado = EstadoTurno.Pendiente;
    }

    // Devuelve la información completa del turno
    public override string ToString()
    {
        return $"Turno #{Id}\n" +
               $"Fecha y Hora: {FechaHora:dd/MM/yyyy HH:mm}\n" +
               $"Paciente: {Paciente.Nombre}\n" +
               $"Doctor: {Doctor.Nombre} - {Doctor.Especialidad}\n" +
               $"Motivo: {Motivo}\n" +
               $"Estado: {Estado}";
    }
}
