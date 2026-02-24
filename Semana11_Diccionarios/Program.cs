using System;
using System.Collections.Generic; 

// Diccionarios - Contador de Palabras

class Program
{
    static void Main()
    {
        // Texto que vamos a analizar
        string texto = "Este es un ejemplo de texto Este texto es simple";

        // Diccionario para guardar palabra y cantidad
        Dictionary<string, int> contadorPalabras = new Dictionary<string, int>();

        // Dividimos el texto en palabras usando el espacio
        string[] palabras = texto.Split(' ');

        // Recorremos cada palabra
        foreach (string palabra in palabras)
        {
            // Si la palabra ya existe en el diccionario
            if (contadorPalabras.ContainsKey(palabra))
            {
                // Aumentamos su contador
                contadorPalabras[palabra]++;
            }
            else
            {
                // Si no existe, la agregamos con valor 1
                contadorPalabras[palabra] = 1;
            }
        }

        // Mostramos el resultado
        foreach (var item in contadorPalabras)
        {
            Console.WriteLine(item.Key + " = " + item.Value);
        }
    }
}