// ================================================================
// ARCHIVO: TorresDeHanoi.cs (EJERCICIO 2 - TORRES DE HANOI)
// ================================================================

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Clase que implementa la solución al problema clásico de las Torres de Hanoi
/// Utiliza pilas (Stacks) para representar las tres torres y recursión para resolver el problema
/// </summary>
public class TorresDeHanoi
{
    private static int contadorMovimientos = 0;
    private static int numeroDiscos = 0;

    /// <summary>
    /// Método recursivo para resolver el problema de las Torres de Hanoi
    /// </summary>
    /// <param name="n">Número de discos a mover</param>
    /// <param name="origen">Torre de origen (pila)</param>
    /// <param name="destino">Torre de destino (pila)</param>
    /// <param name="auxiliar">Torre auxiliar (pila)</param>
    /// <param name="nombreOrigen">Nombre de la torre de origen</param>
    /// <param name="nombreDestino">Nombre de la torre de destino</param>
    /// <param name="nombreAuxiliar">Nombre de la torre auxiliar</param>
    public static void ResolverTorres(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, 
                                     string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        // Caso base: si solo hay un disco, moverlo directamente
        if (n == 1)
        {
            if (origen.Count > 0)
            {
                int disco = origen.Pop();
                destino.Push(disco);
                contadorMovimientos++;
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"🔄 Movimiento {contadorMovimientos}: Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
                Console.ResetColor();
                
                ImprimirEstado(origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAuxiliar);
            }
            return;
        }

        // Paso 1: Mover n-1 discos de origen a auxiliar usando destino como apoyo
        ResolverTorres(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

        // Paso 2: Mover el disco más grande de origen a destino
        if (origen.Count > 0)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            contadorMovimientos++;
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"🔄 Movimiento {contadorMovimientos}: Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            Console.ResetColor();
            
            ImprimirEstado(origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAuxiliar);
        }

        // Paso 3: Mover n-1 discos de auxiliar a destino usando origen como apoyo
        ResolverTorres(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
    }

    /// <summary>
    /// Imprime el estado actual de las tres torres de forma visual
    /// </summary>
    /// <param name="torreOrigen">Torre de origen</param>
    /// <param name="torreDestino">Torre de destino</param>
    /// <param name="torreAuxiliar">Torre auxiliar</param>
    /// <param name="nombreOrigen">Nombre de la torre de origen</param>
    /// <param name="nombreDestino">Nombre de la torre de destino</param>
    /// <param name="nombreAuxiliar">Nombre de la torre auxiliar</param>
    public static void ImprimirEstado(Stack<int> torreOrigen, Stack<int> torreDestino, Stack<int> torreAuxiliar,
                                     string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        Console.WriteLine("\n📊 Estado actual de las torres:");
        Console.WriteLine("┌" + new string('─', 78) + "┐");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"│ {nombreOrigen,-20} │ {nombreDestino,-20} │ {nombreAuxiliar,-20} │");
        Console.ResetColor();
        
        Console.WriteLine("├" + new string('─', 78) + "┤");
        
        // Mostrar discos de forma visual
        var arrayOrigen = torreOrigen.ToArray();
        var arrayDestino = torreDestino.ToArray();
        var arrayAuxiliar = torreAuxiliar.ToArray();
        
        // Encontrar la altura máxima
        int alturaMaxima = Math.Max(Math.Max(arrayOrigen.Length, arrayDestino.Length), arrayAuxiliar.Length);
        
        // Mostrar torre por torre, de arriba hacia abajo
        for (int nivel = alturaMaxima - 1; nivel >= 0; nivel--)
        {
            string discoOrigen = nivel < arrayOrigen.Length ? $"[{arrayOrigen[nivel]}]" : "│";
            string discoDestino = nivel < arrayDestino.Length ? $"[{arrayDestino[nivel]}]" : "│";
            string discoAuxiliar = nivel < arrayAuxiliar.Length ? $"[{arrayAuxiliar[nivel]}]" : "│";
            
            Console.WriteLine($"│ {discoOrigen,-20} │ {discoDestino,-20} │ {discoAuxiliar,-20} │");
        }
        
        Console.WriteLine("└" + new string('─', 78) + "┘");
        
        // Mostrar base de las torres
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"  {"Base A",-20}   {"Base B",-20}   {"Base C",-20}");
        Console.ResetColor();
        Console.WriteLine();
        
        // Pausa para visualizar mejor el proceso
        System.Threading.Thread.Sleep(1000);
    }

    /// <summary>
    /// Método principal que ejecuta el ejercicio de las Torres de Hanoi
    /// Permite al usuario seleccionar el número de discos y observar la solución paso a paso
    /// </summary>
    public static void Resolver()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("🗼 EJERCICIO 2: TORRES DE HANOI");
        Console.WriteLine("=".PadLeft(35, '='));
        Console.ResetColor();
        
        Console.WriteLine("\n📚 El problema de las Torres de Hanoi es un rompecabezas matemático que consiste en:");
        Console.WriteLine("   • Tres torres (A, B, C)");
        Console.WriteLine("   • N discos de diferentes tamaños en la torre A");
        Console.WriteLine("   • Objetivo: Mover todos los discos a la torre C");
        Console.WriteLine("   • Reglas: Solo se puede mover un disco a la vez y nunca poner un disco grande sobre uno pequeño");
        
        while (true)
        {
            Titulo.MostrarSeparador();
            Console.WriteLine("\n🔢 Ingrese el número de discos (1-8, recomendado 3-5): ");
            Console.Write("➤ ");
            string? input = Console.ReadLine();
            
            if (int.TryParse(input, out numeroDiscos) && numeroDiscos >= 1 && numeroDiscos <= 8)
            {
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠️  Error: Ingrese un número válido entre 1 y 8.");
                Console.ResetColor();
            }
        }

        // Inicializar las torres
        Stack<int> torreOrigen = new Stack<int>();
        Stack<int> torreDestino = new Stack<int>();
        Stack<int> torreAuxiliar = new Stack<int>();

        // Llenar la torre de origen con los discos (del más grande al más pequeño)
        for (int i = numeroDiscos; i >= 1; i--)
        {
            torreOrigen.Push(i);
        }

        // Reiniciar contador de movimientos
        contadorMovimientos = 0;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n🎯 Iniciando resolución con {numeroDiscos} discos...");
        Console.WriteLine($"📈 Número mínimo de movimientos requeridos: {Math.Pow(2, numeroDiscos) - 1}");
        Console.ResetColor();

        Titulo.MostrarSeparador();
        Console.WriteLine("🏁 Estado inicial:");
        ImprimirEstado(torreOrigen, torreDestino, torreAuxiliar, "Torre A (Origen)", "Torre B (Destino)", "Torre C (Auxiliar)");

        Console.WriteLine("🚀 Iniciando solución...\n");
        
        // Resolver el problema
        ResolverTorres(numeroDiscos, torreOrigen, torreDestino, torreAuxiliar, 
                      "Torre A", "Torre B", "Torre C");

        // Mostrar resultado final
        Titulo.MostrarSeparador();
        if (torreDestino.Count == numeroDiscos)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("🎉 ¡FELICIDADES! El problema de las Torres de Hanoi se resolvió exitosamente.");
            Console.WriteLine($"✅ Todos los {numeroDiscos} discos han sido movidos a la Torre B (Destino).");
            Console.WriteLine($"📊 Total de movimientos realizados: {contadorMovimientos}");
            Console.WriteLine($"🎯 Movimientos mínimos teóricos: {Math.Pow(2, numeroDiscos) - 1}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Error: No se pudieron mover todos los discos correctamente.");
            Console.ResetColor();
        }
    }
}