using System;
using System.Collections.Generic;

namespace ParqueDiversiones
{
    // Clase que gestiona la fila del parque de diversiones
    public class SistemaParque
    {
        // Cola de personas (FIFO)
        private Queue<Persona> fila;

        // Capacidad máxima de la atracción
        private const int CAPACIDAD_MAXIMA = 30;

        // Contador de turnos
        private int contadorTurnos;

        // Constructor
        public SistemaParque()
        {
            fila = new Queue<Persona>();
            contadorTurnos = 1;
        }

        // Método para registrar la llegada de una persona
        public void AgregarPersona(string nombre)
        {
            if (fila.Count < CAPACIDAD_MAXIMA)
            {
                Persona nuevaPersona = new Persona(nombre, contadorTurnos);
                fila.Enqueue(nuevaPersona); // Encolar
                Console.WriteLine("Persona agregada correctamente a la fila.");
                contadorTurnos++;
            }
            else
            {
                Console.WriteLine("La atracción ya está llena. No se pueden agregar más personas.");
            }
        }

        // Método para permitir el ingreso a la atracción
        public void IngresarAtraccion()
        {
            if (fila.Count > 0)
            {
                Persona personaAtendida = fila.Dequeue(); // Desencolar
                Console.WriteLine($"Ingresó a la atracción: {personaAtendida}");
            }
            else
            {
                Console.WriteLine("No hay personas en la fila.");
            }
        }

        // Método para mostrar la fila completa
        public void MostrarFila()
        {
            if (fila.Count > 0)
            {
                Console.WriteLine("\nPersonas en la fila:");
                foreach (Persona persona in fila)
                {
                    Console.WriteLine(persona);
                }
            }
            else
            {
                Console.WriteLine("La fila está vacía.");
            }
        }

        // Método para mostrar los asientos disponibles
        public void MostrarDisponibilidad()
        {
            int disponibles = CAPACIDAD_MAXIMA - fila.Count;
            Console.WriteLine($"Asientos disponibles: {disponibles}");
        }
    }
}
