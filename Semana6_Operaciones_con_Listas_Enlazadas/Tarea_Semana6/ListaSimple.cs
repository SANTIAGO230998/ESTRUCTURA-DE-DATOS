using System;

// Clase ListaSimple
// Implementa una lista enlazada simple
public class ListaSimple
{
    // Referencia al primer nodo de la lista (cabeza)
    private Nodo? head;

    // Constructor de la lista
    // Inicializa la lista como vacía
    public ListaSimple()
    {
        head = null;
    }

    // Método para insertar un nodo al final de la lista
    public void InsertarFinal(int dato)
    {
        // Se crea un nuevo nodo con el valor recibido
        Nodo nuevoNodo = new Nodo(dato);

        // Si la lista está vacía, el nuevo nodo será la cabeza
        if (head == null)
        {
            head = nuevoNodo;
        }
        else
        {
            // Se recorre la lista hasta llegar al último nodo
            Nodo actual = head;
            while (actual.Next != null)
            {
                actual = actual.Next;
            }

            // Se enlaza el último nodo con el nuevo nodo
            actual.Next = nuevoNodo;
        }
    }

    // Método que muestra los elementos de la lista
    public void Mostrar()
    {
        Nodo? actual = head;
        Console.Write("head -> ");

        // Se recorre la lista desde la cabeza hasta el final
        while (actual != null)
        {
            Console.Write(actual.Data + " -> ");
            actual = actual.Next;
        }

        Console.WriteLine("null");
    }

    // ====================================================
    // EJERCICIO 1:
    // Contar la cantidad de elementos de la lista
    // ====================================================
    public int ContarElementos()
    {
        int contador = 0;
        Nodo? actual = head;

        // Se recorre la lista nodo por nodo
        while (actual != null)
        {
            contador++;
            actual = actual.Next;
        }

        // Se retorna el total de nodos encontrados
        return contador;
    }

    // ====================================================
    // EJERCICIO 2:
    // Invertir los enlaces de la lista enlazada
    // ====================================================
    public void Invertir()
    {
        Nodo? anterior = null;
        Nodo? actual = head;
        Nodo? siguiente;

        // Se recorren los nodos invirtiendo las referencias
        while (actual != null)
        {
            siguiente = actual.Next;   // Se guarda el siguiente nodo
            actual.Next = anterior;    // Se invierte el enlace
            anterior = actual;         // Se avanza el nodo anterior
            actual = siguiente;        // Se avanza al siguiente nodo
        }

        // El último nodo pasa a ser la nueva cabeza
        head = anterior;
    }
}
