using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario_VisualStudio2019_FrameWork4._7._2
{
    public class NodoT
    {
        public NodoT NodoIzquierdo;
        public NodoT NodoDerecho;
        public int Informacion
        { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int Opcion = 0;
            NodoT Arbol = null;
            int Dato = 0;
            do
            {
                Opcion = Menu();
                switch (Opcion)
                {
                    case 1:
                        Console.WriteLine("Valor del nuevo nodo");
                        Dato = int.Parse(Console.ReadLine());
                        if (Arbol == null)
                        {
                            NodoT NuevoNodo = new NodoT();
                            NuevoNodo.Informacion = Dato;
                            Arbol = NuevoNodo;
                        }
                        else
                        {
                            Insertar(Arbol, Dato);
                        }
                        Console.Clear();
                        break;
                    case 2:
                        RecorridoPreOrden(Arbol);
                        Console.WriteLine("Fin del recorrido");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        RecorridoPostOrder(Arbol);
                        Console.WriteLine("Fin del recorrido");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        RecorridoInOrder(Arbol);
                        Console.WriteLine("Fin del recorrido");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 5:
                        if (Arbol == null)
                        {
                            Console.WriteLine("Arbol vacio");
                        }
                        else
                        {
                            Console.WriteLine("Introducir elemento a buscar");
                            int valoAbuscar = int.Parse(Console.ReadLine());

                            Buscar(Arbol, valoAbuscar);
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
            }
            while (Opcion != 7);
            Console.ReadKey(true);



        }

        public static int Menu()
        {
            int resultado = 0;
            do
            {
                Console.WriteLine("Menu con Arboles Binarios de Busqueda");
                Console.WriteLine("");
                Console.WriteLine("1 - Registrar un nuevo nodo");
                Console.WriteLine("2 - Recorrido en pre-orden");
                Console.WriteLine("3 - Recorrido en post-orden");
                Console.WriteLine("4 - Recorrido en In-orden");
                Console.WriteLine("5 - Buscar nodo");
                Console.WriteLine("7 - Salir del programa");
                Console.WriteLine("");
                Console.WriteLine("Teclee la opcion deseada");
                resultado = int.Parse(Console.ReadLine());
                if (resultado < 1 || resultado > 7)
                {
                    Console.WriteLine("Opcion Invalida");
                    Console.ReadLine();
                    Console.WriteLine("");
                }
                else
                {

                }


            }
            while (resultado < 1 || resultado > 7);
            return resultado;
        }

        public static void Insertar(NodoT Arbol, int Valor)
        {
            if (Valor < Arbol.Informacion) // buscar lado izquierdo
            {
                if (Arbol.NodoIzquierdo == null)
                {
                    NodoT NuevoNodo = new NodoT();
                    NuevoNodo.Informacion = Valor;
                    Arbol.NodoIzquierdo = NuevoNodo;
                }
                else
                {
                    Insertar(Arbol.NodoIzquierdo, Valor); //llamada recursiva
                }
            }
            else ///buscar del lado derecho
            {
                if (Valor > Arbol.Informacion)
                {
                    if (Arbol.NodoDerecho == null)
                    {
                        NodoT NuevoNodo = new NodoT();
                        NuevoNodo.Informacion = Valor;
                        Arbol.NodoDerecho = NuevoNodo;
                    }
                    else // llamada recursiva
                    {
                        Insertar(Arbol.NodoDerecho, Valor);
                    }
                }
                else
                {
                    Console.WriteLine("Existe el elemento");
                }
            }
        }
        public static void RecorridoPreOrden(NodoT Arbol)
        {
            if (Arbol != null)
            {
                Console.Write(Arbol.Informacion + " ");
                RecorridoPreOrden(Arbol.NodoIzquierdo);
                RecorridoPreOrden(Arbol.NodoDerecho);

            }
        }
        public static void RecorridoPostOrder(NodoT Arbol)
        {
            if (Arbol != null)
            {
                RecorridoPostOrder(Arbol.NodoIzquierdo);
                RecorridoPostOrder(Arbol.NodoDerecho);
                Console.Write(Arbol.Informacion + " ");
            }

        }
        public static void RecorridoInOrder(NodoT Arbol)
        {
            if (Arbol != null)
            {
                RecorridoInOrder(Arbol.NodoIzquierdo);
                Console.Write(Arbol.Informacion + " ");
                RecorridoInOrder(Arbol.NodoDerecho);
            }

        }
        public static void Buscar(NodoT Arbol, int valor)
        {
            if (valor < Arbol.Informacion)
            {
                if (Arbol.NodoIzquierdo == null)
                {
                    Console.WriteLine("No se encontro el nodo");
                    Console.ReadLine();
                }
                else
                {
                    Buscar(Arbol.NodoIzquierdo, valor);
                }
            }
            else
            {
                if (valor > Arbol.Informacion)
                {
                    if (Arbol.NodoDerecho == null)
                    {
                        Console.WriteLine("No se encontr el nodo");
                    }
                    else
                    {
                        Buscar(Arbol.NodoDerecho, valor);
                    }
                }
                else
                {
                    Console.WriteLine("Se encontro el elemento");
                }
            }
        }

        public static void eliminar(NodoT Arbol, int valor)
        {
            if (Arbol != null)
            {
                if (valor < Arbol.Informacion)
                {
                    eliminar(Arbol.NodoIzquierdo, valor);
                }
                else
                {
                    if (valor > Arbol.Informacion)
                    {
                        eliminar(Arbol.NodoDerecho, valor);
                    }

                    else
                    {
                        //Nodo encontrado

                        NodoT NodoEliminar = Arbol;
                        if (Arbol.NodoDerecho == null)
                        {
                            Arbol = NodoEliminar.NodoIzquierdo;
                        }
                        else
                        {
                            if (Arbol.NodoIzquierdo == null)
                            {
                                Arbol = NodoEliminar.NodoDerecho;
                            }
                            else
                            {
                                //tarea
                            }
                        }
                    }
                }
            }
        }


    }
}
