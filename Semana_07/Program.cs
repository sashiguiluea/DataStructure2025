using System;
// ================================================================
// ARCHIVO: Program.cs (PUNTO DE ENTRADA DEL PROGRAMA)
// ================================================================
// DESCRIPCIÓN: Este archivo contiene el punto de entrada del programa
//              y configura la consola para la visualización de datos.

try // Manejo de excepciones global
{
    // Configurar la consola para mejor visualización
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.Title = "Estructura de Datos - Semana 7: Pilas (Stacks)";

    // Ejecutar el menú principal
    MenuSemana7.Menu7();
}
catch (Exception ex)
{
    // Manejo de errores globales
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"❌ Error crítico en el programa: {ex.Message}");
    Console.ResetColor();
    Console.WriteLine("Presiona cualquier tecla para salir...");
    Console.ReadKey();
}