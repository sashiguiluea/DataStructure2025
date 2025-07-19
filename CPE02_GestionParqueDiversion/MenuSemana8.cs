/// <summary>
/// Clase para el menú principal del sistema de asientos
/// </summary>
public class MenuSemana8
{
    private AtraccionParque atraccion;

    public MenuSemana8()
    {
        atraccion = new AtraccionParque();
    }

    public void Ejecutar()
    {
        Titulo.encabezado();
        Console.WriteLine("=== SISTEMA DE ASIGNACIÓN DE ASIENTOS ===");
        Console.WriteLine("Atracción: Montaña Rusa Extrema");
        Console.WriteLine("Capacidad: 30 asientos");
        Console.WriteLine("Principio: FIFO (Primero en llegar, primero en subir)");
        Console.WriteLine("==========================================\n");

        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();
            continuar = ProcesarOpcion();
        }
    }

    private void MostrarMenu()
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    MENÚ PRINCIPAL                     ║");
        Console.WriteLine("╠═══════════════════════════════════════════════════════╣");
        Console.WriteLine("║  1. Registrar visitante                               ║");
        Console.WriteLine("║  2. Procesar siguiente visitante                      ║");
        Console.WriteLine("║  3. Procesar todos los visitantes                     ║");
        Console.WriteLine("║  4. Consultar visitantes en cola                      ║");
        Console.WriteLine("║  5. Consultar visitantes asignados                    ║");
        Console.WriteLine("║  6. Mostrar estadísticas                              ║");
        Console.WriteLine("║  7. Ver historial de operaciones                      ║");
        Console.WriteLine("║  8. Consultar siguiente en cola                       ║");
        Console.WriteLine("║  9. Salir                                             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        Console.Write("Seleccione una opción: ");
    }

    private bool ProcesarOpcion()
    {
        try
        {
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarVisitante();
                    PausarYContinuar();
                    break;
                case 2:
                    ProcesarSiguienteVisitante();
                    PausarYContinuar();
                    break;
                case 3:
                    ProcesarTodosLosVisitantes();
                    PausarYContinuar();
                    break;
                case 4:
                    ConsultarVisitantesEnCola();
                    PausarYContinuar();
                    break;
                case 5:
                    ConsultarVisitantesAsignados();
                    PausarYContinuar();
                    break;
                case 6:
                    MostrarEstadisticas();
                    PausarYContinuar();
                    break;
                case 7:
                    MostrarHistorial();
                    PausarYContinuar();
                    break;
                case 8:
                    ConsultarSiguienteEnCola();
                    PausarYContinuar();
                    break;
                case 9:
                    Console.WriteLine("¡Gracias por usar el sistema!");
                    return false;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    PausarYContinuar();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            PausarYContinuar();
        }

        return true;
    }

    private void PausarYContinuar()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private void RegistrarVisitante()
    {
        Console.Write("Ingrese el nombre del visitante: ");
        string nombre = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            return;
        }

        int id = atraccion.RegistrarVisitante(nombre);

        if (id > 0)
        {
            Console.WriteLine($"Visitante registrado exitosamente. ID: {id}");
            Console.WriteLine($"Posición en cola: {atraccion.VisitantesEnCola}");
            Console.WriteLine($"Asientos disponibles: {atraccion.AsientosDisponibles}");
        }
        else
        {
            Console.WriteLine("No se pudo registrar el visitante. Asientos agotados.");
        }
    }

    private void ProcesarSiguienteVisitante()
    {
        Visitante visitante = atraccion.ProcesarSiguienteVisitante();

        if (visitante != null)
        {
            Console.WriteLine($"Visitante procesado: {visitante}");
            Console.WriteLine($"Asientos restantes: {atraccion.AsientosDisponibles}");
        }
        else
        {
            Console.WriteLine("No hay visitantes en cola para procesar.");
        }
    }

    private void ProcesarTodosLosVisitantes()
    {
        Console.WriteLine("Procesando todos los visitantes...\n");

        List<Visitante> procesados = atraccion.ProcesarTodosLosVisitantes();

        if (procesados.Count > 0)
        {
            Console.WriteLine($"Se procesaron {procesados.Count} visitantes:");
            foreach (var visitante in procesados)
            {
                Console.WriteLine($"- {visitante}");
            }
        }
        else
        {
            Console.WriteLine("No había visitantes para procesar.");
        }
    }

    private void ConsultarVisitantesEnCola()
    {
        List<Visitante> visitantes = atraccion.ObtenerVisitantesEnCola();

        if (visitantes.Count > 0)
        {
            Console.WriteLine($"Visitantes en cola ({visitantes.Count}):");
            for (int i = 0; i < visitantes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {visitantes[i]}");
            }
        }
        else
        {
            Console.WriteLine("No hay visitantes en cola.");
        }
    }

    private void ConsultarVisitantesAsignados()
    {
        List<Visitante> asignados = atraccion.ObtenerVisitantesAsignados();

        if (asignados.Count > 0)
        {
            Console.WriteLine($"Visitantes con asientos asignados ({asignados.Count}):");
            foreach (var visitante in asignados.OrderBy(v => v.NumeroAsiento))
            {
                Console.WriteLine($"- {visitante}");
            }
        }
        else
        {
            Console.WriteLine("No hay visitantes con asientos asignados.");
        }
    }

    private void MostrarEstadisticas()
    {
        Console.WriteLine("\n=== ESTADÍSTICAS DEL SISTEMA ===");
        Console.WriteLine($"Asientos disponibles: {atraccion.AsientosDisponibles}");
        Console.WriteLine($"Asientos ocupados: {30 - atraccion.AsientosDisponibles}");
        Console.WriteLine($"Visitantes en cola: {atraccion.VisitantesEnCola}");
        Console.WriteLine($"Estado: {(atraccion.AsientosAgotados ? "COMPLETO" : "DISPONIBLE")}");
        Console.WriteLine($"Última operación: {atraccion.ObtenerUltimaOperacion() ?? "Ninguna"}");
    }

    private void MostrarHistorial()
    {
        List<string> historial = atraccion.ObtenerHistorialCompleto();

        if (historial.Count > 0)
        {
            Console.WriteLine($"Historial de operaciones ({historial.Count}):");
            foreach (var operacion in historial)
            {
                Console.WriteLine($"- {operacion}");
            }
        }
        else
        {
            Console.WriteLine("No hay operaciones registradas.");
        }
    }

    private void ConsultarSiguienteEnCola()
    {
        Visitante siguiente = atraccion.ConsultarSiguienteEnCola();

        if (siguiente != null)
        {
            Console.WriteLine($"Siguiente visitante en cola: {siguiente}");
        }
        else
        {
            Console.WriteLine("No hay visitantes en cola.");
        }
    }
}