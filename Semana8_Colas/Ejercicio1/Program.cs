using System;

// ============================================
// CLASE NODO: Representa cada elemento en la cola
// ============================================
public class Nodo
{
    // INFO: Almacena el valor del nodo (dato)
    public int info;
    
    // SGTE: Puntero/referencia al siguiente nodo en la cola
    public Nodo sgte;
}

// ============================================
// CLASE COLA: Implementa la estructura FIFO (First In, First Out)
// ============================================
public class Cola
{
    // PUNTEROS: Controlan el inicio y final de la cola
    private Nodo primero;  // Apunta al primer elemento (frente de la cola)
    private Nodo ultimo;   // Apunta al último elemento (final de la cola)

    // ============================================
    // MÉTODO ENCOLAR: Agrega un elemento al final de la cola
    // ============================================
    public void Encolar(int valor)
    {
        // Paso 1: Crear un nuevo nodo
        Nodo aux = new Nodo();
        aux.info = valor;  // Asignar el valor al nodo
        
        // Paso 2: Verificar si la cola está vacía
        if (primero == null) 
        {
            // CASO: Cola vacía
            // El nuevo nodo será tanto el primero como el último
            primero = ultimo = aux;
            aux.sgte = null;  // No hay siguiente nodo
        }
        else 
        {
            // CASO: Cola con elementos
            // 1. El último actual apunta al nuevo nodo
            ultimo.sgte = aux;
            // 2. El nuevo nodo no apunta a nada (es el último)
            aux.sgte = null;
            // 3. Actualizar puntero "ultimo" al nuevo nodo
            ultimo = aux;
        }
    }

    // ============================================
    // MÉTODO DESENCOLAR: Elimina el primer elemento (sin retornar valor)
    // ============================================
    public void Desencolar() 
    {
        // Verificar si hay elementos en la cola
        if (primero == null)
        {
            // Cola vacía: mostrar mensaje de error
            Console.WriteLine("Cola Vacia");
        }
        else
        {
            // Avanzar el puntero "primero" al siguiente nodo
            // Nota: En C#, el recolector de basura eliminará el nodo desencolado
            primero = primero.sgte;
        }
    }

    // ============================================
    // MÉTODO DESENCOLARVALOR: Elimina y retorna el primer elemento
    // ============================================
    public int DesencolarValor() 
    {
        int valor = 0;  // Variable para almacenar el valor a retornar
        
        if (primero == null)
        {
            // Cola vacía: mostrar mensaje de error
            Console.WriteLine("Cola vacia");
        }
        else
        {
            // Paso 1: Guardar el valor del primer nodo
            valor = primero.info;
            
            // Paso 2: Avanzar el puntero "primero" al siguiente nodo
            primero = primero.sgte;
        }
        
        // Paso 3: Retornar el valor del nodo eliminado
        return valor;
    }

    // ============================================
    // MÉTODO MOSTRAR: Muestra todos los elementos de la cola
    // ============================================
    public void Mostrar()
    {
        // Verificar si la cola está vacía
        if (primero == null)
        {
            Console.WriteLine("Cola vacia");
        }
        else
        {
            // Crear un puntero temporal para recorrer la cola
            Nodo puntero;
            puntero = primero;  // Empezar desde el frente
            
            // Recorrer la cola hasta llegar al final
            do
            {
                // Mostrar el valor del nodo actual
                Console.WriteLine("{0}\t", puntero.info);
                
                // Mover al siguiente nodo
                puntero = puntero.sgte;
            }
            while (puntero != null);  // Continuar hasta que no haya más nodos
        }
        
        // Línea en blanco para mejor formato
        Console.WriteLine("\n");
    }
}

// ============================================
// PROGRAMA PRINCIPAL: Demostración del uso de la cola
// ============================================
class Program
{
    static void Main(string[] args)
    {
        // Paso 1: Crear una instancia de la cola
        Cola objcola = new Cola();
        
        // Paso 2: Encolar 5 elementos
        Console.WriteLine("Colocando 5 elementos en la cola");
        objcola.Encolar(3);
        objcola.Encolar(27);
        objcola.Encolar(5);
        objcola.Encolar(22);
        objcola.Encolar(23);
        
        // Paso 3: Mostrar la cola completa
        objcola.Mostrar();
        
        // Paso 4: Desencolar dos elementos (sin mostrar valores)
        Console.WriteLine("Retirando dos elementos en cola");
        objcola.Desencolar();  // Elimina el 3
        objcola.Mostrar();     // Muestra: 27, 5, 22, 23
        
        objcola.Desencolar();  // Elimina el 27
        objcola.Mostrar();     // Muestra: 5, 22, 23
        
        // Paso 5: Desencolar mostrando el valor eliminado
        Console.WriteLine("Se va a retirar un nodo más, con el valor de {0}", 
                          objcola.DesencolarValor());  // Elimina y muestra el 5
        
        // Paso 6: Mostrar estado final de la cola
        objcola.Mostrar();  // Muestra: 22, 23
        
        // Paso 7: Mantener la consola abierta
        Console.ReadLine();
    }
}