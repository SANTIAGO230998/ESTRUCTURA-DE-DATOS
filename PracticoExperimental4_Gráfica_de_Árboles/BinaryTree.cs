using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

// ======================================================
// CLASE: BinaryTree.cs
// DESCRIPCIÓN:
// Esta clase gestiona el árbol binario.
// Permite:
// - Cargar el árbol desde un archivo de texto
// - Insertar relaciones padre-hijo manualmente
// - Buscar nodos
// - Contar nodos y hojas
// - Calcular altura
// - Mostrar recorridos
// - Mostrar reportería
// - Generar archivo DOT
// - Generar imagen PNG con Graphviz
// ======================================================

namespace TareaArboles
{
    public class BinaryTree
    {
        // Raíz del árbol
        public Node Root;

        // Diccionario auxiliar para acceder a los nodos por nombre
        private Dictionary<string, Node> nodes = new Dictionary<string, Node>();

        // Conjunto auxiliar para identificar qué nodos fueron hijos
        private HashSet<string> childrenNames = new HashSet<string>();

        // ==========================================
        // OBTENER O CREAR UN NODO
        // Si el nodo no existe, se crea
        // ==========================================
        private Node GetOrCreateNode(string value)
        {
            if (!nodes.ContainsKey(value))
            {
                nodes[value] = new Node(value);
            }

            return nodes[value];
        }

        // ==========================================
        // AGREGAR RELACIÓN PADRE - HIJO
        // posición:
        // "L" = hijo izquierdo
        // "R" = hijo derecho
        // ==========================================
        public void AddRelation(string parentValue, string childValue, string position)
        {
            Node parent = GetOrCreateNode(parentValue);
            Node child = GetOrCreateNode(childValue);

            position = position.Trim().ToUpper();

            if (position == "L")
            {
                if (parent.Left != null)
                {
                    Console.WriteLine($"Advertencia: {parentValue} ya tiene hijo izquierdo. Se reemplazará por {childValue}.");
                }

                parent.Left = child;
            }
            else if (position == "R")
            {
                if (parent.Right != null)
                {
                    Console.WriteLine($"Advertencia: {parentValue} ya tiene hijo derecho. Se reemplazará por {childValue}.");
                }

                parent.Right = child;
            }
            else
            {
                Console.WriteLine($"Posición inválida en la relación: {parentValue},{childValue},{position}");
                return;
            }

            // Registramos que childValue es un hijo
            childrenNames.Add(childValue);
        }

        // ==========================================
        // DETERMINAR LA RAÍZ
        // La raíz es el nodo que nunca apareció como hijo
        // ==========================================
        public void DetermineRoot()
        {
            foreach (string nodeName in nodes.Keys)
            {
                if (!childrenNames.Contains(nodeName))
                {
                    Root = nodes[nodeName];
                    return;
                }
            }

            Root = null;
        }

        // ==========================================
        // CARGAR EL ÁRBOL DESDE ARCHIVO
        // Formato esperado por línea:
        // Padre,Hijo,L
        // Padre,Hijo,R
        // ==========================================
        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("No se encontró el archivo: " + filePath);
            }

            Clear();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',');

                if (parts.Length != 3)
                {
                    Console.WriteLine($"Línea inválida ignorada: {line}");
                    continue;
                }

                string parent = parts[0].Trim();
                string child = parts[1].Trim();
                string position = parts[2].Trim();

                AddRelation(parent, child, position);
            }

            DetermineRoot();
        }

        // ==========================================
        // BUSCAR UN NODO POR SU VALOR
        // ==========================================
        public bool Search(string value)
        {
            return SearchRec(Root, value);
        }

        private bool SearchRec(Node node, string value)
        {
            if (node == null)
                return false;

            if (node.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
                return true;

            return SearchRec(node.Left, value) || SearchRec(node.Right, value);
        }

        // ==========================================
        // CONTAR NODOS
        // ==========================================
        public int CountNodes(Node node)
        {
            if (node == null)
                return 0;

            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }

        // ==========================================
        // CONTAR HOJAS
        // Un nodo hoja no tiene hijos
        // ==========================================
        public int CountLeaves(Node node)
        {
            if (node == null)
                return 0;

            if (node.Left == null && node.Right == null)
                return 1;

            return CountLeaves(node.Left) + CountLeaves(node.Right);
        }

        // ==========================================
        // CALCULAR ALTURA DEL ÁRBOL
        // Si está vacío, retorna -1
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
        // MOSTRAR REPORTERÍA COMPLETA
        // ==========================================
        public void ShowReport()
        {
            if (Root == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }

            Console.WriteLine("\n========== REPORTERÍA DEL ÁRBOL ==========");
            Console.WriteLine("Raíz del árbol: " + Root.Value);
            Console.WriteLine("Cantidad total de nodos: " + CountNodes(Root));
            Console.WriteLine("Cantidad de hojas: " + CountLeaves(Root));
            Console.WriteLine("Altura del árbol: " + Height(Root));

            Console.Write("\nRecorrido Preorden: ");
            PreOrder(Root);

            Console.Write("\nRecorrido Inorden: ");
            InOrder(Root);

            Console.Write("\nRecorrido Postorden: ");
            PostOrder(Root);

            Console.WriteLine("\n==========================================");
        }

        // ==========================================
        // LIMPIAR EL ÁRBOL
        // ==========================================
        public void Clear()
        {
            Root = null;
            nodes.Clear();
            childrenNames.Clear();
        }

        // ==========================================
        // GENERAR ARCHIVO .DOT PARA GRAPHVIZ
        // ==========================================
        public void GenerateDotFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("digraph BinaryTree {");
                writer.WriteLine("node [shape=circle, fontname=\"Arial\"];");

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

        // ==========================================
        // MÉTODO RECURSIVO PARA ESCRIBIR NODOS Y CONEXIONES
        // ==========================================
        private void GenerateDotRec(Node node, StreamWriter writer)
        {
            if (node == null)
                return;

            writer.WriteLine($"\"{node.Value}\";");

            if (node.Left != null)
            {
                writer.WriteLine($"\"{node.Value}\" -> \"{node.Left.Value}\" [label=\"L\"];");
                GenerateDotRec(node.Left, writer);
            }

            if (node.Right != null)
            {
                writer.WriteLine($"\"{node.Value}\" -> \"{node.Right.Value}\" [label=\"R\"];");
                GenerateDotRec(node.Right, writer);
            }
        }

        // ==========================================
        // GENERAR IMAGEN PNG USANDO GRAPHVIZ
        // ==========================================
        public void GenerateImage(string dotFile, string pngFile)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();

                // Coloca aquí la ruta real de Graphviz en tu computadora
                startInfo.FileName = @"C:\windows_10_cmake_Release_Graphviz-14.1.3-win64\Graphviz-14.1.3-win64\bin\dot.exe";

                startInfo.Arguments = $"-Tpng \"{dotFile}\" -o \"{pngFile}\"";
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;

                Process process = Process.Start(startInfo);
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar la imagen con Graphviz: " + ex.Message);
                Console.WriteLine("Verifica la ruta de dot.exe.");
            }
        }

        // ==========================================
        // ACTUALIZAR VISUALIZACIÓN
        // Genera nuevamente el archivo .dot y la imagen .png
        // ==========================================
        public void UpdateVisualization(string dotFile = "arbol.dot", string pngFile = "arbol.png")
        {
            GenerateDotFile(dotFile);
            GenerateImage(dotFile, pngFile);
        }
    }
}