using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Declaramos una pila de números enteros (estructura LIFO)
        Stack<int> pilaEnteros = new Stack<int>();

        // -----------------------------
        // INSERTAR ELEMENTOS EN LA PILA
        // -----------------------------

        // Cada Push() coloca el elemento en la "cima" de la pila
        pilaEnteros.Push(1);
        pilaEnteros.Push(2);
        pilaEnteros.Push(20);
        pilaEnteros.Push(4);

        // -----------------------------
        // RECORRER ELEMENTOS DE LA PILA
        // -----------------------------

        Console.WriteLine("Elementos actuales de la pila:");
        foreach (var item in pilaEnteros)
        {
            // Muestra cada elemento sin eliminarlo de la pila
            Console.WriteLine(item);
        }

        // -----------------------------
        // MOSTRAR ELEMENTO SUPERIOR (PEEK)
        // -----------------------------

        // Peek() permite ver el elemento que está en la cima SIN eliminarlo
        int elementoSuperior = pilaEnteros.Peek();

        Console.WriteLine("Elemento en la cima (Peek): {0}", elementoSuperior);

        // -----------------------------
        // ELIMINAR ELEMENTO (POP)
        // -----------------------------

        // Pop() elimina y devuelve el elemento que está en la cima
        int elementoSacado = pilaEnteros.Pop();

        Console.WriteLine("Se ha sacado el elemento: {0}", elementoSacado);

        // Ahora la pila queda:
        // 20
        // 2
        // 1
    }
}
