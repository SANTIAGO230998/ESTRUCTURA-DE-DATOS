using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    // Número total de discos
    static int totalDiscos;

    // Pilas que representan las tres torres
    static Stack<int> torreA;
    static Stack<int> torreB;
    static Stack<int> torreC;

    static void Main()
    {
        // Pedimos al usuario que ingrese la cantidad de discos
        Console.Write("Ingrese el número de discos: ");
        totalDiscos = int.Parse(Console.ReadLine());

        // Inicializamos las pilas de las torres
        torreA = new Stack<int>();
        torreB = new Stack<int>();
        torreC = new Stack<int>();

        // Llenamos la torre A con los discos, de mayor a menor
        // Disco más grande = totalDiscos (abajo), disco más pequeño = 1 (arriba)
        for (int i = totalDiscos; i >= 1; i--)
            torreA.Push(i);

        // Mostramos el estado inicial de las torres
        Console.WriteLine("\nEstado inicial de las torres:");
        MostrarTorres();

        // Llamamos a la función recursiva para mover todos los discos
        ResolverHanoi(totalDiscos, torreA, torreC, torreB, "A", "C", "B");

        Console.WriteLine("\nProceso finalizado. Todos los discos están en la torre C.");
    }

    // Función recursiva que resuelve las Torres de Hanoi
    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                              string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        // Caso base: si solo hay un disco, moverlo directamente de origen a destino
        if (n == 1)
        {
            MoverDisco(origen, destino, nombreOrigen, nombreDestino);
            return;
        }

        // Paso 1: mover n-1 discos de origen a auxiliar usando destino
        ResolverHanoi(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

        // Paso 2: mover el disco más grande restante de origen a destino
        MoverDisco(origen, destino, nombreOrigen, nombreDestino);

        // Paso 3: mover los n-1 discos desde auxiliar a destino usando origen
        ResolverHanoi(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
    }

    // Función que mueve un disco de una torre a otra y muestra el estado
    static void MoverDisco(Stack<int> origen, Stack<int> destino, string nombreOrigen, string nombreDestino)
    {
        // Sacamos el disco de la cima de la torre de origen
        int disco = origen.Pop();

        // Lo colocamos en la cima de la torre de destino
        destino.Push(disco);

        // Mostramos el movimiento realizado
        Console.WriteLine($"\nMover disco {disco} de {nombreOrigen} a {nombreDestino}");

        // Mostramos el estado actual de todas las torres
        MostrarTorres();
    }

    // Función que imprime las torres y los discos de forma visual
    static void MostrarTorres()
    {
        // Determinamos la altura máxima entre las torres
        int maxHeight = Math.Max(Math.Max(torreA.Count, torreB.Count), torreC.Count);

        // Recorremos cada nivel de arriba hacia abajo
        for (int i = maxHeight - 1; i >= 0; i--)
        {
            // Para cada torre, obtenemos el disco correspondiente a este nivel
            // Usamos ToArray() para acceder a los discos de la pila en orden de cima a fondo
            string discoA = (i < torreA.Count) ? DibujarDisco(torreA.ToArray()[torreA.Count - 1 - i]) : DibujarDisco(0);
            string discoB = (i < torreB.Count) ? DibujarDisco(torreB.ToArray()[torreB.Count - 1 - i]) : DibujarDisco(0);
            string discoC = (i < torreC.Count) ? DibujarDisco(torreC.ToArray()[torreC.Count - 1 - i]) : DibujarDisco(0);

            // Imprimimos los tres discos del nivel en la misma línea, separados por espacios
            Console.WriteLine($"{discoA}   {discoB}   {discoC}");
        }

        // Línea de separación debajo de los discos
        Console.WriteLine(new string('-', totalDiscos * 2 - 1) + "   " +
                          new string('-', totalDiscos * 2 - 1) + "   " +
                          new string('-', totalDiscos * 2 - 1));

        // Imprimimos los nombres de las torres centrados debajo de cada una
        string espacio = new string(' ', totalDiscos - 1);
        Console.WriteLine($"{espacio}A{espacio}   {espacio}B{espacio}   {espacio}C{espacio}\n");
    }

    // Función que dibuja un disco centrado
    // tamaño = 0 indica que no hay disco en ese nivel
    static string DibujarDisco(int tamaño)
    {
        if (tamaño == 0)
            return new string(' ', totalDiscos * 2 - 1); // Espacio vacío para niveles sin disco

        int espacios = totalDiscos - tamaño;                  // Espacios a cada lado para centrar
        string disco = new string('=', tamaño * 2 - 1);       // Disco formado por "="
        return new string(' ', espacios) + disco + new string(' ', espacios);
    }
}
