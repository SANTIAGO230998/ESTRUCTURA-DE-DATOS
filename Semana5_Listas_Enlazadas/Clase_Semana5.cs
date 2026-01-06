using System;
// Repaso Clase Semana 5 Listas Enlazables
List<string> nombres = new List<string> { "Bernabé", "Ana", "Felipe" };

foreach (var name in nombres)
{
    Console.WriteLine($"Hola {name.ToUpper()}!");
}

// Listas Simples Modificación del Contenido de las Listas
nombres.Add("Maria");
nombres.Add("Billy");
nombres.Remove("Ana");
foreach (var name in nombres)
{
 Console.WriteLine($"Hola {name.ToUpper()}!");
}
Console.WriteLine($"Mi nombre is {nombres[0]}");
Console.WriteLine($"Se agrega a {nombres[2]} y {nombres[3]} a la lista");
Console.WriteLine($"La lista tiene {nombres.Count} personas"); 

// Búsqueda y Orden en las Listas en C#
var index = nombres.IndexOf("Felipe");
if (index == -1)
{
 Console.WriteLine($"Cuando un item no se encuenta, IndexOf retorna {index}");
 }
else
{
 Console.WriteLine($"El nombre {nombres[index]} esta en el índice {index}");
}

index = nombres.IndexOf("Not Found");
if (index == -1)
{
 Console.WriteLine($" Cuando un item no se encuenta, IndexOf retorna {index}");
}
else
{
 Console.WriteLine($"El nombre {nombres[index]} esta en la posición {index}");
}

// Ordenar Elementos Sort
nombres.Sort();
foreach (var name in nombres)
{
 Console.WriteLine($"Saludos {name.ToUpper()}!");
}

// Listas de Otros Tipos Fibonacci
List<int> fibonacciNumeros = [1, 1];
var anterior = fibonacciNumeros[fibonacciNumeros.Count - 1];
var anterior2 = fibonacciNumeros[fibonacciNumeros.Count - 2];
fibonacciNumeros.Add(anterior + anterior2);
foreach (var item in fibonacciNumeros)
{
 Console.WriteLine(item);
}

var fibonacciNumbers = new List<int> { 1, 1 };
while (fibonacciNumbers.Count < 20)
{
    var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
    var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
    fibonacciNumbers.Add(previous + previous2);
}
foreach (var item in fibonacciNumbers)
Console.WriteLine(item);
