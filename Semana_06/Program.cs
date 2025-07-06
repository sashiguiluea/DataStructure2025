// ================================================================
// ARCHIVO: Program.cs (PUNTO DE ENTRADA PRINCIPAL)
// ================================================================
using System;
using System.Collections.Generic;

/// <summary>
/// Clase principal del programa con el método Main
/// </summary>
class Program
{
    /// <summary>
    /// Punto de entrada principal del programa
    /// </summary>
    /// <param name="args">Argumentos de línea de comandos</param>
    static void Main(string[] args)
    {
        try
        {
            // Llamar al menú de la MenuSemana 6
            MenuSemana6.menu6();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en la ejecución: {ex.Message}");
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}


