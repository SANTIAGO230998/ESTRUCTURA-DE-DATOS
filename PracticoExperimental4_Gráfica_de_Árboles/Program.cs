using System;
using System.Diagnostics;
using System.IO;

// ======================================================
// ARCHIVO: Program.cs
// DESCRIPCIÓN:
// Programa principal con menú interactivo para:
// - Cargar ejemplos desde bloc de notas
// - Buscar nodos
// - Mostrar recorridos
// - Mostrar reportería
// - Generar y abrir imagen
// - Analizar tiempo de ejecución
// ======================================================

namespace TareaArboles
{
    class Program
    {
        // ==========================================
        // ABRIR LA IMAGEN GENERADA
        // ==========================================
        static void OpenImage(string imagePath = "arbol.png")
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = imagePath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    Console.WriteLine("La imagen todavía no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo abrir la imagen: " + ex.Message);
            }
        }

        // ==========================================
        // LEER TEXTO DE FORMA SEGURA
        // ==========================================
        static string ReadText(string message)
        {
            string text;

            do
            {
                Console.Write(message);
                text = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Entrada inválida. Intente nuevamente.");
                }

            } while (string.IsNullOrWhiteSpace(text));

            return text.Trim();
        }

        // ==========================================
        // CARGAR EJEMPLO DESDE ARCHIVO
        // Y MEDIR EL TIEMPO DE EJECUCIÓN
        // ==========================================
        static void LoadExample(BinaryTree tree, string filePath)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                tree.LoadFromFile(filePath);

                stopwatch.Stop();

                tree.UpdateVisualization();

                Console.WriteLine($"\nÁrbol cargado correctamente desde: {filePath}");
                Console.WriteLine($"Tiempo de ejecución de carga: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");

                tree.ShowReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar el archivo: " + ex.Message);
            }
        }

        // ==========================================
        // MÉTODO PRINCIPAL
        // ==========================================
        static void Main()
        {
            BinaryTree tree = new BinaryTree();
            int option;

            do
            {
                Console.WriteLine("\n=======================================");
                Console.WriteLine("    MENÚ - GRÁFICA DE ÁRBOLES BINARIOS");
                Console.WriteLine("=======================================");
                Console.WriteLine("1. Cargar ejemplo de gerencia");
                Console.WriteLine("2. Cargar ejemplo de familia");
                Console.WriteLine("3. Buscar un elemento");
                Console.WriteLine("4. Mostrar recorridos");
                Console.WriteLine("5. Mostrar reportería completa");
                Console.WriteLine("6. Generar y abrir imagen del árbol");
                Console.WriteLine("7. Limpiar árbol");
                Console.WriteLine("0. Salir");
                Console.WriteLine("=======================================");

                Console.Write("Seleccione una opción: ");
                bool valid = int.TryParse(Console.ReadLine(), out option);

                if (!valid)
                {
                    Console.WriteLine("Debe ingresar un número válido.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        LoadExample(tree, "ejemplo_gerencia.txt");
                        break;

                    case 2:
                        LoadExample(tree, "ejemplo_familia.txt");
                        break;

                    case 3:
                        if (tree.Root == null)
                        {
                            Console.WriteLine("Primero debe cargar un ejemplo.");
                        }
                        else
                        {
                            string value = ReadText("Ingrese el nombre a buscar: ");

                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();

                            bool found = tree.Search(value);

                            stopwatch.Stop();

                            if (found)
                                Console.WriteLine("El elemento sí existe en el árbol.");
                            else
                                Console.WriteLine("El elemento no existe en el árbol.");

                            Console.WriteLine($"Tiempo de ejecución de búsqueda: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
                        }
                        break;

                    case 4:
                        if (tree.Root == null)
                        {
                            Console.WriteLine("El árbol está vacío.");
                        }
                        else
                        {
                            Console.Write("Recorrido Preorden: ");
                            tree.PreOrder(tree.Root);

                            Console.Write("\nRecorrido Inorden: ");
                            tree.InOrder(tree.Root);

                            Console.Write("\nRecorrido Postorden: ");
                            tree.PostOrder(tree.Root);

                            Console.WriteLine();
                        }
                        break;

                    case 5:
                        tree.ShowReport();
                        break;

                    case 6:
                        tree.UpdateVisualization();
                        OpenImage("arbol.png");
                        Console.WriteLine("Imagen generada: arbol.png");
                        break;

                    case 7:
                        tree.Clear();
                        tree.UpdateVisualization();
                        Console.WriteLine("El árbol fue limpiado correctamente.");
                        break;

                    case 0:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (option != 0);
        }
    }
}