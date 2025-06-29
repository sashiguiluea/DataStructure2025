using System;

// Registro (struct) para el Paciente
public struct Paciente
{
    private string cedula; // Campo privado encapsulado
    public string nombre;
    public int edad;
    public DateTime fechaTurno;
    public string urgencia;
    public string especialidad;
    public string doctor;
    public bool activo; // Para marcar si el registro está en uso

    // Constructor para inicializar un Paciente 
    public Paciente(string cedula, string nombre, int edad, DateTime fechaTurno, string urgencia, string especialidad, string doctor)
    {
        this.cedula = cedula;
        this.nombre = nombre;
        this.edad = edad;
        this.fechaTurno = fechaTurno;
        this.urgencia = urgencia;
        this.especialidad = especialidad;
        this.doctor = doctor;
        this.activo = true;
    }

    // Método para obtener la cédula (encapsulación)
    public string ObtenerCedula()
    {
        return cedula;
    }

    // Método para obtener información completa del paciente
    public string ObtenerInformacionCompleta()
    {
        return $"Cédula: {cedula}, Nombre: {nombre}, Edad: {edad}, " +
               $"Turno: {fechaTurno:yyyy-MM-dd HH:mm}, Urgencia: {urgencia}, " +
               $"Especialidad: {especialidad}, Doctor: {doctor}";
    }
}

// Estructura para contador de urgencias
public struct ContadorUrgencia
{
    public string tipoUrgencia;
    public int cantidad;
    public bool enUso;

    public ContadorUrgencia(string tipo, int cant)
    {
        tipoUrgencia = tipo;
        cantidad = cant;
        enUso = true;
    }
}

// Estructura para agrupar pacientes por especialidad
public struct EspecialidadGrupo
{
    public string nombreEspecialidad;
    public Paciente[] pacientesEspecialidad;
    public int cantidadPacientes;
    public bool enUso;

    public EspecialidadGrupo(string especialidad, int capacidad)
    {
        nombreEspecialidad = especialidad;
        pacientesEspecialidad = new Paciente[capacidad];
        cantidadPacientes = 0;
        enUso = true;
    }
}

// Clase principal para la Agenda de turnos
public class AgendaTurnos
{
    // Vector principal de pacientes
    private Paciente[] pacientes;
    private int totalPacientes;
    private const int MAX_PACIENTES = 1000;

    // Vector para contadores de urgencias
    private ContadorUrgencia[] contadoresUrgencia;
    private int totalTiposUrgencia;
    private const int MAX_TIPOS_URGENCIA = 10;

    // Vector para especialidades
    private EspecialidadGrupo[] gruposEspecialidades;
    private int totalEspecialidades;
    private const int MAX_ESPECIALIDADES = 20;
    private const int MAX_PACIENTES_POR_ESPECIALIDAD = 200;

    // Matriz para reportes por rango de edad [rango][0=desde, 1=hasta, 2=cantidad]
    private int[,] matrizRangosEdad;
    private string[] etiquetasRangos;
    private const int CANTIDAD_RANGOS = 5;

    public AgendaTurnos()
    {
        // Inicializar vector principal
        pacientes = new Paciente[MAX_PACIENTES];
        totalPacientes = 0;

        // Inicializar vector de contadores de urgencia
        contadoresUrgencia = new ContadorUrgencia[MAX_TIPOS_URGENCIA];
        totalTiposUrgencia = 0;

        // Inicializar vector de especialidades
        gruposEspecialidades = new EspecialidadGrupo[MAX_ESPECIALIDADES];
        totalEspecialidades = 0;

        // Inicializar matriz de rangos de edad [rango, datos] 
        // Columna 0: edad desde, Columna 1: edad hasta, Columna 2: cantidad
        matrizRangosEdad = new int[CANTIDAD_RANGOS, 3];
        etiquetasRangos = new string[CANTIDAD_RANGOS];

        // Configurar rangos de edad
        ConfigurarRangosEdad();
    }

    private void ConfigurarRangosEdad()
    {
        // Configurar matriz de rangos de edad
        matrizRangosEdad[0, 0] = 0; matrizRangosEdad[0, 1] = 17; matrizRangosEdad[0, 2] = 0;
        matrizRangosEdad[1, 0] = 18; matrizRangosEdad[1, 1] = 34; matrizRangosEdad[1, 2] = 0;
        matrizRangosEdad[2, 0] = 35; matrizRangosEdad[2, 1] = 49; matrizRangosEdad[2, 2] = 0;
        matrizRangosEdad[3, 0] = 50; matrizRangosEdad[3, 1] = 64; matrizRangosEdad[3, 2] = 0;
        matrizRangosEdad[4, 0] = 65; matrizRangosEdad[4, 1] = 120; matrizRangosEdad[4, 2] = 0;

        etiquetasRangos[0] = "0-17 años";
        etiquetasRangos[1] = "18-34 años";
        etiquetasRangos[2] = "35-49 años";
        etiquetasRangos[3] = "50-64 años";
        etiquetasRangos[4] = "65+ años";
    }

    // Método para agregar un paciente a la agenda
    public void AgregarPaciente(Paciente paciente)
    {
        if (totalPacientes >= MAX_PACIENTES)
        {
            Console.WriteLine("Error: Capacidad máxima de pacientes alcanzada.");
            return;
        }

        pacientes[totalPacientes] = paciente;
        totalPacientes++;

        // Actualizar contadores y estructuras auxiliares
        ActualizarContadorUrgencia(paciente.urgencia);
        ActualizarGrupoEspecialidad(paciente);
        ActualizarMatrizRangosEdad(paciente.edad);

        Console.WriteLine("Paciente agregado exitosamente.");
    }

    // Método para actualizar contador de urgencias usando vector
    private void ActualizarContadorUrgencia(string urgencia)
    {
        // Buscar si ya existe el tipo de urgencia
        for (int i = 0; i < totalTiposUrgencia; i++)
        {
            if (contadoresUrgencia[i].tipoUrgencia == urgencia && contadoresUrgencia[i].enUso)
            {
                contadoresUrgencia[i] = new ContadorUrgencia(urgencia, contadoresUrgencia[i].cantidad + 1);
                return;
            }
        }

        // Si no existe, crear nuevo
        if (totalTiposUrgencia < MAX_TIPOS_URGENCIA)
        {
            contadoresUrgencia[totalTiposUrgencia] = new ContadorUrgencia(urgencia, 1);
            totalTiposUrgencia++;
        }
    }

    // Método para actualizar grupo de especialidad usando vector
    private void ActualizarGrupoEspecialidad(Paciente paciente)
    {
        // Buscar si ya existe la especialidad
        for (int i = 0; i < totalEspecialidades; i++)
        {
            if (gruposEspecialidades[i].nombreEspecialidad == paciente.especialidad && gruposEspecialidades[i].enUso)
            {
                if (gruposEspecialidades[i].cantidadPacientes < MAX_PACIENTES_POR_ESPECIALIDAD)
                {
                    gruposEspecialidades[i].pacientesEspecialidad[gruposEspecialidades[i].cantidadPacientes] = paciente;
                    gruposEspecialidades[i].cantidadPacientes++;
                }
                return;
            }
        }

        // Si no existe, crear nuevo grupo
        if (totalEspecialidades < MAX_ESPECIALIDADES)
        {
            gruposEspecialidades[totalEspecialidades] = new EspecialidadGrupo(paciente.especialidad, MAX_PACIENTES_POR_ESPECIALIDAD);
            gruposEspecialidades[totalEspecialidades].pacientesEspecialidad[0] = paciente;
            gruposEspecialidades[totalEspecialidades].cantidadPacientes = 1;
            totalEspecialidades++;
        }
    }

    // Método para actualizar matriz de rangos de edad
    private void ActualizarMatrizRangosEdad(int edad)
    {
        for (int i = 0; i < CANTIDAD_RANGOS; i++)
        {
            if (edad >= matrizRangosEdad[i, 0] && edad <= matrizRangosEdad[i, 1])
            {
                matrizRangosEdad[i, 2]++; // Incrementar contador en columna 2
                break;
            }
        }
    }

    // Método para ordenar pacientes por fecha usando algoritmo burbuja
    private void OrdenarPacientesPorFecha()
    {
        for (int i = 0; i < totalPacientes - 1; i++)
        {
            for (int j = 0; j < totalPacientes - i - 1; j++)
            {
                if (pacientes[j].activo && pacientes[j + 1].activo &&
                    DateTime.Compare(pacientes[j].fechaTurno, pacientes[j + 1].fechaTurno) > 0)
                {
                    // Intercambiar
                    Paciente temp = pacientes[j];
                    pacientes[j] = pacientes[j + 1];
                    pacientes[j + 1] = temp;
                }
            }
        }
    }

    // Método para visualizar todos los turnos en formato tabla
    public void VisualizarTurnos()
    {
        if (totalPacientes == 0)
        {
            Console.WriteLine("No hay pacientes en la agenda.");
            return;
        }

        OrdenarPacientesPorFecha();

        Console.WriteLine("\n=== AGENDA COMPLETA DE TURNOS ===");
        Console.WriteLine(new string('=', 120));
        Console.WriteLine($"{"Cédula",-12} {"Nombre",-20} {"Edad",-5} {"Fecha/Hora",-17} {"Urgencia",-10} {"Especialidad",-15} {"Doctor",-20}");
        Console.WriteLine(new string('-', 120));

        for (int i = 0; i < totalPacientes; i++)
        {
            if (pacientes[i].activo)
            {
                Console.WriteLine($"{pacientes[i].ObtenerCedula(),-12} {pacientes[i].nombre,-20} {pacientes[i].edad,-5} " +
                                $"{pacientes[i].fechaTurno,-17:yyyy-MM-dd HH:mm} {pacientes[i].urgencia,-10} " +
                                $"{pacientes[i].especialidad,-15} {pacientes[i].doctor,-20}");
            }
        }
        Console.WriteLine(new string('=', 120));
        Console.WriteLine($"Total de pacientes: {totalPacientes}");
    }

    // Método para buscar paciente por cédula usando búsqueda lineal en vector
    public void ConsultarPacientePorCedula()
    {
        Console.Write("Ingrese la cédula del paciente a consultar: ");
        string cedula = Console.ReadLine();

        for (int i = 0; i < totalPacientes; i++)
        {
            if (pacientes[i].activo && pacientes[i].ObtenerCedula() == cedula)
            {
                Console.WriteLine("\n=== INFORMACIÓN DEL PACIENTE ===");
                Console.WriteLine(pacientes[i].ObtenerInformacionCompleta());
                return;
            }
        }
        Console.WriteLine("Paciente no encontrado.");
    }

    // Método para mostrar turnos por especialidad usando vector de estructuras
    public void VisualizarTurnosPorEspecialidad()
    {
        if (totalEspecialidades == 0)
        {
            Console.WriteLine("No hay especialidades registradas.");
            return;
        }

        Console.WriteLine("\n=== TURNOS POR ESPECIALIDAD ===");
        for (int i = 0; i < totalEspecialidades; i++)
        {
            if (gruposEspecialidades[i].enUso)
            {
                Console.WriteLine($"\n--- {gruposEspecialidades[i].nombreEspecialidad.ToUpper()} ---");
                Console.WriteLine($"{"Nombre",-20} {"Fecha/Hora",-17} {"Urgencia",-10} {"Doctor",-20}");
                Console.WriteLine(new string('-', 70));

                for (int j = 0; j < gruposEspecialidades[i].cantidadPacientes; j++)
                {
                    Paciente p = gruposEspecialidades[i].pacientesEspecialidad[j];
                    Console.WriteLine($"{p.nombre,-20} {p.fechaTurno,-17:yyyy-MM-dd HH:mm} " +
                                    $"{p.urgencia,-10} {p.doctor,-20}");
                }
                Console.WriteLine($"Subtotal: {gruposEspecialidades[i].cantidadPacientes} pacientes");
            }
        }
    }

    // Método para mostrar estadísticas de urgencias usando vector
    public void MostrarEstadisticasUrgencias()
    {
        if (totalTiposUrgencia == 0)
        {
            Console.WriteLine("No hay datos de urgencias.");
            return;
        }

        // Ordenar por cantidad (algoritmo burbuja)
        for (int i = 0; i < totalTiposUrgencia - 1; i++)
        {
            for (int j = 0; j < totalTiposUrgencia - i - 1; j++)
            {
                if (contadoresUrgencia[j].cantidad < contadoresUrgencia[j + 1].cantidad)
                {
                    ContadorUrgencia temp = contadoresUrgencia[j];
                    contadoresUrgencia[j] = contadoresUrgencia[j + 1];
                    contadoresUrgencia[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("\n=== ESTADÍSTICAS POR NIVEL DE URGENCIA ===");
        Console.WriteLine($"{"Nivel de Urgencia",-15} {"Cantidad",-10} {"Porcentaje",-12}");
        Console.WriteLine(new string('-', 40));

        for (int i = 0; i < totalTiposUrgencia; i++)
        {
            if (contadoresUrgencia[i].enUso)
            {
                double porcentaje = (double)contadoresUrgencia[i].cantidad / totalPacientes * 100;
                Console.WriteLine($"{contadoresUrgencia[i].tipoUrgencia,-15} {contadoresUrgencia[i].cantidad,-10} {porcentaje,-12:F1}%");
            }
        }
        Console.WriteLine(new string('-', 40));
        Console.WriteLine($"{"Total",-15} {totalPacientes,-10} {"100.0%",-12}");
    }

    // Método para mostrar turnos del día actual usando vector
    public void VisualizarTurnosDelDia()
    {
        DateTime hoy = DateTime.Today;
        int turnosHoy = 0;

        // Crear vector temporal para turnos de hoy
        Paciente[] turnosDelDia = new Paciente[totalPacientes];

        // Buscar turnos de hoy
        for (int i = 0; i < totalPacientes; i++)
        {
            if (pacientes[i].activo && pacientes[i].fechaTurno.Date == hoy)
            {
                turnosDelDia[turnosHoy] = pacientes[i];
                turnosHoy++;
            }
        }

        if (turnosHoy == 0)
        {
            Console.WriteLine($"No hay turnos programados para hoy ({hoy:yyyy-MM-dd}).");
            return;
        }

        // Ordenar turnos de hoy por hora
        for (int i = 0; i < turnosHoy - 1; i++)
        {
            for (int j = 0; j < turnosHoy - i - 1; j++)
            {
                if (DateTime.Compare(turnosDelDia[j].fechaTurno, turnosDelDia[j + 1].fechaTurno) > 0)
                {
                    Paciente temp = turnosDelDia[j];
                    turnosDelDia[j] = turnosDelDia[j + 1];
                    turnosDelDia[j + 1] = temp;
                }
            }
        }

        Console.WriteLine($"\n=== TURNOS DE HOY ({hoy:yyyy-MM-dd}) ===");
        Console.WriteLine($"{"Hora",-8} {"Nombre",-20} {"Especialidad",-15} {"Doctor",-20} {"Urgencia",-10}");
        Console.WriteLine(new string('-', 80));

        for (int i = 0; i < turnosHoy; i++)
        {
            Console.WriteLine($"{turnosDelDia[i].fechaTurno,-8:HH:mm} {turnosDelDia[i].nombre,-20} " +
                            $"{turnosDelDia[i].especialidad,-15} {turnosDelDia[i].doctor,-20} {turnosDelDia[i].urgencia,-10}");
        }
        Console.WriteLine(new string('-', 80));
        Console.WriteLine($"Total de turnos hoy: {turnosHoy}");
    }

    // Método para generar reporte usando matriz de rangos de edad
    public void ReportePorRangoEdad()
    {
        if (totalPacientes == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }

        Console.WriteLine("\n=== REPORTE POR RANGO DE EDAD (usando matriz) ===");
        Console.WriteLine($"{"Rango de Edad",-15} {"Cantidad",-10} {"Porcentaje",-12}");
        Console.WriteLine(new string('-', 40));

        for (int i = 0; i < CANTIDAD_RANGOS; i++)
        {
            double porcentaje = (double)matrizRangosEdad[i, 2] / totalPacientes * 100;
            Console.WriteLine($"{etiquetasRangos[i],-15} {matrizRangosEdad[i, 2],-10} {porcentaje,-12:F1}%");
        }
        Console.WriteLine(new string('-', 40));
        Console.WriteLine($"Matriz utilizada: {CANTIDAD_RANGOS} filas x 3 columnas (desde, hasta, cantidad)");
    }

    // Método para obtener el total de pacientes
    public int ObtenerTotalPacientes()
    {
        return totalPacientes;
    }
}

// Programa principal
public class Program
{
    public static void Main()
    {
        MostrarTitulo();
        AgendaTurnos agenda = new AgendaTurnos();
        bool continuar = true;

        while (continuar)
        {
            MostrarMenu();
            int opcion = LeerOpcion();

            switch (opcion)
            {
                case 1:
                    AgregarNuevoPaciente(agenda);
                    break;
                case 2:
                    agenda.VisualizarTurnos();
                    break;
                case 3:
                    agenda.ConsultarPacientePorCedula();
                    break;
                case 4:
                    agenda.VisualizarTurnosPorEspecialidad();
                    break;
                case 5:
                    agenda.MostrarEstadisticasUrgencias();
                    break;
                case 6:
                    agenda.VisualizarTurnosDelDia();
                    break;
                case 7:
                    agenda.ReportePorRangoEdad();
                    break;
                case 8:
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    Console.WriteLine("¡Gracias por usar el Sistema de Agenda Médica!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                //MostrarTitulo();
            }
        }
    }

    private static void MostrarTitulo()
    {
        Console.WriteLine(@"    █████╗  ██████╗ ███████╗███╗   ██╗██████╗  █████╗     ███╗   ███╗███████╗██████╗ ██╗ ██████╗ █████╗ ");
        Console.WriteLine(@"   ██╔══██╗██╔════╝ ██╔════╝████╗  ██║██╔══██╗██╔══██╗    ████╗ ████║██╔════╝██╔══██╗██║██╔════╝██╔══██╗");
        Console.WriteLine(@"   ███████║██║  ███╗█████╗  ██╔██╗ ██║██║  ██║███████║    ██╔████╔██║█████╗  ██║  ██║██║██║     ███████║");
        Console.WriteLine(@"   ██╔══██║██║   ██║██╔══╝  ██║╚██╗██║██║  ██║██╔══██║    ██║╚██╔╝██║██╔══╝  ██║  ██║██║██║     ██╔══██║");
        Console.WriteLine(@"   ██║  ██║╚██████╔╝███████╗██║ ╚████║██████╔╝██║  ██║    ██║ ╚═╝ ██║███████╗██████╔╝██║╚██████╗██║  ██║");
        Console.WriteLine(@"   ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝╚═════╝ ╚═╝  ╚═╝    ╚═╝     ╚═╝╚══════╝╚═════╝ ╚═╝ ╚═════╝╚═╝  ╚═╝");
        Console.WriteLine("\n                    Sistema de Gestión de Turnos Médicos v2.0 - Estructuras Básicas");
        Console.WriteLine("                       Usando: Vectores, Matrices, Registros y Estructuras");
    }

    private static void MostrarMenu()
    {
        Console.WriteLine("\n╔══════════════════════════════════════╗");
        Console.WriteLine("║            MENÚ PRINCIPAL            ║");
        Console.WriteLine("╠══════════════════════════════════════╣");
        Console.WriteLine("║ 1. Agregar nuevo paciente            ║");
        Console.WriteLine("║ 2. Visualizar todos los turnos       ║");
        Console.WriteLine("║ 3. Consultar paciente por cédula     ║");
        Console.WriteLine("║ 4. Turnos por especialidad           ║");
        Console.WriteLine("║ 5. Estadísticas de urgencias         ║");
        Console.WriteLine("║ 6. Turnos del día actual             ║");
        Console.WriteLine("║ 7. Reporte por rango de edad         ║");
        Console.WriteLine("║ 8. Salir                             ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
    }

    private static int LeerOpcion()
    {
        Console.Write("Seleccione una opción (1-8): ");
        try
        {
            return int.Parse(Console.ReadLine());
        }
        catch
        {
            return 0; // Retorna opción inválida
        }
    }

    private static void AgregarNuevoPaciente(AgendaTurnos agenda)
    {
        try
        {
            Console.WriteLine("\n=== AGREGAR NUEVO PACIENTE ===");

            Console.Write("Ingrese la cédula del paciente: ");
            string cedula = Console.ReadLine();

            Console.Write("Ingrese el nombre completo del paciente: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la edad del paciente: ");
            int edad = int.Parse(Console.ReadLine());

            Console.Write("Ingrese la fecha del turno (YYYY-MM-DD HH:MM): ");
            DateTime fechaTurno = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el nivel de urgencia (Urgente/Moderada/Baja): ");
            string urgencia = Console.ReadLine();

            Console.Write("Ingrese la especialidad: ");
            string especialidad = Console.ReadLine();

            Console.Write("Ingrese el nombre del doctor: ");
            string doctor = Console.ReadLine();

            // Crear y agregar el paciente
            Paciente nuevoPaciente = new Paciente(cedula, nombre, edad, fechaTurno, urgencia, especialidad, doctor);
            agenda.AgregarPaciente(nuevoPaciente);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al agregar paciente: {ex.Message}");
            Console.WriteLine("Por favor, verifique los datos ingresados.");
        }
    }
}
