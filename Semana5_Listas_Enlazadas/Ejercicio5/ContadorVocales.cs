using System;
using System.Collections.Generic;

// Clase que cuenta las vocales de una palabra
public class ContadorVocales
{
    // Diccionario para contar cada vocal
    private Dictionary<char, int> vocales;

    // Constructor: inicializa el contador en 0
    public ContadorVocales()
    {
        vocales = new Dictionary<char, int>
        {
            { 'a', 0 },
            { 'e', 0 },
            { 'i', 0 },
            { 'o', 0 },
            { 'u', 0 }
        };
    }

    // Método que solicita la palabra al usuario
    public void PedirPalabraYContar()
    {
        Console.Write("Ingrese una palabra: ");
        string palabra = Console.ReadLine().ToLower(); // convertir a minúsculas

        // Recorrer cada letra
        foreach (char letra in palabra)
        {
            if (vocales.ContainsKey(letra))
            {
                vocales[letra]++; // incrementar contador
            }
        }
    }

    // Método para mostrar los resultados
    public void MostrarResultado()
    {
        Console.WriteLine("\nCantidad de vocales encontradas:\n");

        foreach (var v in vocales)
        {
            Console.WriteLine($"{v.Key}: {v.Value}");
        }
    }
}