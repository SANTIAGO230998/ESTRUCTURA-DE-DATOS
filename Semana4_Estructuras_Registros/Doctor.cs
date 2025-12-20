using System;

// Clase que representa a un doctor de la clínica
public class Doctor
{
    // Matrícula profesional del doctor
    public string Matricula { get; set; }

    // Nombre completo del doctor
    public string Nombre { get; set; }

    // Especialidad médica
    public string Especialidad { get; set; }

    // Constructor de la clase Doctor
    public Doctor(string matricula, string nombre, string especialidad)
    {
        Matricula = matricula;
        Nombre = nombre;
        Especialidad = especialidad;
    }

    // Devuelve una representación legible del doctor
    public override string ToString()
    {
        return $"Dr. {Nombre} - {Especialidad} (Matrícula: {Matricula})";
    }
}
