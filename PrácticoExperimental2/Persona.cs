using System;

namespace ParqueDiversiones
{
    // Clase que representa a una persona que desea subir a la atracción
    public class Persona
    {
        // Atributos
        public string Nombre { get; set; }
        public int Turno { get; set; }

        // Constructor
        public Persona(string nombre, int turno)
        {
            Nombre = nombre;
            Turno = turno;
        }

        // Método para mostrar la información de la persona
        public override string ToString()
        {
            return $"Turno {Turno} - Nombre: {Nombre}";
        }
    }
}
