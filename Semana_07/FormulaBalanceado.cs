
// ================================================================
// ARCHIVO: FormulaBalanceado.cs (EJERCICIO 1 - FORMULA BALANCEADA)
// ================================================================

using System;
using System.Collections.Generic;

/// <summary>
/// Clase que implementa la verificación de paréntesis balanceados en expresiones matemáticas
/// Utiliza una pila (Stack) para verificar que los símbolos de apertura y cierre estén correctamente balanceados
/// </summary>
public class BalanceoOperaciones
{
    /// <summary>
    /// Verifica si una expresión matemática tiene los paréntesis, llaves y corchetes balanceados
    /// </summary>
    /// <param name="expresion">La expresión matemática a verificar</param>
    /// <returns>True si está balanceada, False si no lo está</returns>
    public static bool EsBalanceada(string expresion)
    {
        // Validación de entrada
        if (string.IsNullOrEmpty(expresion))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠️  Error: La expresión no puede estar vacía.");
            Console.ResetColor();
            return false;
        }

        // Pila para almacenar los símbolos de apertura
        Stack<char> pila = new Stack<char>();
        
        // Contador para mostrar el progreso del análisis
        int posicion = 0;

        foreach (char caracter in expresion)
        {
            posicion++;
            
            // Si encontramos un símbolo de apertura, lo apilamos
            if (caracter == '(' || caracter == '{' || caracter == '[')
            {
                pila.Push(caracter);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"📍 Posición {posicion}: Encontrado '{caracter}' (apertura) - Apilado");
                Console.ResetColor();
            }
            // Si encontramos un símbolo de cierre, verificamos el balance
            else if (caracter == ')' || caracter == '}' || caracter == ']')
            {
                // Si la pila está vacía, no hay símbolo de apertura correspondiente
                if (pila.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ Posición {posicion}: Encontrado '{caracter}' (cierre) sin apertura correspondiente");
                    Console.ResetColor();
                    return false;
                }

                // Obtenemos el último símbolo de apertura
                char apertura = pila.Pop();
                
                // Verificamos si los símbolos coinciden
                if (!Coinciden(apertura, caracter))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ Posición {posicion}: '{apertura}' no coincide con '{caracter}'");
                    Console.ResetColor();
                    return false;
                }
                
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"✅ Posición {posicion}: '{apertura}' coincide con '{caracter}' - Balanceado");
                Console.ResetColor();
            }
        }

        // Si la pila está vacía, todos los símbolos se balancearon correctamente
        bool resultado = pila.Count == 0;
        
        if (!resultado)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Quedan {pila.Count} símbolo(s) de apertura sin cerrar");
            Console.ResetColor();
        }

        return resultado;
    }

    /// <summary>
    /// Verifica si un símbolo de apertura coincide con su correspondiente símbolo de cierre
    /// </summary>
    /// <param name="apertura">Símbolo de apertura</param>
    /// <param name="cierre">Símbolo de cierre</param>
    /// <returns>True si coinciden, False si no coinciden</returns>
    private static bool Coinciden(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }

    /// <summary>
    /// Método principal que ejecuta el ejercicio de verificación de fórmulas balanceadas
    /// Proporciona una interfaz interactiva para que el usuario ingrese expresiones
    /// </summary>
    public static void FormulaBalanceada()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🔍 EJERCICIO 1: VERIFICACIÓN DE PARÉNTESIS BALANCEADOS");
        Console.WriteLine("=".PadLeft(55, '='));
        Console.ResetColor();
        
        Console.WriteLine("\n📝 Este ejercicio verifica si los paréntesis (), llaves {} y corchetes [] están correctamente balanceados.");
        Console.WriteLine("💡 Ejemplos válidos: {7 + (8 * 5)}, [(1 + 2) * 3], {[()]}");
        Console.WriteLine("❌ Ejemplos inválidos: {7 + (8 * 5], [(1 + 2) * 3), {[()}");
        
        Titulo.MostrarSeparador();

        while (true)
        {
            Console.WriteLine("\n🔤 Por favor, ingresa una expresión matemática para verificar:");
            Console.Write("➤ ");
            string? expresion = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(expresion))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠️  Error: Debe ingresar una expresión válida.");
                Console.ResetColor();
                continue;
            }

            Console.WriteLine($"\n🔍 Analizando la expresión: '{expresion}'");
            Titulo.MostrarSeparador();

            // Verificar si la expresión está balanceada
            bool esBalanceada = EsBalanceada(expresion);

            Titulo.MostrarSeparador();
            
            // Mostrar resultado final
            if (esBalanceada)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ RESULTADO: La fórmula está BALANCEADA.");
                Console.WriteLine("🎉 Todos los símbolos de apertura tienen su correspondiente cierre.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ RESULTADO: La fórmula NO está balanceada.");
                Console.WriteLine("⚠️  Revisa los símbolos de apertura y cierre.");
            }
            Console.ResetColor();

            // Preguntar si desea continuar
            Console.WriteLine("\n¿Desea verificar otra expresión? (s/n): ");
            Console.Write("➤ ");
            string? respuesta = Console.ReadLine();
            
            if (respuesta?.ToLower() != "s")
            {
                break;
            }
        }
    }
}
