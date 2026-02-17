//Juego Básico Usando Conjuntos
// Crear un objeto de la clase Random para generar números aleatorios
Random random = new Random();

// Generar un número aleatorio entre 1 y 9 (el 10 no se incluye)
int numeroSecreto = random.Next(1, 10);

// Variable para guardar el número que ingresa el usuario
int intento = 0;

// Variable booleana para controlar si el número fue adivinado
bool adivinado = false;

// Mostrar mensaje inicial al usuario
Console.WriteLine("Qué número estoy pensando entre 1 y 10.");

// Bucle que se ejecuta mientras el número no haya sido adivinado
while (!adivinado)
{
    // Pedir al usuario que ingrese un número
    Console.Write("¿Qué número es?: ");

    // Leer lo que el usuario escribe y guardarlo como texto
    string entrada = Console.ReadLine();

    // Intentar convertir el texto ingresado a número entero
    // Si la conversión es correcta, guarda el número en la variable 'intento'
    if (int.TryParse(entrada, out intento))
    {
        // Si el número ingresado es menor que el número secreto
        if (intento < numeroSecreto)
        {
            Console.WriteLine("El número secreto es mayor.");
        }
        // Si el número ingresado es mayor que el número secreto
        else if (intento > numeroSecreto)
        {
            Console.WriteLine("El número secreto es menor.");
        }
        // Si no es menor ni mayor, significa que es igual
        else
        {
            // Mostrar mensaje de éxito
            Console.WriteLine($"¡Felicidades! Adivinaste el número {numeroSecreto}.");

            // Cambiar la variable a true para terminar el ciclo
            adivinado = true;
        }
    }
    else
    {
        // Si el usuario no ingresó un número válido
        Console.WriteLine("Por favor, introduce un número válido.");
    }
}
