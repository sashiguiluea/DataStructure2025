// ================================================================
// ARCHIVO: MenuSemana7.cs (MENÚ PRINCIPAL)
// ================================================================

/// <summary>
/// Clase principal que gestiona el menú de opciones para los ejercicios de la Semana 7
/// Proporciona una interfaz de usuario interactiva para acceder a los diferentes ejercicios
/// </summary>
public class MenuSemana7
{
    /// <summary>
    /// Método principal que muestra el menú y gestiona la navegación entre ejercicios
    /// </summary>
    public static void Menu7()
    {
        while (true)
        {
            // Mostrar encabezado del programa
            Titulo.Encabezado();
            
            // Mostrar opciones del menú
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("🎯 MENÚ PRINCIPAL - SELECCIONE UNA OPCIÓN:");
            Console.ResetColor();
            
            Titulo.MostrarSeparador();
            
            Console.WriteLine("1.  Ejercicio 1: Verificación de Paréntesis Balanceados");
            Console.WriteLine("    📝 Verifica si los paréntesis, llaves y corchetes están correctamente balanceados");
            Console.WriteLine();
            
            Console.WriteLine("2.  Ejercicio 2: Torres de Hanoi");
            Console.WriteLine("    🗼 Resuelve el problema clásico de las Torres de Hanoi paso a paso");
            Console.WriteLine();
            
            Console.WriteLine("3.  Salir del programa");
            Console.WriteLine("    👋 Terminar la ejecución del programa");
            
            Titulo.MostrarSeparador();
            Console.WriteLine();
            
            Console.Write("➤ Ingrese su opción (1-3): ");
            string? input = Console.ReadLine();

            // Validar entrada del usuario
            if (string.IsNullOrWhiteSpace(input))
            {
                MostrarError("Entrada vacía. Por favor, ingrese una opción válida.");
                continue;
            }

            // Procesar la opción seleccionada
            if (int.TryParse(input, out int seleccionEjercicio))
            {
                switch (seleccionEjercicio)
                {

                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("🎯 Has seleccionado: Ejercicio 1 - Verificación de Paréntesis Balanceados");
                        Console.ResetColor();
                        Console.WriteLine();
                        
                        BalanceoOperaciones.FormulaBalanceada();
                        Titulo.PausarEjecucion();
                        break;

                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("🎯 Has seleccionado: Ejercicio 2 - Torres de Hanoi");
                        Console.ResetColor();
                        Console.WriteLine();
                        
                        TorresDeHanoi.Resolver();
                        Titulo.PausarEjecucion();
                        break;

                    case 3:
                        MostrarDespedida();
                        return;
                    default:
                        MostrarError("Opción no válida. Por favor, seleccione una opción entre 0 y 2.");
                        break;
                }
            }
            else
            {
                MostrarError("Entrada no válida. Por favor, ingrese un número.");
            }
        }
    }

    /// <summary>
    /// Muestra un mensaje de error con formato consistente
    /// </summary>
    /// <param name="mensaje">Mensaje de error a mostrar</param>
    private static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n❌ Error: {mensaje}");
        Console.ResetColor();
        Titulo.PausarEjecucion();
    }

    /// <summary>
    /// Muestra el mensaje de despedida al salir del programa
    /// </summary>
    private static void MostrarDespedida()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("👋 ¡Gracias por usar el programa!");
        Console.WriteLine("🎓 Esperamos que hayas aprendido sobre el uso de pilas (stacks) en C#.");
        Console.WriteLine("📚 Desarrollado como parte del curso de Estructura de Datos.");
        Console.ResetColor();
        Console.WriteLine("\n🔚 Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}