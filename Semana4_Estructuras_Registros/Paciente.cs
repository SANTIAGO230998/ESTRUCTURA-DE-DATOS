using System;

// Clase que representa a un paciente de la clínica
public class Paciente
{
    // Cédula de identidad del paciente
    public string CI { get; set; }

    // Nombre completo del paciente
    public string Nombre { get; set; }

    // Teléfono del paciente
    public string Telefono { get; set; }

    // Correo electrónico del paciente
    public string Email { get; set; }

    // Constructor de la clase Paciente
    public Paciente(string ci, string nombre, string telefono, string email)
    {
        CI = ci;
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
    }

    // Devuelve una representación legible del paciente
    public override string ToString()
    {
        return $"Paciente: {Nombre} (CI: {CI})\nTeléfono: {Telefono}\nEmail: {Email}";
    }
}
