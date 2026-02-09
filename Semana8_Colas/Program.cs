// Explicación Semana 8 Colas
Queue<string> marcas = new Queue<string>();
marcas.Enqueue("Audi");
marcas.Enqueue("Opel");
marcas.Enqueue("BMW");

foreach(string marca in marcas)
 Console.WriteLine(marca);