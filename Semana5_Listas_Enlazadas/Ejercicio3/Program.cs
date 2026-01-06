using System;

class Program
{
    static void Main(string[] args)
    {
        // Crear el curso
        Curso curso1 = new Curso();

        // Registrar las notas ingresadas por el usuario
        curso1.RegistrarNotas();

        // Mostrar los resultados
        curso1.MostrarResultados();
    }
}
