// Ejercicio 2
// Escribir un programa que almacene las asignaturas de un curso 
// (por ejemplo Matemáticas, Física, Química, Historia y Lengua) 
// en una lista y la muestre por pantalla el mensaje Yo estudio <asignatura>, 
// donde <asignatura> es cada una de las asignaturas de la lista.

using System;
using System.Collections.Generic;

// Clase que representa un curso
public class Curso
{
    // Lista donde se guardan las asignaturas
    private List<string> asignaturas;

    // Constructor: inicializa la lista
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

    // Método para mostrar el mensaje solicitado
    public void MostrarAsignaturasConMensaje()
    {
        Console.WriteLine("Listado de asignaturas del curso:\n");

        // Recorre la lista asignatura por asignatura
        foreach (string materia in asignaturas)
        {
            // Muestra el mensaje requerido
            Console.WriteLine($"Yo estudio {materia}");
        }
    }
}
