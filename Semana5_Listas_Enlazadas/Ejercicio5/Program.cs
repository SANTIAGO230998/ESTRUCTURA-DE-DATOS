using System;

class Program
{
    static void Main(string[] args)
    {
        // Crear objeto
        ContadorVocales contador = new ContadorVocales();

        // Ejecutar métodos
        contador.PedirPalabraYContar();
        contador.MostrarResultado();
    }
}
