
// ================================================================
// ARCHIVO: MenuSemana6.cs (MENÚ PRINCIPAL)
// ================================================================
/// <summary>
/// Clase que maneja el menú principal de la semana 6
/// </summary>
public static class MenuSemana6
{
    /// <summary>
    /// Muestra el menú principal y maneja la selección de ejercicios
    /// </summary>
    public static void menu6()
    {
        bool continuar = true;
        
        while (continuar)
        {
            Titulo.encabezado();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== MENÚ SEMANA 6 - LISTAS ENLAZADAS ===");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1. Ejercicio 4: Lista enlazada con números aleatorios y filtrado");
            Console.WriteLine("2. Ejercicio 7: Sistema de registro de vehículos");
            Console.WriteLine("3. Salir");
            Console.WriteLine();
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                MostrarMensajeError("Por favor, ingrese una opción válida.");
                continue;
            }

            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Nodos.nodos();
                        PausarEjecucion();
                        break;
                    case 2:
                        RegistroVehiculos.registro();
                        PausarEjecucion();
                        break;
                    case 3:
                        continuar = false;
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        MostrarMensajeError("Opción no válida. Por favor, seleccione 1, 2 o 3.");
                        break;
                }
            }
            else
            {
                MostrarMensajeError("Por favor, ingrese un número válido.");
            }
        }
    }

    /// <summary>
    /// Muestra un mensaje de error con formato
    /// </summary>
    /// <param name="mensaje">Mensaje de error a mostrar</param>
    private static void MostrarMensajeError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {mensaje}");
        Console.ResetColor();
        PausarEjecucion();
    }

    /// <summary>
    /// Pausa la ejecución hasta que el usuario presione una tecla
    /// </summary>
    private static void PausarEjecucion()
    {
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
