// Clase que representa un nodo del árbol
public class Node
{
    // Valor que guarda el nodo
    public int Value;

    // Referencia al hijo izquierdo
    public Node Left;

    // Referencia al hijo derecho
    public Node Right;

    // Constructor que recibe el valor del nodo
    public Node(int value)
    {
        Value = value;   // Asignamos el valor
        Left = null;     // Inicialmente no tiene hijo izquierdo
        Right = null;    // Inicialmente no tiene hijo derecho
    }
}