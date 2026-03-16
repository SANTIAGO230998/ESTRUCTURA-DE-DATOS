// ======================================================
// CLASE NODE
// Representa un nodo del Árbol Binario de Búsqueda (BST)
// Cada nodo almacena:
// - Un valor entero
// - Referencia al hijo izquierdo
// - Referencia al hijo derecho
// ======================================================

public class Node
{
    // Valor almacenado en el nodo
    public int Value;

    // Referencia al hijo izquierdo
    public Node Left;

    // Referencia al hijo derecho
    public Node Right;

    // ==========================================
    // CONSTRUCTOR DEL NODO
    // ==========================================
    public Node(int value)
    {
        // Guardamos el valor recibido
        Value = value;

        // Inicialmente el nodo no tiene hijos
        Left = null;
        Right = null;
    }
}
