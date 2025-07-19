// ================================================================
// ARCHIVO: Titulo.cs (CLASE UTILITARIA PARA ENCABEZADO)
// ================================================================
/// <summary>
/// Clase utilitaria para mostrar el encabezado del programa
/// </summary>
public static class Titulo
{
    /// <summary>
    /// Muestra el arte ASCII del encabezado
    /// </summary>
    public static void encabezado()
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
        Console.WriteLine();
    }
}