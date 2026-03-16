using System.IO;                 // Permite trabajar con archivos
using System.Diagnostics;       // Permite ejecutar programas externos
using System.Collections.Generic; // Permite usar listas

// =====================================================
// CLASE QUE REPRESENTA UN ÁRBOL BINARIO DE BÚSQUEDA (BST)
// =====================================================
public class BinaryTree
{
    // Nodo raíz del árbol
    // Desde aquí se conectan todos los demás nodos
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
    // MÉTODO RECURSIVO PARA INSERTAR
    // ==========================================
    private void InsertRec(Node root, int value)
    {
        // Si el valor es menor que el nodo actual
        if (value < root.Value)
        {
            // Si no existe hijo izquierdo
            if (root.Left == null)
            {
                // Creamos un nuevo nodo en la izquierda
                root.Left = new Node(value);
            }
            else
            {
                // Si ya existe hijo izquierdo seguimos bajando
                InsertRec(root.Left, value);
            }
        }
        else
        {
            // Si el valor es mayor o igual

            // Si no existe hijo derecho
            if (root.Right == null)
            {
                // Creamos un nodo en la derecha
                root.Right = new Node(value);
            }
            else
            {
                // Si ya existe hijo derecho seguimos bajando
                InsertRec(root.Right, value);
            }
        }
    }

    // ==========================================
    // RECORRIDO INORDER
    // Izquierda - Raíz - Derecha
    // ==========================================
    public void InOrder(Node root)
    {
        // Si el nodo no es nulo
        if (root != null)
        {
            // Primero recorremos el lado izquierdo
            InOrder(root.Left);

            // Mostramos el valor del nodo actual
            System.Console.Write(root.Value + " ");

            // Finalmente recorremos el lado derecho
            InOrder(root.Right);
        }
    }

    // ==========================================
    // RECORRIDO PREORDER
    // Raíz - Izquierda - Derecha
    // ==========================================
    public void PreOrder(Node root)
    {
        // Si el nodo existe
        if (root != null)
        {
            // Mostramos primero el nodo
            System.Console.Write(root.Value + " ");

            // Luego recorremos el subárbol izquierdo
            PreOrder(root.Left);

            // Finalmente recorremos el subárbol derecho
            PreOrder(root.Right);
        }
    }

    // ==========================================
    // RECORRIDO POSTORDER
    // Izquierda - Derecha - Raíz
    // ==========================================
    public void PostOrder(Node root)
    {
        // Si el nodo existe
        if (root != null)
        {
            // Primero el lado izquierdo
            PostOrder(root.Left);

            // Luego el lado derecho
            PostOrder(root.Right);

            // Finalmente mostramos el nodo
            System.Console.Write(root.Value + " ");
        }
    }

    // ==========================================
    // MÉTODO PARA ELIMINAR UN NODO
    // ==========================================
    public void Delete(int key)
    {
        // Llamamos al método recursivo
        Root = DeleteRec(Root, key);
    }

    private Node DeleteRec(Node root, int key)
    {
        // Si el árbol está vacío
        if (root == null)
            return root;

        // Si el valor es menor buscamos a la izquierda
        if (key < root.Value)
            root.Left = DeleteRec(root.Left, key);

        // Si el valor es mayor buscamos a la derecha
        else if (key > root.Value)
            root.Right = DeleteRec(root.Right, key);

        else
        {
            // Si encontramos el nodo a eliminar

            // Caso 1: no tiene hijo izquierdo
            if (root.Left == null)
                return root.Right;

            // Caso 2: no tiene hijo derecho
            else if (root.Right == null)
                return root.Left;

            // Caso 3: tiene dos hijos

            // Buscamos el menor valor del lado derecho
            root.Value = MinValue(root.Right);

            // Eliminamos el nodo duplicado
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

        // Mientras exista hijo izquierdo
        while (root.Left != null)
        {
            // Avanzamos hacia la izquierda
            minValue = root.Left.Value;
            root = root.Left;
        }

        // Retornamos el menor valor encontrado
        return minValue;
    }

    // ==========================================
    // MÉTODO PARA OBTENER EL MAYOR VALOR
    // ==========================================
    public int FindMax()
    {
        // Comenzamos desde la raíz
        Node current = Root;

        // Mientras exista hijo derecho
        while (current.Right != null)
        {
            // Avanzamos hacia la derecha
            current = current.Right;
        }

        // El último nodo a la derecha es el mayor
        return current.Value;
    }

    // ==========================================
    // BÚSQUEDA RECURSIVA
    // ==========================================
    public Node Search(Node root, int key)
    {
        // Si el nodo es null o encontramos el valor
        if (root == null || root.Value == key)
            return root;

        // Si el valor es menor buscamos a la izquierda
        if (key < root.Value)
            return Search(root.Left, key);

        // Caso contrario buscamos a la derecha
        return Search(root.Right, key);
    }

    public Node Search(int key)
    {
        return Search(Root, key);
    }

    // ==========================================
    // BÚSQUEDA ITERATIVA
    // ==========================================
    public Node SearchIterative(int key)
    {
        // Empezamos desde la raíz
        Node current = Root;

        // Mientras el nodo exista
        while (current != null)
        {
            // Si encontramos el valor
            if (key == current.Value)
                return current;

            // Si el valor es menor vamos a la izquierda
            if (key < current.Value)
                current = current.Left;
            else
                // Si es mayor vamos a la derecha
                current = current.Right;
        }

        // Si no se encontró
        return null;
    }

    // ==========================================
    // CONTAR NODOS
    // ==========================================
    public int CountNodes(Node root)
    {
        // Si el nodo es null
        if (root == null)
            return 0;

        // Contamos nodo actual + izquierdo + derecho
        return 1 + CountNodes(root.Left) + CountNodes(root.Right);
    }

    // ==========================================
    // CONTAR HOJAS
    // ==========================================
    public int CountLeaves(Node root)
    {
        // Si no existe nodo
        if (root == null)
            return 0;

        // Si no tiene hijos es una hoja
        if (root.Left == null && root.Right == null)
            return 1;

        // Sumamos hojas izquierda y derecha
        return CountLeaves(root.Left) + CountLeaves(root.Right);
    }

    // ==========================================
    // ALTURA DEL ÁRBOL
    // ==========================================
    public int Height(Node root)
    {
        // Si no hay nodo
        if (root == null)
            return -1;

        // Calculamos altura izquierda
        int left = Height(root.Left);

        // Calculamos altura derecha
        int right = Height(root.Right);

        // Retornamos la mayor altura + 1
        return System.Math.Max(left, right) + 1;
    }

    // ==========================================
    // INVERTIR ÁRBOL (ESPEJO)
    // ==========================================
    public Node InvertTree(Node root)
    {
        // Si el nodo es null
        if (root == null)
            return null;

        // Guardamos temporalmente el hijo izquierdo
        Node temp = root.Left;

        // Intercambiamos los hijos
        root.Left = root.Right;
        root.Right = temp;

        // Aplicamos el mismo proceso a los subárboles
        InvertTree(root.Left);
        InvertTree(root.Right);

        return root;
    }

    // ==========================================
    // VERIFICAR SI ES BST
    // ==========================================
    public bool IsBST(Node root, int? min, int? max)
    {
        // Si el nodo es null
        if (root == null)
            return true;

        // Verificamos que el valor esté dentro del rango permitido
        if ((min != null && root.Value <= min) ||
            (max != null && root.Value >= max))
            return false;

        // Verificamos recursivamente los subárboles
        return IsBST(root.Left, min, root.Value) &&
               IsBST(root.Right, root.Value, max);
    }

    // ==========================================
    // BALANCEAR EL ÁRBOL
    // ==========================================
    public void BalanceTree()
    {
        // Lista donde guardaremos los valores ordenados
        List<int> nodes = new List<int>();

        // Guardamos los nodos usando recorrido InOrder
        StoreInOrder(Root, nodes);

        // Reconstruimos el árbol balanceado
        Root = BuildBalancedTree(nodes, 0, nodes.Count - 1);
    }
    // ==========================================
    // GUARDAR NODOS EN ORDEN
    // ==========================================
    private void StoreInOrder(Node node, List<int> nodes)
    {
        // Si el nodo es null terminamos
        if (node == null)
            return;

        // Recorrer lado izquierdo
        StoreInOrder(node.Left, nodes);

        // Guardar valor del nodo
        nodes.Add(node.Value);

        // Recorrer lado derecho
        StoreInOrder(node.Right, nodes);
    }
    // ==========================================
    // CONSTRUIR ÁRBOL BALANCEADO
    // ==========================================
    private Node BuildBalancedTree(List<int> nodes, int start, int end)
    {
        // Si el rango es inválido
        if (start > end)
            return null;

        // Elegimos el elemento del medio
        int mid = (start + end) / 2;

        // Creamos el nodo raíz del subárbol
        Node node = new Node(nodes[mid]);

        // Construimos subárbol izquierdo
        node.Left = BuildBalancedTree(nodes, start, mid - 1);

        // Construimos subárbol derecho
        node.Right = BuildBalancedTree(nodes, mid + 1, end);

        return node;
    }

     // ==========================================
     // LIMPIAR COMPLETAMENTE EL ÁRBOL
     // ==========================================
     public void Clear()
     {
        Root = null;
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
    // GENERAR ARCHIVO .DOT PARA GRAPHVIZ
    // ==========================================
    public void GenerateDotFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("digraph BST {");
            writer.WriteLine("node [shape=circle, fontname=\"Arial\"];");

            // Si el árbol está vacío, mostramos un nodo informativo
            if (Root == null)
            {
                writer.WriteLine("empty [label=\"Árbol vacío\"];");
            }
            else
            {
                GenerateDotRec(Root, writer);
            }

            writer.WriteLine("}");
        }
    }

    // Método recursivo para escribir los nodos y conexiones
    private void GenerateDotRec(Node node, StreamWriter writer)
    {
        if (node == null)
            return;

        // Declaramos el nodo actual
        writer.WriteLine($"{node.Value};");

        // Si existe hijo izquierdo, dibujamos la conexión
        if (node.Left != null)
        {
            writer.WriteLine($"{node.Value} -> {node.Left.Value};");
            GenerateDotRec(node.Left, writer);
        }

        // Si existe hijo derecho, dibujamos la conexión
        if (node.Right != null)
        {
            writer.WriteLine($"{node.Value} -> {node.Right.Value};");
            GenerateDotRec(node.Right, writer);
        }
    }

    // ==========================================
    // GENERAR IMAGEN PNG USANDO GRAPHVIZ
    // ==========================================
    public void GenerateImage()
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();

            // RUTA DE dot.exe
            startInfo.FileName = @"C:\windows_10_cmake_Release_Graphviz-14.1.3-win64\Graphviz-14.1.3-win64\bin\dot.exe";

            // Convierte el archivo DOT en imagen PNG
            startInfo.Arguments = "-Tpng arbol.dot -o arbol.png";

            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;

            Process process = Process.Start(startInfo);
            process.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al generar la imagen con Graphviz: " + ex.Message);
            Console.WriteLine("Verifica que Graphviz esté instalado y que la ruta de dot.exe sea correcta.");
        }
    }

    // ==========================================
    // ACTUALIZAR LA VISUALIZACIÓN DEL ÁRBOL
    // Genera nuevamente el DOT y la imagen PNG
    // ==========================================
    public void UpdateVisualization()
    {
        GenerateDotFile("arbol.dot");
        GenerateImage();
    }
}