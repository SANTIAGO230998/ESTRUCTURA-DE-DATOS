using System;
using System.Collections.Generic;

// Clase que gestiona una lista de números
public class Numeros
{
    // Lista donde se almacenan los números
    private List<int> listaNumeros;

    // Constructor: llena la lista del 1 al 10
    public Numeros()
    {
        listaNumeros = new List<int>();

        // Agregar números del 1 al 10
        for (int i = 1; i <= 10; i++)
        {
            listaNumeros.Add(i);
        }
    }

    // Método para mostrar los números en orden inverso
    public void MostrarInverso()
    {
        Console.WriteLine("Números del 10 al 1:\n");

        // Creamos otra lista invertida
        listaNumeros.Reverse();

        // Unimos los valores separados por coma
        string resultado = string.Join(", ", listaNumeros);

        Console.WriteLine(resultado);
    }
}
