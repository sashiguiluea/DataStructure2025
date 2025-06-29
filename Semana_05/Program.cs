using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Clase que representa una asignatura académica con su nombre y nota asociada.
/// Permite gestionar la información básica de una materia del curso.
/// </summary>
public class Asignatura
{
    /// <summary>
    /// Nombre de la asignatura (ej: Matemáticas, Física, etc.)
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Nota obtenida en la asignatura (valor decimal)
    /// </summary>
    public double Nota { get; set; }

    /// <summary>
    /// Constructor que inicializa una asignatura con solo el nombre
    /// La nota se establece por defecto en 0.0
    /// </summary>
    /// <param name="nombre">Nombre de la asignatura</param>
    public Asignatura(string nombre)
    {
        Nombre = nombre;
        Nota = 0.0; // Valor por defecto
    }

    /// <summary>
    /// Constructor que inicializa una asignatura con nombre y nota
    /// </summary>
    /// <param name="nombre">Nombre de la asignatura</param>
    /// <param name="nota">Nota obtenida en la asignatura</param>
    public Asignatura(string nombre, double nota)
    {
        Nombre = nombre;
        Nota = nota;
    }

    /// <summary>
    /// Sobrescribe el método ToString para mostrar solo el nombre de la asignatura
    /// Útil para mostrar la asignatura de forma sencilla
    /// </summary>
    /// <returns>El nombre de la asignatura como string</returns>
    public override string ToString()
    {
        return Nombre;
    }
}

/// <summary>
/// Clase que representa un curso académico con múltiples asignaturas.
/// Gestiona las operaciones relacionadas con las materias del curso como
/// mostrar asignaturas, manejar notas y generar mensajes de estudio.
/// </summary>
public class Curso
{
    /// <summary>
    /// Lista privada que contiene todas las asignaturas del curso
    /// Se mantiene privada para controlar el acceso desde fuera de la clase
    /// </summary>
    private List<Asignatura> asignaturas;

    /// <summary>
    /// Constructor que inicializa el curso con las asignaturas predeterminadas
    /// Crea automáticamente las 5 asignaturas básicas del curso
    /// </summary>
    public Curso()
    {
        // Inicialización con las asignaturas del curso
        asignaturas = new List<Asignatura>
        {
            new Asignatura("Matemáticas"),
            new Asignatura("Física"),
            new Asignatura("Química"),
            new Asignatura("Historia"),
            new Asignatura("Lengua")
        };
    }

    /// <summary>
    /// Método público para obtener la lista de asignaturas
    /// Permite acceso controlado a la lista desde fuera de la clase
    /// </summary>
    /// <returns>Lista de asignaturas del curso</returns>
    public List<Asignatura> ObtenerAsignaturas()
    {
        return asignaturas;
    }

    /// <summary>
    /// Muestra por pantalla todas las asignaturas del curso
    /// Implementa la funcionalidad del Ejercicio 1
    /// </summary>
    public void MostrarAsignaturas()
    {
        Console.WriteLine("\nAsignaturas del curso:");
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine(asignatura.Nombre);
        }
    }

    /// <summary>
    /// Muestra mensajes de estudio para cada asignatura
    /// Implementa la funcionalidad del Ejercicio 2
    /// Formato: "Yo estudio [nombre de asignatura]"
    /// </summary>
    public void MostrarMensajeEstudio()
    {
        Console.WriteLine("\nMensajes de estudio:");
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"Yo estudio {asignatura.Nombre}");
        }
    }

    /// <summary>
    /// Solicita al usuario las notas de cada asignatura y las muestra
    /// Implementa la funcionalidad del Ejercicio 3
    /// Pide la nota de cada materia y luego muestra los resultados
    /// </summary>
    public void PedirYMostrarNotas()
    {
        // Fase 1: Solicitar notas al usuario
        Console.WriteLine("\nIngreso de notas:");
        foreach (var asignatura in asignaturas)
        {
            Console.Write($"¿Qué nota has sacado en {asignatura.Nombre}? ");
            asignatura.Nota = Convert.ToDouble(Console.ReadLine());
        }

        // Fase 2: Mostrar resultados
        Console.WriteLine("\nResultados:");
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"En {asignatura.Nombre} has sacado {asignatura.Nota}");
        }
    }
}

/// <summary>
/// Clase que simula el funcionamiento de una lotería primitiva.
/// Gestiona los números ganadores, su ingreso y ordenamiento.
/// Implementa la funcionalidad del Ejercicio 4.
/// </summary>
public class Loteria
{
    /// <summary>
    /// Lista privada que almacena los 6 números ganadores de la lotería
    /// Se mantiene privada para controlar su acceso y modificación
    /// </summary>
    private List<int> numerosGanadores;

    /// <summary>
    /// Constructor que inicializa la lotería con una lista vacía
    /// Los números se añadirán posteriormente mediante el método correspondiente
    /// </summary>
    public Loteria()
    {
        numerosGanadores = new List<int>();
    }

    /// <summary>
    /// Solicita al usuario que ingrese los 6 números ganadores de la lotería
    /// Valida que se ingresen exactamente 6 números enteros
    /// </summary>
    public void PedirNumerosGanadores()
    {
        Console.WriteLine("\nIntroduce los 6 números ganadores de la lotería:");

        // Ciclo para pedir exactamente 6 números
        for (int i = 1; i <= 6; i++)
        {
            Console.Write($"Número {i}: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            numerosGanadores.Add(numero);
        }
    }

    /// <summary>
    /// Ordena los números ganadores de menor a mayor y los muestra por pantalla
    /// Utiliza el método Sort() de List para ordenamiento automático
    /// </summary>
    public void MostrarNumerosOrdenados()
    {
        // Ordenamiento de menor a mayor
        numerosGanadores.Sort();

        Console.WriteLine("\nLos números ganadores ordenados de menor a mayor son:");
        foreach (int numero in numerosGanadores)
        {
            Console.WriteLine(numero);
        }
    }
}

/// <summary>
/// Clase que maneja secuencias de números enteros.
/// Permite crear rangos de números y mostrarlos en diferentes órdenes.
/// Implementa la funcionalidad del Ejercicio 5.
/// </summary>
public class SecuenciaNumeros
{
    /// <summary>
    /// Lista privada que contiene la secuencia de números
    /// Almacena los números en el rango especificado
    /// </summary>
    private List<int> numeros;

    /// <summary>
    /// Constructor que crea una secuencia de números en un rango determinado
    /// Genera automáticamente todos los números desde 'inicio' hasta 'fin' (inclusive)
    /// </summary>
    /// <param name="inicio">Número inicial del rango</param>
    /// <param name="fin">Número final del rango (inclusive)</param>
    public SecuenciaNumeros(int inicio, int fin)
    {
        numeros = new List<int>();

        // Llenar la lista con números del rango especificado
        for (int i = inicio; i <= fin; i++)
        {
            numeros.Add(i);
        }
    }

    /// <summary>
    /// Muestra los números de la secuencia en orden inverso separados por comas
    /// Utiliza LINQ para ordenamiento descendente y formateo personalizado
    /// Implementa el formato requerido: "10, 9, 8, 7, 6, 5, 4, 3, 2, 1"
    /// </summary>
    public void MostrarEnOrdenInverso()
    {
        Console.WriteLine("\nNúmeros del 1 al 10 en orden inverso:");

        // Usar LINQ para obtener los números en orden descendente
        var numerosInversos = numeros.OrderByDescending(x => x).ToList();

        // Mostrar con formato de comas (excepto el último)
        for (int i = 0; i < numerosInversos.Count; i++)
        {
            if (i > 0)
            {
                Console.Write(", "); // Separador de comas
            }
            Console.Write(numerosInversos[i]);
        }
        Console.WriteLine(); // Salto de línea final
    }
}

/// <summary>
/// Clase estática que maneja la interfaz de usuario del programa.
/// Contiene métodos para mostrar el título artístico y el menú principal.
/// Se mantiene separada para seguir el principio de responsabilidad única.
/// </summary>
public class MenuPrincipal
{
    /// <summary>
    /// Muestra el título artístico del programa en ASCII art
    /// Incluye información sobre la semana y el tipo de programación utilizada
    /// Método estático para facilitar su llamada sin instanciar la clase
    /// </summary>
    public static void MostrarTitulo()
    {
        // Arte ASCII para el título "CSHARP POO"
        Console.WriteLine(@"    ██████╗███████╗██╗  ██╗ █████╗ ██████╗ ██████╗     ██████╗  ██████╗  ██████╗ ");
        Console.WriteLine(@"   ██╔════╝██╔════╝██║  ██║██╔══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔═══██╗██╔═══██╗");
        Console.WriteLine(@"   ██║     ███████╗███████║███████║██████╔╝██████╔╝    ██████╔╝██║   ██║██║   ██║");
        Console.WriteLine(@"   ██║     ╚════██║██╔══██║██╔══██║██╔══██╗██╔═══╝     ██╔═══╝ ██║   ██║██║   ██║");
        Console.WriteLine(@"   ╚██████╗███████║██║  ██║██║  ██║██║  ██║██║         ██║     ╚██████╔╝╚██████╔╝");
        Console.WriteLine(@"    ╚═════╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝         ╚═╝      ╚═════╝  ╚═════╝ ");
        Console.WriteLine("\n                    Semana 05 - Tarea - 5 Ejercicios seleccionados");
        Console.WriteLine("                       Usando: Programación Orientada a Objetos y Listas");
    }

    /// <summary>
    /// Muestra el menú principal con las opciones disponibles
    /// Presenta las 6 opciones: 5 ejercicios + opción de salir
    /// Utiliza caracteres Unicode para crear un diseño atractivo
    /// Método estático para facilitar su uso
    /// </summary>
    public static void MostrarMenu()
    {
        Console.WriteLine("\n╔═════════════════════════════════════════════════════╗");
        Console.WriteLine("║            MENÚ PRINCIPAL                             ║");
        Console.WriteLine("╠═══════════════════════════════════════════════════════╣");
        Console.WriteLine("║ 1. Ejercicio 1 - Asignaturas del curso                ║");
        Console.WriteLine("║ 2. Ejercicio 2 - Yo estudio las asignatura..          ║");
        Console.WriteLine("║ 3. Ejercicio 3 - Notas de las asignaturas             ║");
        Console.WriteLine("║ 4. Ejercicio 4 - Números ganadores de la lotería      ║");
        Console.WriteLine("║ 5. Ejercicio 5 - Números del 1 al 10 en orden inverso ║");
        Console.WriteLine("║ 6. Salir                                              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
    }

    /// <summary>
    /// Muestra un separador visual para indicar el inicio de un ejercicio
    /// Se utiliza para mantener la interfaz limpia sin repetir el título
    /// </summary>
    /// <param name="numeroEjercicio">Número del ejercicio que se está ejecutando</param>
    public static void MostrarSeparadorEjercicio(int numeroEjercicio)
    {
        Console.WriteLine("\n" + new string('=', 60));
        Console.WriteLine($"                    EJECUTANDO EJERCICIO {numeroEjercicio}");
        Console.WriteLine(new string('=', 60));
    }
}

/// <summary>
/// Clase principal del programa que contiene el método Main y coordina la ejecución.
/// Actúa como punto de entrada y controlador principal de la aplicación.
/// Maneja el bucle principal del menú y delega las tareas a las clases especializadas.
/// </summary>
public class Program
{
    /// <summary>
    /// Método principal de entrada del programa
    /// Controla el flujo general de la aplicación mediante un menú interactivo
    /// Instancia las clases necesarias y coordina la ejecución de los ejercicios
    /// </summary>
    public static void Main()
    {
        bool continuar = true; // Variable de control del bucle principal
        Curso curso = new Curso(); // Instancia única del curso para reutilizar datos

        // Mostrar título y menú solo al inicio
        Console.Clear();
        MenuPrincipal.MostrarTitulo();
        MenuPrincipal.MostrarMenu();

        // Bucle principal del programa
        while (continuar)
        {
            Console.Write("\nSelecciona un ejercicio (1-6): ");

            // Capturar opción del usuario
            string opcion = Console.ReadLine();

            // Procesar la opción seleccionada
            switch (opcion)
            {
                case "1":
                    MenuPrincipal.MostrarSeparadorEjercicio(1);
                    EjecutarEjercicio1(curso);
                    break;
                case "2":
                    MenuPrincipal.MostrarSeparadorEjercicio(2);
                    EjecutarEjercicio2(curso);
                    break;
                case "3":
                    MenuPrincipal.MostrarSeparadorEjercicio(3);
                    EjecutarEjercicio3(curso);
                    break;
                case "4":
                    MenuPrincipal.MostrarSeparadorEjercicio(4);
                    EjecutarEjercicio4();
                    break;
                case "5":
                    MenuPrincipal.MostrarSeparadorEjercicio(5);
                    EjecutarEjercicio5();
                    break;
                case "6":
                    continuar = false; // Terminar el bucle
                    Console.WriteLine("\n¡Gracias por usar el programa!");
                    break;
                default:
                    Console.WriteLine("Opción no válida, por favor selecciona entre 1 y 6.");
                    break;
            }

            // Pausa para que el usuario pueda ver los resultados
            if (continuar)
            {
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    /// <summary>
    /// Ejecuta el Ejercicio 1: Mostrar asignaturas del curso
    /// Utiliza el método de la clase Curso para mostrar todas las asignaturas
    /// </summary>
    /// <param name="curso">Instancia del curso con las asignaturas cargadas</param>
    private static void EjecutarEjercicio1(Curso curso)
    {
        curso.MostrarAsignaturas();
    }

    /// <summary>
    /// Ejecuta el Ejercicio 2: Mostrar mensajes "Yo estudio [asignatura]"
    /// Utiliza el método de la clase Curso para generar los mensajes de estudio
    /// </summary>
    /// <param name="curso">Instancia del curso con las asignaturas cargadas</param>
    private static void EjecutarEjercicio2(Curso curso)
    {
        curso.MostrarMensajeEstudio();
    }

    /// <summary>
    /// Ejecuta el Ejercicio 3: Pedir y mostrar notas de asignaturas
    /// Utiliza el método de la clase Curso para manejar el ingreso y muestra de notas
    /// </summary>
    /// <param name="curso">Instancia del curso con las asignaturas cargadas</param>
    private static void EjecutarEjercicio3(Curso curso)
    {
        curso.PedirYMostrarNotas();
    }

    /// <summary>
    /// Ejecuta el Ejercicio 4: Números ganadores de la lotería
    /// Crea una nueva instancia de Loteria y ejecuta el proceso completo
    /// (pedir números y mostrarlos ordenados)
    /// </summary>
    private static void EjecutarEjercicio4()
    {
        Loteria loteria = new Loteria();
        loteria.PedirNumerosGanadores(); // Solicitar los 6 números
        loteria.MostrarNumerosOrdenados(); // Mostrar ordenados de menor a mayor
    }

    /// <summary>
    /// Ejecuta el Ejercicio 5: Números del 1 al 10 en orden inverso
    /// Crea una secuencia del 1 al 10 y la muestra en orden inverso con comas
    /// </summary>
    private static void EjecutarEjercicio5()
    {
        SecuenciaNumeros secuencia = new SecuenciaNumeros(1, 10);
        secuencia.MostrarEnOrdenInverso(); // Mostrar: 10, 9, 8, 7, 6, 5, 4, 3, 2, 1
    }
}