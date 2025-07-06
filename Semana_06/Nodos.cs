// ================================================================
// ARCHIVO: Nodos.cs (EJERCICIO 4 - LISTA ENLAZADA CON FILTRADO)
// ================================================================

/// <summary>
/// Clase que representa un nodo en la lista enlazada
/// </summary>
public class Nodo
{
    /// <summary>
    /// Valor entero almacenado en el nodo
    /// </summary>
    public int Valor { get; set; }
    
    /// <summary>
    /// Referencia al siguiente nodo en la lista
    /// </summary>
    public Nodo? Siguiente { get; set; }

    /// <summary>
    /// Constructor del nodo
    /// </summary>
    /// <param name="valor">Valor entero a almacenar</param>
    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

/// <summary>
/// Implementación de lista enlazada simple para números enteros
/// </summary>
public class ListaEnlazada
{
    /// <summary>
    /// Referencia al primer nodo de la lista (cabeza)
    /// </summary>
    public Nodo? Cabeza { get; private set; }

    /// <summary>
    /// Contador de elementos en la lista
    /// </summary>
    public int Contador { get; private set; }

    /// <summary>
    /// Constructor de la lista enlazada
    /// </summary>
    public ListaEnlazada()
    {
        Cabeza = null;
        Contador = 0;
    }

    /// <summary>
    /// Agrega un nuevo nodo al final de la lista
    /// Complejidad temporal: O(n)
    /// </summary>
    /// <param name="valor">Valor a agregar</param>
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        
        if (Cabeza == null)
        {
            Cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
        Contador++;
    }

    /// <summary>
    /// Imprime todos los valores de la lista con formato mejorado
    /// Complejidad temporal: O(n)
    /// </summary>
    public void Imprimir()
    {
        if (Cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Console.WriteLine($"Lista ({Contador} elementos):");
        Console.Write("[");
        
        Nodo? actual = Cabeza;
        bool primero = true;
        
        while (actual != null)
        {
            if (!primero)
                Console.Write(", ");
            
            Console.Write(actual.Valor);
            actual = actual.Siguiente;
            primero = false;
        }
        
        Console.WriteLine("]");
    }

    /// <summary>
    /// Elimina todos los nodos cuyos valores están fuera del rango especificado
    /// Complejidad temporal: O(n)
    /// </summary>
    /// <param name="minimo">Valor mínimo del rango (inclusive)</param>
    /// <param name="maximo">Valor máximo del rango (inclusive)</param>
    /// <returns>Número de elementos eliminados</returns>
    public int EliminarFueraDeRango(int minimo, int maximo)
    {
        int eliminados = 0;
        
        // Eliminar nodos fuera del rango al principio de la lista
        while (Cabeza != null && (Cabeza.Valor < minimo || Cabeza.Valor > maximo))
        {
            Cabeza = Cabeza.Siguiente;
            eliminados++;
            Contador--;
        }

        // Eliminar nodos fuera del rango en el resto de la lista
        Nodo? actual = Cabeza;
        while (actual != null && actual.Siguiente != null)
        {
            if (actual.Siguiente.Valor < minimo || actual.Siguiente.Valor > maximo)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                eliminados++;
                Contador--;
            }
            else
            {
                actual = actual.Siguiente;
            }
        }
        
        return eliminados;
    }

    /// <summary>
    /// Obtiene estadísticas de la lista
    /// </summary>
    /// <returns>Tupla con (mínimo, máximo, promedio)</returns>
    public (int minimo, int maximo, double promedio) ObtenerEstadisticas()
    {
        if (Cabeza == null)
            return (0, 0, 0);

        int min = int.MaxValue;
        int max = int.MinValue;
        long suma = 0;
        
        Nodo? actual = Cabeza;
        while (actual != null)
        {
            if (actual.Valor < min) min = actual.Valor;
            if (actual.Valor > max) max = actual.Valor;
            suma += actual.Valor;
            actual = actual.Siguiente;
        }
        
        return (min, max, (double)suma / Contador);
    }
}

/// <summary>
/// Clase principal para ejecutar el ejercicio de filtrado de lista enlazada
/// </summary>
public static class Nodos
{
    /// <summary>
    /// Método principal que ejecuta el ejercicio 4
    /// </summary>
    public static void nodos()
    {
        try
        {
            Random random = new Random();
            ListaEnlazada lista = new ListaEnlazada();

            Titulo.encabezado();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== EJERCICIO 4: LISTA ENLAZADA CON FILTRADO ===");
            Console.ResetColor();
            Console.WriteLine();

            // Crear la lista enlazada con 50 números aleatorios del 1 al 999
            Console.WriteLine("Generando 50 números aleatorios del 1 al 999...");
            for (int i = 0; i < 50; i++)
            {
                lista.Agregar(random.Next(1, 1000));
            }

            // Mostrar la lista original
            Console.WriteLine("\nLista original:");
            lista.Imprimir();
            
            // Mostrar estadísticas
            var estadisticas = lista.ObtenerEstadisticas();
            Console.WriteLine($"\nEstadísticas: Min={estadisticas.minimo}, Max={estadisticas.maximo}, Promedio={estadisticas.promedio:F2}");

            // Solicitar y validar el rango de valores
            int minimo = SolicitarValor("Introduce el valor mínimo del rango (1-999): ", 1, 999);
            int maximo = SolicitarValor($"Introduce el valor máximo del rango ({minimo}-999): ", minimo, 999);

            // Eliminar nodos fuera del rango especificado
            Console.WriteLine($"\nEliminando elementos fuera del rango [{minimo}, {maximo}]...");
            int eliminados = lista.EliminarFueraDeRango(minimo, maximo);

            // Mostrar la lista después del filtrado
            Console.WriteLine($"\nResultado: Se eliminaron {eliminados} elementos.");
            Console.WriteLine("Lista después del filtrado:");
            lista.Imprimir();
            
            if (lista.Contador > 0)
            {
                var nuevasEstadisticas = lista.ObtenerEstadisticas();
                Console.WriteLine($"\nNuevas estadísticas: Min={nuevasEstadisticas.minimo}, Max={nuevasEstadisticas.maximo}, Promedio={nuevasEstadisticas.promedio:F2}");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error en el ejercicio de nodos: {ex.Message}");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Solicita un valor entero dentro de un rango específico
    /// </summary>
    /// <param name="mensaje">Mensaje a mostrar al usuario</param>
    /// <param name="minimo">Valor mínimo permitido</param>
    /// <param name="maximo">Valor máximo permitido</param>
    /// <returns>Valor válido ingresado por el usuario</returns>
    private static int SolicitarValor(string mensaje, int minimo, int maximo)
    {
        int valor;
        do
        {
            Console.Write(mensaje);
            string input = Console.ReadLine() ?? "";
            
            if (int.TryParse(input, out valor) && valor >= minimo && valor <= maximo)
            {
                return valor;
            }
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: Ingresa un valor válido entre {minimo} y {maximo}.");
            Console.ResetColor();
        } while (true);
    }
}

