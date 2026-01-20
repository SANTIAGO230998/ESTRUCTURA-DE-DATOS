using System;
using System.Collections.Generic;

class VerificadorParentesis
{
    static void Main()
    {
        // Expresión de entrada
        string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";

        Console.WriteLine("Expresión evaluada:");
        Console.WriteLine(expresion);

        // Llamamos al método que verifica el balanceo
        bool balanceada = VerificarBalanceo(expresion);

        // Mostramos el resultado final
        if (balanceada)
        {
            Console.WriteLine("Resultado: Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Resultado: Fórmula NO balanceada.");
        }
    }

    // Método que verifica si la expresión está balanceada
    static bool VerificarBalanceo(string expresion)
    {
        // Creamos una pila de caracteres
        Stack<char> pila = new Stack<char>();

        // Recorremos la expresión carácter por carácter
        foreach (char c in expresion)
        {
            // Si encontramos un símbolo de apertura, lo apilamos
            if (c == '(' || c == '[' || c == '{')
            {
                pila.Push(c);
            }
            // Si encontramos un símbolo de cierre, se valida con la pila
            else if (c == ')' || c == ']' || c == '}')
            {
                // Si la pila está vacía, hay un cierre sin apertura
                if (pila.Count == 0)
                {
                    return false;
                }

                // Sacamos el último símbolo abierto
                char ultimo = pila.Pop();

                // Verificamos que el cierre corresponda al tipo correcto
                if (!Coinciden(ultimo, c))
                {
                    return false;
                }
            }
        }

        // Si la pila quedó vacía, la expresión está balanceada
        return pila.Count == 0;
    }

    // Método auxiliar para verificar pares correctos
    static bool Coinciden(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '[' && cierre == ']') ||
               (apertura == '{' && cierre == '}');
    }
}
