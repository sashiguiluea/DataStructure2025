/// <summary>
/// Implementa una cola FIFO para la gestión de asientos
/// </summary>
public class ColaAsientos
{
    private Queue<Visitante> colaEspera;
    private const int TOTAL_ASIENTOS = 30;
    private int asientosDisponibles;

    public ColaAsientos()
    {
        colaEspera = new Queue<Visitante>();
        asientosDisponibles = TOTAL_ASIENTOS;
    }

    /// <summary>
    /// Añade un visitante a la cola de espera
    /// </summary>
    /// <param name="visitante">Visitante a añadir</param>
    /// <returns>True si se añadió exitosamente, False si no hay asientos</returns>
    public bool AgregarVisitante(Visitante visitante)
    {
        if (asientosDisponibles > 0)
        {
            colaEspera.Enqueue(visitante);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Asigna un asiento al siguiente visitante en la cola
    /// </summary>
    /// <returns>Visitante asignado o null si no hay visitantes</returns>
    public Visitante AsignarAsiento()
    {
        if (colaEspera.Count > 0 && asientosDisponibles > 0)
        {
            Visitante visitante = colaEspera.Dequeue();
            visitante.NumeroAsiento = TOTAL_ASIENTOS - asientosDisponibles + 1;
            asientosDisponibles--;
            return visitante;
        }
        return null;
    }

    /// <summary>
    /// Consulta el siguiente visitante sin eliminarlo de la cola
    /// </summary>
    /// <returns>Próximo visitante o null si la cola está vacía</returns>
    public Visitante ConsultarSiguiente()
    {
        return colaEspera.Count > 0 ? colaEspera.Peek() : null;
    }

    public int VisitantesEnCola => colaEspera.Count;
    public int AsientosDisponibles => asientosDisponibles;
    public bool CollaVacia => colaEspera.Count == 0;
    public bool AsientosAgotados => asientosDisponibles == 0;

    /// <summary>
    /// Obtiene una lista de todos los visitantes en cola
    /// </summary>
    /// <returns>Lista de visitantes</returns>
    public List<Visitante> ObtenerVisitantesEnCola()
    {
        return colaEspera.ToList();
    }
}