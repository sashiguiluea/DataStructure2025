/// <summary>
/// Clase principal que coordina el sistema de atracción
/// </summary>
public class AtraccionParque
{
    private ColaAsientos colaAsientos;
    private PilaHistorial pilaHistorial;
    private List<Visitante> visitantesAsignados;

    public AtraccionParque()
    {
        colaAsientos = new ColaAsientos();
        pilaHistorial = new PilaHistorial();
        visitantesAsignados = new List<Visitante>();
    }

    /// <summary>
    /// Registra un nuevo visitante en el sistema
    /// </summary>
    /// <param name="nombre">Nombre del visitante</param>
    /// <returns>ID del visitante registrado o -1 si no hay espacio</returns>
    public int RegistrarVisitante(string nombre)
    {
        if (colaAsientos.AsientosAgotados)
        {
            pilaHistorial.RegistrarOperacion($"Intento fallido: {nombre} - No hay asientos disponibles");
            return -1;
        }

        int nuevoId = visitantesAsignados.Count + colaAsientos.VisitantesEnCola + 1;
        Visitante nuevoVisitante = new Visitante(nuevoId, nombre);

        if (colaAsientos.AgregarVisitante(nuevoVisitante))
        {
            pilaHistorial.RegistrarOperacion($"Visitante registrado: {nombre} (ID: {nuevoId})");
            return nuevoId;
        }

        return -1;
    }

    /// <summary>
    /// Procesa el siguiente visitante en la cola
    /// </summary>
    /// <returns>Visitante procesado o null si no hay visitantes</returns>
    public Visitante ProcesarSiguienteVisitante()
    {
        Visitante visitante = colaAsientos.AsignarAsiento();
        if (visitante != null)
        {
            visitantesAsignados.Add(visitante);
            pilaHistorial.RegistrarOperacion($"Asiento asignado: {visitante.Nombre} - Asiento {visitante.NumeroAsiento}");
        }
        return visitante;
    }

    /// <summary>
    /// Procesa todos los visitantes en cola
    /// </summary>
    /// <returns>Lista de visitantes procesados</returns>
    public List<Visitante> ProcesarTodosLosVisitantes()
    {
        List<Visitante> procesados = new List<Visitante>();

        while (!colaAsientos.CollaVacia && !colaAsientos.AsientosAgotados)
        {
            Visitante visitante = ProcesarSiguienteVisitante();
            if (visitante != null)
            {
                procesados.Add(visitante);
            }
        }

        return procesados;
    }

    // Métodos de consulta y reportería
    public List<Visitante> ObtenerVisitantesEnCola() => colaAsientos.ObtenerVisitantesEnCola();
    public List<Visitante> ObtenerVisitantesAsignados() => visitantesAsignados.ToList();
    public List<string> ObtenerHistorialCompleto() => pilaHistorial.ObtenerHistorialCompleto();
    public string ObtenerUltimaOperacion() => pilaHistorial.ObtenerUltimaOperacion();
    public Visitante ConsultarSiguienteEnCola() => colaAsientos.ConsultarSiguiente();

    public int AsientosDisponibles => colaAsientos.AsientosDisponibles;
    public int VisitantesEnCola => colaAsientos.VisitantesEnCola;
    public bool AsientosAgotados => colaAsientos.AsientosAgotados;
}