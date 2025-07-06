// ================================================================
// ARCHIVO: RegistroVehiculos.cs (EJERCICIO 7 - SISTEMA DE VEHÍCULOS)
// ================================================================

/// <summary>
/// Clase que representa un vehículo en el sistema
/// </summary>
public class Vehiculo
{
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
    public double Precio { get; set; }
    public Vehiculo? Siguiente { get; set; }

    public Vehiculo(string placa, string marca, string modelo, int año, double precio)
    {
        Placa = placa.ToUpper().Trim();
        Marca = marca.Trim();
        Modelo = modelo.Trim();
        Año = año;
        Precio = precio;
        Siguiente = null;
    }

    public override string ToString()
    {
        return $"[{Placa}] {Marca} {Modelo} ({Año}) - {Precio:C}";
    }
}

/// <summary>
/// Clase que maneja el estacionamiento de vehículos
/// </summary>
public class Estacionamiento
{
    public Vehiculo? Primero { get; private set; }
    public int Contador { get; private set; }

    public Estacionamiento()
    {
        Primero = null;
        Contador = 0;
    }

    /// <summary>
    /// Agrega un vehículo al estacionamiento
    /// </summary>
    public bool AgregarVehiculo(string placa, string marca, string modelo, int año, double precio)
    {
        try
        {
            // Verificar si la placa ya existe
            if (BuscarPorPlaca(placa) != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Ya existe un vehículo con esa placa.");
                Console.ResetColor();
                return false;
            }

            Vehiculo nuevoVehiculo = new Vehiculo(placa, marca, modelo, año, precio);

            if (Primero == null)
            {
                Primero = nuevoVehiculo;
            }
            else
            {
                Vehiculo actual = Primero;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoVehiculo;
            }
            
            Contador++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vehículo agregado exitosamente.");
            Console.ResetColor();
            return true;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al agregar vehículo: {ex.Message}");
            Console.ResetColor();
            return false;
        }
    }

    /// <summary>
    /// Busca un vehículo por su placa
    /// </summary>
    public Vehiculo? BuscarPorPlaca(string placa)
    {
        try
        {
            Vehiculo? actual = Primero;
            while (actual != null)
            {
                if (actual.Placa.Equals(placa.ToUpper().Trim(), StringComparison.OrdinalIgnoreCase))
                    return actual;
                actual = actual.Siguiente;
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al buscar vehículo: {ex.Message}");
            Console.ResetColor();
            return null;
        }
    }

    /// <summary>
    /// Muestra vehículos de un año específico
    /// </summary>
    public void VerPorAño(int año)
    {
        try
        {
            List<Vehiculo> vehiculosEncontrados = new List<Vehiculo>();
            Vehiculo? actual = Primero;
            
            while (actual != null)
            {
                if (actual.Año == año)
                {
                    vehiculosEncontrados.Add(actual);
                }
                actual = actual.Siguiente;
            }

            if (vehiculosEncontrados.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"No se encontraron vehículos del año {año}.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine($"\nVehículos encontrados del año {año} ({vehiculosEncontrados.Count}):");
            MostrarTablaVehiculos(vehiculosEncontrados);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al mostrar vehículos por año: {ex.Message}");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Muestra todos los vehículos registrados ordenados por año
    /// </summary>
    public void VerTodos()
    {
        try
        {
            if (Primero == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay vehículos registrados.");
                Console.ResetColor();
                return;
            }

            List<Vehiculo> listaVehiculos = new List<Vehiculo>();
            Vehiculo? actual = Primero;
            
            while (actual != null)
            {
                listaVehiculos.Add(actual);
                actual = actual.Siguiente;
            }

            listaVehiculos.Sort((v1, v2) => v1.Año.CompareTo(v2.Año));

            Console.WriteLine($"\nVehículos registrados ({Contador} total):");
            MostrarTablaVehiculos(listaVehiculos);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al mostrar todos los vehículos: {ex.Message}");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Elimina un vehículo por su placa
    /// </summary>
    public bool EliminarPorPlaca(string placa)
    {
        try
        {
            if (Primero == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay vehículos para eliminar.");
                Console.ResetColor();
                return false;
            }

            string placaBuscar = placa.ToUpper().Trim();

            if (Primero.Placa.Equals(placaBuscar, StringComparison.OrdinalIgnoreCase))
            {
                Primero = Primero.Siguiente;
                Contador--;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vehículo eliminado exitosamente.");
                Console.ResetColor();
                return true;
            }

            Vehiculo? actual = Primero;
            while (actual.Siguiente != null && !actual.Siguiente.Placa.Equals(placaBuscar, StringComparison.OrdinalIgnoreCase))
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vehículo no encontrado.");
                Console.ResetColor();
                return false;
            }
            else
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                Contador--;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vehículo eliminado exitosamente.");
                Console.ResetColor();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al eliminar vehículo: {ex.Message}");
            Console.ResetColor();
            return false;
        }
    }

    /// <summary>
    /// Muestra una tabla formateada de vehículos
    /// </summary>
    private void MostrarTablaVehiculos(List<Vehiculo> vehiculos)
    {
        Console.WriteLine("╔═══════════╦═══════════╦═══════════╦═══════╦══════════════╗");
        Console.WriteLine("║   PLACA   ║   MARCA   ║  MODELO   ║  AÑO  ║    PRECIO    ║");
        Console.WriteLine("╠═══════════╬═══════════╬═══════════╬═══════╬══════════════╣");
        
        foreach (var vehiculo in vehiculos)
        {
            Console.WriteLine($"║ {vehiculo.Placa,-9} ║ {vehiculo.Marca,-9} ║ {vehiculo.Modelo,-9} ║ {vehiculo.Año,-5} ║ {vehiculo.Precio,-12:C} ║");
        }
        
        Console.WriteLine("╚═══════════╩═══════════╩═══════════╩═══════╩══════════════╝");
    }
}

/// <summary>
/// Clase principal que maneja el sistema de registro de vehículos
/// </summary>
public static class RegistroVehiculos
{
    public static void registro()
    {
        try
        {
            Estacionamiento estacionamiento = new Estacionamiento();
            bool continuar = true;

            while (continuar)
            {
                Titulo.encabezado();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=== SISTEMA DE REGISTRO DE VEHÍCULOS ===");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("1. Agregar vehículo");
                Console.WriteLine("2. Buscar vehículo por placa");
                Console.WriteLine("3. Ver vehículos por año");
                Console.WriteLine("4. Ver todos los vehículos registrados");
                Console.WriteLine("5. Eliminar vehículo registrado");
                Console.WriteLine("6. Salir");
                Console.WriteLine();
                Console.Write("Seleccione una opción: ");

                string input = Console.ReadLine() ?? "";
                
                if (string.IsNullOrWhiteSpace(input))
                {
                    MostrarError("Por favor, ingrese una opción válida.");
                    continue;
                }

                if (int.TryParse(input, out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarVehiculo(estacionamiento);
                            break;
                        case 2:
                            BuscarVehiculo(estacionamiento);
                            break;
                        case 3:
                            VerVehiculosPorAño(estacionamiento);
                            break;
                        case 4:
                            estacionamiento.VerTodos();
                            break;
                        case 5:
                            EliminarVehiculo(estacionamiento);
                            break;
                        case 6:
                            continuar = false;
                            break;
                        default:
                            MostrarError("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    MostrarError("Por favor, ingrese un número válido.");
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Programa finalizado.");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error en el registro de vehículos: {ex.Message}");
            Console.ResetColor();
        }
    }

    private static void AgregarVehiculo(Estacionamiento estacionamiento)
    {
        try
        {
            Console.WriteLine("\n=== AGREGAR NUEVO VEHÍCULO ===");
            
            string placa = SolicitarTexto("Ingrese la placa: ");
            string marca = SolicitarTexto("Ingrese la marca: ");
            string modelo = SolicitarTexto("Ingrese el modelo: ");
            int año = SolicitarAño("Ingrese el año: ");
            double precio = SolicitarPrecio("Ingrese el precio: ");

            estacionamiento.AgregarVehiculo(placa, marca, modelo, año, precio);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al agregar vehículo: {ex.Message}");
            Console.ResetColor();
        }
    }

    private static void BuscarVehiculo(Estacionamiento estacionamiento)
    {
        try
        {
            Console.WriteLine("\n=== BUSCAR VEHÍCULO ===");
            string placaBuscar = SolicitarTexto("Ingrese la placa a buscar: ");

            Vehiculo? vehiculo = estacionamiento.BuscarPorPlaca(placaBuscar);
            if (vehiculo != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nVehículo encontrado:");
                Console.WriteLine($"  {vehiculo}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vehículo no encontrado.");
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al buscar vehículo: {ex.Message}");
            Console.ResetColor();
        }
    }

    private static void VerVehiculosPorAño(Estacionamiento estacionamiento)
    {
        try
        {
            Console.WriteLine("\n=== VER VEHÍCULOS POR AÑO ===");
            int añoBuscar = SolicitarAño("Ingrese el año de los vehículos a mostrar: ");
            estacionamiento.VerPorAño(añoBuscar);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al ver vehículos por año: {ex.Message}");
            Console.ResetColor();
        }
    }

    private static void EliminarVehiculo(Estacionamiento estacionamiento)
    {
        try
        {
            Console.WriteLine("\n=== ELIMINAR VEHÍCULO ===");
            string placaEliminar = SolicitarTexto("Ingrese la placa del vehículo a eliminar: ");
            estacionamiento.EliminarPorPlaca(placaEliminar);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al eliminar vehículo: {ex.Message}");
            Console.ResetColor();
        }
    }

    // Métodos auxiliares para validación de entrada
    private static string SolicitarTexto(string mensaje)
    {
        string texto;
        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(texto))
            {
                MostrarError("Este campo no puede estar vacío.");
            }
        } while (string.IsNullOrWhiteSpace(texto));
        
        return texto;
    }

    private static int SolicitarAño(string mensaje)
    {
        int año;
        do
        {
            Console.Write(mensaje);
            string input = Console.ReadLine() ?? "";
            
            if (int.TryParse(input, out año) && año >= 1900 && año <= DateTime.Now.Year + 1)
            {
                return año;
            }
            
            MostrarError($"Ingrese un año válido (entre 1900 y {DateTime.Now.Year + 1}).");
        } while (true);
    }

    private static double SolicitarPrecio(string mensaje)
    {
        double precio;
        do
        {
            Console.Write(mensaje);
            string input = Console.ReadLine() ?? "";
            
            if (double.TryParse(input, out precio) && precio >= 0)
            {
                return precio;
            }
            
            MostrarError("Ingrese un precio válido (no negativo).");
        } while (true);
    }

    private static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {mensaje}");
        Console.ResetColor();
    }
}
