using System;

// Clase Ejercicio1
//Función que calcule el número de elementos de una lista
// Demuestra el uso del método ContarElementos()
public class Ejercicio1
{
    public static void Ejecutar()
    {
        // Se crea una lista enlazada
        ListaSimple lista = new ListaSimple();

        // Se insertan elementos en la lista
        lista.InsertarFinal(10);
        lista.InsertarFinal(20);
        lista.InsertarFinal(30);

        Console.WriteLine("EJERCICIO 1: CONTAR ELEMENTOS");
        lista.Mostrar();

        // Se muestra la cantidad de elementos
        Console.WriteLine("Cantidad de elementos: " + lista.ContarElementos());
        Console.WriteLine();
    }
}
