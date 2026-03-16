using System;

class Program
{
    static void Main(string[] args)
    {
        // Creamos el árbol binario
        BinaryTree tree = new BinaryTree();

        // ==========================================
        // ÁRBOL DE EJEMPLO INICIAL
        // ==========================================
        int[] valoresIniciales = { 50, 30, 20, 40, 70, 60, 80 };

        foreach (int v in valoresIniciales)
        {
            tree.Insert(v);
        }
        
        // Generar imagen inicial
        tree.UpdateVisualization();
        Console.WriteLine("✅ Imagen inicial generada: arbol.png");

        int opcion;

        do
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("      MENU ARBOL BINARIO");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Eliminar nodo");
            Console.WriteLine("3. Buscar nodo (recursivo)");
            Console.WriteLine("4. Buscar nodo (iterativo)");
            Console.WriteLine("5. Recorrido InOrder");
            Console.WriteLine("6. Recorrido PreOrder");
            Console.WriteLine("7. Recorrido PostOrder");
            Console.WriteLine("8. Contar nodos");
            Console.WriteLine("9. Contar hojas");
            Console.WriteLine("10. Altura del arbol");
            Console.WriteLine("11. Invertir arbol (Espejo)");
            Console.WriteLine("12. Verificar si es BST");
            Console.WriteLine("13. Imprimir arbol en consola");
            Console.WriteLine("14. Balancear arbol");
            Console.WriteLine("15. Generar imagen PNG");
            Console.WriteLine("16. LIMPIAR árbol (eliminar todo)");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opcion: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                // ==========================================
                // CASO 1: INSERTAR
                // ==========================================
                case 1:
                    Console.Write("Ingrese valor a insertar: ");
                    int insertar = int.Parse(Console.ReadLine());
                    tree.Insert(insertar);
                    tree.UpdateVisualization(); // ← AGREGADO
                    Console.WriteLine("✅ Nodo insertado. Imagen actualizada.");
                    break;

                // ==========================================
                // CASO 2: ELIMINAR
                // ==========================================
                case 2:
                    Console.Write("Ingrese valor a eliminar: ");
                    int eliminar = int.Parse(Console.ReadLine());
                    tree.Delete(eliminar);
                    tree.UpdateVisualization(); // ← AGREGADO
                    Console.WriteLine("✅ Nodo eliminado. Imagen actualizada.");
                    break;

                // ==========================================
                // CASO 3: BUSCAR RECURSIVO
                // ==========================================
                case 3:
                    Console.Write("Ingrese valor a buscar: ");
                    int buscar = int.Parse(Console.ReadLine());

                    var resultado = tree.Search(buscar);

                    if (resultado != null)
                        Console.WriteLine("✅ Nodo encontrado.");
                    else
                        Console.WriteLine("❌ Nodo NO encontrado.");

                    break;

                // ==========================================
                // CASO 4: BUSCAR ITERATIVO
                // ==========================================
                case 4:
                    Console.Write("Ingrese valor a buscar: ");
                    int buscarIter = int.Parse(Console.ReadLine());

                    var resIter = tree.SearchIterative(buscarIter);

                    if (resIter != null)
                        Console.WriteLine("✅ Nodo encontrado.");
                    else
                        Console.WriteLine("❌ Nodo NO encontrado.");

                    break;

                // ==========================================
                // CASO 5: RECORRIDO INORDER
                // ==========================================
                case 5:
                    Console.WriteLine("Recorrido InOrder:");
                    tree.InOrder(tree.Root);
                    Console.WriteLine();
                    break;

                // ==========================================
                // CASO 6: RECORRIDO PREORDER
                // ==========================================
                case 6:
                    Console.WriteLine("Recorrido PreOrder:");
                    tree.PreOrder(tree.Root);
                    Console.WriteLine();
                    break;

                // ==========================================
                // CASO 7: RECORRIDO POSTORDER
                // ==========================================
                case 7:
                    Console.WriteLine("Recorrido PostOrder:");
                    tree.PostOrder(tree.Root);
                    Console.WriteLine();
                    break;

                // ==========================================
                // CASO 8: CONTAR NODOS
                // ==========================================
                case 8:
                    Console.WriteLine("Total nodos: " + tree.CountNodes(tree.Root));
                    break;

                // ==========================================
                // CASO 9: CONTAR HOJAS
                // ==========================================
                case 9:
                    Console.WriteLine("Total hojas: " + tree.CountLeaves(tree.Root));
                    break;

                // ==========================================
                // CASO 10: ALTURA DEL ÁRBOL
                // ==========================================
                case 10:
                    Console.WriteLine("Altura del arbol: " + tree.Height(tree.Root));
                    break;

                // ==========================================
                // CASO 11: INVERTIR ÁRBOL
                // ==========================================
                case 11:
                    tree.Root = tree.InvertTree(tree.Root);
                    tree.UpdateVisualization(); // ← AGREGADO
                    Console.WriteLine("✅ Arbol invertido correctamente. Imagen actualizada.");
                    break;

                // ==========================================
                // CASO 12: VERIFICAR SI ES BST
                // ==========================================
                case 12:
                    bool esBST = tree.IsBST(tree.Root, null, null);

                    if (esBST)
                        Console.WriteLine("✅ El arbol SI es un BST.");
                    else
                        Console.WriteLine("❌ El arbol NO es un BST.");

                    break;

                // ==========================================
                // CASO 13: IMPRIMIR ÁRBOL EN CONSOLA
                // ==========================================
                case 13:
                    Console.WriteLine("\nEstructura del arbol:");
                    tree.PrintTree();
                    break;

                // ==========================================
                // CASO 14: BALANCEAR ÁRBOL
                // ==========================================
                case 14:
                    tree.BalanceTree();
                    tree.UpdateVisualization(); // ← AGREGADO
                    Console.WriteLine("✅ Arbol balanceado correctamente. Imagen actualizada.");
                    break;

                // ==========================================
                // CASO 15: GENERAR IMAGEN PNG
                // ==========================================
                case 15:
                    tree.GenerateDotFile("arbol.dot");
                    tree.GenerateImage();
                    Console.WriteLine("✅ Imagen generada: arbol.png");
                    break;

                // ==========================================
                // CASO 16: LIMPIAR ÁRBOL
                // ==========================================
                case 16:
                    Console.Write("¿Está seguro de limpiar TODO el árbol? (s/n): ");
                    string confirmacion = Console.ReadLine().ToLower();
                    
                    if (confirmacion == "s" || confirmacion == "si")
                    {
                        tree.Clear();
                        tree.UpdateVisualization(); // ← AGREGADO
                        Console.WriteLine("✅ Árbol limpiado completamente. Imagen actualizada.");
                    }
                    else
                    {
                        Console.WriteLine("Operación cancelada.");
                    }
                    break;
                    
                // ==========================================
                // CASO 0: SALIR
                // ==========================================
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                // ==========================================
                // OPCIÓN INVÁLIDA
                // ==========================================
                default:
                    Console.WriteLine("❌ Opcion invalida.");
                    break;
            }

        } while (opcion != 0);
    }
}