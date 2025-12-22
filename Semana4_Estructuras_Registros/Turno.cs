using System;

// Clase que representa un turno médico.
// Relaciona paciente, doctor, fecha y estado.
public class Turno
{
    public int Id { get; set; }
    public Paciente Paciente { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime Fecha { get; set; }
    public EstadoTurno Estado { get; set; }

    // Constructor del turno
    public Turno(int id, Paciente paciente, Doctor doctor, DateTime fecha)
    {
        Id = id;
        Paciente = paciente;
        Doctor = doctor;
        Fecha = fecha;
        Estado = EstadoTurno.Pendiente;
    }
}
