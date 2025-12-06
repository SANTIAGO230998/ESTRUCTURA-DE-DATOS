using System;

public class Rectangulo
{
    // Atributos privados
    private double ancho;
    private double alto;

    // Propiedades públicas para acceder a los atributos
    public double Ancho
    {
        get => ancho;            // Obtener el valor del ancho
        set => ancho = value;    // Asignar un valor al ancho
    }

    public double Alto
    {
        get => alto;             // Obtener el valor del alto
        set => alto = value;     // Asignar un valor al alto
    }

    // Método void para asignar los datos del rectángulo
    public void CrearRectangulo(double _ancho, double _alto)
    {
        ancho = _ancho;
        alto = _alto;
    }

    // Método para calcular el área del rectángulo
    // Fórmula: área = ancho * alto
    public double CalcularArea()
    {
        return ancho * alto;
    }

    // Método para calcular el perímetro
    // Fórmula: perímetro = 2 * (ancho + alto)
    public double CalcularPerimetro()
    {
        return 2 * (ancho + alto);
    }
}
