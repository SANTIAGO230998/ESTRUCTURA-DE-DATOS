// Ejercicio1
// Escribir un programa que almacene las asignaturas de un curso 
// (por ejemplo Matemáticas, Física, Química, Historia y Lengua) 
// en una lista y la muestre por pantalla.

using System;
using System.Collections.Generic;

// Clase que representa un curso académico
public class Curso
{
    // Lista donde se almacenan las asignaturas del curso
    private List<string> asignaturas;

    // Constructor: inicializa la lista con materias predefinidas
    public Curso()
    {
        asignaturas = new List<string>
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua"
        };
    }

    // Método que muestra las asignaturas por pantalla
    public void MostrarAsignaturas()
    {
        Console.WriteLine("Asignaturas del curso:\n");

        // Recorre la lista y muestra cada materia
        foreach (string materia in asignaturas)
        {
            Console.WriteLine("- " + materia);
        }
    }
}

