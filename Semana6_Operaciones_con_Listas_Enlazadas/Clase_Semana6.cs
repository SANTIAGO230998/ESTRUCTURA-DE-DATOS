using System; // Permite usar Console, WriteLine, etc.

// =======================
// CLASE NODO
// Representa un elemento de la lista
// =======================
public class Nodo
{
    // Dato que almacena el nodo
    public int Data;

    // Referencia al siguiente nodo
    // Puede ser null si es el último
    public Nodo? Next;

    // Constructor del nodo
    // Se ejecuta al crear un nodo nuevo
    public Nodo(int data)
    {
        Data = data;   // Asigna el valor al nodo
        Next = null;   // Por defecto no apunta a nadie
    }
}

// =======================
// CLASE LISTA SIMPLE
// Maneja la lista enlazada
// =======================
public class ListaSimple
{
    // Cabeza de la lista (primer nodo)
    // Es privada para proteger la estructura
    private Nodo? head;

    // Constructor de la lista
    // La lista inicia vacía
    public ListaSimple()
    {
        head = null;
    }

    // -----------------------
    // INSERTAR AL INICIO
    // -----------------------
    public void InsertarInicio(int dato)
    {
        // Crear un nuevo nodo con el dato
        Nodo nuevoNodo = new Nodo(dato);

        // El nuevo nodo apunta al antiguo primero
        nuevoNodo.Next = head;

        // El nuevo nodo ahora es la cabeza
        head = nuevoNodo;
    }

    // -----------------------
    // INSERTAR AL FINAL
    // -----------------------
    public void InsertarFinal(int dato)
    {
        // Crear el nuevo nodo
        Nodo nuevoNodo = new Nodo(dato);

        // Si la lista está vacía
        if (head == null)
        {
            // El nuevo nodo se convierte en la cabeza
            head = nuevoNodo;
        }
        else
        {
            // Nodo auxiliar para recorrer la lista
            Nodo actual = head;

            // Avanza hasta el último nodo
            while (actual.Next != null)
            {
                actual = actual.Next;
            }

            // Enlaza el último nodo con el nuevo
            actual.Next = nuevoNodo;
        }
    }

    // -----------------------
    // ELIMINAR AL INICIO
    // -----------------------
    public void EliminarInicio()
    {
        // Verifica que la lista no esté vacía
        if (head != null)
        {
            // El segundo nodo pasa a ser el primero
            head = head.Next;
        }
    }

    // -----------------------
    // ELIMINAR AL FINAL
    // -----------------------
    public void EliminarFinal()
    {
        // Si la lista no está vacía
        if (head != null)
        {
            // Si solo hay un nodo
            if (head.Next == null)
            {
                // La lista queda vacía
                head = null;
            }
            else
            {
                // Nodo auxiliar para recorrer
                Nodo actual = head;

                // Se detiene en el penúltimo nodo
                while (actual.Next!.Next != null)
                {
                    actual = actual.Next;
                }

                // El penúltimo deja de apuntar al último
                actual.Next = null;
            }
        }
    }

    // -----------------------
    // BUSCAR UN DATO
    // -----------------------
    public Nodo? Buscar(int dato)
    {
        // Nodo auxiliar para recorrer la lista
        Nodo? actual = head;

        // Recorre mientras haya nodos y no se encuentre el dato
        while (actual != null && actual.Data != dato)
        {
            actual = actual.Next;
        }

        // Devuelve el nodo encontrado o null
        return actual;
    }

    // -----------------------
    // DIBUJAR LA LISTA
    // -----------------------
    public void DibujarLista()
    {
        // Nodo auxiliar para recorrer
        Nodo? actual = head;

        // Imprime la cabeza
        Console.Write("head -->");

        // Recorre toda la lista
        while (actual != null)
        {
            // Imprime el nodo actual
            Console.Write(" [ " + actual.Data + " | * ]");

            // Si hay un siguiente nodo, dibuja la flecha
            if (actual.Next != null)
            {
                Console.Write(" -->");
            }

            // Avanza al siguiente nodo
            actual = actual.Next;
        }

        // Fin de la lista
        Console.Write(" --> null");
        Console.WriteLine();
    }
}

// =======================
// PROGRAMA PRINCIPAL
// =======================
class Program
{
    // Punto de entrada del programa
    static void Main(string[] args)
    {
        // Crear la lista enlazada
        ListaSimple lista = new ListaSimple();

        // Insertar elementos al inicio
        lista.InsertarInicio(2);
        lista.InsertarInicio(3);
        lista.InsertarInicio(100);

        // Insertar elementos al final
        lista.InsertarFinal(20);
        lista.InsertarFinal(230);

        // Mostrar la lista en consola
        lista.DibujarLista();

        // Espera una tecla para no cerrar la consola
        Console.ReadKey();
    }
}
