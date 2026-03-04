using System;

class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();

        int[] valores = { 18, 9, 25, 7, 12, 23, 29, 2, 8, 11, 21, 24, 31 };

        foreach (int v in valores)
        {
            tree.Insert(v);
        }

        // INSERTAR
        int numeroInsertar = 30; // aquí puedes cambiar el número
        Console.WriteLine("Insertando el " + numeroInsertar + "...");
        tree.Insert(numeroInsertar);

        Console.WriteLine("\nRecorrido InOrder del árbol:");
        tree.InOrder(tree.Root);

        Console.WriteLine("\nÁrbol Visual:\n");
        tree.PrintTree();

        // ELIMINAR
        int numeroEliminar = 12; // aquí puedes cambiar el número
        Console.WriteLine("Eliminando " + numeroEliminar + "...");
        tree.Delete(numeroEliminar);

        // BUSCAR
        int numeroBuscar = 12; // aquí se puede cambiar el número
        Node resultado = tree.Search(numeroBuscar);

        if (resultado != null)
            Console.WriteLine("El " + numeroBuscar + " SI existe en el árbol");
        else
            Console.WriteLine("El " + numeroBuscar + " NO existe en el árbol");
    }
}