using System;

class Program
{
    static void Main(string[] args)
    {
        // -------------------------------
        // Crear y usar un objeto Circulo
        // -------------------------------

        // Crear el objeto vacío
        Circulo c = new Circulo();

        // Cargar datos usando un método void
        c.CrearCirculo(5);

        // Mostrar los resultados
        Console.WriteLine("=== CÍRCULO ===");
        Console.WriteLine("Radio: " + c.Radio);
        Console.WriteLine("Área: " + c.CalcularArea());
        Console.WriteLine("Perímetro: " + c.CalcularPerimetro());
        Console.WriteLine();


        // -------------------------------
        // Crear y usar un objeto Rectángulo
        // -------------------------------

        Rectangulo r = new Rectangulo();

        // Cargar datos
        r.CrearRectangulo(4, 6);

        // Mostrar resultados
        Console.WriteLine("=== RECTÁNGULO ===");
        Console.WriteLine("Ancho: " + r.Ancho);
        Console.WriteLine("Alto: " + r.Alto);
        Console.WriteLine("Área: " + r.CalcularArea());
        Console.WriteLine("Perímetro: " + r.CalcularPerimetro());
        Console.WriteLine();

        // Evitar cierre inmediato de la consola
        Console.WriteLine("Presione una tecla para salir...");
        Console.ReadKey();
    }
}
