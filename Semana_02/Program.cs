using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Clase que representa un Rectángulo y encapsula sus propiedades primitivas
/// </summary>
public class Rectangulo
{
    // Encapsulación de tipos de datos primitivos
    private double largo;
    private double ancho;

    /// <summary>
    /// Constructor de un Rectangulo que inicializa sus dimensiones
    /// </summary>
    /// <param name="largoRectangulo">Medida decimal del largo del rectángulo</param>
    /// <param name="anchoRectangulo">Medida decimal del ancho del rectángulo</param>
    public Rectangulo(double largoRectangulo, double anchoRectangulo)
    {
        largo = largoRectangulo;
        ancho = anchoRectangulo;
    }

    // CalcularArea es un metodo que devuelve un valor double, se utiliza para calcular el área de un rectángulo
    // multiplicando el largo por el ancho
    public double CalcularArea()
    {
        return largo * ancho;
    }

    // CalcularPerimetro es una metodo que devuelve un valor double, se utiliza para calcular el perímetro de un rectángulo
    // sumando todos sus lados: 2 veces el largo más 2 veces el ancho
    public double CalcularPerimetro()
    {
        return 2 * (largo + ancho);
    }
}

/// <summary>
/// Clase que representa un Círculo y encapsula sus propiedades primitivas
/// </summary>
public class Circulo
{
    // Encapsulación de tipos de datos primitivos
    private double radio;

    /// <summary>
    /// Constructor de un Círculo que inicializa su radio
    /// </summary>
    /// <param name="radioCirculo">Medida decimal del radio del círculo</param>
    public Circulo(double radioCirculo)
    {
        radio = radioCirculo;
    }

    // CalcularArea es una metodo que devuelve un valor double, se utiliza para calcular el área de un círculo
    // usando la fórmula π * radio²
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // CalcularPerimetro es una metodo que devuelve un valor double, se utiliza para calcular el perímetro (circunferencia) de un círculo
    // usando la fórmula 2 * π * radio
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }
}
// <summary>
// Programa principal que permite al usuario seleccionar una figura geométrica y calcular su área y perímetro
// </summary>
class Program
{
    static void Main()
    {
        int opcion = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("Seleccione una figura geométrica para calcular su área y perímetro:");
            Console.WriteLine("1. Rectángulo");
            Console.WriteLine("2. Círculo");
            Console.WriteLine("3. Salir");
            Console.Write("Opción: ");

            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        // Ingreso de datos para el Rectángulo
                        Console.Write("\nIngrese el largo del Rectángulo: ");
                        double largo = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Ingrese el ancho del Rectángulo: ");
                        double ancho = Convert.ToDouble(Console.ReadLine());

                        // Crear una instancia de Rectángulo con los valores ingresados
                        Rectangulo miRectangulo = new Rectangulo(largo, ancho);

                        // Mostrar área y perímetro del rectángulo
                        Console.WriteLine("\nRectángulo:");
                        Console.WriteLine($"Área: {miRectangulo.CalcularArea():F2}");
                        Console.WriteLine($"Perímetro: {miRectangulo.CalcularPerimetro():F2}");
                        break;

                    case 2:
                        // Ingreso de datos para el Círculo
                        Console.Write("\nIngrese el radio del Círculo: ");
                        double radio = Convert.ToDouble(Console.ReadLine());

                        // Crear una instancia de Círculo con el valor ingresado
                        Circulo miCirculo = new Circulo(radio);

                        // Mostrar área y perímetro del círculo
                        Console.WriteLine("\nCírculo:");
                        Console.WriteLine($"Área: {miCirculo.CalcularArea():F2}");
                        Console.WriteLine($"Perímetro: {miCirculo.CalcularPerimetro():F2}");
                        break;

                    case 3:
                        Console.WriteLine("\nSaliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: Ingrese un número válido.");
                opcion = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
                opcion = 0;
            }

            if (opcion != 3)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 3);
    }
}
