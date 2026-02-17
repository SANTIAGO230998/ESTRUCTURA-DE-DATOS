using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        // ==============================
        // 1. CREACIÓN DEL UNIVERSO (U)
        // ==============================
        // Se generan 500 ciudadanos ficticios
        HashSet<string> ciudadanos = new HashSet<string>();

        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add("Ciudadano " + i);
        }

        // Convertimos a lista para poder acceder por índice aleatorio
        List<string> listaCiudadanos = ciudadanos.ToList();

        // ==============================
        // 2. CONJUNTO PFIZER (P)
        // ==============================
        // Se seleccionan 75 ciudadanos aleatorios
        HashSet<string> pfizer = new HashSet<string>();

        while (pfizer.Count < 75)
        {
            int index = random.Next(0, 500);
            pfizer.Add(listaCiudadanos[index]);
        }

        // ==============================
        // 3. CONJUNTO ASTRAZENECA (A)
        // ==============================
        // Se seleccionan 75 ciudadanos aleatorios
        HashSet<string> astraZeneca = new HashSet<string>();

        while (astraZeneca.Count < 75)
        {
            int index = random.Next(0, 500);
            astraZeneca.Add(listaCiudadanos[index]);
        }

        // ==============================
        // 4. OPERACIONES DE CONJUNTOS
        // ==============================

        // Unión: P ∪ A
        HashSet<string> unionVacunados = new HashSet<string>(pfizer);
        unionVacunados.UnionWith(astraZeneca);

        // No vacunados: U - (P ∪ A)
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(unionVacunados);

        // Ambas dosis: P ∩ A
        HashSet<string> ambasDosis = new HashSet<string>(pfizer);
        ambasDosis.IntersectWith(astraZeneca);

        // Solo Pfizer: P - A
        HashSet<string> soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astraZeneca);

        // Solo AstraZeneca: A - P
        HashSet<string> soloAstra = new HashSet<string>(astraZeneca);
        soloAstra.ExceptWith(pfizer);

        // ==============================
        // 5. MOSTRAR RESULTADOS
        // ==============================

        Console.WriteLine("=======================================");
        Console.WriteLine("        REPORTE DE VACUNACIÓN");
        Console.WriteLine("=======================================\n");

        Console.WriteLine("Total ciudadanos (Universo): " + ciudadanos.Count);
        Console.WriteLine("Vacunados con Pfizer: " + pfizer.Count);
        Console.WriteLine("Vacunados con AstraZeneca: " + astraZeneca.Count);
        Console.WriteLine("Ciudadanos con ambas dosis (P ∩ A): " + ambasDosis.Count);
        Console.WriteLine("Ciudadanos solo Pfizer (P - A): " + soloPfizer.Count);
        Console.WriteLine("Ciudadanos solo AstraZeneca (A - P): " + soloAstra.Count);
        Console.WriteLine("Ciudadanos no vacunados (U - (P ∪ A)): " + noVacunados.Count);

        // ==============================
        // 6. LISTADOS
        // ==============================

        Console.WriteLine("\n--- LISTADO VACUNADOS PFIZER ---");
        foreach (var ciudadano in pfizer)
        {
            Console.WriteLine(ciudadano);
        }

        Console.WriteLine("\n--- LISTADO VACUNADOS ASTRAZENECA ---");
        foreach (var ciudadano in astraZeneca)
        {
            Console.WriteLine(ciudadano);
        }

        Console.WriteLine("\n--- LISTADO CON AMBAS DOSIS ---");
        foreach (var ciudadano in ambasDosis)
        {
            Console.WriteLine(ciudadano);
        }

        Console.WriteLine("\n--- LISTADO SOLO PFIZER ---");
        foreach (var ciudadano in soloPfizer)
        {
            Console.WriteLine(ciudadano);
        }

        Console.WriteLine("\n--- LISTADO SOLO ASTRAZENECA ---");
        foreach (var ciudadano in soloAstra)
        {
            Console.WriteLine(ciudadano);
        }

        Console.WriteLine("\n=======================================");
        Console.WriteLine("Proceso finalizado correctamente.");
    }
}
