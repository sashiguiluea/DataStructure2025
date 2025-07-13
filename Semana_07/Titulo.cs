
// ================================================================
// ARCHIVO: Titulo.cs (CLASE UTILITARIA PARA ENCABEZADO)
// ================================================================
/// <summary>
/// Clase utilitaria para mostrar el encabezado del programa
/// Proporciona métodos para la presentación visual del sistema
/// </summary>
public static class Titulo
{
    /// <summary>
    /// Muestra el arte ASCII del encabezado con colores personalizados
    /// </summary>
    public static void Encabezado()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        string arteAscii = @"
    _____________________  __  ________________  ______  ___       ____  ______   ____  ___  __________  _____
   / ____/ ___/_  __/ __ \/ / / / ____/_  __/ / / / __ \/   |     / __ \/ ____/  / __ \/   |/_  __/ __ \/ ___/
  / __/  \__ \ / / / /_/ / / / / /     / / / / / / /_/ / /| |    / / / / __/    / / / / /| | / / / / / /\__ \ 
 / /___ ___/ // / / _, _/ /_/ / /___  / / / /_/ / _, _/ ___ |   / /_/ / /___   / /_/ / ___ |/ / / /_/ /___/ / 
/_____//____//_/ /_/ |_|\____/\____/ /_/  \____/_/ |_/_/  |_|  /_____/_____/  /_____/_/  |_/_/  \____//____/ 
        ";
        Console.WriteLine(arteAscii);
        Console.ResetColor();
        
        // Información adicional del programa
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(new string('=', 100));
        Console.WriteLine("\t\t\t\tSEMANA 7 - ESTRUCTURA DE DATOS: PILAS (STACKS)");
        Console.WriteLine("\t\t\t\t\tDesarrollado en C# - Ejercicios Prácticos");
        Console.WriteLine(new string('=', 100));
        Console.ResetColor();
        Console.WriteLine();
    }

    /// <summary>
    /// Muestra una línea separadora decorativa
    /// </summary>
    public static void MostrarSeparador()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(new string('-', 80));
        Console.ResetColor();
    }

    /// <summary>
    /// Pausa la ejecución y espera que el usuario presione una tecla
    /// </summary>
    public static void PausarEjecucion()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ResetColor();
        Console.ReadKey();
    }
}
