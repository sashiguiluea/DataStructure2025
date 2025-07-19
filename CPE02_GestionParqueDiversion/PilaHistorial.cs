/// <summary>
/// Implementa una pila LIFO para mantener historial de operaciones
/// </summary>
public class PilaHistorial
{
    private Stack<string> historial;

    public PilaHistorial()
    {
        historial = new Stack<string>();
    }

    /// <summary>
    /// Registra una operación en el historial
    /// </summary>
    /// <param name="operacion">Descripción de la operación</param>
    public void RegistrarOperacion(string operacion)
    {
        string registro = $"{DateTime.Now:HH:mm:ss} - {operacion}";
        historial.Push(registro);
    }

    /// <summary>
    /// Obtiene la última operación registrada
    /// </summary>
    /// <returns>Última operación o null si no hay historial</returns>
    public string ObtenerUltimaOperacion()
    {
        return historial.Count > 0 ? historial.Peek() : null;
    }

    /// <summary>
    /// Deshacer la última operación (simulación)
    /// </summary>
    /// <returns>Operación deshecha</returns>
    public string DeshacerUltimaOperacion()
    {
        return historial.Count > 0 ? historial.Pop() : null;
    }

    /// <summary>
    /// Obtiene todo el historial de operaciones
    /// </summary>
    /// <returns>Lista de operaciones en orden LIFO</returns>
    public List<string> ObtenerHistorialCompleto()
    {
        return historial.ToList();
    }

    public int CantidadOperaciones => historial.Count;
    public bool HistorialVacio => historial.Count == 0;
}