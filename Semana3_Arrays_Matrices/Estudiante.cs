// Clase Estudiante
// Esta clase representa el modelo de un estudiante. 
// Contiene atributos, un constructor y un método para mostrar
// los datos. Aplica los principios básicos de POO
using System;
public class Estudiante
{
    // Propiedades del estudiante
    public int ID { get; set; }                  // Identificador único
    public string Nombres { get; set; }          // Nombres del estudiante
    public string Apellidos { get; set; }        // Apellidos del estudiante
    public string Direccion { get; set; }        // Dirección del estudiante

    // Arreglo para almacenar los 3 números de teléfono
    public string[] Telefonos { get; set; }

    // Constructor: permite inicializar un objeto Estudiante con
    // todos los datos necesarios, incluyendo el arreglo de teléfonos
    public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
    {
        ID = id;
        Nombres = nombres;
        Apellidos = apellidos;
        Direccion = direccion;
        Telefonos = telefonos;  // Se asigna el arreglo recibido
    }

    // Método para mostrar los datos del estudiante en pantalla
    public void MostrarDatos()
    {
        Console.WriteLine($"ID: {ID.ToString("D3")}");
        Console.WriteLine($"Nombres: {Nombres}");
        Console.WriteLine($"Apellidos: {Apellidos}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.WriteLine("Teléfonos:");

        // Recorrer el arreglo de teléfonos usando foreach
        foreach (var tel in Telefonos)
        {
            Console.WriteLine($"- {tel}");
        }
    }
}