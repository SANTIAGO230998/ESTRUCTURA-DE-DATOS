// ======================================================
// CLASE: Node.cs
// DESCRIPCIÓN:
// Esta clase representa un nodo de un árbol binario.
// Cada nodo almacena:
// - Un valor de tipo texto
// - Referencia al hijo izquierdo
// - Referencia al hijo derecho
// ======================================================

namespace TareaArboles
{
    public class Node
    {
        // Valor almacenado en el nodo
        public string Value;

        // Referencia al hijo izquierdo
        public Node Left;

        // Referencia al hijo derecho
        public Node Right;

        // ==========================================
        // CONSTRUCTOR DEL NODO
        // ==========================================
        public Node(string value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}