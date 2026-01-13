using System;

// Clase Ejercicio2
//Invertir una lista enlazada
// Demuestra el uso del método Invertir()
public class Ejercicio2
{
    public static void Ejecutar()
    {
        // Se crea una lista enlazada
        ListaSimple lista = new ListaSimple();

        // Se insertan elementos
        lista.InsertarFinal(1);
        lista.InsertarFinal(2);
        lista.InsertarFinal(3);
        lista.InsertarFinal(4);

        Console.WriteLine("EJERCICIO 2: INVERTIR LISTA");
        Console.WriteLine("Lista original:");
        lista.Mostrar();

        // Se invierte la lista
        lista.Invertir();

        Console.WriteLine("Lista invertida:");
        lista.Mostrar();
        Console.WriteLine();
    }
}
