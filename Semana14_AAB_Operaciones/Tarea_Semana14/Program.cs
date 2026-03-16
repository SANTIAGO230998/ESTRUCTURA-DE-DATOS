using System;
using System.IO;
using System.Diagnostics;

// ======================================================
// PROGRAMA PRINCIPAL
// MENÚ INTERACTIVO PARA GESTIONAR EL BST
// ======================================================
using TareaSemana14;

namespace TareaSemana14
{
class Program
{
    // ==========================================
    // ABRIR LA IMAGEN GENERADA
    // ==========================================
    static void OpenImage()
    {
        try
        {
            if (File.Exists("arbol.png"))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "arbol.png",
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
    // LEER UN ENTERO DE FORMA SEGURA
    // Evita que el programa se cierre por errores
    // ==========================================
    static int ReadInt(string message)
    {
        int number;
        bool valid;

        do
        {
            Console.Write(message);
            valid = int.TryParse(Console.ReadLine(), out number);

            if (!valid)
            {
                Console.WriteLine("Entrada inválida. Debe ingresar un número entero.");
            }

        } while (!valid);

        return number;
    }

    // ==========================================
    // MÉTODO PRINCIPAL
    // ==========================================
    static void Main()
    {
        // Creamos el árbol binario de búsqueda
        BinarySearchTree tree = new BinarySearchTree();

        int option;

        do
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("   MENÚ ÁRBOL BINARIO BST");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Insertar valor");
            Console.WriteLine("2. Buscar valor");
            Console.WriteLine("3. Eliminar valor");
            Console.WriteLine("4. Mostrar recorridos");
            Console.WriteLine("5. Mostrar mínimo, máximo y altura");
            Console.WriteLine("6. Limpiar árbol");
            Console.WriteLine("7. Generar y abrir imagen del árbol");
            Console.WriteLine("0. Salir");
            Console.WriteLine("==============================");

            option = ReadInt("Seleccione una opción: ");

            switch (option)
            {
                case 1:
                    {
                        int value = ReadInt("Ingrese el valor a insertar: ");
                        tree.Insert(value);

                        // Actualizamos la imagen del árbol
                        tree.UpdateVisualization();

                        Console.WriteLine("Valor insertado correctamente.");
                        Console.WriteLine("La visualización del árbol fue actualizada.");
                        break;
                    }

                case 2:
                    {
                        int value = ReadInt("Ingrese el valor a buscar: ");

                        if (tree.Search(value))
                            Console.WriteLine("El valor sí existe en el árbol.");
                        else
                            Console.WriteLine("El valor no existe en el árbol.");

                        break;
                    }

                case 3:
                    {
                        int value = ReadInt("Ingrese el valor a eliminar: ");

                        if (tree.Search(value))
                        {
                            tree.Delete(value);

                            // Actualizamos la imagen del árbol
                            tree.UpdateVisualization();

                            Console.WriteLine("Valor eliminado correctamente.");
                            Console.WriteLine("La visualización del árbol fue actualizada.");
                        }
                        else
                        {
                            Console.WriteLine("El valor no existe en el árbol.");
                        }

                        break;
                    }

                case 4:
                    {
                        if (tree.Root == null)
                        {
                            Console.WriteLine("El árbol está vacío.");
                        }
                        else
                        {
                            Console.WriteLine("Recorrido Preorden:");
                            tree.PreOrder(tree.Root);

                            Console.WriteLine("\nRecorrido Inorden:");
                            tree.InOrder(tree.Root);

                            Console.WriteLine("\nRecorrido Postorden:");
                            tree.PostOrder(tree.Root);

                            Console.WriteLine();
                        }

                        break;
                    }

                case 5:
                    {
                        if (tree.Root == null)
                        {
                            Console.WriteLine("El árbol está vacío.");
                        }
                        else
                        {
                            Console.WriteLine("Valor mínimo: " + tree.MinValue(tree.Root));
                            Console.WriteLine("Valor máximo: " + tree.MaxValue(tree.Root));
                            Console.WriteLine("Altura del árbol: " + tree.Height(tree.Root));
                        }

                        break;
                    }

                case 6:
                    {
                        tree.Clear();

                        // Actualizamos la imagen del árbol
                        tree.UpdateVisualization();

                        Console.WriteLine("El árbol fue limpiado completamente.");
                        Console.WriteLine("La visualización del árbol fue actualizada.");
                        break;
                    }

                case 7:
                    {
                        // Generamos la imagen actual y la abrimos
                        tree.UpdateVisualization();
                        OpenImage();

                        Console.WriteLine("Imagen generada: arbol.png");
                        break;
                    }

                case 0:
                    {
                        Console.WriteLine("Programa finalizado.");
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                    }
            }

        } while (option != 0);
    }
}
}