using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Llamadas a los ejemplos
        EjemploHashSetBasico();
        Console.WriteLine();

        EjemploHashSetSinDuplicados();
        Console.WriteLine();

        EjemploUnionHashSet();
        Console.WriteLine();

        EjemploInterseccionHashSet();
        Console.WriteLine();

        EjemploDiferenciaHashSet();
        Console.WriteLine();

        EjemploSubconjuntoSuperconjunto();
        Console.WriteLine();

        EjemploDiferenciaSimetricaHashSet();
    }

    // ==============================
    // EJEMPLO 1: HashSet básico
    // ==============================
    static void EjemploHashSetBasico()
    {
        // Inicializa un HashSet de enteros vacío
        HashSet<int> numbers = new HashSet<int>();

        // Agrega elementos al HashSet
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);

        // Elimina un elemento del HashSet
        numbers.Remove(2);

        // Verifica si un elemento existe en el HashSet
        bool containsThree = numbers.Contains(3);

        Console.WriteLine("Ejemplo 1 - HashSet básico");
        Console.WriteLine($"Contiene 3: {containsThree}");
    }

    // ==============================
    // EJEMPLO 2: Eliminación de duplicados con HashSet
    // ==============================
    static void EjemploHashSetSinDuplicados()
    {
        // Crea una lista con elementos duplicados
        List<int> duplicateNumbers = new List<int> { 1, 2, 2, 3, 3, 4 };

        // Inicializa un HashSet con la lista (elimina duplicados automáticamente)
        HashSet<int> uniqueNumbers = new HashSet<int>(duplicateNumbers);

        Console.WriteLine("Ejemplo 2 - HashSet sin duplicados");
        Console.WriteLine("Números únicos:");

        // Recorre el HashSet e imprime cada elemento
        foreach (var number in uniqueNumbers)
        {
            Console.WriteLine(number);
        }
    }

    // ==============================
    // EJEMPLO 3: Unión de HashSet
    // ==============================
    static void EjemploUnionHashSet()
    {
        // Crea el primer HashSet
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };

        // Crea el segundo HashSet
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        // Une set2 en set1, agregando solo elementos que no están ya en set1
        set1.UnionWith(set2);

        Console.WriteLine("Ejemplo 3 - Unión de set1 y set2:");

        // Recorre el HashSet resultante e imprime cada elemento
        foreach (var item in set1)
        {
            Console.WriteLine(item);
        }
    }

    // ==============================
    // EJEMPLO 4: Intersección de HashSet
    // ==============================
    static void EjemploInterseccionHashSet()
    {
        // Crea el primer HashSet
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };

        // Crea el segundo HashSet
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        // Conserva solo los elementos que existen en ambos HashSet
        set1.IntersectWith(set2);

        Console.WriteLine("Ejemplo 4 - Intersección de set1 y set2:");

        // Recorre el HashSet resultante e imprime cada elemento
        foreach (var item in set1)
        {
            Console.WriteLine(item);
        }
    }

    // ==============================
    // EJEMPLO 5: Diferencia de HashSet
    // ==============================
    static void EjemploDiferenciaHashSet()
    {
        // Crea el primer HashSet
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };

        // Crea el segundo HashSet
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        // Elimina de set1 los elementos que también existen en set2
        set1.ExceptWith(set2);

        Console.WriteLine("Ejemplo 5 - Diferencia de set1 y set2:");

        // Recorre el HashSet resultante e imprime cada elemento
        foreach (var item in set1)
        {
            Console.WriteLine(item);
        }
    }

    // ==============================
    // EJEMPLO 6: Subconjunto y Superconjunto
    // ==============================
    static void EjemploSubconjuntoSuperconjunto()
    {
        // Crea el HashSet principal
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };

        // Crea un segundo HashSet más pequeño
        HashSet<int> set2 = new HashSet<int> { 2, 3 };

        // Verifica si set2 es un subconjunto de set1
        bool isSubset = set2.IsSubsetOf(set1);

        // Verifica si set1 es un superconjunto de set2
        bool isSuperset = set1.IsSupersetOf(set2);

        Console.WriteLine("Ejemplo 6 - Subconjunto y Superconjunto");
        Console.WriteLine($"¿set2 es subconjunto de set1?: {isSubset}");
        Console.WriteLine($"¿set1 es superconjunto de set2?: {isSuperset}");
    }

    // ==============================
    // EJEMPLO 7: Diferencia simétrica de HashSet
    // ==============================
    static void EjemploDiferenciaSimetricaHashSet()
    {
        // Crea el primer HashSet
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };

        // Crea el segundo HashSet
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        // Conserva solo los elementos que están en set1 o set2, pero no en ambos
        set1.SymmetricExceptWith(set2);

        Console.WriteLine("Ejemplo 7 - Diferencia simétrica de set1 y set2:");

        // Recorre el HashSet resultante e imprime cada elemento
        foreach (var item in set1)
        {
            Console.WriteLine(item);
        }
    }
}
