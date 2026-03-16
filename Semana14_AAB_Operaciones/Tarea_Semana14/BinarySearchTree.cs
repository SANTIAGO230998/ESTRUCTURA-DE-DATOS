using System;
using System.IO;
using System.Diagnostics;

// ======================================================
// CLASE BINARY SEARCH TREE (BST)
// Contiene todas las operaciones principales del árbol:
// - Insertar
// - Buscar
// - Eliminar
// - Recorridos
// - Mínimo, máximo y altura
// - Limpiar árbol
// - Generar archivo DOT e imagen con Graphviz
// ======================================================
using Tarea_Semana14;

namespace TareaSemana14
{
public class BinarySearchTree
{
    // Nodo raíz del árbol
    public Node Root;

    // ==========================================
    // INSERTAR UN VALOR EN EL ÁRBOL
    // ==========================================
    public void Insert(int value)
    {
        Root = InsertRec(Root, value);
    }

    // Método recursivo de inserción
    private Node InsertRec(Node node, int value)
    {
        // Si el nodo actual es null, creamos un nuevo nodo
        if (node == null)
        {
            return new Node(value);
        }

        // Si el valor es menor, va al subárbol izquierdo
        if (value < node.Value)
        {
            node.Left = InsertRec(node.Left, value);
        }
        // Si el valor es mayor, va al subárbol derecho
        else if (value > node.Value)
        {
            node.Right = InsertRec(node.Right, value);
        }
        // Si es igual, no insertamos repetidos
        else
        {
            Console.WriteLine("El valor ya existe en el árbol. No se insertan duplicados.");
        }

        return node;
    }

    // ==========================================
    // BUSCAR UN VALOR EN EL ÁRBOL
    // ==========================================
    public bool Search(int value)
    {
        return SearchRec(Root, value);
    }

    private bool SearchRec(Node node, int value)
    {
        // Si llegamos a null, el valor no existe
        if (node == null)
            return false;

        // Si encontramos el valor
        if (node.Value == value)
            return true;

        // Si el valor es menor, buscamos a la izquierda
        if (value < node.Value)
            return SearchRec(node.Left, value);

        // Si es mayor, buscamos a la derecha
        return SearchRec(node.Right, value);
    }

    // ==========================================
    // ELIMINAR UN VALOR DEL ÁRBOL
    // ==========================================
    public void Delete(int value)
    {
        Root = DeleteRec(Root, value);
    }

    private Node DeleteRec(Node node, int value)
    {
        // Si el nodo es null, no hay nada que eliminar
        if (node == null)
            return null;

        // Buscamos el nodo a eliminar
        if (value < node.Value)
        {
            node.Left = DeleteRec(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = DeleteRec(node.Right, value);
        }
        else
        {
            // CASO 1: Nodo sin hijo izquierdo
            if (node.Left == null)
                return node.Right;

            // CASO 2: Nodo sin hijo derecho
            if (node.Right == null)
                return node.Left;

            // CASO 3: Nodo con dos hijos
            // Se reemplaza por el valor mínimo del subárbol derecho
            int minValue = MinValue(node.Right);
            node.Value = minValue;

            // Eliminamos el nodo duplicado del subárbol derecho
            node.Right = DeleteRec(node.Right, minValue);
        }

        return node;
    }

    // ==========================================
    // RECORRIDO INORDEN
    // Izquierda - Raíz - Derecha
    // ==========================================
    public void InOrder(Node node)
    {
        if (node != null)
        {
            InOrder(node.Left);
            Console.Write(node.Value + " ");
            InOrder(node.Right);
        }
    }

    // ==========================================
    // RECORRIDO PREORDEN
    // Raíz - Izquierda - Derecha
    // ==========================================
    public void PreOrder(Node node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
    }

    // ==========================================
    // RECORRIDO POSTORDEN
    // Izquierda - Derecha - Raíz
    // ==========================================
    public void PostOrder(Node node)
    {
        if (node != null)
        {
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write(node.Value + " ");
        }
    }

    // ==========================================
    // OBTENER EL VALOR MÍNIMO DEL ÁRBOL
    // Se busca el nodo más a la izquierda
    // ==========================================
    public int MinValue(Node node)
    {
        if (node == null)
            throw new InvalidOperationException("El árbol está vacío.");

        while (node.Left != null)
        {
            node = node.Left;
        }

        return node.Value;
    }

    // ==========================================
    // OBTENER EL VALOR MÁXIMO DEL ÁRBOL
    // Se busca el nodo más a la derecha
    // ==========================================
    public int MaxValue(Node node)
    {
        if (node == null)
            throw new InvalidOperationException("El árbol está vacío.");

        while (node.Right != null)
        {
            node = node.Right;
        }

        return node.Value;
    }

    // ==========================================
    // CALCULAR LA ALTURA DEL ÁRBOL
    // Si el árbol está vacío, retorna -1
    // ==========================================
    public int Height(Node node)
    {
        if (node == null)
            return -1;

        int leftHeight = Height(node.Left);
        int rightHeight = Height(node.Right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    // ==========================================
    // LIMPIAR COMPLETAMENTE EL ÁRBOL
    // ==========================================
    public void Clear()
    {
        Root = null;
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
}