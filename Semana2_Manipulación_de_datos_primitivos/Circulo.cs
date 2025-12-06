using System;

public class Circulo
{
    // Atributo privado que almacena el radio del círculo
    private double radio;

    // Propiedad pública para acceder al radio desde fuera de la clase
    public double Radio
    {
        get => radio;          // Devuelve el valor del radio
        set => radio = value;  // Permite asignar un nuevo valor al radio
    }

    // Método tipo void para asignar el valor del radio
    // No devuelve ningún valor. Solo carga datos dentro del objeto.
    public void CrearCirculo(double _radio)
    {
        radio = _radio;
    }

    // Método que calcula el área del círculo y devuelve un double
    // Fórmula: área = π * radio^2
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // Método que calcula el perímetro del círculo y devuelve un double
    // Fórmula: perímetro = 2 * π * radio
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }
}
