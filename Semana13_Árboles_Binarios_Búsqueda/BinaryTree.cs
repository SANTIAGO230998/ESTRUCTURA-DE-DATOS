using System.IO;
using System.Diagnostics;
// Clase que representa el Árbol Binario de Búsqueda (BST)
public class BinaryTree
{
    // Raíz del árbol (primer nodo)
    public Node Root;

    // ==========================================
    // MÉTODO PÚBLICO PARA INSERTAR UN VALOR
    // ==========================================
    public void Insert(int value)
    {
        // Si el árbol está vacío
        if (Root == null)
        {
            // El nuevo nodo se convierte en la raíz
            Root = new Node(value);
        }
        else
        {
            // Si ya existe raíz, llamamos al método recursivo
            InsertRec(Root, value);
        }
    }

    // ==========================================
    // MÉTODO PRIVADO RECURSIVO DE INSERCIÓN
    // ==========================================
    private void InsertRec(Node root, int value)
    {
        // CASO 1: Si el valor es menor que el nodo actual
        // Se debe insertar en el subárbol izquierdo
        if (value < root.Value)
        {
            // Si no existe hijo izquierdo
            if (root.Left == null)
            {
                // Creamos el nuevo nodo en la izquierda
                root.Left = new Node(value);
            }
            else
            {
                // Si ya existe hijo izquierdo,
                // volvemos a llamar al método pero bajando un nivel
                InsertRec(root.Left, value);
            }
        }
        else // CASO 2: Si el valor es mayor o igual
        {
            // Se debe insertar en el subárbol derecho

            // Si no existe hijo derecho
            if (root.Right == null)
            {
                // Creamos el nuevo nodo en la derecha
                root.Right = new Node(value);
            }
            else
            {
                // Si ya existe hijo derecho,
                // seguimos bajando recursivamente
                InsertRec(root.Right, value);
            }
        }
    }

    // ==========================================
    // RECORRIDO INORDER (Izquierda - Raíz - Derecha)
    // Sirve para mostrar los valores ordenados
    // ==========================================
    public void InOrder(Node root)
    {
        // Si el nodo actual no es nulo
        if (root != null)
        {
            // 1️⃣ Recorremos el subárbol izquierdo
            InOrder(root.Left);

            // 2️⃣ Mostramos el valor del nodo actual
            System.Console.Write(root.Value + " ");

            // 3️⃣ Recorremos el subárbol derecho
            InOrder(root.Right);
        }
    } 

    // ==========================================
    // MÉTODO PÚBLICO PARA ELIMINAR UN VALOR
    // ==========================================
    public void Delete(int key)
    {
        // Llamamos al método recursivo y actualizamos la raíz
        Root = DeleteRec(Root, key);
    }

    // ==========================================
    // MÉTODO PRIVADO RECURSIVO DE ELIMINACIÓN
    // ==========================================
    private Node DeleteRec(Node root, int key)
    {
        // Caso base: si el árbol está vacío
        if (root == null)
            return root;

        // Si el valor a eliminar es menor,
        // buscamos en el subárbol izquierdo
        if (key < root.Value)
        {
            root.Left = DeleteRec(root.Left, key);
        }

        // Si el valor es mayor,
        // buscamos en el subárbol derecho
        else if (key > root.Value)
        {
            root.Right = DeleteRec(root.Right, key);
        }

        // Si encontramos el nodo a eliminar
        else
        {
            // CASO 1: No tiene hijo izquierdo
            if (root.Left == null)
                return root.Right;

            // CASO 2: No tiene hijo derecho
            else if (root.Right == null)
                return root.Left;

            // CASO 3: Tiene dos hijos
            // Buscamos el menor valor del subárbol derecho
            root.Value = MinValue(root.Right);

            // Eliminamos el nodo duplicado del lado derecho
            root.Right = DeleteRec(root.Right, root.Value);
        }

        return root;
    }


    // ==========================================
    // MÉTODO PARA OBTENER EL MENOR VALOR
    // ==========================================
    public int MinValue(Node root)
    {
        // Empezamos desde el nodo recibido
        int minValue = root.Value;

        // Mientras exista hijo izquierdo,
        // seguimos bajando
        while (root.Left != null)
        {
            minValue = root.Left.Value;
            root = root.Left;
        }

        // El último nodo a la izquierda es el menor
        return minValue;
    }

    // ==========================================
    // MÉTODO PARA OBTENER EL MÁXIMO
    // En un BST el valor máximo siempre está
    // en el nodo más a la derecha
    // ==========================================
    public int FindMax()
    {
        // Empezamos desde la raíz
        Node current = Root;

        // Mientras exista hijo derecho
        // seguimos avanzando hacia la derecha
        while (current.Right != null)
        {
            current = current.Right;
        }

        // El último nodo a la derecha es el mayor
        return current.Value;
    }

    // =====================================================
    // MÉTODO SEARCH
    // Busca un valor dentro del Árbol Binario de Búsqueda
    // Devuelve el nodo si lo encuentra
    // Devuelve null si no existe
    // =====================================================
    public Node Search(Node root, int key)
    {
        // Si el nodo es null (no existe)
        // O si el valor del nodo actual es igual al que buscamos
        // entonces retornamos ese nodo
        if (root == null || root.Value == key) 
            return root;

        // Si el valor que buscamos es menor que el valor actual
        // debemos buscar en el subárbol izquierdo
        if (key < root.Value) 
            return Search(root.Left, key);

        // Si no es menor, entonces es mayor
        // buscamos en el subárbol derecho
        return Search(root.Right, key);
    }
    // =====================================================
    // MÉTODO SIMPLIFICADO (PARA LLAMAR FÁCIL DESDE MAIN)
    // =====================================================
    public Node Search(int key)
    {
        return Search(Root, key);
    }

    // ==========================================
    // MÉTODO SEARCH ITERATIVO
    // Busca un valor dentro del árbol SIN usar recursión
    // Utiliza un bucle while para recorrer el árbol
    // ==========================================
    public Node SearchIterative(int key)
    {
        // Empezamos desde la raíz del árbol
        Node current = Root;

        // Mientras el nodo actual no sea null
        while (current != null)
        {
            // Si encontramos el valor buscado
            if (key == current.Value)
                return current;

            // Si el valor buscado es menor
            // debemos ir hacia el hijo izquierdo
            if (key < current.Value)
                current = current.Left;
            else
            {
                // Si el valor es mayor
                // debemos ir hacia el hijo derecho
                current = current.Right;
            }
        }

        // Si terminamos el recorrido y no lo encontramos
        return null;
    }
    
    // ==========================================
    // MÉTODO PARA IMPRIMIR EL ÁRBOL VISUALMENTE
    // ==========================================
    public void PrintTree()
    {
        PrintTreeRec(Root, "", true);
    }

    // Método recursivo auxiliar
    private void PrintTreeRec(Node node, string indent, bool last)
    {
        // Si el nodo no es nulo
        if (node != null)
        {
            // Imprime la indentación acumulada
            Console.Write(indent);

            // Si es el último hijo
            if (last)
            {
                Console.Write("└── ");
                indent += "    ";
            }
            else
            {
                Console.Write("├── ");
                indent += "|   ";
            }

            // Imprime el valor del nodo
            Console.WriteLine(node.Value);

            // Primero imprime el hijo derecho
            PrintTreeRec(node.Right, indent, false);

            // Luego imprime el hijo izquierdo
            PrintTreeRec(node.Left, indent, true);
        }
    }

    // ==========================================
    // MÉTODO PARA GENERAR ARCHIVO .DOT
    // (Formato que usa Graphviz)
    // ==========================================
    public void GenerateDotFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("digraph BST {");
            writer.WriteLine("node [shape=circle];");

            GenerateDotRec(Root, writer);

            writer.WriteLine("}");
        }
    }

    // ==========================================
    // MÉTODO RECURSIVO PARA GENERAR RELACIONES
    // ENTRE NODOS
    // ==========================================
    private void GenerateDotRec(Node node, StreamWriter writer)
    {
        if (node == null)
            return;

        if (node.Left != null)
        {
            writer.WriteLine($"{node.Value} -> {node.Left.Value};");
            GenerateDotRec(node.Left, writer);
        }

        if (node.Right != null)
        {
            writer.WriteLine($"{node.Value} -> {node.Right.Value};");
            GenerateDotRec(node.Right, writer);
        }
    }

    // ==========================================
    // MÉTODO PARA CREAR LA IMAGEN CON GRAPHVIZ
    // ==========================================
    public void GenerateImage()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();

        startInfo.FileName = "C:\\windows_10_cmake_Release_Graphviz-14.1.3-win64\\Graphviz-14.1.3-win64\\bin\\dot.exe";

        startInfo.Arguments = "-Tpng arbol.dot -o arbol.png";

        startInfo.CreateNoWindow = true;
        startInfo.UseShellExecute = false;

        Process.Start(startInfo);
    }
}