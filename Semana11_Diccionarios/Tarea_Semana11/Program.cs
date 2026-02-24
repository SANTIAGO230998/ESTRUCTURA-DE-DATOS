using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        // =====================================================
        // DICCIONARIO
        // =====================================================
        Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            { "tiempo", "time" },
            { "persona", "person" },
            { "año", "year" },
            { "día", "day" },
            { "cosa", "thing" },
            { "hombre", "man" },
            { "mundo", "world" },
            { "vida", "life" },
            { "mano", "hand" },
            { "parte", "part" },
            { "niño", "child" },
            { "ojo", "eye" },
            { "mujer", "woman" },
            { "lugar", "place" },
            { "trabajo", "work" },
            { "semana", "week" },
            { "caso", "case" },
            { "punto", "point" },
            { "gobierno", "government" },
            { "empresa", "company" }
        };

        // =====================================================
        // CREAMOS DICCIONARIO NORMALIZADO PARA BÚSQUEDA
        // =====================================================
        Dictionary<string, string> diccionarioNorm = new Dictionary<string, string>();

        foreach (var item in diccionario)
        {
            // Guardamos la clave normalizada (sin acento)
            diccionarioNorm[Normalizar(item.Key)] = item.Value;
        }

        int opcion;

        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionarioNorm);
                    break;

                case 2:
                    AgregarPalabra(diccionario, diccionarioNorm);
                    break;

                case 0:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }

    // =====================================================
    // TRADUCCIÓN (ESPAÑOL -> INGLÉS)
    // =====================================================
    static void TraducirFrase(Dictionary<string, string> diccionarioNorm)
    {
        Console.Write("\nIngrese la frase en español: ");
        string frase = Console.ReadLine();

        string[] palabras = frase.Split(' ');

        Console.Write("\nTraducción: ");

        foreach (string palabra in palabras)
        {
            // Quitamos puntuación
            string sinPuntuacion = new string(palabra.Where(char.IsLetter).ToArray());

            // Normalizamos (quita acentos)
            string normalizada = Normalizar(sinPuntuacion);

            // Buscamos en diccionario normalizado
            if (diccionarioNorm.ContainsKey(normalizada))
            {
                Console.Write(diccionarioNorm[normalizada] + " ");
            }
            else
            {
                Console.Write(palabra + " ");
            }
        }

        Console.WriteLine();
    }

    // =====================================================
    // NORMALIZAR (QUITAR ACENTOS)
    // =====================================================
    static string Normalizar(string texto)
    {
        string normalized = texto.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();

        foreach (char c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }

        return sb.ToString().Normalize(NormalizationForm.FormC);
    }

    // =====================================================
    // AGREGAR PALABRAS AL DICCIONARIO
    // =====================================================
    static void AgregarPalabra(
        Dictionary<string, string> diccionario,
        Dictionary<string, string> diccionarioNorm)
    {
        Console.Write("\nIngrese la nueva palabra en español: ");
        string espanol = Console.ReadLine().ToLower();

        Console.Write("Ingrese su traducción en inglés: ");
        string ingles = Console.ReadLine().ToLower();

        // Guardamos en diccionario original (con acento si tiene)
        diccionario[espanol] = ingles;

        // También guardamos en diccionario normalizado
        diccionarioNorm[Normalizar(espanol)] = ingles;

        Console.WriteLine("Palabra agregada/actualizada.");
    }
}