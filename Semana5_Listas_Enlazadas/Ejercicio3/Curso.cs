using System;
using System.Collections.Generic;

// Clase que representa un curso con asignaturas y notas
public class Curso
{
    // Diccionario: clave = asignatura | valor = nota
    private Dictionary<string, double> notasPorAsignatura;

    // Constructor: inicializa las asignaturas del curso
    public Curso()
    {
        notasPorAsignatura = new Dictionary<string, double>
        {
            { "Matemáticas", 0 },
            { "Física", 0 },
            { "Química", 0 },
            { "Historia", 0 },
            { "Lengua", 0 }
        };
    }

    // Método para pedir al usuario las notas
    public void RegistrarNotas()
    {
        Console.WriteLine("Ingrese la nota obtenida en cada asignatura:\n");

        // Recorremos cada asignatura del diccionario
        List<string> asignaturas = new List<string>(notasPorAsignatura.Keys);

        foreach (string materia in asignaturas)
        {
            Console.Write($"Nota en {materia}: ");

            // Leer la nota ingresada
            double nota = Convert.ToDouble(Console.ReadLine());

            // Guardar la nota en el diccionario
            notasPorAsignatura[materia] = nota;
        }
    }

    // Método para mostrar las notas registradas
    public void MostrarResultados()
    {
        Console.WriteLine("\nResultados del estudiante:\n");

        foreach (var registro in notasPorAsignatura)
        {
            Console.WriteLine($"En {registro.Key} has sacado {registro.Value}");
        }
    }
}
