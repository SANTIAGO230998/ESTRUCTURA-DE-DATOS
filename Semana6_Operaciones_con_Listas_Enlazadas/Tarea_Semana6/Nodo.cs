// Clase Nodo
// Representa cada elemento de la lista enlazada
public class Nodo
{
    // Dato almacenado en el nodo
    public int Data;

    // Referencia al siguiente nodo de la lista
    public Nodo? Next;

    // Constructor del nodo
    // Inicializa el dato y establece el siguiente nodo como null
    public Nodo(int data)
    {
        Data = data;
        Next = null;
    }
}
